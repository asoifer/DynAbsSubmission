using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Operations;
using System;
using System.Collections.Generic;
using System.Linq;
using DynAbs.Tracing;

namespace DynAbs
{
    public class ProcessConsumer
    {
        #region Properties
        // Con esto identificamos cada ProcessConsumer
        public static int lastProcessId = 0;
        public int processId = ++lastProcessId;

        ITraceConsumer _traceConsumer;
        ISemanticModelsContainer _semanticModelsContainer;
        IBroker _broker;
        InstrumentationResult _instrumentationResult;
        TermFactory _termFactory;
        ExecutedStatementsContainer _executedStatements;
        public Term _thisObject { get; set; }
        public Term _returnObject { get; set; }
        public Term ExceptionTerm { get; set; }
        public Term PatternOperationReceiver { get; set; }
        public bool _setReturn { get; set; }
        public bool _sliceCriteriaReached { get; set; }
        public bool _returnComplexType { get; set; }
        public bool _returnPostponed { get; set; }
        public bool _rv_assigned { get; set; }
        public bool _throwingException { get; set; }
        int _statementsWithoutCleaning;
        Stack<Term> _usingStack;
        Stmt _originalStatement;
        SyntaxNode _methodNode;
        int _currentFileId;
        IDictionary<CSharpSyntaxNode, Term> _foreachHubsDictionary = new Dictionary<CSharpSyntaxNode, Term>();
        IDictionary<Stmt, bool> _enterLoopSet = new Dictionary<Stmt, bool>();
        Term yieldReturnValuesContainer = null;
        Term temporaryConditionalAccessTerm = null;
        Term temporarySwitchTerm = null;
        IDictionary<ITypeSymbol, ITypeSymbol> _typeArguments { get; set; }
        #endregion

        #region Constructor
        public ProcessConsumer(
            ITraceConsumer traceConsumer,
            IBroker broker,
            ISemanticModelsContainer semanticModelsContainer,
            InstrumentationResult instrumentationResult,
            TermFactory termFactory,
            ExecutedStatementsContainer executedStatements)
        {
            _traceConsumer = traceConsumer;
            _semanticModelsContainer = semanticModelsContainer;
            _instrumentationResult = instrumentationResult;
            _termFactory = termFactory;
            _broker = broker;
            _executedStatements = executedStatements;
            _statementsWithoutCleaning = 0;
            _usingStack = new Stack<Term>();
        }
        #endregion

        #region Public
        public bool Process(Term term = null, List<Term> argumentList = null, Term @this = null, Stmt controlDependency = null, IDictionary<ITypeSymbol, ITypeSymbol> typeArguments = null)
        {
            var enterMethodStatement = _traceConsumer.GetNextStatement();
            var isStatic = Utils.IsStaticTrace(enterMethodStatement.TraceType);

            if (!Utils.IsEnterMethodOrConstructor(enterMethodStatement.TraceType))
                throw new UnexpectedTrace();

            if (enterMethodStatement.TraceType == TraceType.BeforeConstructor)
            {
                // Va a haber un BeforeConstructor único por cada clase, por eso da bien el conteo
                // Si se entra por enter constructor no hace falta el base call del mismo método...
                _executedStatements.AddClass(enterMethodStatement);
                var temp = LookupForEnterConstructor(enterMethodStatement, argumentList != null ? (int?)argumentList.Count : null);
                if (temp == null)
                    ;
                enterMethodStatement = temp;
            }

            // Habrá un executed statement por cada método distinto
            if (enterMethodStatement == null || enterMethodStatement.CSharpSyntaxNode == null)
            {
                // In this case the constructor is not instrumented
                var currentOp = GetOperation(controlDependency.CSharpSyntaxNode);
                HandleNonInstrumentedMethod(currentOp, argumentList, @this, null, currentOp.Type, ".ctor");
                return false;
            }
            _executedStatements.AddMethod(enterMethodStatement);
            var syntaxNode = (CSharpSyntaxNode)enterMethodStatement.CSharpSyntaxNode;
            if (syntaxNode is ArgumentSyntax)
            {
                syntaxNode = (CSharpSyntaxNode)syntaxNode.GetContainer();
                ConsumeBeforeConstructor((CSharpSyntaxNode)syntaxNode.GetContainerClass(), enterMethodStatement.FileId);
            }

            _methodNode = syntaxNode;
            _currentFileId = enterMethodStatement.FileId;

            var currentSymbol = _semanticModelsContainer.GetBySyntaxNode(syntaxNode)
                .GetDeclaredSymbol((syntaxNode is ArrowExpressionClauseSyntax) ? syntaxNode.Parent : syntaxNode);
            var currentNameSymbol = Utils.GetNamespaceName(currentSymbol) + "." + Utils.GetClassName(currentSymbol) + "." + Utils.GetPropertyName(syntaxNode, currentSymbol);

            // XXX: Necesitamos saber si devuelve un tipo complejo (object por ejemplo) por si le mandamos un int (por ejemplo) y debe crear el nodo
            var returnTypeSyntax = syntaxNode.ReturnTypeSyntax();
            if (returnTypeSyntax != null)
            {
                if (returnTypeSyntax is RefTypeSyntax)
                    returnTypeSyntax = ((RefTypeSyntax)returnTypeSyntax).Type;
                _returnComplexType = ((ITypeSymbol)_semanticModelsContainer.GetBySyntaxNode(syntaxNode).GetSymbolInfo(returnTypeSyntax).Symbol).IsNotScalar();
            }

            _typeArguments = typeArguments;
            _returnObject = term;
            if (isStatic)
                @this = _thisObject = null; // Si la entrada es estática no hay this
            else
            {
                if (@this != null)
                    _thisObject = _termFactory.Create(syntaxNode, Utils.GetThisBySyntaxNode(syntaxNode, _semanticModelsContainer.GetBySyntaxNode(syntaxNode)), false, "this", false);
                else
                    ;
            }

            argumentList = argumentList ?? new List<Term>();
            var parameters = GetParameters(syntaxNode, argumentList);

            if (parameters.Count > argumentList.Count)
                ;

            if (argumentList.Count > parameters.Count)
                ;

            if (enterMethodStatement.FileId == 10091 && enterMethodStatement.Line == 385 && parameters.Count != argumentList.Count)
                ;

            _broker.EnterMethod(Utils.GetRealName(currentNameSymbol, typeArguments), argumentList, parameters, @this, _thisObject, controlDependency, enterMethodStatement);

            if (parameters.Count > argumentList.Count)
                for (var i = argumentList.Count; i < parameters.Count; i++)
                {
                    if (parameters[i].Stmt.CSharpSyntaxNode is ParameterSyntax &&
                        ((ParameterSyntax)parameters[i].Stmt.CSharpSyntaxNode).Default != null)
                    {
                        var newTerm = _termFactory.CreateParameterTerm((ParameterSyntax)parameters[i].Stmt.CSharpSyntaxNode, ISlicerSymbol.Create(_semanticModelsContainer.GetBySyntaxNode(parameters[i].Stmt.CSharpSyntaxNode).GetTypeInfo(((ParameterSyntax)parameters[i].Stmt.CSharpSyntaxNode).Type).Type));
                        _broker.DefUseOperation(newTerm);
                    }
                    else
                        ;
                }

            // Setea los parámetros no definidos, ejemplo ARGS al comienzo, puede ser "peligroso" hacerlo así.
            if (argumentList.Count == 0 && (syntaxNode is MethodDeclarationSyntax || syntaxNode is LocalFunctionStatementSyntax))
                foreach (var param in syntaxNode is MethodDeclarationSyntax ? ((MethodDeclarationSyntax)syntaxNode).ParameterList.Parameters : ((LocalFunctionStatementSyntax)syntaxNode).ParameterList.Parameters)
                {
                    var newTerm = _termFactory.CreateParameterTerm(param, ISlicerSymbol.Create(_semanticModelsContainer.GetBySyntaxNode(param.Type).GetTypeInfo(param.Type).Type));
                    _broker.DefUseOperation(newTerm);
                    if (!newTerm.IsScalar)
                    {
                        _broker.Alloc(newTerm);
                        _broker.DefUseOperation(newTerm, new Term[] { });

                        var otherField = new Field(Field.SIGMA_FIELD);
                        if (!(newTerm.Parts[0].Symbol.Symbol is IArrayTypeSymbol))
                            ;
                        otherField.Symbol = ISlicerSymbol.Create(((IArrayTypeSymbol)newTerm.Parts[0].Symbol.Symbol).ElementType);

                        var otherTerm = newTerm.AddingField(otherField);
                        otherTerm.Stmt = newTerm.Stmt;
                        _broker.DefUseOperation(otherTerm, new Term[] { newTerm });
                    }
                }


            if (!isStatic && (syntaxNode is ConstructorDeclarationSyntax || syntaxNode is ClassDeclarationSyntax || syntaxNode is StructDeclarationSyntax))
                HandleBaseConstructor(term, syntaxNode);

            // Si entraste por BaseCall, tenés que consumir el enter constructor
            if (enterMethodStatement.TraceType == TraceType.BaseCall)
                GetNextStatement(TraceType.EnterConstructor);

            BodyConsume();
            return true;
        }

        public void FirstProcess(out string entryPointClassName)
        {
            // TODO: Esta garcha la voy a sacar
            entryPointClassName = "";
            var acumTerms = new List<Term>();
            try
            {
                while (_traceConsumer.HasNext())
                {
                    var nextStmt = _traceConsumer.ObserveNextStatement();

                    if (nextStmt.TraceType == TraceType.SimpleStatement)
                    {
                        _traceConsumer.GetNextStatement();
                        continue;
                    }

                    var isStatic = Utils.IsStaticTrace(nextStmt.TraceType);
                    var isDispose = ((nextStmt.CSharpSyntaxNode) is MethodDeclarationSyntax &&
                        ((MethodDeclarationSyntax)nextStmt.CSharpSyntaxNode).Identifier.ValueText == "Dispose");

                    if (isDispose)
                        break;

                    var processconsumer = new ProcessConsumer(_traceConsumer, _broker, _semanticModelsContainer, Globals.InstrumentationResult, _termFactory, _executedStatements);
                    entryPointClassName = nextStmt.FileName;
                    // TODO: Si es estático pero devuelve algo no lo estamos capturando
                    //if (isStatic)
                    //    processconsumer.Process();
                    //else
                    //{
                    // 1era vez: inicializamos el contexto:
                    if (acumTerms.Count == 0)
                        _broker.EnterMethod("FirstProcess", new List<Term>(), new List<Term>(), null, null, null, null);

                    // Si entra acá captura todo en el WaitForEnd
                    acumTerms.AddRange(WaitForEnd(nextStmt.CSharpSyntaxNode, acumTerms, null, "FirstProcess", null, false));
                    //}
                }
            }
            catch (SliceCriteriaReachedException)
            {

            }
        }
        #endregion

        #region Private
        void BodyConsume()
        {
            Stmt currentStatement = null;
            var consumingFinallyAfterReturn = false;
            while (_traceConsumer.HasNext())
            {
                currentStatement = _traceConsumer.GetNextStatement();

                var @break = false;
                var @continue = false;

                if (_setReturn && currentStatement.TraceType == TraceType.ExitLoop)
                    @continue = true;

                if (!@continue)
                {
                    if (_setReturn && currentStatement.TraceType == TraceType.EnterFinally)
                        consumingFinallyAfterReturn = true;
                    else if (_setReturn && !consumingFinallyAfterReturn)
                        @break = true;
                    else if (_setReturn && consumingFinallyAfterReturn && currentStatement.TraceType == TraceType.EnterFinalFinally)
                        @break = true;
                }

                //var oldSliceCriteriaReached = _traceConsumer.SliceCriteriaReached();
                _broker.SliceCriteriaReached = _traceConsumer.SliceCriteriaReached();
                //_broker.SliceCriteriaReached = _traceConsumer.SliceCriteriaReached(currentStatement);

                //if (_broker.SliceCriteriaReached != oldSliceCriteriaReached)
                //    ;

                if (@break)
                    break;
                if (@continue)
                    continue;

                switch (currentStatement.TraceType)
                {
                    case TraceType.EnterCondition: EnterCondition(currentStatement); break;
                    case TraceType.Break: _broker.Break(); break;
                    case TraceType.ExitUsing: HandleExitUsing(); break;
                    case TraceType.ExitCondition: ExitCondition(currentStatement); break;
                    case TraceType.ExitLoop: ExitLoop(currentStatement); break;
                    case TraceType.ExitStaticMethod:
                    case TraceType.ExitMethod:
                    case TraceType.ExitStaticConstructor:
                    case TraceType.ExitConstructor: ExitMethod(currentStatement); break;
                    case TraceType.EnterCatch: HandleCatch(currentStatement); break;
                    case TraceType.ExitCatch: ExceptionTerm = null; break;
                    case TraceType.EnterFinally: break;
                    case TraceType.ExitFinally: HandleFinnaly(currentStatement); break;
                    case TraceType.SimpleStatement: StatementConsume(currentStatement); break;
                    case TraceType.EnterFinalCatch: HandleFinalCatch(currentStatement); break;
                    default: HandleBodyUnexpectedTrace(currentStatement); break;
                }
            }
            while (currentStatement != null)
            {
                if (currentStatement.TraceType == TraceType.EnterFinalFinally)
                    break;

                switch (currentStatement.TraceType)
                {
                    case TraceType.ExitLoop: break;
                    default: HandleBodyUnexpectedTrace(currentStatement); break;
                }

                if (_traceConsumer.HasNext())
                    currentStatement = _traceConsumer.GetNextStatement();
                else
                    currentStatement = null;
            }
        }

        public static int lineNumber = 181;
        public static int fileId = 1454;

        public static int spanStart = 1;
        public static int spanEnd = 1;
        public static int lastTraceAmount = 0;

        //public static int apparitionNumber = 1;
        //public static int lineCounter = 0;
        void StatementConsume(Stmt currentStatement)
        {
            //Console.WriteLine("{4},{0},{1},{2},{3}", currentStatement.FileId, currentStatement.Line, currentStatement.SpanStart, currentStatement.SpanEnd, _traceConsumer.Stack.Count);

            //if (_executedStatements.ExecutedStatmentsCounter % 100000 == 0)
            //    Utils.Print(_executedStatements.ExecutedStatmentsCounter + " " + DateTime.Now.ToString("HH:mm"));

            if (_traceConsumer.TotalTracedLines >= lastTraceAmount)
            {
                Utils.Print(_traceConsumer.TotalTracedLines + " " + DateTime.Now.ToString("HH:mm"));
                lastTraceAmount += 75000;
            }

            var line = currentStatement.Line;
            if ((currentStatement.FileId == fileId && line == lineNumber)
                || (currentStatement.SpanStart == spanStart && currentStatement.SpanEnd == spanEnd)
                )
                ;

            //{
            //    //if (lineCounter == apparitionNumber)
            //    Console.WriteLine("Línea correcta");
            //    //Console.WriteLine(lineCounter++);
            //}

            _originalStatement = currentStatement;
            _executedStatements.Add(currentStatement);

            try
            {
                var operation = GetOperation(currentStatement.CSharpSyntaxNode);
                if (operation == null && currentStatement.CSharpSyntaxNode is WhenClauseSyntax)
                    VisitCaseWhenSyntax(currentStatement);
                else if (operation == null)
                    VisitPropertyOrFieldDeclaration(currentStatement);
                else if (_methodNode is ArrowExpressionClauseSyntax && (_methodNode.Parent is PropertyDeclarationSyntax || _methodNode.Parent is ConversionOperatorDeclarationSyntax ||
                    (_methodNode.Parent is AccessorDeclarationSyntax &&
                    ((AccessorDeclarationSyntax)_methodNode.Parent).Keyword.ValueText.Equals("get", StringComparison.OrdinalIgnoreCase)) ||
                    ((_methodNode.Parent is MethodDeclarationSyntax || _methodNode.Parent is LocalFunctionStatementSyntax) &&
                    !((IMethodSymbol)_semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)_methodNode).GetDeclaredSymbol(_methodNode.Parent)).ReturnsVoid)))
                    VisitArrowExpressionClause(operation);
                else
                    Visit(operation);

                if ((currentStatement.FileId == fileId && line == lineNumber)
                    || (currentStatement.SpanStart == spanStart && currentStatement.SpanEnd == spanEnd))
                    ;

                #region Mediciones
#if DEBUG
                //GlobalPerformanceValues.MemoryConsumptionValues.Eval();

                if (UserSliceConfiguration.CurrentUserConfiguration.results.printGraphForEachStatement &&
                    currentStatement.FileId == 4)
                    _broker.Solver.DumpPTG(System.IO.Path.Combine(UserSliceConfiguration.CurrentUserConfiguration.results.mainResultsFolder, _executedStatements.DistinctExecutedStatements + ".dot"),
                        (currentStatement.CSharpSyntaxNode).ToString().Length > 30 ? (currentStatement.CSharpSyntaxNode).ToString().Substring(0, 30)
                        : (currentStatement.CSharpSyntaxNode).ToString());
#endif
                #endregion

                #region Extras
                // El 0 de la derecha es cada cuanto limpia los temporales
                if ((!(_setReturn || _returnPostponed)) && _statementsWithoutCleaning >= 0)
                {
                    //_broker.CleanTemporaryEntries();
                    _statementsWithoutCleaning = 0;
                }
                else
                    _statementsWithoutCleaning++;

                if (_sliceCriteriaReached || (!_setReturn && _broker.SliceCriteriaReached))
                {
                    _broker.Slice(new ResultSummaryData(currentStatement.FileName, currentStatement.Line,
                        _traceConsumer, _executedStatements, DateTime.Now.Subtract(Globals.start_time)));

                    if (UserSliceConfiguration.CurrentUserConfiguration.criteria.mode != UserConfiguration.Criteria.CriteriaMode.AtEndWithCriteria
                        && _traceConsumer.RemoveCriteria())
                        throw new SliceCriteriaReachedException();
                }
                #endregion

            }
            catch (CatchedProgramException)
            {

            }
        }
        #endregion

        #region Visits
        #region MainVisitor
        Term Visit(IOperation operation)
        {
            if (operation == null)
                return null;

            Term returnValue = null;
            switch (operation.Kind)
            {
                case OperationKind.IsType:
                    returnValue = Visit(((IIsTypeOperation)operation).ValueOperand);
                    break;
                case OperationKind.ExpressionStatement:
                    returnValue = Visit(((IExpressionStatementOperation)operation).Operation);
                    break;
                case OperationKind.Conversion:
                    returnValue = VisitConversionExpression((IConversionOperation)operation);
                    break;
                case OperationKind.Empty:
                    VisitEmptyStatement((IEmptyOperation)operation);
                    break;
                case OperationKind.SimpleAssignment:
                    returnValue = VisitAssignmentExpression((IAssignmentOperation)operation);
                    break;
                case OperationKind.DeconstructionAssignment:
                    returnValue = VisitDeconstructionAssignmentExpression((IDeconstructionAssignmentOperation)operation);
                    break;
                case OperationKind.EventAssignment:
                    VisitEventAssignmentExpression((IEventAssignmentOperation)operation);
                    break;
                case OperationKind.DelegateCreation:
                    returnValue = VisitDelegateCreationOperation((IDelegateCreationOperation)operation);
                    break;
                case OperationKind.MethodReference:
                    returnValue = VisitMethodReferenceOperation((IMethodReferenceOperation)operation);
                    break;
                case OperationKind.CompoundAssignment:
                    returnValue = VisitCompoundAssignmentExpression((ICompoundAssignmentOperation)operation);
                    break;
                case OperationKind.Increment:
                    returnValue = VisitIncrementExpression((IIncrementOrDecrementOperation)operation);
                    break;
                case OperationKind.Decrement:
                    returnValue = VisitIncrementExpression((IIncrementOrDecrementOperation)operation);
                    break;
                case OperationKind.UnaryOperator:
                    returnValue = VisitUnaryOperatorExpression((IUnaryOperation)operation);
                    break;
                case OperationKind.BinaryOperator:
                    returnValue = VisitBinaryOperatorExpression((IBinaryOperation)operation);
                    break;
                case OperationKind.Using:
                    VisitUsingStatement((IUsingOperation)operation);
                    break;
                case OperationKind.UsingDeclaration:
                    VisitUsingDeclarationStatement((IUsingDeclarationOperation)operation);
                    break;
                case OperationKind.Conditional:
                    if (((IConditionalOperation)operation).Syntax is IfStatementSyntax)
                        VisitIfStatement((IConditionalOperation)operation);
                    else
                        returnValue = VisitConditionalChoiceExpression((IConditionalOperation)operation);
                    break;
                case OperationKind.Loop:
                    switch (((ILoopOperation)operation).LoopKind)
                    {
                        case LoopKind.ForEach:
                            VisitForEachLoopStatement((IForEachLoopOperation)operation);
                            break;
                        case LoopKind.While:
                            VisitWhileUntilLoopStatement((IWhileLoopOperation)operation);
                            break;
                        case LoopKind.For:
                            VisitForOperation((IForLoopOperation)operation);
                            break;
                    }
                    break;
                case OperationKind.Switch:
                    VisitSwitchStatement((ISwitchOperation)operation);
                    break;
                case OperationKind.SwitchExpression:
                    returnValue = VisitSwitchExpression((ISwitchExpressionOperation)operation);
                    break;
                case OperationKind.SwitchCase:
                    VisitSwitchCase((ISwitchCaseOperation)operation);
                    break;
                case OperationKind.CaseClause:
                    VisitCaseClause((ICaseClauseOperation)operation);
                    break;
                case OperationKind.VariableDeclarationGroup:
                    VisitVariableDeclarationStatement((IVariableDeclarationGroupOperation)operation);
                    break;
                case OperationKind.VariableDeclaration:
                    VisitVariableDeclaration((IVariableDeclarationOperation)operation);
                    break;
                case OperationKind.VariableDeclarator:
                    VisitVariableDeclarator((IVariableDeclaratorOperation)operation);
                    break;
                case OperationKind.DeclarationExpression:
                    returnValue = VisitDeclarationExpression((IDeclarationExpressionOperation)operation);
                    break;
                case OperationKind.VariableInitializer:
                    return Visit(((IVariableInitializerOperation)operation).Value);
                    break;
                case OperationKind.TypeOf:
                    returnValue = VisitTypeOperationExpression((ITypeOfOperation)operation);
                    break;
                case OperationKind.IsPattern:
                    returnValue = VisitIsPatternOperationExpression((IIsPatternOperation)operation);
                    break;
                case OperationKind.DefaultValue:
                    returnValue = VisitDefaultValueExpression((IDefaultValueOperation)operation);
                    break;
                case OperationKind.ArrayCreation:
                    returnValue = VisitArrayCreationExpression((IArrayCreationOperation)operation);
                    break;
                case OperationKind.ArrayInitializer:
                    returnValue = VisitArrayInitializer((IArrayInitializerOperation)operation);
                    break;
                case OperationKind.Coalesce:
                    returnValue = VisitNullCoalescingExpression((ICoalesceOperation)operation);
                    break;
                case OperationKind.CoalesceAssignment:
                    returnValue = VisitCoalesceAssignmentOperation((ICoalesceAssignmentOperation)operation);
                    break;
                case OperationKind.Return:
                    VisitReturnStatement((IReturnOperation)operation);
                    break;
                case OperationKind.YieldReturn:
                    VisitYieldReturnStatement((IReturnOperation)operation);
                    break;
                case OperationKind.YieldBreak:
                    VisitYieldBreakStatement((IReturnOperation)operation);
                    break;
                case OperationKind.Invocation:
                    returnValue = VisitInvocationExpression((IInvocationOperation)operation);
                    break;
                case OperationKind.ObjectCreation:
                    returnValue = VisitObjectCreationExpression((IObjectCreationOperation)operation);
                    break;
                case OperationKind.AnonymousObjectCreation:
                    returnValue = VisitAnonymousObjectCreationExpression((IAnonymousObjectCreationOperation)operation);
                    break;
                case OperationKind.TypeParameterObjectCreation:
                    returnValue = VisitTypeParameterObjectCreationExpression((ITypeParameterObjectCreationOperation)operation);
                    break;
                case OperationKind.Argument:
                    returnValue = VisitArgument((IArgumentOperation)operation);
                    break;
                case OperationKind.LocalReference:
                    returnValue = VisitLocalReferenceExpression((ILocalReferenceOperation)operation);
                    break;
                case OperationKind.EventReference:
                    returnValue = VisitEventReferenceExpression((IEventReferenceOperation)operation);
                    break;
                case OperationKind.FieldReference:
                    returnValue = VisitFieldReferenceExpression((IFieldReferenceOperation)operation);
                    break;
                case OperationKind.PropertyReference:
                    returnValue = (((IPropertyReferenceOperation)operation).IsIndexer()) ?
                        VisitIndexedPropertyReferenceExpression((IPropertyReferenceOperation)operation) :
                        VisitPropertyReferenceExpression((IPropertyReferenceOperation)operation);
                    break;
                case OperationKind.ConditionalAccess:
                    returnValue = VisitConditionalAccessOperation((IConditionalAccessOperation)operation);
                    break;
                case OperationKind.ConditionalAccessInstance:
                    returnValue = VisitConditionalAccessInstance((IConditionalAccessInstanceOperation)operation);
                    break;
                case OperationKind.ParameterReference:
                    returnValue = VisitParameterReferenceExpression((IParameterReferenceOperation)operation);
                    break;
                case OperationKind.ArrayElementReference:
                    returnValue = VisitArrayElementReferenceExpression((IArrayElementReferenceOperation)operation);
                    break;
                case OperationKind.InstanceReference:
                    returnValue = VisitInstanceReferenceExpression((IInstanceReferenceOperation)operation);
                    break;
                case OperationKind.AnonymousFunction:
                    returnValue = VisitLambdaExpression((IAnonymousFunctionOperation)operation);
                    break;
                case OperationKind.InterpolatedStringText:
                    returnValue = Visit(((IInterpolatedStringTextOperation)operation).Text);
                    break;
                case OperationKind.Interpolation:
                    returnValue = Visit(((IInterpolationOperation)operation).Expression);
                    break;
                case OperationKind.InterpolatedString:
                    returnValue = VisitInterpolatedStringOperation((IInterpolatedStringOperation)operation);
                    break;
                case OperationKind.Literal:
                    returnValue = VisitLiteralExpression((ILiteralOperation)operation);
                    break;
                case OperationKind.SizeOf:
                    returnValue = VisitSizeOfOperation((ISizeOfOperation)operation);
                    break;
                case OperationKind.Branch:
                    VisitBranchStatement((IBranchOperation)operation);
                    break;
                case OperationKind.Lock:
                    VisitLockStatement((ILockOperation)operation);
                    break;
                case OperationKind.NameOf:
                    returnValue = VisitNameOf((INameOfOperation)operation);
                    break;
                case OperationKind.Throw:
                    VisitThrowStatement((IThrowOperation)operation);
                    break;
                case OperationKind.TranslatedQuery:
                    returnValue = VisitQueryExpression((ITranslatedQueryOperation)operation);
                    break;
                case OperationKind.DynamicMemberReference:
                    returnValue = VisitDynamicMemberReference((IDynamicMemberReferenceOperation)operation);
                    break;
                case OperationKind.DynamicIndexerAccess:
                    returnValue = VisitDynamicAccess((IDynamicIndexerAccessOperation)operation);
                    break;
                case OperationKind.Tuple:
                    returnValue = VisitTuple((ITupleOperation)operation);
                    break;
                case OperationKind.Discard:
                    returnValue = VisitDiscard((IDiscardOperation)operation);
                    break;
                case OperationKind.Await:
                    returnValue = Visit(((IAwaitOperation)operation).Operation);
                    break;
                case OperationKind.Invalid:
                case OperationKind.None:
                    returnValue = VisitInvalidOperation(operation);
                    break;
                default:
                    throw new SlicerException("Operación no desarrollada");
            }

            if (!_throwingException)
                CheckExceptions();

            return returnValue;
        }
        #endregion

        #region Visits especiales
        void VisitEmptyStatement(IEmptyOperation operation)
        {
            _broker.UseOperation(Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult), new List<Term>());
        }

        void VisitLockStatement(ILockOperation operation)
        {
            var internalTerm = Visit(operation.LockedValue);
            _broker.UseOperation(Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult), new List<Term>() { internalTerm });
        }

        Term VisitNameOf(INameOfOperation operation)
        {
            // XXX: No voy a hacer que utilice la variable porque no tiene sentido, no la utiliza! así que es como un literal. 
            var slicerSymbol = ISlicerSymbol.Create(operation.Type);
            var newTerm = _termFactory.Create(operation, slicerSymbol, false, TermFactory.GetFreshName());
            _broker.DefUseOperation(newTerm);
            return newTerm;
        }

        void VisitEventAssignmentExpression(IEventAssignmentOperation operation)
        {
            // XXX: Asumimos que no hay callbacks
            var def = Visit(operation.EventReference);
            var use = Visit(operation.HandlerValue);
            // XXX: En realidad es new EventHandler(<MethodBinding>) pero MethodBinding no es lo que tiene el End, de hecho se puede invocar desde otros lados
            // Como es un new()... tiene un EndInvocation que no se consume
            // TODOX
            //if (operation.HandlerValue.Kind == OperationKind.MethodBindingExpression)
            //    OptionalGetNextStatement(TraceType.EndInvocation, operation.Syntax.Span.End);
            if (use != null)
                _broker.Assign(def, use, null);
        }

        Term VisitDelegateCreationOperation(IDelegateCreationOperation operation)
        {
            var internalMethod = Visit(operation.Target);
            OptionalGetNextStatement(TraceType.EndInvocation, operation.Syntax.Span.End);

            // No sé si vale la pena devolver algo. TODOX IMPORTANTE REVISAR QUE QUEREMOS DEVOLVER
            return internalMethod;
        }

        Term VisitMethodReferenceOperation(IMethodReferenceOperation operation)
        {
            Term newTerm;
            IDictionary<ITypeSymbol, ITypeSymbol> typesDictionary = null;
            var recTerm = Visit(operation.Instance);
            if (recTerm == null)
            {
                newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments), operation.Method.IsStatic,
                    Utils.GetRealName(operation.Method.ToString(), _typeArguments));
                typesDictionary = Utils.GetTypesDictionary(operation.Method.ContainingType, _typeArguments);
            }
            else if (recTerm.IsScalar)
                newTerm = recTerm;
            else
            {
                // TODO: Habría que tener un tipo especial para "métodos" pero no tiene sentido. 
                newTerm = recTerm.AddingField(new Field(operation.Method.Name, ISlicerSymbol.CreateObjectSymbol()));
                newTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
            }
            return newTerm;
        }

        void VisitUsingStatement(IUsingOperation operation)
        {
            // Inicialización de variables
            var definedTerm = Visit(operation.Resources);

            List<Term> defs;
            if (operation.Resources is IVariableDeclarationGroupOperation)
                defs = ((IVariableDeclarationGroupOperation)operation.Resources).Declarations.SelectMany(x => x.Declarators.Select(y =>
                _termFactory.Create(x, ISlicerSymbol.Create(((IVariableDeclaratorOperation)y).Symbol.Type), false, ((IVariableDeclaratorOperation)y).Symbol.Name))).ToList();
            else if (operation.Resources is ILocalReferenceOperation)
                defs = new List<Term>() { _termFactory.Create(((ILocalReferenceOperation)operation.Resources),
                    ISlicerSymbol.Create(((ILocalReferenceOperation)operation.Resources).Local.Type), false, ((ILocalReferenceOperation)operation.Resources).Local.Name)};
            else if (operation.Resources is IInvocationOperation)
                defs = new List<Term>() { definedTerm };
            else if (operation.Resources is IObjectCreationOperation)
                defs = new List<Term>() { Visit(operation.Resources) };
            else
                throw new NotImplementedException();

            defs.Reverse();

            foreach (var def in defs)
                _usingStack.Push(def);
        }

        void VisitUsingDeclarationStatement(IUsingDeclarationOperation operation)
        {
            Visit(operation.DeclarationGroup);
        }

        Term VisitTypeOperationExpression(ITypeOfOperation operation)
        {
            var returnHub = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type), false, TermFactory.GetFreshName());
            _broker.CustomEvent(new List<Term>(), null, new List<Term>(), returnHub, "TypeOf");
            return returnHub;
        }

        Term VisitIsPatternOperationExpression(IIsPatternOperation operation)
        {
            var valueTerm = Visit(operation.Value);
            var slicerSymbol = ISlicerSymbol.Create(operation.Type);
            var newTerm = _termFactory.Create(operation, slicerSymbol, false, TermFactory.GetFreshName());
            var usedTerms = new List<Term>() { valueTerm };
            _broker.DefUseOperation(newTerm, usedTerms.ToArray());

            if (operation.Pattern != null)
            {
                var pattern = operation.Pattern;
                if (pattern is INegatedPatternOperation negatedPatternOperation)
                    pattern = negatedPatternOperation.Pattern;

                if (pattern is IDeclarationPatternOperation declarationPatternOperation)
                {
                    var declaredVariable = _termFactory.Create(pattern, ISlicerSymbol.Create(pattern.NarrowedType), false, declarationPatternOperation.DeclaredSymbol.Name, false, false);
                    _broker.Assign(declaredVariable, valueTerm, new List<Term>() { newTerm });
                }
                else if (pattern is IRecursivePatternOperation recPatternOp)
                {
                    PatternOperationReceiver = valueTerm;
                    foreach (var propSupPat in recPatternOp.PropertySubpatterns)
                    {
                        var member = Visit(propSupPat.Member);

                        DealWithPatterns(member, propSupPat.Pattern, usedTerms);
                        // VOY POR ACÁ
                        //usedTerms.Add(member);
                        //if (propSupPat.Pattern is IDeclarationPatternOperation)
                        //{
                        //    if (!(((IDeclarationPatternOperation)propSupPat.Pattern).DeclaredSymbol is null))
                        //    { 
                        //        var varMem = _termFactory.Create(propSupPat.Pattern, ISlicerSymbol.Create(propSupPat.Pattern.NarrowedType), false, ((IDeclarationPatternOperation)propSupPat.Pattern).DeclaredSymbol.Name, false, false);
                        //        try 
                        //        { 
                        //            _broker.Assign(varMem, member, new List<Term>() { newTerm });
                        //        }
                        //        catch(NonGlobalUninitializedTerm ex)
                        //        {
                        //            ;
                        //        }
                        //    }
                        //}
                    }
                    PatternOperationReceiver = null;

                    if (recPatternOp.DeclaredSymbol != null)
                    {
                        // TODO: Repeated code
                        var declaredVariable = _termFactory.Create(recPatternOp, ISlicerSymbol.Create(recPatternOp.NarrowedType), false, recPatternOp.DeclaredSymbol.Name, false, false);
                        _broker.Assign(declaredVariable, valueTerm, new List<Term>() { newTerm });
                    }
                }
            }

            while (usedTerms.Count > 1)
            {
                try
                {
                    _broker.DefUseOperation(newTerm, usedTerms.ToArray());
                    break;
                }
                catch (NonGlobalUninitializedTerm ex)
                {
                    usedTerms.Remove(ex.Term);
                }
            }
            return newTerm;
        }

        Term VisitDefaultValueExpression(IDefaultValueOperation operation)
        {
            var returnTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type), false, TermFactory.GetFreshName(), true);
            //_broker.Alloc(returnTerm);
            //_broker.DefUseOperation(returnTerm);
            _broker.HandleNonInstrumentedMethod(new List<Term>(), null, new List<Term>(), returnTerm, operation.Type, ".ctor");
            return returnTerm;
        }

        void VisitThrowStatement(IThrowOperation operation)
        {
            if (operation.Exception != null)
            {
                _throwingException = true;
                Term expTerm = Visit(operation.Exception);
                ExceptionTerm = _termFactory.Create(operation, expTerm.Last.Symbol, true, TermFactory.GetFreshName());
                _broker.Assign(ExceptionTerm, expTerm);
                _throwingException = false;
            }
            else
                _broker.UseOperation(Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult), new List<Term>());
        }

        Term VisitLambdaExpression(IAnonymousFunctionOperation operation)
        {
            // Hay casos particulares donde estás haciendo una invocación y esto es un parámetro. 
            // Veamos caso por caso y analicemos en concreto.
            var slicerSymbol = ISlicerSymbol.CreateLambdaSlicerSymbol();
            if (operation.Parent != null && operation.Parent.Parent != null && operation.Parent.Parent is IArgumentOperation)
                slicerSymbol = ISlicerSymbol.Create(((IArgumentOperation)operation.Parent.Parent).Parameter.Type, _typeArguments);
            else if (operation.Parent != null && operation.Parent is IDelegateCreationOperation)
                slicerSymbol = ISlicerSymbol.Create(((IDelegateCreationOperation)operation.Parent).Type, _typeArguments);
            else if (operation.Parent is IInvalidOperation)
                slicerSymbol = ISlicerSymbol.CreateObjectSymbol();
            else
                throw new NotImplementedException("REVISAR");

            var newTerm = _termFactory.Create(operation, slicerSymbol, false, TermFactory.GetFreshName());

            var parameterList = new List<string>();

            if (operation.Syntax is SimpleLambdaExpressionSyntax)
                parameterList.Add(((SimpleLambdaExpressionSyntax)operation.Syntax).Parameter.Identifier.ValueText);
            else if (operation.Syntax is ParenthesizedLambdaExpressionSyntax)
                parameterList.AddRange(((ParenthesizedLambdaExpressionSyntax)operation.Syntax)
                    .ParameterList.Parameters.Select(x => x.Identifier.ValueText));
            else if (operation.Syntax is AnonymousMethodExpressionSyntax &&
                ((AnonymousMethodExpressionSyntax)operation.Syntax).ParameterList != null)
                parameterList.AddRange(((AnonymousMethodExpressionSyntax)operation.Syntax)
                    .ParameterList.Parameters.Select(x => x.Identifier.ValueText));

            IOperation bodyStatement = operation.Body.Operations.First();

            var dependentTerms = new HashSet<Term>();
            // AGREGAMOS TODOS LOS USOS, SERÍA COMO UN HAVOC BENÉVOLO
            var usesVisitor = new UsesVisitor(_semanticModelsContainer, _instrumentationResult, _termFactory);
            usesVisitor.Visit(bodyStatement)
                .Where(x => !parameterList.Contains(x.First.ToString()))
                .ToList()
                .ForEach(x => dependentTerms.Add(x));

            /// XXX Lo que queremos es que funcione como lista, que apunte a todos los usos, pero estos no apunten al lambda
            _broker.CustomEvent(dependentTerms.ToList(), null, new List<Term>(), newTerm, "Lambda");
            return newTerm;
        }

        Term VisitQueryExpression(ITranslatedQueryOperation operation)
        {
            // El término que vamos a devolver
            //TODO: Esto no tiene tipo?
            Term newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type), false, TermFactory.GetFreshName());
            // Las variables que se definen dentro de la query (los elementos de las listas)
            // Sirve para filtrar las variables externas de las internas
            var listIdentifiers = new List<string>();
            // Las variables que vamos a ligar a la operation
            var dependentTerms = new HashSet<Term>();
            // Instanciamos el visitor que no consume traza
            var usesVisitor = new UsesVisitor(_semanticModelsContainer, _instrumentationResult, _termFactory);

            // XXX: (QUERYEXPRESSIONSYNTAX): LO TRATO CON EJEMPLOS
            /*
                from unaCasa in lista
                join otraCasa in lista2 
                on unaCasa.cantVentanas equals otraCasa.cantVentanas - variableAuxiliar2
                where otraCasa.cantVentanas < variableAuxiliar3
                select new { unaCasa.cantVentanas, unaCasa.propietario.nombre, variableAuxiliar }
            */

            // CONSTRUCCIÓN SINTÁCTICA:
            /*
	            1. BODY: select new { unaCasa.cantVentanas, unaCasa.propietario.nombre, variableAuxiliar }
                    ==> De acá me importan solo las variables libres externas como variableAuxiliar, al resto se llega por lista
	            2. FROM CLAUSE: El resto
		            A. Expression ==> Lo que SI me importa
		            B. FROM KEYWORD
		            C. Identifier (nombre que le pongo al elemento, puede servir para filtrar el body)
		            D. IN KEYWORD
            */

            // Si fuera un from solo sería: operation.FromClause.Expression... pero puede haber otros from anidados, por eso consultamos así
            foreach (var fromClause in operation.Syntax.DescendantNodes().OfType<FromClauseSyntax>())
            {
                // 1. Arrancamos obteniendo las variables declaradas en el FROM (identifiers)
                listIdentifiers.Add(fromClause.Identifier.Text);
                // 2. Luego obtenemos nuestras variables externas (vamos filtrando porque pueden ser parte de las variables ya leidas)
                usesVisitor.Visit(GetOperation(fromClause.Expression))
                    .Where(x => !listIdentifiers.Contains(x.First.ToString().Split('.')[0]))
                    .ToList()
                    .ForEach(x => dependentTerms.Add(x));
            }

            // 3. De las cláusulas obtenemos los términos que importan
            foreach (var clause in ((QueryExpressionSyntax)operation.Syntax).Body.Clauses)
            {
                if (clause is JoinClauseSyntax)
                {
                    // EJEMPLO DE JOIN:
                    /* join otraCasa in lista2 on unaCasa.cantVentanas equals otraCasa.cantVentanas - variableAuxiliar2 */

                    // 1. JOIN KEYWORD
                    // 2. Identifier: otraCasa
                    // 3. IN KEYWORD
                    // 4. InExpression: lista2
                    // 5. ON KEYWORD
                    // 6. LeftExpression: unaCasa.cantVentanas
                    // 7. EQUALS KEYWORD
                    // 8. RightExpression: otraCasa.cantVentanas - variableAuxiliar2

                    listIdentifiers.Add(((JoinClauseSyntax)clause).Identifier.Text);

                    usesVisitor.Visit(GetOperation(((JoinClauseSyntax)clause).InExpression))
                                .Where(x => !listIdentifiers.Contains(x.First.ToString().Split('.')[0]))
                               .ToList()
                               .ForEach(x => dependentTerms.Add(x));

                    usesVisitor.Visit(GetOperation(((JoinClauseSyntax)clause).LeftExpression))
                               .Where(x => !listIdentifiers.Contains(x.First.ToString().Split('.')[0]))
                               .ToList()
                               .ForEach(x => dependentTerms.Add(x));

                    usesVisitor.Visit(GetOperation(((JoinClauseSyntax)clause).RightExpression))
                               .Where(x => !listIdentifiers.Contains(x.First.ToString().Split('.')[0]))
                               .ToList()
                               .ForEach(x => dependentTerms.Add(x));
                }
                if (clause is WhereClauseSyntax)
                {
                    // EJEMPLO DE WHERE: where otraCasa.cantVentanas < variableAuxiliar3
                    // Lo único que importa es la expresión

                    usesVisitor.Visit(GetOperation(((WhereClauseSyntax)clause).Condition))
                               .Where(x => !listIdentifiers.Contains(x.First.ToString().Split('.')[0]))
                               .ToList()
                               .ForEach(x => dependentTerms.Add(x));
                }
            }

            // 2. Obtenemos del body las variables utilizadas
            // TODO: FALTA EL GROUPCLAUSESYNTAX
            if (((QueryExpressionSyntax)operation.Syntax).Body.SelectOrGroup is SelectClauseSyntax)
                usesVisitor.Visit(GetOperation(((SelectClauseSyntax)((QueryExpressionSyntax)operation.Syntax).Body.SelectOrGroup).Expression))
                    .Where(x => !listIdentifiers.Contains(x.First.ToString().Split('.')[0]))
                    .ToList()
                    .ForEach(x => dependentTerms.Add(x));

            var returnedTerms = WaitForEnd(newTerm.Stmt.CSharpSyntaxNode, dependentTerms.ToList(), null, "QUERY", TraceType.EndInvocation, true);
            _broker.CustomEvent(dependentTerms.ToList(), null, new List<Term>(), newTerm, "Query");
            return newTerm;
        }

        Term VisitConversionExpression(IConversionOperation operation)
        {
            var recTerm = Visit(operation.Operand);
            if (recTerm == null || operation.Operand.Type == null)
                return recTerm;
            // Si se tiene que devolvear algo lo devolvemos a través de algo de otro tipo.

            if (operation.IsImplicit && operation.Type != operation.Operand.Type && !TypesUtils.Compatibles(operation.Type, operation.Operand.Type))
            {
                var realType = operation.Type;
                if (operation.Operand.Type.TypeKind == TypeKind.TypeParameter && _typeArguments == null)
                    ;

                if (operation.Operand.Type.TypeKind == TypeKind.TypeParameter && _typeArguments != null)
                {
                    var tempType = _typeArguments.Where(x => x.Key.Name == operation.Operand.Type.Name).FirstOrDefault().Value;
                    if (tempType != null)
                        realType = tempType;
                }

                // La conversión está overraideada
                if (_traceConsumer.HasNext() &&
                    ObserveNextStatement().TraceType == TraceType.EnterStaticMethod &&
                    ((ObserveNextStatement().CSharpSyntaxNode is ConversionOperatorDeclarationSyntax) ||
                    (ObserveNextStatement().CSharpSyntaxNode.Parent is ConversionOperatorDeclarationSyntax)))
                {
                    var useTerms = new List<Term>() { CreateArgument(recTerm) };
                    var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(realType), false, TermFactory.GetFreshName());
                    HandleInstrumentedMethod(operation, newTerm, useTerms, null);
                    return newTerm;
                }

                // Cuando se castean object a string por ej.
                if (!realType.IsNotScalar() && operation.Operand.Type.IsNotScalar())
                {
                    // TODOX: chequear porque sigue alocado... 
                    var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(realType));
                    _broker.DefUseOperation(newTerm, new Term[] { recTerm });
                    return newTerm;
                }
                else if (realType.IsNotScalar() && operation.Operand.Type.IsNotScalar())
                {
                    recTerm.Last.Symbol = ISlicerSymbol.Create(realType);
                    _broker.RedefineType(recTerm);
                }
                else if (realType.IsNotScalar() && !operation.Operand.Type.IsNotScalar())
                {
                    var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(realType), false, TermFactory.GetFreshName());
                    // XXX: We're not expecting callbacks
                    _broker.HandleNonInstrumentedMethod(new List<Term>() { recTerm }, null, new List<Term>(), newTerm, operation.OperatorMethod);
                    return newTerm;
                }
            }
            else if (operation.Operand.Kind == OperationKind.Tuple && operation.Type is INamedTypeSymbol && ((INamedTypeSymbol)operation.Type).IsTupleType)
            {
                var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments), false, TermFactory.GetFreshName());
                _broker.Alloc(newTerm);
                _broker.DefUseOperation(newTerm);
                var i = 0;
                foreach (var e in ((INamedTypeSymbol)operation.Type).TupleElements)
                {
                    var tempTerm_old = recTerm.AddingField("x" + i, ISlicerSymbol.Create(((INamedTypeSymbol)operation.Operand.Type).TupleElements[i].Type, _typeArguments));
                    var tempTerm_new = recTerm.AddingField(e.Name, ISlicerSymbol.Create(e.Type, _typeArguments));
                    tempTerm_old.Stmt = tempTerm_new.Stmt = Utils.StmtFromSyntaxNode(((TupleExpressionSyntax)operation.Operand.Syntax).Arguments[i], _instrumentationResult);
                    _broker.Assign(tempTerm_new, tempTerm_old);

                }
            }
            else if (_traceConsumer.HasNext() &&
                    ObserveNextStatement().TraceType == TraceType.EnterStaticMethod &&
                    ((ObserveNextStatement().CSharpSyntaxNode is ConversionOperatorDeclarationSyntax) ||
                    (ObserveNextStatement().CSharpSyntaxNode.Parent is ConversionOperatorDeclarationSyntax)))
            {
                var useTerms = new List<Term>() { CreateArgument(recTerm) };
                var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type), false, TermFactory.GetFreshName());
                HandleInstrumentedMethod(operation, newTerm, useTerms, null);
                return newTerm;
            }
            return recTerm;
        }

        void VisitCaseWhenSyntax(Stmt stmt)
        {
            var caseClauseOp = GetOperation((CSharpSyntaxNode)stmt.CSharpSyntaxNode.Parent) as ICaseClauseOperation;
            var uses = new List<Term>();
            if (caseClauseOp != null && caseClauseOp.CaseKind == CaseKind.Pattern)
                DealWithPatterns(temporarySwitchTerm, ((IPatternCaseClauseOperation)caseClauseOp).Pattern, uses);

            var operation = GetOperation(((WhenClauseSyntax)stmt.CSharpSyntaxNode).Condition);

            // Before entering to the visit I want to keep the temporary switch term outside
            var localTemporarySwitchTerm = temporarySwitchTerm;
            temporarySwitchTerm = null;
            var recTerm = Visit(operation);
            temporarySwitchTerm = localTemporarySwitchTerm;

            var nextStmt = ObserveNextStatement();
            if (nextStmt.TraceType == TraceType.EnterExpression && nextStmt.CSharpSyntaxNode == stmt.CSharpSyntaxNode)
            {
                GetNextStatement();
                // The next trace has to be EnterCondition (section body)
                var switchStmt = GetNextStatement();
                if (switchStmt.TraceType != TraceType.EnterCondition)
                    throw new SlicerException("Unexpected behavior");

                EnterCondition(switchStmt);
                uses.Add(recTerm);
                _broker.UseOperation(stmt, uses);
                ExitCondition(switchStmt);
                EnterCondition(stmt);
            }
        }

        void VisitPropertyOrFieldDeclaration(Stmt stmt)
        {
            try
            {
                _executedStatements.AddPropertyOrFieldInitialization(stmt);
                var syntaxNode = stmt.CSharpSyntaxNode;
                var semanticModel = _semanticModelsContainer.GetBySyntaxNode(syntaxNode);
                Term _definedVariable;

                if (syntaxNode is VariableDeclaratorSyntax)
                {
                    var identifier = ((VariableDeclaratorSyntax)syntaxNode);
                    var type = semanticModel.GetTypeInfo(identifier);
                    var symbol = semanticModel.GetSymbolInfo(identifier);
                    var isGlobal = ((FieldDeclarationSyntax)syntaxNode.Parent.Parent).Modifiers.Any(x => x.ToString() == "static" || x.ToString() == "const");
                    var name = isGlobal ? Utils.GetRealName(semanticModel.GetDeclaredSymbol(syntaxNode).ToString(), _typeArguments) : identifier.Identifier.ValueText;

                    if (((VariableDeclaratorSyntax)syntaxNode).Initializer != null)
                    {
                        var operation = GetOperation(((VariableDeclaratorSyntax)syntaxNode).Initializer.Value);
                        var recTerm = Visit(operation);

                        // Trying to get the correct type
                        var s = semanticModel.GetDeclaredSymbol(syntaxNode);
                        ISlicerSymbol slicerType = null;
                        if (s != null)
                        {
                            ITypeSymbol t = null;
                            if (s is IFieldSymbol)
                                t = ((IFieldSymbol)s).Type;
                            if (s is IPropertySymbol)
                                t = ((IPropertySymbol)s).Type;
                            if (t != null)
                                slicerType = ISlicerSymbol.Create(t, _typeArguments);
                        }
                        if (!isGlobal)
                            _definedVariable = _thisObject.AddingField(name, slicerType ?? recTerm.Last.Symbol);
                        else
                            _definedVariable = _termFactory.Create(syntaxNode, slicerType ?? recTerm.Last.Symbol, isGlobal, name);
                        _definedVariable.Stmt = Utils.StmtFromSyntaxNode(syntaxNode, _instrumentationResult);

                        // Possible implícit conversion
                        if (ObserveNextStatement().TraceType == TraceType.EnterStaticMethod &&
                            _semanticModelsContainer.GetBySyntaxNode(ObserveNextStatement().CSharpSyntaxNode).GetDeclaredSymbol(ObserveNextStatement().CSharpSyntaxNode) is IMethodSymbol &&
                            ((IMethodSymbol)_semanticModelsContainer.GetBySyntaxNode(ObserveNextStatement().CSharpSyntaxNode).GetDeclaredSymbol(ObserveNextStatement().CSharpSyntaxNode)).MethodKind == MethodKind.Conversion)
                        {
                            var newTerm = _termFactory.Create(operation, slicerType ?? recTerm.Last.Symbol, false, TermFactory.GetFreshName());
                            HandleInstrumentedMethod(_definedVariable.Stmt, newTerm, new List<Term> { recTerm }, null, _typeArguments);
                            _broker.Assign(_definedVariable, newTerm);
                        }
                        else
                            _broker.Assign(_definedVariable, recTerm);
                    }
                    else
                    {
                        var declaredSymbol = (IFieldSymbol)semanticModel.GetDeclaredSymbol(syntaxNode);
                        var currentSymbol = declaredSymbol != null && declaredSymbol.Type != null ? ISlicerSymbol.Create(declaredSymbol.Type, _typeArguments) : ISlicerSymbol.CreateNullTypeSymbol();
                        if (!isGlobal)
                            _definedVariable = _thisObject.AddingField(name, currentSymbol);
                        else
                            _definedVariable = _termFactory.Create(syntaxNode, currentSymbol, isGlobal, name);
                        _definedVariable.Stmt = Utils.StmtFromSyntaxNode(syntaxNode, _instrumentationResult);

                        _broker.DefUseOperation(_definedVariable);
                        if (currentSymbol.Symbol.CustomIsStruct())
                        {
                            _broker.Alloc(_definedVariable);
                            foreach (var f in currentSymbol.Symbol.GetMembers().Where(x => x is IFieldSymbol))
                            {
                                var fieldMember = _definedVariable.AddingField(f.Name, ISlicerSymbol.Create(((IFieldSymbol)f).Type, _typeArguments));
                                fieldMember.Stmt = _definedVariable.Stmt;
                                _broker.DefUseOperation(fieldMember);
                            }
                        }
                    }
                }
                else
                {
                    var identifier = ((PropertyDeclarationSyntax)syntaxNode);
                    var type = semanticModel.GetSymbolInfo(((PropertyDeclarationSyntax)syntaxNode).Type).Symbol;
                    var slicerType = type == null ? ISlicerSymbol.CreateNullTypeSymbol() : ISlicerSymbol.Create((ITypeSymbol)type);
                    var isGlobal = ((PropertyDeclarationSyntax)syntaxNode).Modifiers.Any(x => x.ToString() == "static" || x.ToString() == "const");
                    var name = isGlobal ? Utils.GetRealName(semanticModel.GetDeclaredSymbol(syntaxNode).ToString(), _typeArguments) : identifier.Identifier.ValueText;
                    if (isGlobal)
                        _definedVariable = _termFactory.Create((PropertyDeclarationSyntax)syntaxNode, slicerType, isGlobal, name);
                    else
                        _definedVariable = _thisObject.AddingField(name, slicerType);
                    _definedVariable.Stmt = Utils.StmtFromSyntaxNode(syntaxNode, _instrumentationResult);

                    if (((PropertyDeclarationSyntax)syntaxNode).Initializer != null)
                    {
                        var recTerm = Visit(GetOperation(((PropertyDeclarationSyntax)syntaxNode).Initializer.Value));

                        var obsNextStmt = ObserveNextStatement();
                        if (obsNextStmt.TraceType == TraceType.EnterStaticMethod && obsNextStmt.CSharpSyntaxNode is ConversionOperatorDeclarationSyntax)
                        {
                            var convTerm = _termFactory.Create((PropertyDeclarationSyntax)syntaxNode, slicerType);
                            HandleInstrumentedMethod(_originalStatement, convTerm, new List<Term>() { recTerm }, null, _typeArguments);
                            if (convTerm != null)
                                recTerm = convTerm;
                        }
                        _broker.Assign(_definedVariable, recTerm);
                    }
                    else
                        _broker.DefUseOperation(_definedVariable);
                }
            }
            catch (Exception ex)
            {
                ;
            }
        }

        Term VisitDynamicAccess(IDynamicIndexerAccessOperation operation)
        {
            var recTerm = Visit(operation.Operation);
            var useTerms = operation.Arguments.Select(x => Visit(x)).ToList();

            Term newTerm;
            IDictionary<ITypeSymbol, ITypeSymbol> typesDictionary = null;

            bool isSetAccessor;
            var hasGetAccesor = HasAccesor("", typesDictionary, out isSetAccessor) && !isSetAccessor; // TODOX: me sumo a cualquier get

            newTerm = recTerm.AddingField(new Field(/*hasGetAccesor ? (TODOX: si tenía nombre se lo ponía antes)*/ TermFactory.GetFreshName(), ISlicerSymbol.Create(operation.Type)));
            newTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);

            if (hasGetAccesor)
                HandleInstrumentedMethod(operation, newTerm, null, recTerm, typesDictionary);

            if (!((operation.Syntax.Parent is AssignmentExpressionSyntax &&
                ((AssignmentExpressionSyntax)operation.Syntax.Parent).Left == operation &&
                ((AssignmentExpressionSyntax)operation.Syntax.Parent).OperatorToken.Kind() == SyntaxKind.EqualsToken) ||
                //(operation.Syntax.Parent is MemberAccessExpressionSyntax // Structs
                //&& operation.Operation.Type.CustomIsStruct()) || // TODOX (hay que ver si es el tipo)
                (operation.Syntax.Parent is ArgumentSyntax && ((ArgumentSyntax)operation.Syntax.Parent).RefOrOutKeyword.Value != null)))
            {
                var nextStmt = ObserveNextStatement();
                if (newTerm.Count == 1)
                    GetNextStatement(TraceType.EndMemberAccess);
                else
                {
                    var returnTerms = WaitForEnd(newTerm.Stmt.CSharpSyntaxNode, new List<Term>() { newTerm }, null, "INIT", TraceType.EndMemberAccess);
                    _broker.HandleNonInstrumentedMethod(new List<Term>(), newTerm.IsGlobal ? null : newTerm.DiscardLast(), returnTerms, newTerm, operation.Type); // No sabemos siempre el nombre de la operación
                }
            }

            return newTerm;
        }

        Term VisitTuple(ITupleOperation operation)
        {
            List<Term> recTerms = new List<Term>();
            foreach (var o in operation.Elements)
                recTerms.Add(Visit(o));
            // Build the new object... 
            var returnTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments));
            _broker.Alloc(returnTerm);
            _broker.DefUseOperation(returnTerm);
            var i = 0;
            foreach (var e in ((INamedTypeSymbol)operation.Type).TupleElements)
            {
                var newTerm = returnTerm.AddingField("x" + i, ISlicerSymbol.Create(e.Type));
                newTerm.Stmt = Utils.StmtFromSyntaxNode(((TupleExpressionSyntax)operation.Syntax).Arguments[i], _instrumentationResult);
                _broker.Assign(newTerm, recTerms[i++]);
            }
            return returnTerm;
        }

        Term VisitDiscard(IDiscardOperation operation)
        {
            var returnTerm = _termFactory.Create(operation, ISlicerSymbol.CreateNullTypeSymbol(), false, TermFactory.GetFreshName());
            _broker.DefUseOperation(returnTerm);
            return returnTerm;
        }

        Term VisitInvalidOperation(IOperation operation)
        {
            var syntaxNode = (CSharpSyntaxNode)operation.Syntax;
            var syntaxKind = operation.Syntax.Kind();
            var model = _semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)operation.Syntax);
            switch (syntaxKind)
            {
                case SyntaxKind.InvocationExpression:
                    #region Invocation
                    var invocationSyntaxNode = (InvocationExpressionSyntax)syntaxNode;

                    //Console.WriteLine(invocationSyntaxNode.ToString() + "&" + _originalStatement.FileId + "&" + invocationSyntaxNode.SpanStart + "&" + invocationSyntaxNode.Span.End);

                    var symbolInfo = Utils.GetMethodSymbolInfo(model, invocationSyntaxNode);
                    if (symbolInfo == null)
                        BugLogging.Log(_originalStatement.FileId, syntaxNode, BugLogging.Behavior.WithoutSymbol);
                    else
                        BugLogging.Log(_originalStatement.FileId, syntaxNode, BugLogging.Behavior.WithoutIOperation);

                    Term thisTerm = null;
                    if ((symbolInfo == null || !symbolInfo.IsStatic) && invocationSyntaxNode.Expression is MemberAccessExpressionSyntax)
                    {
                        var receiverOp = GetOperation(((MemberAccessExpressionSyntax)invocationSyntaxNode.Expression).Expression);
                        thisTerm = Visit(receiverOp);
                    }

                    var isStatic = symbolInfo != null ? symbolInfo.IsStatic :
                    thisTerm == null && UserSliceConfiguration.GetIsStatic(_originalStatement.FileId, invocationSyntaxNode);

                    var argumentos = invocationSyntaxNode.ArgumentList.Arguments
                                         .Select(x => CreateArgument(x))
                                         .Where(x => x != null)
                                         .ToList();

                    var dictionary = symbolInfo != null ? Utils.GetTypesDictionary(symbolInfo, _typeArguments) : new Dictionary<ITypeSymbol, ITypeSymbol>();
                    var returnType = symbolInfo != null ? ISlicerSymbol.Create(symbolInfo.ReturnType, _typeArguments) : ISlicerSymbol.CreateObjectSymbol();
                    var newTerm = _termFactory.Create(operation, returnType, false, TermFactory.GetFreshName());

                    var name = symbolInfo != null ? symbolInfo.Name : invocationSyntaxNode.Expression.ToString().Split('.').Last();
                    // El false del final está para que no pinche
                    if (IsInstrumented(name, dictionary, false))
                    {
                        HandleInstrumentedMethod(operation, newTerm, argumentos, isStatic ? null : thisTerm, dictionary);
                        GetNextStatement(TraceType.EndInvocation);
                        if (symbolInfo != null && symbolInfo.ReturnsVoid)
                            _broker.DefUseOperation(newTerm);
                    }
                    else
                        HandleNonInstrumentedMethod(operation, argumentos, thisTerm, newTerm, symbolInfo, symbolInfo != null ? null : ((InvocationExpressionSyntax)operation.Syntax).Expression.ToString());
                    return newTerm;
                #endregion
                case SyntaxKind.SimpleMemberAccessExpression:
                    #region MemberAccess
                    var localSymbolInfo = Utils.GetSymbolInfo(model, syntaxNode);
                    BugLogging.Log(_originalStatement.FileId, syntaxNode, localSymbolInfo == null ? BugLogging.Behavior.WithoutSymbol : BugLogging.Behavior.WithoutIOperation);
                    Term t = null;
                    if (((MemberAccessExpressionSyntax)syntaxNode).Expression is BaseExpressionSyntax ||
                        ((MemberAccessExpressionSyntax)syntaxNode).Expression is ThisExpressionSyntax)
                    {
                        // TODO: se puede poner algo más específico en cada caso
                        var l = _termFactory.Create(operation, ISlicerSymbol.CreateObjectSymbol(), false, "this", false);
                        t = l.AddingField(new Field(((MemberAccessExpressionSyntax)syntaxNode).Name.Identifier.ValueText, ISlicerSymbol.CreateObjectSymbol()));
                        t.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)syntaxNode, _instrumentationResult);
                    }
                    else
                    {
                        if (localSymbolInfo != null)
                        {
                            #region WithSymbol
                            if (localSymbolInfo is IPropertySymbol)
                            {
                                Term recTerm = null;
                                IDictionary<ITypeSymbol, ITypeSymbol> typesDictionary = null;
                                bool isSetAccessor;
                                var hasGetAccesor = HasAccesor(localSymbolInfo.Name, typesDictionary, out isSetAccessor) && !isSetAccessor;

                                var staticProp = ((IPropertySymbol)localSymbolInfo).IsStatic;
                                var type = ((IPropertySymbol)localSymbolInfo).Type;
                                if (staticProp)
                                {
                                    t = _termFactory.Create(syntaxNode, ISlicerSymbol.Create(type, _typeArguments), staticProp,
                                        hasGetAccesor ? TermFactory.GetFreshName() : Utils.GetRealName(((IPropertySymbol)localSymbolInfo).Name, _typeArguments));
                                    typesDictionary = Utils.GetTypesDictionary(((IPropertySymbol)localSymbolInfo).ContainingType, _typeArguments);
                                }
                                else
                                {
                                    recTerm = Visit(GetOperation(((MemberAccessExpressionSyntax)syntaxNode).Expression));
                                    if (recTerm.IsScalar)
                                        throw new NotImplementedException();

                                    if (hasGetAccesor)
                                        t = _termFactory.Create(operation, ISlicerSymbol.Create(type, _typeArguments), staticProp, TermFactory.GetFreshName());
                                    else
                                    {
                                        t = recTerm.AddingField(new Field(hasGetAccesor ? TermFactory.GetFreshName() : ((IPropertySymbol)localSymbolInfo).Name, ISlicerSymbol.Create(type)));
                                        t.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
                                    }
                                }

                                if (hasGetAccesor)
                                    HandleInstrumentedMethod(operation, t, null, staticProp ? null : recTerm, typesDictionary);

                                var Model = _semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)operation.Syntax);
                                if (/*(!forSet) &&*/ !((operation.Syntax.Parent is AssignmentExpressionSyntax &&
                                    ((AssignmentExpressionSyntax)operation.Syntax.Parent).Left == operation.Syntax &&
                                    ((AssignmentExpressionSyntax)operation.Syntax.Parent).OperatorToken.Kind() == SyntaxKind.EqualsToken) ||
                                    //(operation.Syntax.Parent is MemberAccessExpressionSyntax // Structs
                                    //&& (Model.GetTypeInfo(((MemberAccessExpressionSyntax)operation.Syntax.Parent).Expression).Type).CustomIsStruct()) ||
                                    (operation.Syntax.Parent is ArgumentSyntax && ((ArgumentSyntax)operation.Syntax.Parent).RefOrOutKeyword.Value != null)))
                                {
                                    var nextStmt = ObserveNextStatement();
                                    if (t.Count == 1)
                                        GetNextStatement(TraceType.EndMemberAccess, false); // Siempre false
                                    else
                                    {
                                        var returnTerms = WaitForEnd(t.Stmt.CSharpSyntaxNode, new List<Term>() { t }, ((IPropertySymbol)localSymbolInfo).GetMethod, null, TraceType.EndMemberAccess);
                                        if (returnTerms.Count > 0)
                                            throw new NotImplementedException();

                                        if (!Globals.properties_as_fields)
                                            _broker.HandleNonInstrumentedMethod(new List<Term>(), t.IsGlobal ? null : t.DiscardLast(), returnTerms, t, ((IPropertySymbol)localSymbolInfo).GetMethod);
                                    }
                                }
                            }
                            else if (localSymbolInfo is IFieldSymbol)
                            {
                                //if (!((IFieldSymbol)localSymbolInfo).IsStatic)
                                //    Console.WriteLine("Field no estático: " + syntaxNode.ToString());
                                var type = ((IFieldSymbol)localSymbolInfo).Type;
                                t = _termFactory.Create(syntaxNode, ISlicerSymbol.Create(type, _typeArguments), true, syntaxNode.ToString(), false);
                            }
                            else
                                t = _termFactory.Create(syntaxNode, ISlicerSymbol.CreateObjectSymbol(), true, syntaxNode.ToString(), false);
                            #endregion
                        }
                        else
                        {
                            // Intentemos que sea una property y veamos que podemos hacer
                            //t = _termFactory.Create(syntaxNode, ISlicerSymbol.CreateObjectSymbol(), true, syntaxNode.ToString(), false);

                            Term recTerm = Visit(GetOperation(((MemberAccessExpressionSyntax)syntaxNode).Expression));
                            IDictionary<ITypeSymbol, ITypeSymbol> typesDictionary = null;
                            bool isSetAccessor;
                            var hasGetAccesor = HasAccesor(((MemberAccessExpressionSyntax)syntaxNode).Name.Identifier.ValueText, typesDictionary, out isSetAccessor) && !isSetAccessor;

                            // TODO: Vamos a suponer que es false...
                            var staticProp = recTerm.IsGlobal;
                            //var type = ((IPropertySymbol)localSymbolInfo).Type;
                            if (staticProp)
                            {
                                throw new SlicerException("Funcionalidad no implementada: member access con globals");
                                //t = _termFactory.Create(syntaxNode, ISlicerSymbol.Create(type, _typeArguments), staticProp,
                                //    hasGetAccesor ? TermFactory.GetFreshName() : Utils.GetRealName(((IPropertySymbol)localSymbolInfo).Name, _typeArguments));
                                //typesDictionary = Utils.GetTypesDictionary(((IPropertySymbol)localSymbolInfo).ContainingType, _typeArguments);
                            }
                            else
                            {

                                if (recTerm.IsScalar)
                                    throw new NotImplementedException();

                                if (hasGetAccesor)
                                    t = _termFactory.Create(operation, ISlicerSymbol.CreateObjectSymbol(), staticProp, TermFactory.GetFreshName());
                                else
                                {
                                    t = recTerm.AddingField(new Field(hasGetAccesor ? TermFactory.GetFreshName() : ((MemberAccessExpressionSyntax)syntaxNode).Name.Identifier.ValueText, ISlicerSymbol.CreateObjectSymbol()));
                                    t.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
                                }
                            }

                            if (hasGetAccesor)
                                HandleInstrumentedMethod(operation, t, null, staticProp ? null : recTerm, typesDictionary);

                            var Model = _semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)operation.Syntax);
                            if (/*(!forSet) &&*/ !((operation.Syntax.Parent is AssignmentExpressionSyntax &&
                                ((AssignmentExpressionSyntax)operation.Syntax.Parent).Left == operation.Syntax &&
                                ((AssignmentExpressionSyntax)operation.Syntax.Parent).OperatorToken.Kind() == SyntaxKind.EqualsToken) ||
                                //(operation.Syntax.Parent is MemberAccessExpressionSyntax // Structs
                                //&& (Model.GetTypeInfo(((MemberAccessExpressionSyntax)operation.Syntax.Parent).Expression).Type).CustomIsStruct()) ||
                                (operation.Syntax.Parent is ArgumentSyntax && ((ArgumentSyntax)operation.Syntax.Parent).RefOrOutKeyword.Value != null)))
                            {
                                var nextStmt = ObserveNextStatement();
                                if (t.Count == 1)
                                    GetNextStatement(TraceType.EndMemberAccess, false); // Siempre false
                                else
                                {
                                    var returnTerms = WaitForEnd(t.Stmt.CSharpSyntaxNode, new List<Term>() { t }, null, null, TraceType.EndMemberAccess);
                                    if (returnTerms.Count > 0)
                                        throw new NotImplementedException();

                                    // TODO: Si no se tratan las propiedades como fields se hace algo, pero no sabemos si es property...
                                    //if (!Globals.properties_as_fields)
                                    //    _broker.HandleNonInstrumentedMethod(new List<Term>(), t.IsGlobal ? null : t.DiscardLast(), returnTerms, t, ((IPropertySymbol)localSymbolInfo).GetMethod);
                                }
                            }
                        }
                    }

                    return t;
                #endregion
                case SyntaxKind.ObjectCreationExpression:
                    #region ObjectCreation

                    var objectCreationSyntax = (ObjectCreationExpressionSyntax)syntaxNode;
                    var symbolInfoObj = Utils.GetMethodSymbolInfo(model, objectCreationSyntax);
                    if (symbolInfoObj == null)
                        BugLogging.Log(_originalStatement.FileId, syntaxNode, BugLogging.Behavior.WithoutSymbol);
                    else
                        BugLogging.Log(_originalStatement.FileId, syntaxNode, BugLogging.Behavior.WithoutIOperation);

                    var args = objectCreationSyntax.ArgumentList.Arguments
                                         .Select(x => CreateArgument(x))
                                         .Where(x => x != null)
                                         .ToList();


                    var newScalar = symbolInfoObj != null && !symbolInfoObj.ReceiverType.IsNotScalar();
                    // XXX: Constructor de Struct sin parametros no ejecuta codigo, debe venir EndInvocation. Opción 2: es new string()
                    var noExecution = symbolInfoObj != null && (symbolInfoObj.ReceiverType.CustomIsStruct() && args.Count == 0) || newScalar;
                    var isInstrumented = symbolInfoObj != null && IsInstrumented(symbolInfoObj.ReceiverType.Name, null, false);
                    var newTermObj = _termFactory.Create(operation, symbolInfoObj != null ? ISlicerSymbol.Create(symbolInfoObj.ReceiverType, null) : ISlicerSymbol.CreateObjectSymbol(), false, TermFactory.GetFreshName());

                    if (newScalar)
                    {
                        _broker.DefUseOperation(newTermObj, args.ToArray());
                        GetNextStatement(TraceType.EndInvocation, false);
                    }
                    else
                    {
                        if (isInstrumented || noExecution)
                        {
                            _broker.Alloc(newTermObj);
                            _broker.DefUseOperation(newTermObj);
                        }

                        if (isInstrumented)
                            HandleInstrumentedMethod(operation, null, args, newTermObj, null);

                        if (!isInstrumented && !noExecution)
                            HandleNonInstrumentedMethod(operation, args, null, newTermObj, symbolInfoObj?.ReceiverType);

                        if (isInstrumented || noExecution)
                        {
                            GetNextStatement(TraceType.EndInvocation, false);
                            if (symbolInfoObj.ReceiverType.CustomIsStruct() && args.Count() == 0)
                            {
                                var m = symbolInfoObj.ReceiverType.GetMembers().Where(x => (x is IFieldSymbol || x is IPropertySymbol) && !x.IsStatic).ToList();
                                foreach (var n in m)
                                {

                                    var tTerm = newTermObj.AddingField(new Field(n.Name, ISlicerSymbol.Create((n is IFieldSymbol) ? ((IFieldSymbol)n).Type : ((IPropertySymbol)n).Type, _typeArguments)));
                                    tTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
                                    _broker.DefUseOperation(tTerm);
                                }
                            }
                        }


                    }

                    return newTermObj;

                #endregion
                case SyntaxKind.StackAllocArrayCreationExpression:
                    #region StackAllocArrayCreation
                    var stackAllocSyntaxNode = (StackAllocArrayCreationExpressionSyntax)syntaxNode;

                    //Console.WriteLine(invocationSyntaxNode.ToString() + "&" + _originalStatement.FileId + "&" + invocationSyntaxNode.SpanStart + "&" + invocationSyntaxNode.Span.End);

                    var typeInfoSA = model.GetTypeInfo(stackAllocSyntaxNode).Type;

                    BugLogging.Log(_originalStatement.FileId, syntaxNode, BugLogging.Behavior.WithoutIOperation);

                    var argsSA = ((ArrayRankSpecifierSyntax)(((ArrayTypeSyntax)((StackAllocArrayCreationExpressionSyntax)syntaxNode).Type).RankSpecifiers).FirstOrDefault()).Sizes
                                         .Select(x => Visit(GetOperation(x)))
                                         .Where(x => x != null)
                                         .ToList();

                    var returnTypeSA = ISlicerSymbol.Create(typeInfoSA, _typeArguments);
                    var newTermSA = _termFactory.Create(operation, returnTypeSA, false, TermFactory.GetFreshName());
                    HandleNonInstrumentedMethod(operation, argsSA, null, newTermSA, typeInfoSA, ".ctor");
                    return newTermSA;
                #endregion
                case SyntaxKind.FixedStatement:
                    #region FixedStatement
                    Visit(GetOperation(((FixedStatementSyntax)operation.Syntax).Declaration));
                    #endregion
                    break;
                case SyntaxKind.AddressOfExpression:
                    #region AddressOfExpression
                    // TODO XXX This expression is not well resolved since external method can "write" on memory addresses
                    var recTermAE = Visit(GetOperation(((PrefixUnaryExpressionSyntax)operation.Syntax).Operand));
                    var typeInfoAE = model.GetTypeInfo((PrefixUnaryExpressionSyntax)operation.Syntax).Type;
                    var returnTypeAE = ISlicerSymbol.Create(typeInfoAE, _typeArguments);
                    var newTermAE = _termFactory.Create(((PrefixUnaryExpressionSyntax)operation.Syntax), returnTypeAE, false, TermFactory.GetFreshName());
                    _broker.DefUseOperation(newTermAE, new Term[] { recTermAE });
                    return newTermAE;
                #endregion
                case SyntaxKind.IdentifierName:
                    return new Term(syntaxNode.ToString(), ISlicerSymbol.CreateObjectSymbol());
                default:
                    throw new NotImplementedException();
            }

            return null;
        }
        #endregion

        #region Declaraciones y asignaciones
        void VisitVariableDeclarationStatement(IVariableDeclarationGroupOperation operation)
        {
            foreach (var v in operation.Declarations)
                Visit(v);
        }

        void VisitVariableDeclaration(IVariableDeclarationOperation operation)
        {
            foreach (var d in operation.Declarators)
                Visit(d);
        }

        void VisitVariableDeclarator(IVariableDeclaratorOperation operation)
        {
            var use = Visit(operation.Initializer);
            var def = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Symbol.Type), false, ((ILocalSymbol)operation.Symbol).Name, false);

            // Special case, structs don't need an implicit initializer
            if (use == null && operation.Symbol.Type.CustomIsStruct())
            {
                _broker.Alloc(def);
                _broker.DefUseOperation(def);

                var m = operation.Symbol.Type.GetMembers()
                    .Where(x => (x is IFieldSymbol || x is IPropertySymbol) && !x.IsStatic).ToList();
                foreach (var n in m)
                {
                    var tTerm = def.AddingField(new Field(n.Name, ISlicerSymbol.Create((n is IFieldSymbol) ? ((IFieldSymbol)n).Type : ((IPropertySymbol)n).Type, _typeArguments)));
                    tTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
                    _broker.DefUseOperation(tTerm);
                }
            }
            else
                _broker.Assign(def, use);
        }

        Term VisitDeclarationExpression(IDeclarationExpressionOperation operation)
        {
            var def = Visit(operation.Expression);
            _broker.DefUseOperation(def);
            return def;
        }

        Term VisitIncrementExpression(IIncrementOrDecrementOperation operation)
        {
            Term def = null;
            List<Term> dependentTerms = new List<Term>();
            if (operation.Target is IArrayElementReferenceOperation)
            {
                var t = VisitArrayElementReferenceExpression((IArrayElementReferenceOperation)operation.Target, true);
                def = t.Item1;
                dependentTerms = t.Item2;
            }
            else if (operation.Target is IPropertyReferenceOperation && ((IPropertyReferenceOperation)operation.Target).IsIndexer())
            {
                var t = VisitIndexedPropertyReferenceExpression((IPropertyReferenceOperation)operation.Target, true);
                def = t.Item1;
                dependentTerms = t.Item2;
            }
            else
                def = Visit(operation.Target);

            // OVERRIDE DEL OPERADOR --/++
            var tmp = _traceConsumer.ObserveNextStatement();
            if (tmp.TraceType == TraceType.EnterStaticMethod &&
                tmp.CSharpSyntaxNode is OperatorDeclarationSyntax &&
                ((((OperatorDeclarationSyntax)tmp.CSharpSyntaxNode).OperatorToken.ValueText.Equals("++")) ||
                (((OperatorDeclarationSyntax)tmp.CSharpSyntaxNode).OperatorToken.ValueText.Equals("--"))))
            {
                // Como es estático esto va como parámetro, no como "this"
                // TODO: Hacer el no estático (si existe...)
                var returnTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type), false, TermFactory.GetFreshName());
                HandleInstrumentedMethod(operation, returnTerm, new List<Term> { def }, null);
                return returnTerm;
            }
            else
            {
                if (operation.Target is IPropertyReferenceOperation && !operation.Target.IsInSource())
                    CheckForSetCallbacks(def, def, dependentTerms, ((IPropertyReferenceOperation)operation.Target).Property);
                dependentTerms.Add(def);
                _broker.DefUseOperation(def, dependentTerms.ToArray());
                return def;
            }
        }

        Term VisitCompoundAssignmentExpression(ICompoundAssignmentOperation operation)
        {
            // TODO: El operador += con string y override del + creo que fallaría
            // NOTA IMPORTANTE: El funcionamiento es así (PROBADO):
            // 1: Se obtiene el objecto principal (el reciver del lado izquierdo)
            // 2: Se le hace GET a la property
            // 3: Se le hace SET a la property
            // ESO IMPLICA:
            // Si hacés A().B().myProperty += 1;
            // 1. SE EJECUTA A().B() ==> Esto lo estamos haciendo visitando el GET
            // 2. SE EJECUTA EL GET
            // 3. SE EJECUTA EL LADO DERECHO
            // 4. SE EJECUTA EL SET

            // ACÁ CONSUME TODO. INCLUSIVE CAPTURA EL GET SI LO TIENE! Ya que detecta que hay un get al leer la property!
            // POR OTRO LADO... Los posibles accessos o callbacks del GET necesitan un EndMemberAccess 
            // que se agregó antes de que ejecute el lado derecho lo consume el Visit de la property izquierda!
            // Quedó genial
            List<Term> dependentTerms = new List<Term>();
            Term def;
            Term set_receiver = null;
            if (operation.Target is IArrayElementReferenceOperation)
            {
                var t = VisitArrayElementReferenceExpression((IArrayElementReferenceOperation)operation.Target, true);
                def = t.Item1;
                dependentTerms = t.Item2;
            }
            else if (operation.Target is IPropertyReferenceOperation && ((IPropertyReferenceOperation)operation.Target).IsIndexer())
            {
                var t = VisitIndexedPropertyReferenceExpression((IPropertyReferenceOperation)operation.Target, true);
                def = t.Item1;
                dependentTerms = t.Item2;
            }
            else if (operation.Target is IPropertyReferenceOperation)
            {
                var temp = VisitPropertyReferenceExpression((IPropertyReferenceOperation)operation.Target, false);
                set_receiver = temp.Item1;
                def = temp.Item2;
            }
            else
                def = Visit(operation.Target);
            var use = Visit(operation.Value);

            var binaryResult = _termFactory.Create(operation, def.Last.Symbol);
            if (!binaryResult.IsScalar)
                _broker.Alloc(binaryResult);
            _broker.DefUseOperation(binaryResult, new Term[] { def, use });

            bool isSetAssignment;
            if (operation.Target is IPropertyReferenceOperation &&
                HasAccesor(((IPropertyReferenceOperation)operation.Target).Property.Name, null, out isSetAssignment))
            {
                Term @this = null;
                List<Term> arguments = null;
                if (((IPropertyReferenceOperation)operation.Target).IsIndexer())
                {
                    @this = Visit(((IPropertyReferenceOperation)operation.Target).Instance);
                    var args = ((IPropertyReferenceOperation)operation.Target).Arguments;
                    arguments = new List<Term>();
                    foreach (var arg in args)
                        arguments.Add(Visit(arg));
                    if (binaryResult != null)
                        arguments.Add(binaryResult);
                }
                else
                {
                    @this = set_receiver;
                    arguments = binaryResult != null ? new List<Term>() { binaryResult } : null;
                }

                HandleInstrumentedMethod(operation, null, arguments, @this);
            }
            else
            {
                if (operation.Target is IPropertyReferenceOperation && !operation.Target.IsInSource())
                    CheckForSetCallbacks(def, use, dependentTerms, ((IPropertyReferenceOperation)operation.Target).Property);

                _broker.Assign(def, binaryResult, dependentTerms);
            }

            return use;
        }

        Term VisitAssignmentExpression(IAssignmentOperation operation)
        {
            Term def = null;
            List<Term> dependentTerms = new List<Term>();
            if (operation.Target is IArrayElementReferenceOperation)
            {
                var t = VisitArrayElementReferenceExpression((IArrayElementReferenceOperation)operation.Target, true);
                def = t.Item1;
                dependentTerms = t.Item2;
            }
            else if (operation.Target is IPropertyReferenceOperation && ((IPropertyReferenceOperation)operation.Target).IsIndexer())
            {
                var t = VisitIndexedPropertyReferenceExpression((IPropertyReferenceOperation)operation.Target, true);
                def = t.Item1;
                dependentTerms = t.Item2;
            }
            else if (operation.Target is IPropertyReferenceOperation)
            {
                def = VisitPropertyReferenceExpression((IPropertyReferenceOperation)operation.Target, true).Item2;
            }
            else
                def = Visit(operation.Target);

            var use = Visit(operation.Value);
            bool isSetAssignment;
            if (operation.Target is IPropertyReferenceOperation &&
                HasAccesor(((IPropertyReferenceOperation)operation.Target).Property.Name, null, out isSetAssignment) && isSetAssignment)
            {
                Term @this = null;
                List<Term> arguments = null;
                if (((IPropertyReferenceOperation)operation.Target).IsIndexer())
                {
                    @this = Visit(((IPropertyReferenceOperation)operation.Target).Instance);
                    var args = ((IPropertyReferenceOperation)operation.Target).Arguments;
                    arguments = new List<Term>();
                    foreach (var arg in args)
                        arguments.Add(Visit(arg));
                    if (use != null)
                        arguments.Add(use);
                }
                else
                {
                    @this = ((IPropertyReferenceOperation)operation.Target).Property.IsStatic ? null : def.DiscardLast();
                    arguments = use != null ? new List<Term>() { use } : null;
                }

                HandleInstrumentedMethod(operation, null, arguments, @this);
            }
            else
            {
                if ((operation.Target is IPropertyReferenceOperation && !operation.Target.IsInSource())
                    || (operation.Target is IPropertyReferenceOperation && ((IPropertyReferenceOperation)operation.Target).IsIndexer()))
                    CheckForSetCallbacks(def, use, dependentTerms, ((IPropertyReferenceOperation)operation.Target).Property);

                ISymbol _paramSymbol = null;
                var methodName = "";
                if (operation.Target is IPropertyReferenceOperation)
                    _paramSymbol = ((IPropertyReferenceOperation)operation.Target).Property;
                if (operation.Target is IFieldReferenceOperation)
                    _paramSymbol = ((IFieldReferenceOperation)operation.Target).Field;

                if (!Globals.properties_as_fields && (operation.Target is IPropertyReferenceOperation && ((IPropertyReferenceOperation)operation.Target).IsIndexer()))
                    _broker.HandleNonInstrumentedMethod(dependentTerms, def, new List<Term>(), null, ((IPropertySymbol)_paramSymbol).SetMethod, methodName);
                else if (def != null)
                    _broker.Assign(def, use, dependentTerms);
            }
            // Los Assignment retornan el def.
            return use;
        }

        Term VisitDeconstructionAssignmentExpression(IDeconstructionAssignmentOperation operation)
        {
            var recTerm = Visit(operation.Value);
            var i = 0;
            var elements = operation.Target is ITupleOperation ?
                ((ITupleOperation)operation.Target).Elements :
                ((ITupleOperation)((IDeclarationExpressionOperation)operation.Target).Expression).Elements;
            foreach (var e in elements)
            {
                var leftTerm = Visit(e);
                var tempTerm = recTerm.AddingField("x" + i, ISlicerSymbol.Create(e.Type, _typeArguments));
                _broker.Assign(leftTerm, tempTerm);
            }
            return recTerm;
        }
        #endregion

        #region Funciones y creaciones de objetos
        Term VisitUnaryOperatorExpression(IUnaryOperation operation)
        {
            Term newTerm = Visit(operation.Operand);
            // Operator overloading
            if (_traceConsumer.HasNext() &&
                ObserveNextStatement().TraceType == TraceType.EnterStaticMethod &&
                (ObserveNextStatement().CSharpSyntaxNode is OperatorDeclarationSyntax))
            {
                var declToken = ((OperatorDeclarationSyntax)ObserveNextStatement().CSharpSyntaxNode).OperatorToken.ValueText;
                string opToken = null;
                if (operation.Syntax is PrefixUnaryExpressionSyntax)
                    opToken = ((PrefixUnaryExpressionSyntax)operation.Syntax).OperatorToken.ValueText;
                else if (operation.Syntax is PostfixUnaryExpressionSyntax)
                    opToken = ((PostfixUnaryExpressionSyntax)operation.Syntax).OperatorToken.ValueText;
                else
                    throw new InvalidOperationException();

                if (declToken.Equals(opToken))
                {
                    var useTerms = new List<Term>();
                    useTerms.Add(newTerm);
                    newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type), false, TermFactory.GetFreshName());
                    HandleInstrumentedMethod(operation, newTerm, useTerms, null);
                }
            }

            return newTerm;
        }

        Term VisitBinaryOperatorExpression(IBinaryOperation operation)
        {
            Term recTermLeft = Visit(operation.LeftOperand);
            if ((Utils.IOperationStringBinaries.Contains(operation.OperatorKind)) &&
                (operation.LeftOperand.Type != null && operation.LeftOperand.Type.Name != "String") &&
                (operation.RightOperand.Type != null && operation.RightOperand.Type.Name == "String"))
            {
                var tmp = ObserveNextStatement();
                if (tmp.TraceType == TraceType.EndInvocation)
                    GetNextStatement(TraceType.EndInvocation);
                else if ((tmp.TraceType == TraceType.EnterMethod) &&
                        (((MethodDeclarationSyntax)tmp.CSharpSyntaxNode).Identifier.ValueText.Equals("ToString")))
                {
                    var returnTerm = _termFactory.Create(operation.LeftOperand,
                        ISlicerSymbol.Create(operation.Type), false, TermFactory.GetFreshName());
                    HandleInstrumentedMethod(operation.LeftOperand, returnTerm, null, recTermLeft);
                    recTermLeft = returnTerm;
                    GetNextStatement(TraceType.EndInvocation);
                }
                // TODO: ES CALLBACK
                else
                    throw new SlicerException("Funcionalidad no implementada");
            }

            Term recTermRight = null;

            if (Utils.ShortcircuitsBinaries.Contains(((BinaryExpressionSyntax)operation.Syntax).Kind()) &&
               (ObserveNextStatement().TraceType == TraceType.EnterExpression) &&
               (ObserveNextStatement().CSharpSyntaxNode.FullSpan == operation.Syntax.FullSpan))
            {
                GetNextStatement(TraceType.EnterExpression);
                recTermRight = Visit(operation.RightOperand);
            }
            else if (!Utils.ShortcircuitsBinaries.Contains(((BinaryExpressionSyntax)operation.Syntax).Kind()))
                recTermRight = Visit(operation.RightOperand);

            if ((Utils.IOperationStringBinaries.Contains(operation.OperatorKind))
                && (operation.RightOperand.Type != null && operation.RightOperand.Type.Name != "String") &&
                (operation.LeftOperand.Type != null && operation.LeftOperand.Type.Name == "String"))
            {
                var tmp = _traceConsumer.ObserveNextStatement();
                if (tmp.TraceType == TraceType.EndInvocation)
                    GetNextStatement(TraceType.EndInvocation);
                else if ((tmp.TraceType == TraceType.EnterMethod) &&
                (((MethodDeclarationSyntax)tmp.CSharpSyntaxNode).Identifier.ValueText.Equals("ToString")))
                {
                    var returnTerm = _termFactory.Create(operation.RightOperand,
                        ISlicerSymbol.Create(operation.Type), false, TermFactory.GetFreshName());
                    HandleInstrumentedMethod(operation.RightOperand, returnTerm, null, recTermRight);
                    recTermRight = returnTerm;
                    GetNextStatement(TraceType.EndInvocation);
                }
                // TODO: ES CALLBACK
                else
                {
                    //throw new SlicerException("Funcionalidad no implementada");
                    WaitForEnd((CSharpSyntaxNode)operation.RightOperand.Syntax, new List<Term>() { recTermLeft, recTermRight }, operation.RightOperand.Type, "WeirdCall", TraceType.EndInvocation, true);
                }
            }

            var useTerms = new List<Term>();
            if (recTermLeft != null)
                useTerms.Add(recTermLeft);
            if (recTermRight != null)
                useTerms.Add(recTermRight);

            var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type), false, TermFactory.GetFreshName());

            // Operator overloading
            if (_traceConsumer.HasNext() &&
                ObserveNextStatement().TraceType == TraceType.EnterStaticMethod &&
                (ObserveNextStatement().CSharpSyntaxNode is OperatorDeclarationSyntax) &&
                ((OperatorDeclarationSyntax)ObserveNextStatement().CSharpSyntaxNode)
                    .OperatorToken.ValueText.Equals(((BinaryExpressionSyntax)operation.Syntax).OperatorToken.ValueText))
            {
                HandleInstrumentedMethod(operation, newTerm, useTerms, null);
                if (_traceConsumer.HasNext() && ObserveNextStatement().TraceType == TraceType.EndInvocation)
                    GetNextStatement(TraceType.EndInvocation);
            }
            // Pueden aplicarse operaciones binarias entre objetos y resultar en nuevos objetos, pero cuando es dynamic generalmente esto es bool
            // XXX: hasta ahora siempre fue así...
            else if (!newTerm.IsScalar && !newTerm.IsDynamic)
            {
                HandleNonInstrumentedMethod(operation, useTerms, null, newTerm, operation.OperatorMethod, ((BinaryExpressionSyntax)operation.Syntax).OperatorToken.ValueText);
                return newTerm;
            }

            _broker.DefUseOperation(newTerm, useTerms.ToArray());
            return newTerm;
        }

        Term VisitInvocationExpression(IInvocationOperation operation)
        {
            Term thisTerm = null;
            if (((IInvocationOperation)operation).Instance != null &&
                (((ITypeSymbol)((IInvocationOperation)operation).TargetMethod.ContainingSymbol)).TypeKind == TypeKind.Delegate &&
                ((IInvocationOperation)operation).Instance is IPropertyReferenceOperation)
                thisTerm = Visit(((IPropertyReferenceOperation)((IInvocationOperation)operation).Instance).Instance);
            else
                thisTerm = Visit(operation.Instance);

            if (operation.TargetMethod.MethodKind == MethodKind.LocalFunction &&
                !operation.TargetMethod.IsStatic &&
                thisTerm == null &&
                _thisObject != null)
                thisTerm = _termFactory.Create(operation, _thisObject.Last.Symbol, false, "this", false);

            List<Term> arguments = null;
            if (operation.Arguments.Length == operation.TargetMethod.Parameters.Length)
            {
                var argDict = new Dictionary<IArgumentOperation, Term>();
                foreach (var arg in operation.Arguments)
                {
                    var argTerm = CreateArgument(arg);
                    argDict.Add(arg, argTerm);
                }
                arguments = operation.TargetMethod.Parameters
                    .Select(x => argDict[operation.Arguments.Single(y => y.Parameter.Equals(x))]).ToList();
            }
            else
                // Default, as always, TODO: do the same with constructors, or not?
                arguments = operation.Arguments.Select(x => CreateArgument(x)).Where(x => x != null).ToList();


            var dictionary = Utils.GetTypesDictionary(operation.TargetMethod, _typeArguments);
            var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.TargetMethod.ReturnType, _typeArguments), false, TermFactory.GetFreshName());

            var isException = methodsExceptions.Any(x =>
                ((_originalStatement != null && x.Item1 == _originalStatement.FileId) || (_originalStatement == null && x.Item1 == _currentFileId)) &&
                x.Item2 <= operation.Syntax.Span.Start && x.Item3 >= operation.Syntax.Span.End);
            if (IsInstrumented(operation.TargetMethod.Name, dictionary, true, operation.TargetMethod.CustomStructReceiver(), null, arguments.Count, operation.TargetMethod.IsStatic) && !isException)
            {
                HandleInstrumentedMethod(operation, newTerm, arguments, operation.TargetMethod.IsStatic ? null : thisTerm, dictionary);
                if (Globals.wrap_structs_calls || !operation.TargetMethod.CustomStructReceiver())
                    GetNextStatement(TraceType.EndInvocation);
                if (operation.TargetMethod.ReturnsVoid)
                    _broker.DefUseOperation(newTerm);
            }
            else
                HandleNonInstrumentedMethod(operation, arguments, thisTerm, newTerm, operation.TargetMethod, null, operation.Syntax);
            return newTerm;
        }

        Term VisitObjectCreationExpression(IObjectCreationOperation operation)
        {
            var parameters = operation.Arguments.Select(x => CreateArgument(x)).Where(x => x != null).ToList();

            // Si hacés new string(char array) es un escalar, no hay que alocarlo... hay que tratarlo como un literal que usa lo que recibe
            var newScalar = !operation.Constructor.ReceiverType.IsNotScalar();
            // XXX: Constructor de Struct sin parametros no ejecuta codigo, debe venir EndInvocation. Opción 2: es new string()
            var noExecution = (operation.Type.CustomIsStruct() && operation.Arguments.Count() == 0) || newScalar;
            var dictionary = Utils.GetTypesDictionary(operation.Constructor, _typeArguments);
            var isInstrumented = IsInstrumented(operation.Constructor.ReceiverType.Name, dictionary, objectCreationOperation: operation);

            var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments), false, TermFactory.GetFreshName());

            if (newScalar)
            {
                _broker.DefUseOperation(newTerm, parameters.ToArray());
                GetNextStatement(TraceType.EndInvocation);
            }
            else
            {
                if (isInstrumented || noExecution)
                {
                    _broker.Alloc(newTerm);
                    _broker.DefUseOperation(newTerm);
                }

                var wellHandled = true;
                if (isInstrumented)
                    wellHandled = HandleInstrumentedMethod(operation, null, parameters, newTerm, dictionary);

                if (!isInstrumented && !noExecution)
                    HandleNonInstrumentedMethod(operation, parameters, null, newTerm, operation.Constructor, null, operation.Syntax);

                if (!wellHandled)
                    isInstrumented = false;

                if (isInstrumented || noExecution)
                {
                    GetNextStatement(TraceType.EndInvocation);
                    if (operation.Type.CustomIsStruct() && operation.Arguments.Count() == 0)
                    {
                        var m = operation.Type.GetMembers().Where(x => (x is IFieldSymbol || x is IPropertySymbol) && !x.IsStatic).ToList();
                        foreach (var n in m)
                        {

                            var tTerm = newTerm.AddingField(new Field(n.Name, ISlicerSymbol.Create((n is IFieldSymbol) ? ((IFieldSymbol)n).Type : ((IPropertySymbol)n).Type, _typeArguments)));
                            tTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
                            _broker.DefUseOperation(tTerm);
                        }
                    }
                }

                if (operation.Initializer != null)
                    foreach (var init in operation.Initializer.Initializers)
                    {
                        if (init.Kind == OperationKind.SimpleAssignment)
                        {
                            var use = Visit(((ISimpleAssignmentOperation)init).Value);
                            if (((ISimpleAssignmentOperation)init).Target.Kind == OperationKind.FieldReference)
                            {
                                var field = ((IFieldReferenceOperation)((ISimpleAssignmentOperation)init).Target).Field;
                                var def = _termFactory.Create(((ISimpleAssignmentOperation)init).Target, ISlicerSymbol.Create(field.Type), false, field.Name);
                                var completeTerm = newTerm.AddingField(def.ToString(), use.Last.Symbol);
                                completeTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)((ISimpleAssignmentOperation)init).Target.Syntax, _instrumentationResult);
                                _broker.Assign(completeTerm, use);
                            }
                            else if (((ISimpleAssignmentOperation)init).Target.Kind == OperationKind.PropertyReference)
                            {
                                var property = ((IPropertyReferenceOperation)((ISimpleAssignmentOperation)init).Target).Property;

                                bool isSetAssignment;
                                if (HasAccesor(property.Name, null, out isSetAssignment))
                                {
                                    if (!isSetAssignment)
                                        throw new Exception("Deberia ser setAssginment y no es!");
                                    HandleInstrumentedMethod(operation, null, use != null ? new List<Term>() { use } : null, newTerm);
                                }
                                else
                                {
                                    var def = _termFactory.Create(((ISimpleAssignmentOperation)init).Target, ISlicerSymbol.Create(property.Type), false, property.Name);
                                    var completeTerm = newTerm.AddingField(def.ToString(), use.Last.Symbol);
                                    completeTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)((ISimpleAssignmentOperation)init).Target.Syntax, _instrumentationResult);
                                    _broker.Assign(completeTerm, use);
                                }
                            }
                            else
                                throw new NotImplementedException();
                        }
                        else if (init.Kind == OperationKind.Invocation)
                        {
                            var initArgs = ((IInvocationOperation)init).Arguments.Select(x => Visit(x)).ToList();

                            if (IsInstrumented(((IInvocationOperation)init).TargetMethod.Name, dictionary, false))
                                HandleInstrumentedMethod(operation, null, initArgs, newTerm, dictionary);
                            else
                            {
                                var involvedTerms = new List<Term>(initArgs);
                                involvedTerms.Add(newTerm);
                                var returnedTerms = WaitForEnd((newTerm.Stmt.CSharpSyntaxNode), involvedTerms, ((IInvocationOperation)init).TargetMethod);
                                _broker.HandleNonInstrumentedMethod(initArgs, newTerm, returnedTerms, null, ((IInvocationOperation)init).TargetMethod);
                            }
                        }
                    }
            }

            return newTerm;
        }

        Term VisitAnonymousObjectCreationExpression(IAnonymousObjectCreationOperation operation)
        {
            var newTerm = _termFactory.Create(operation, ISlicerSymbol.CreateAnonymousSymbol(), false, TermFactory.GetFreshName());
            _broker.Alloc(newTerm);
            _broker.DefUseOperation(newTerm);

            foreach (var init in operation.Initializers)
            {
                if (init.Kind == OperationKind.SimpleAssignment)
                {
                    var use = Visit(((ISimpleAssignmentOperation)init).Value);
                    if (((ISimpleAssignmentOperation)init).Target.Kind == OperationKind.FieldReference)
                    {
                        var field = ((IFieldReferenceOperation)((ISimpleAssignmentOperation)init).Target).Field;
                        var def = _termFactory.Create(((ISimpleAssignmentOperation)init).Target, ISlicerSymbol.Create(field.Type), false, field.Name);
                        var completeTerm = newTerm.AddingField(def.ToString(), use.Last.Symbol);
                        completeTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)((ISimpleAssignmentOperation)init).Target.Syntax, _instrumentationResult);
                        _broker.Assign(completeTerm, use);
                    }
                    else if (((ISimpleAssignmentOperation)init).Target.Kind == OperationKind.PropertyReference)
                    {
                        var property = ((IPropertyReferenceOperation)((ISimpleAssignmentOperation)init).Target).Property;

                        bool isSetAssignment;
                        if (HasAccesor(property.Name, null, out isSetAssignment))
                        {
                            if (!isSetAssignment)
                                throw new Exception("Deberia ser setAssginment y no es!");
                            HandleInstrumentedMethod(operation, null, use != null ? new List<Term>() { use } : null, newTerm);
                        }
                        else
                        {
                            var def = _termFactory.Create(((ISimpleAssignmentOperation)init).Target, ISlicerSymbol.Create(property.Type), false, property.Name);
                            var completeTerm = newTerm.AddingField(def.ToString(), use.Last.Symbol);
                            completeTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)((ISimpleAssignmentOperation)init).Target.Syntax, _instrumentationResult);
                            _broker.Assign(completeTerm, use);
                        }
                    }
                    else
                        throw new NotImplementedException();
                }
                else
                    throw new NotImplementedException();
            }

            return newTerm;
        }

        private Term VisitTypeParameterObjectCreationExpression(ITypeParameterObjectCreationOperation operation)
        {
            var type = _typeArguments.Single(x => x.Key.TypeKind == TypeKind.TypeParameter && x.Key == operation.Type);
            var paramType = type.Value;
            var isScalar = !type.Value.IsNotScalar();
            var noExecution = operation.Type.CustomIsStruct() || isScalar;
            var isInstrumented = IsInstrumented(type.Value.Name);

            var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments), false, TermFactory.GetFreshName());

            if (isScalar)
            {
                _broker.DefUseOperation(newTerm);
                GetNextStatement(TraceType.EndInvocation);
            }
            else
            {
                _broker.Alloc(newTerm);
                _broker.DefUseOperation(newTerm);
                if (isInstrumented)
                    HandleInstrumentedMethod(operation, null, null, newTerm, _typeArguments);

                if (!isInstrumented && !noExecution)
                    HandleNonInstrumentedMethod((IOperation)null, null, newTerm, null, null);

                if (isInstrumented || noExecution)
                    GetNextStatement(TraceType.EndInvocation);
            }

            return newTerm;
        }
        #endregion

        #region Arrays
        Term VisitArrayCreationExpression(IArrayCreationOperation operation)
        {
            var uses = (operation.DimensionSizes != null) ? operation.DimensionSizes.Select(x => Visit(x)).ToList() : new List<Term>();

            var previousExpressions = new List<IOperation>();
            if (operation.Syntax is ArrayCreationExpressionSyntax && ((ArrayCreationExpressionSyntax)operation.Syntax).Initializer != null)
                previousExpressions.AddRange(((ArrayCreationExpressionSyntax)operation.Syntax).Initializer.Expressions.Select(x => GetOperation(x)).ToList());
            else if (operation.Syntax is ImplicitArrayCreationExpressionSyntax && ((ImplicitArrayCreationExpressionSyntax)operation.Syntax).Initializer != null)
                previousExpressions.AddRange(((ImplicitArrayCreationExpressionSyntax)operation.Syntax).Initializer.Expressions.Select(x => GetOperation(x)).ToList());
            // XXX: arrayCreationExpression.ElementValues.ArrayClass = Dimension
            // Se utiliza cuando tenemos params[]
            else if (operation.Initializer != null && operation.Initializer.ElementValues != null)
                operation.Initializer.ElementValues.ToList().ForEach(elementValue => previousExpressions.Add(elementValue));

            var dependentTerms = previousExpressions.Select(x => Visit(x)).ToList();

            var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type), false, TermFactory.GetFreshName());

            _broker.Alloc(newTerm);
            _broker.DefUseOperation(newTerm, uses.ToArray());

            var otherField = new Field(Field.SIGMA_FIELD);
            otherField.Symbol = ISlicerSymbol.Create(((IArrayTypeSymbol)newTerm.Parts[0].Symbol.Symbol).ElementType);
            var otherTerm = newTerm.AddingField(otherField);
            otherTerm.Stmt = newTerm.Stmt;
            _broker.DefUseOperation(otherTerm, new Term[] { newTerm });

            foreach (var dependentTerm in dependentTerms)
            {
                otherField = new Field(Field.SIGMA_FIELD);
                otherField.Symbol = ISlicerSymbol.Create(((IArrayTypeSymbol)newTerm.Parts[0].Symbol.Symbol).ElementType);

                var termToAssign = newTerm.AddingField(otherField);
                termToAssign.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
                _broker.Assign(termToAssign, dependentTerm);
            }

            return newTerm;
        }

        Term VisitArrayInitializer(IArrayInitializerOperation operation)
        {
            var dependentTerms = new List<Term>();
            if (operation.ElementValues != null)
                dependentTerms.AddRange(operation.ElementValues.ToList().Select(x => Visit(x)));

            var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Parent.Type ?? operation.Parent.Parent.Type), false, TermFactory.GetFreshName());

            // XXX: Revisar
            _broker.Alloc(newTerm);
            _broker.DefUseOperation(newTerm, new Term[] { });

            var otherField = new Field(Field.SIGMA_FIELD);
            if (dependentTerms.Count == 0)
            {
                // Igual definimos sigma
                otherField.Symbol = ISlicerSymbol.Create(((IArrayTypeSymbol)operation.Parent.Type).ElementType);
                var otherTerm = newTerm.AddingField(otherField);
                otherTerm.Stmt = newTerm.Stmt;
                _broker.DefUseOperation(otherTerm, new Term[] { newTerm });
            }
            else
            {
                foreach (var dependentTerm in dependentTerms)
                {
                    otherField.Symbol = ISlicerSymbol.Create(((IArrayTypeSymbol)(operation.Parent.Type ?? operation.Parent.Parent.Type)).ElementType);
                    var otherTerm = newTerm.AddingField(otherField);
                    otherTerm.Stmt = newTerm.Stmt;
                    _broker.Assign(otherTerm, dependentTerm);
                }
            }

            return newTerm;
        }

        Term VisitArrayElementReferenceExpression(IArrayElementReferenceOperation operation)
        {
            return VisitArrayElementReferenceExpression(operation, false).Item1;
        }

        Tuple<Term, List<Term>> VisitArrayElementReferenceExpression(IArrayElementReferenceOperation operation, bool forSet)
        {
            var recTerm = Visit(operation.ArrayReference);
            var dependentTerms = operation.Indices.Select(x => Visit(x)).ToList();

            //if (Globals.use_new_annotations)
            //{
            //    if (forSet)
            //        return new Tuple<Term, List<Term>>(recTerm, dependentTerms);
            //    else
            //    {
            //        var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments));
            //        _broker.HandleNonInstrumentedMethod(dependentTerms, recTerm, new List<Term>(), newTerm, operation.Type, "this");
            //        return new Tuple<Term, List<Term>>(newTerm, null);
            //    }
            //}
            //else
            //{
            // TODO: XXXX: Reemplazar por anotaciones y oftype...
            var newTerm = recTerm.AddingField(Field.SigmaField(ISlicerSymbol.Create(operation.Type)));
            newTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
            // Si es para SET debemos devolver lo que tiene que modificar... TODO: Si hubiera un HAVOC decente lo usaríamos :'(
            if (forSet)
                return new Tuple<Term, List<Term>>(newTerm, dependentTerms);
            else
            {
                var returnTerm = _termFactory.Create(operation, newTerm.Last.Symbol, false);
                _broker.Assign(returnTerm, newTerm, dependentTerms);
                return new Tuple<Term, List<Term>>(returnTerm, null);
            }
            //}
        }
        #endregion

        #region Visits de control
        Term VisitNullCoalescingExpression(ICoalesceOperation operation)
        {
            // XXX: Se tiene que devolver el término correcto
            Term recTermLeft = Visit(operation.Value);
            Term recTermRight = null;

            if (ObserveNextStatement().TraceType == TraceType.EnterExpression)
            {
                GetNextStatement(TraceType.EnterExpression);
                recTermRight = Visit(operation.WhenNull);
            }

            // Si el de la derecha es distinto de null devolvemos ese, sino el izquierdo
            var termToAssign = recTermRight ?? recTermLeft;
            var newTerm = _termFactory.Create(operation, termToAssign.Last.Symbol, false, TermFactory.GetFreshName());
            _broker.Assign(newTerm, termToAssign);

            // XXX: Si asignamos el término derecho hay que agregar el USE del izquierdo porque este término utilizó ese para crearse
            if (recTermRight != null)
                _broker.DefUseOperation(newTerm, new Term[] { newTerm, recTermLeft });

            return newTerm;
        }

        Term VisitCoalesceAssignmentOperation(ICoalesceAssignmentOperation operation)
        {
            var left = Visit(operation.Target);
            var nextStmt = ObserveNextStatement();
            if (nextStmt.TraceType == TraceType.EnterExpression &&
                nextStmt.FileId == _originalStatement.FileId &&
                nextStmt.SpanStart <= _originalStatement.SpanStart &&
                nextStmt.SpanEnd >= _originalStatement.SpanEnd)
            {
                GetNextStatement(TraceType.EnterExpression);
                // TODO: complete left side with callback prevention

                var right = Visit(operation.Value);
                _broker.Assign(left, right);
            }
            return left;
        }

        Term VisitConditionalChoiceExpression(IConditionalOperation operation)
        {
            // 1) Leer la condición
            var conditionStmt = GetNextStatement(TraceType.SimpleStatement);
            var internalTerm = Visit(operation.Condition);
            _broker.UseOperation(
                Utils.StmtFromSyntaxNode(conditionStmt.CSharpSyntaxNode, _instrumentationResult),
                new List<Term>() { internalTerm });

            // 2) Leer la entrada
            var enterConditionStmt = conditionStmt;
            var enterConditionSyntaxNode = Utils.StmtFromSyntaxNode(enterConditionStmt.CSharpSyntaxNode, _instrumentationResult);
            _broker.EnterCondition(enterConditionSyntaxNode);
            // 3) Leer la instrucción
            var instructionStmt = GetNextStatement(TraceType.SimpleStatement);
            var recTerm = Visit(GetOperation((instructionStmt.CSharpSyntaxNode)));

            Term[] uses = new Term[] { recTerm };
            _broker.DefUseOperation(recTerm, uses);

            // 4) Exit
            _broker.ExitCondition(enterConditionSyntaxNode);

            return recTerm;
        }

        void VisitIfStatement(IConditionalOperation operation)
        {
            var internalTerm = Visit(operation.Condition);
            _broker.UseOperation(_originalStatement, new List<Term>() { internalTerm });
        }

        void VisitWhileUntilLoopStatement(IWhileLoopOperation operation)
        {
            var internalTerm = Visit(operation.Condition);
            _broker.UseOperation(_originalStatement, internalTerm != null ? new List<Term>() { internalTerm } : new List<Term>());
        }

        void VisitForOperation(IForLoopOperation operation)
        {
            var internalTerm = Visit(operation.Condition);
            _broker.UseOperation(_originalStatement, internalTerm != null ? new List<Term>() { internalTerm } : new List<Term>());
        }

        void VisitForEachLoopStatement(IForEachLoopOperation operation)
        {
            var term = Visit(operation.Collection);

            // TODO: Fallaría el override del GetEnumerator
            // Llamada implícita al GetEnumerator. Puede ser propia o no. TODO: Por ahora es solo externa
            // XXX: Si ahora cae una invocación, suponemos que es por el GetEnumerable de la collection
            Term returnHub = null;
            var returnedValues = WaitForEnd((CSharpSyntaxNode)operation.Collection.Syntax, new List<Term>() { term }, operation.Collection.Type, "GetEnumerator", TraceType.EndInvocation, true);

            IMethodSymbol methodSymbol = null;
            if (operation.Collection.Type.Name != "IEnumerable")
            {
                var typeSymbol = operation.Collection.Type.AllInterfaces.Where(x => x.Name.Contains("IEnumerable")).FirstOrDefault();
                if (typeSymbol != null)
                    methodSymbol = (IMethodSymbol)(typeSymbol.GetMembers().First());
                else
                    methodSymbol = (IMethodSymbol)((INamedTypeSymbol)operation.Collection.Type).GetMembers().First(x => x.Name == "GetEnumerator");
            }
            else
                methodSymbol = (IMethodSymbol)(operation.Collection.Type.GetMembers().First());

            returnHub = _termFactory.Create(operation.Collection,
            ISlicerSymbol.Create(methodSymbol.ReturnType, _typeArguments), false, TermFactory.GetFreshName(), false);

            _broker.CustomEvent(new List<Term>(), term, returnedValues, returnHub, "ForeachGetEnumerator");

            // Porque puede existir: porque hay un foreach dentro de otro foreach, entonces ya existe la clave del foreach de la iteración anterior y la reemplaza
            if (_foreachHubsDictionary.ContainsKey((CSharpSyntaxNode)operation.Syntax))
                _foreachHubsDictionary[(CSharpSyntaxNode)operation.Syntax] = returnHub;
            else
                _foreachHubsDictionary.Add((CSharpSyntaxNode)operation.Syntax, returnHub);
            CheckForMoveNextCallbacks(operation);
        }

        void VisitSwitchStatement(ISwitchOperation operation)
        {
            var recTerm = Visit(operation.Value);
            temporarySwitchTerm = recTerm;
            _broker.UseOperation(_originalStatement, new List<Term>() { recTerm });

            var nextStmt = ObserveNextStatement();
            if (nextStmt.TraceType == TraceType.EnterMethod && nextStmt.CSharpSyntaxNode.GetContainer().GetName().Equals("Deconstruct"))
            {
                var currentSymbol = (IMethodSymbol)_semanticModelsContainer.GetBySyntaxNode(nextStmt.CSharpSyntaxNode)
                    .GetDeclaredSymbol((nextStmt.CSharpSyntaxNode is ArrowExpressionClauseSyntax) ? nextStmt.CSharpSyntaxNode.Parent : nextStmt.CSharpSyntaxNode);
                var paramTerms = new List<Term>();
                foreach (var p in currentSymbol.Parameters)
                {
                    var tp = _termFactory.Create(operation, ISlicerSymbol.Create(p.Type));
                    tp.IsOutOrRef = p.RefKind == RefKind.Out || p.RefKind == RefKind.Ref;
                    tp.ReferencedTerm = tp;
                    _broker.DefUseOperation(tp);
                    paramTerms.Add(tp);
                }


                if (HandleInstrumentedMethod(operation, null, paramTerms, recTerm, _typeArguments))
                {
                    var enterConditionStmt = ObserveNextStatement();
                    if (enterConditionStmt.TraceType == TraceType.EnterCondition)
                    {
                        EnterCondition(_originalStatement);
                        GetNextStatement();
                        var firstStmt = ObserveNextStatement();
                        var switchSectionSyntax = firstStmt.CSharpSyntaxNode.GetCaseContainer();
                        if (((SwitchSectionSyntax)switchSectionSyntax).Labels.First() is CasePatternSwitchLabelSyntax casePatternSwitchLabelSyntax &&
                            casePatternSwitchLabelSyntax.Pattern is RecursivePatternSyntax recursivePatternSyntax)
                        {
                            var tempSubpatterns = recursivePatternSyntax.PositionalPatternClause.Subpatterns.ToList();
                            var i = 0;
                            foreach (var subpattern in tempSubpatterns)
                            {
                                var name = ((SingleVariableDesignationSyntax)((DeclarationPatternSyntax)subpattern.Pattern).Designation).Identifier.ValueText;
                                var declaringTerm = _termFactory.Create(subpattern.Pattern, paramTerms[i].Last.Symbol, false, name, false);
                                _broker.Assign(declaringTerm, paramTerms[i++]);
                            }
                        }
                    }
                    else
                        throw new NotImplementedException();
                }
            }

            try
            {
                foreach (var p in operation.Cases)
                    Visit(p);
            }
            catch (EnterSwitchException ex)
            {
                ;
            }
        }

        Term VisitSwitchExpression(ISwitchExpressionOperation operation)
        {
            Term retTerm = null;
            var valueTerm = Visit(operation.Value);
            // TODO: temporarySwitchTerm = valueTerm;

            var switchStmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, this._instrumentationResult);
            _broker.UseOperation(switchStmt, new List<Term>() { valueTerm });

            var nextStmt = ObserveNextStatement();
            while (nextStmt.CSharpSyntaxNode is WhenClauseSyntax ||
                nextStmt.CSharpSyntaxNode is SwitchExpressionArmSyntax)
            {
                GetNextStatement();

                if (nextStmt.CSharpSyntaxNode is WhenClauseSyntax)
                {
                    var conditionOp = GetOperation(((WhenClauseSyntax)nextStmt.CSharpSyntaxNode).Condition);
                    var conditionTerm = Visit(conditionOp);

                    nextStmt = ObserveNextStatement();
                    if (nextStmt.TraceType == TraceType.EnterExpression)
                    {
                        GetNextStatement();

                        var whenStmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)nextStmt.CSharpSyntaxNode, this._instrumentationResult);
                        _broker.UseOperation(whenStmt, new List<Term>() { conditionTerm });
                        EnterCondition(switchStmt);
                        EnterCondition(whenStmt);

                        var expOp = GetOperation(((SwitchExpressionArmSyntax)(((WhenClauseSyntax)nextStmt.CSharpSyntaxNode).Parent)).Expression);
                        retTerm = Visit(expOp);

                        ExitCondition(whenStmt);
                        ExitCondition(switchStmt);
                        nextStmt = ObserveNextStatement();
                    }
                }
                else if (nextStmt.CSharpSyntaxNode is SwitchExpressionArmSyntax)
                {
                    nextStmt = ObserveNextStatement();
                    if (nextStmt.TraceType == TraceType.EnterExpression)
                    {
                        var armOp = GetOperation(nextStmt.CSharpSyntaxNode);
                        if (armOp is ISwitchExpressionArmOperation switchExpOp && switchExpOp.Pattern != null)
                        {
                            if (switchExpOp.Pattern is IDeclarationPatternOperation)
                            {
                                var pattern = (IDeclarationPatternOperation)(switchExpOp.Pattern);
                                var matchedType = pattern.NarrowedType;
                                var varName = pattern.DeclaredSymbol.Name;
                                var newTerm = _termFactory.Create((CSharpSyntaxNode)pattern.Syntax, ISlicerSymbol.Create(matchedType, _typeArguments), false, varName, false, false);

                                _broker.Assign(newTerm, valueTerm);
                            }
                            // TODO: Repeated code
                            else if (switchExpOp.Pattern is IRecursivePatternOperation recPatternOp)
                            {
                                PatternOperationReceiver = valueTerm;
                                foreach (var propSupPat in recPatternOp.PropertySubpatterns)
                                {
                                    var member = Visit(propSupPat.Member);
                                    //usedTerms.Add(member);
                                    if (propSupPat.Pattern is IDeclarationPatternOperation)
                                    {
                                        if (!(((IDeclarationPatternOperation)propSupPat.Pattern).DeclaredSymbol is null))
                                        {
                                            var varMem = _termFactory.Create(propSupPat.Pattern, ISlicerSymbol.Create(propSupPat.Pattern.NarrowedType), false, ((IDeclarationPatternOperation)propSupPat.Pattern).DeclaredSymbol.Name, false, false);
                                            _broker.Assign(varMem, member, new List<Term>() { valueTerm });
                                        }
                                    }
                                }
                                PatternOperationReceiver = null;

                                if (recPatternOp.DeclaredSymbol != null)
                                {
                                    var declaredVariable = _termFactory.Create(recPatternOp, ISlicerSymbol.Create(recPatternOp.NarrowedType), false, recPatternOp.DeclaredSymbol.Name, false, false);
                                    _broker.Assign(declaredVariable, valueTerm, new List<Term>() { valueTerm });
                                }
                            }
                        }

                        GetNextStatement();
                        EnterCondition(switchStmt);
                        var expOp = GetOperation(((SwitchExpressionArmSyntax)nextStmt.CSharpSyntaxNode).Expression);
                        retTerm = Visit(expOp);
                        nextStmt = ObserveNextStatement();
                        ExitCondition(switchStmt);
                    }
                }
            }

            return retTerm;
        }

        void VisitSwitchCase(ISwitchCaseOperation operation)
        {
            foreach (var clause in operation.Clauses)
                Visit(clause);
        }

        void VisitCaseClause(ICaseClauseOperation operation)
        {
            if (operation is IPatternCaseClauseOperation patternCaseClauseOperation)
            {
                var uses = new List<Term>();
                DealWithPatterns(temporarySwitchTerm, patternCaseClauseOperation.Pattern, uses);

                if (patternCaseClauseOperation.Guard != null)
                {
                    var nextStmt = ObserveNextStatement();
                    if (nextStmt.CSharpSyntaxNode is WhenClauseSyntax &&
                        nextStmt.CSharpSyntaxNode == patternCaseClauseOperation.Guard.Syntax.Parent)
                    {
                        GetNextStatement();
                        var recTerm = Visit(patternCaseClauseOperation.Guard);

                        nextStmt = ObserveNextStatement();
                        if (nextStmt.TraceType == TraceType.EnterExpression &&
                            nextStmt.CSharpSyntaxNode == patternCaseClauseOperation.Guard.Syntax.Parent)
                        {
                            GetNextStatement();
                            // The next trace has to be EnterCondition (section body)
                            var switchStmt = GetNextStatement();
                            if (switchStmt.TraceType != TraceType.EnterCondition)
                                throw new SlicerException("Unexpected behavior");

                            EnterCondition(switchStmt);
                            uses.Add(recTerm);
                            var whenStmt = Utils.StmtFromSyntaxNode(
                                (CSharpSyntaxNode)patternCaseClauseOperation.Guard.Syntax.Parent, _instrumentationResult);
                            _broker.UseOperation(whenStmt, uses);
                            ExitCondition(switchStmt);
                            EnterCondition(whenStmt);
                            throw new EnterSwitchException();
                        }
                    }
                }
            }
        }

        void VisitBranchStatement(IBranchOperation operation)
        {
            _broker.Continue();
            if (operation.BranchKind == BranchKind.Continue)
            {
                var container = operation.Syntax.GetLoopContainer();
                if (container is ForEachStatementSyntax)
                    CheckForMoveNextCallbacks((IForEachLoopOperation)GetOperation((CSharpSyntaxNode)container));
            }
        }

        void VisitReturnStatement(IReturnOperation operation)
        {
            var _returnTerm = Visit(((IReturnOperation)operation).ReturnedValue);
            SetReturn(operation, _returnTerm);
        }

        void VisitArrowExpressionClause(IOperation operation)
        {
            var _returnTerm = Visit(operation);
            SetReturn(operation, _returnTerm);
        }

        void SetReturn(IOperation operation, Term _returnTerm)
        {
            if (_returnTerm != null)
            {
                var newTerm = _termFactory.Create(operation, _returnTerm.Last.Symbol, false, TermFactory.GetFreshName());
                _broker.Assign(newTerm, _returnTerm);

                // XXX: Estamos retorando un tipo complejo a través de un escalar, lo tenemos que alocar
                if (_returnComplexType && newTerm.IsScalar && !newTerm.Last.Symbol.IsNullSymbol)
                {
                    newTerm.Last.Symbol = ISlicerSymbol.CreateObjectSymbol();
                    newTerm.IsScalar = false;
                    _broker.Alloc(newTerm);
                }

                AssignRV(newTerm);
            }
            // Caso Tasks
            else if (_returnComplexType)
            {
                var type = ((IMethodSymbol)(_semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)_methodNode)
                .GetDeclaredSymbol((((CSharpSyntaxNode)_methodNode) is ArrowExpressionClauseSyntax) ? _methodNode.Parent : _methodNode))).ReturnType;
                var newTerm = _termFactory.Create(operation, ISlicerSymbol.Create((ITypeSymbol)type), false, TermFactory.GetFreshName(), false);
                _broker.HandleNonInstrumentedMethod(new List<Term>(), null, new List<Term>(), newTerm, type, "ctor");
                AssignRV(newTerm);
            }
            else
                _broker.DefUseOperation(_termFactory.Create(operation, ISlicerSymbol.CreateNullTypeSymbol(), false, null));

            ConsumeExitLoops();
            if (!_traceConsumer.HasNext() || _traceConsumer.ObserveNextStatement().TraceType != TraceType.EnterFinally)
            {
                _sliceCriteriaReached = _broker.SliceCriteriaReached;
                _broker.ExitMethod(_originalStatement, _returnObject);
                _setReturn = true;
            }
            else
                _returnPostponed = true;
        }

        void VisitYieldReturnStatement(IReturnOperation operation)
        {
            if (yieldReturnValuesContainer == null)
                InitializeYieldReturnContainer((CSharpSyntaxNode)operation.Syntax);

            var recTerm = Visit(operation.ReturnedValue);
            _broker.HandleNonInstrumentedMethod(new List<Term>() { recTerm }, yieldReturnValuesContainer, new List<Term>(), null, yieldReturnValuesContainer.First.Symbol.Symbol, "Add");
        }

        void VisitYieldBreakStatement(IReturnOperation operation)
        {
            if (yieldReturnValuesContainer == null)
                InitializeYieldReturnContainer((CSharpSyntaxNode)operation.Syntax);

            AssignRV(yieldReturnValuesContainer);

            ConsumeExitLoops();
            if (!_traceConsumer.HasNext() || _traceConsumer.ObserveNextStatement().TraceType != TraceType.EnterFinally)
            {
                _sliceCriteriaReached = _broker.SliceCriteriaReached;
                _broker.ExitMethod(_originalStatement, _returnObject);
                _setReturn = true;
            }
            else
                _returnPostponed = true;
        }
        #endregion

        #region Properties y Fields
        Term VisitFieldReferenceExpression(IFieldReferenceOperation operation)
        {
            var recTerm = Visit(operation.Instance);
            Term newTerm;
            if (recTerm == null)
                newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments), operation.Field.IsStatic || operation.Field.IsConst, Utils.GetRealName(operation.Field.ToString(), _typeArguments));
            else
            {
                newTerm = recTerm.AddingField(new Field(operation.Field.Name, ISlicerSymbol.Create(operation.Type, _typeArguments)));
                newTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
            }

            //var Model = _semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)operation.Syntax);

            // XXX: Si no es asignación del lado izquierdo, o un struct, o ref, o un field constante entonces es wrappeado y espero el end
            //if (!((operation.Syntax.Parent is AssignmentExpressionSyntax &&
            //    ((AssignmentExpressionSyntax)operation.Syntax.Parent).Left == operation.Syntax &&
            //    ((AssignmentExpressionSyntax)operation.Syntax.Parent).OperatorToken.Kind() == SyntaxKind.EqualsToken) ||
            //    //((operation.Syntax.Parent is MemberAccessExpressionSyntax // Structs
            //    //    && (Model.GetTypeInfo(((MemberAccessExpressionSyntax)operation.Syntax.Parent).Expression).Type).CustomIsStruct())) ||

            //    // Esto es lo último que comenté
            //    //(((INamedTypeSymbol)operation.Field.ContainingSymbol).CustomIsStruct()) ||

            //        //&& operation.Instance != null && operation.Instance.Kind == OperationKind.InstanceReference) ||
            //    (operation.Syntax.Parent is ArgumentSyntax && ((ArgumentSyntax)operation.Syntax.Parent).RefOrOutKeyword.Value != null) ||
            //    (operation.Field.IsConst)))
            //    // XXX: ASUMIMOS QUE LOS FIELDS NO TIENEN CALLBACKS!
            //    if (Utils.IsEnterMethodOrConstructor(ObserveNextStatement().TraceType))
            //        throw new SlicerException("No se esperan callbacks de fields");
            //    else
            //        GetNextStatement(TraceType.EndMemberAccess);

            return newTerm;
        }

        Term VisitPropertyReferenceExpression(IPropertyReferenceOperation operation)
        {
            return VisitPropertyReferenceExpression(operation, false).Item2;
        }

        Tuple<Term, Term> VisitPropertyReferenceExpression(IPropertyReferenceOperation operation, bool forSet)
        {
            var recTerm = Visit(operation.Instance);
           
            Term newTerm;
            IDictionary<ITypeSymbol, ITypeSymbol> typesDictionary = null;

            // Special case, this refers to the parent
            if (operation.Parent is IPropertySubpatternOperation propertySubpatternOperation && recTerm.ToString() == "this" &&
                propertySubpatternOperation.Member == operation)
                recTerm = PatternOperationReceiver;

            bool isSetAccessor;
            var hasGetAccesor = (!forSet) && HasAccesor(operation.Property.Name, typesDictionary, out isSetAccessor) && !isSetAccessor;

            if (recTerm == null)
            {
                newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments), operation.Property.IsStatic,
                    hasGetAccesor ? TermFactory.GetFreshName() : Utils.GetRealName(operation.Property.ToString(), _typeArguments));
                typesDictionary = Utils.GetTypesDictionary(operation.Property.ContainingType, _typeArguments);
            }
            // Si el recTerm es escalar estamos accediendo a cosas como string.length, cosa.IsNull, cuyo "last def" es equivalente al anterior,
            // Por lo tanto no cambia el slice devolver el término anterior.
            else if (recTerm.IsScalar)
                newTerm = recTerm;
            else
            {
                if (hasGetAccesor)
                    newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments), operation.Property.IsStatic, TermFactory.GetFreshName());
                else
                {
                    newTerm = recTerm.AddingField(new Field(hasGetAccesor ? TermFactory.GetFreshName() : operation.Property.Name, ISlicerSymbol.Create(operation.Type)));
                    newTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
                }
            }

            if (hasGetAccesor)
                HandleInstrumentedMethod(operation, newTerm, null, operation.Property.IsStatic ? null : recTerm, typesDictionary);

            var Model = _semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)operation.Syntax);
            var isException = structsExceptions.Any(x =>
                ((_originalStatement != null && x.Item1 == _originalStatement.FileId) || (_originalStatement == null && x.Item1 == _currentFileId)) &&
                x.Item2 < operation.Syntax.Span.Start && x.Item3 > operation.Syntax.Span.End);
            if (isException)
                ;

            if ((!forSet) && !((operation.Syntax.Parent is AssignmentExpressionSyntax &&
                ((AssignmentExpressionSyntax)operation.Syntax.Parent).Left == operation.Syntax &&
                ((AssignmentExpressionSyntax)operation.Syntax.Parent).OperatorToken.Kind() == SyntaxKind.EqualsToken) ||
                (!Globals.wrap_structs_calls && (
                operation.Property.GetMethod.ReceiverType.CustomIsStruct() && !isException)) ||

                (operation.Syntax.Parent is ArgumentSyntax && ((ArgumentSyntax)operation.Syntax.Parent).RefOrOutKeyword.Value != null)))
            {
                var nextStmt = ObserveNextStatement();
                if (newTerm.Count == 1)
                    GetNextStatement(TraceType.EndMemberAccess, false);
                else
                {
                    var returnTerms = WaitForEnd(newTerm.Stmt.CSharpSyntaxNode, new List<Term>() { newTerm }, operation.Property.GetMethod, null, TraceType.EndMemberAccess);

                    if (!Globals.properties_as_fields || returnTerms.Count > 0)
                        _broker.HandleNonInstrumentedMethod(new List<Term>(), newTerm.IsGlobal ? null : newTerm.DiscardLast(), returnTerms, newTerm, operation.Property.GetMethod);
                }
            }

            return new Tuple<Term, Term>(recTerm, newTerm);
        }

        Term VisitIndexedPropertyReferenceExpression(IPropertyReferenceOperation operation)
        {
            return VisitIndexedPropertyReferenceExpression(operation, false).Item1;
        }

        Tuple<Term, List<Term>> VisitIndexedPropertyReferenceExpression(IPropertyReferenceOperation operation, bool forSet)
        {
            // Lista
            var recTerm = Visit(operation.Instance);
            Term newTerm;

            // Si el operador está overraideado... (lo hago solo para un indexer de un argumento)
            var nextStmt = _traceConsumer.ObserveNextStatement();

            if (nextStmt.TraceType == TraceType.EnterMethod &&
                nextStmt.CSharpSyntaxNode is AccessorDeclarationSyntax &&
                ((AccessorDeclarationSyntax)nextStmt.CSharpSyntaxNode).Parent.Parent is IndexerDeclarationSyntax &&
                operation.Arguments.Count() == 1)
            {
                bool isSetAccessor;
                var hasGetAccesor = HasAccesor(operation.Property.Name, null, out isSetAccessor) && !isSetAccessor;

                var accesorSymbol = (IMethodSymbol)_semanticModelsContainer.GetBySyntaxNode(nextStmt.CSharpSyntaxNode).GetDeclaredSymbol(nextStmt.CSharpSyntaxNode);
                newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(accesorSymbol.ReturnType, _typeArguments), false, TermFactory.GetFreshName());
                if (hasGetAccesor)
                {
                    var argumentos = new List<Term>();
                    foreach (var arg in operation.Arguments)
                    {
                        var argTerm = CreateArgument(arg);
                        argumentos.Add(argTerm);
                    }

                    var dictionary = Utils.GetTypesDictionary(accesorSymbol, _typeArguments);
                    HandleInstrumentedMethod(operation, newTerm, argumentos, accesorSymbol.IsStatic ? null : recTerm, dictionary);
                    // TODO: Si el Indexer está overraideado te puede hacer callback...
                    GetNextStatement(TraceType.EndMemberAccess, false); // TODO: False dentro de Roslyn...
                }
            }
            else
            {
                // Si se accede a un caracter de un string mediante [], ejemplo "hola"[0], pincha. Hay que devolver el literal.
                if (recTerm.IsScalar)
                {
                    newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type), false, TermFactory.GetFreshName());
                    _broker.DefUseOperation(newTerm,
                        operation.Arguments.Select(x => Visit(x)).Union(new Term[] { recTerm }).ToArray());
                    // TODO: False only with structs... (and not exceptions)
                    GetNextStatement(TraceType.EndMemberAccess, false);
                }
                else
                {
                    // No sabemos que hay adentro del indexer. Solo podemos utilizarlo y hacer una especie de Havoc readonly que apunte a todo y utilize el indexer.
                    // Una mejora es: si es string, entonces podemos crear el termino recTerm."Property"

                    var dependentTerms = new List<Term>();
                    if (operation.Arguments.Count() == 1 &&
                        operation.Arguments.Single().Value.Kind == OperationKind.Literal &&
                        operation.Arguments.Single().Value.Type.Name == "String")
                    {
                        newTerm = recTerm.AddingField(new Field(((ILiteralOperation)operation.Arguments.Single().Value).ConstantValue.Value.ToString(), ISlicerSymbol.Create(operation.Type)));
                        newTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
                    }
                    else
                    {
                        // Términos dependientes
                        dependentTerms = operation.Arguments.Select(x => Visit(x)).ToList();
                        if (forSet)
                            return new Tuple<Term, List<Term>>(recTerm, dependentTerms);
                        else
                        {
                            newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments));
                            _broker.HandleNonInstrumentedMethod(dependentTerms, recTerm, new List<Term>(), newTerm, operation.Property.GetMethod);
                        }
                    }

                    var isException = structsExceptions.Any(x =>
                        ((_originalStatement != null && x.Item1 == _originalStatement.FileId) || (_originalStatement == null && x.Item1 == _currentFileId)) &&
                        x.Item2 < operation.Syntax.Span.Start && x.Item3 > operation.Syntax.Span.End);
                    if (Globals.wrap_structs_calls || isException || !(operation.Property.GetMethod?.ReceiverType.CustomIsStruct() ?? false))
                    {
                        if (ObserveNextStatement().TraceType != TraceType.EndMemberAccess)
                        {
                            var returnTerms = WaitForEnd(recTerm.Stmt.CSharpSyntaxNode, new List<Term>() { recTerm }, operation.Property, null, TraceType.EndMemberAccess);
                            _broker.HandleNonInstrumentedMethod(dependentTerms, recTerm, returnTerms, newTerm, operation.Property);
                        }
                        else
                            GetNextStatement(TraceType.EndMemberAccess);
                    }
                }
            }
            return new Tuple<Term, List<Term>>(newTerm, null);
        }

        Term VisitConditionalAccessOperation(IConditionalAccessOperation operation)
        {
            var recTerm = Visit(operation.Operation);
            if (ObserveNextStatement(false, _typeArguments).TraceType == TraceType.ConditionalAccessIsNull)
            {
                GetNextStatement(TraceType.ConditionalAccessIsNull, true);
                var slicerSymbol = ISlicerSymbol.CreateNullTypeSymbol();
                var newTerm = _termFactory.Create(operation.Operation, slicerSymbol, false, TermFactory.GetFreshName(), true);
                _broker.DefUseOperation(newTerm, new Term[] { recTerm });
                // We have to consume one extra trace (with the instrumentation the client sends one more trace line)
                if (operation.WhenNotNull.Kind != OperationKind.FieldReference)
                {
                    var tempStmt = ObserveNextStatement();
                    if ((tempStmt.TraceType == TraceType.EndInvocation || tempStmt.TraceType == TraceType.EndMemberAccess) &&
                        tempStmt.SpanEnd == operation.Syntax.Span.End)
                        GetNextStatement();
                }
                return newTerm;
            }

            temporaryConditionalAccessTerm = recTerm;
            var whenNotNull = Visit(operation.WhenNotNull);
            return whenNotNull;
        }

        Term VisitConditionalAccessInstance(IConditionalAccessInstanceOperation operation)
        {
            var returnTerm = temporaryConditionalAccessTerm;
            temporaryConditionalAccessTerm = null;
            return returnTerm;
        }

        Term VisitEventReferenceExpression(IEventReferenceOperation operation)
        {
            var recTerm = Visit(operation.Instance);
            Term returnTerm = null;
            if (recTerm == null)
                returnTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments), operation.Event.IsStatic, Utils.GetRealName(operation.Event.ToString(), _typeArguments));
            else
            {
                returnTerm = recTerm.AddingField(operation.Member.Name, ISlicerSymbol.Create(operation.Type));
                returnTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
            }
            var nextTrace = _traceConsumer.ObserveNextStatement();
            if (nextTrace.TraceType == TraceType.EndMemberAccess && nextTrace.SpanStart == operation.Syntax.Span.Start && nextTrace.SpanEnd == operation.Syntax.Span.End)
                _traceConsumer.GetNextStatement();
            return returnTerm;
        }

        Term VisitDynamicMemberReference(IDynamicMemberReferenceOperation operation)
        {
            return VisitDynamicMemberReference(operation, false);
        }

        Term VisitDynamicMemberReference(IDynamicMemberReferenceOperation operation, bool forSet)
        {
            var recTerm = Visit(operation.Instance);
            Term newTerm;
            IDictionary<ITypeSymbol, ITypeSymbol> typesDictionary = null;

            bool isSetAccessor;
            var hasGetAccesor = (!forSet) && HasAccesor(operation.MemberName, typesDictionary, out isSetAccessor) && !isSetAccessor;

            // TODO: Chequear que sucede con los dynamic types

            if (recTerm == null)
            {
                newTerm = _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type, _typeArguments), operation.Type.IsStatic,
                    hasGetAccesor ? TermFactory.GetFreshName() : Utils.GetRealName(operation.MemberName, _typeArguments));
                typesDictionary = Utils.GetTypesDictionary((INamedTypeSymbol)operation.Type, _typeArguments);
            }
            // Si el recTerm es escalar estamos accediendo a cosas como string.length, cosa.IsNull, cuyo "last def" es equivalente al anterior,
            // Por lo tanto no cambia el slice devolver el término anterior.
            else if (recTerm.IsScalar)
                newTerm = recTerm;
            else
            {
                newTerm = recTerm.AddingField(new Field(hasGetAccesor ? TermFactory.GetFreshName() : operation.MemberName, ISlicerSymbol.Create(operation.Type)));
                newTerm.Stmt = Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult);
            }

            if (hasGetAccesor)
                HandleInstrumentedMethod(operation, newTerm, null, operation.Type.IsStatic ? null : recTerm, typesDictionary);

            var Model = _semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)operation.Syntax);
            if ((!forSet) && !((operation.Syntax.Parent is AssignmentExpressionSyntax &&
                ((AssignmentExpressionSyntax)operation.Syntax.Parent).Left == operation.Syntax &&
                ((AssignmentExpressionSyntax)operation.Syntax.Parent).OperatorToken.Kind() == SyntaxKind.EqualsToken) ||
                //(operation.Syntax.Parent is MemberAccessExpressionSyntax // Structs
                //&& (Model.GetTypeInfo(((MemberAccessExpressionSyntax)operation.Syntax.Parent).Expression).Type).CustomIsStruct()) ||
                (operation.Syntax.Parent is ArgumentSyntax && ((ArgumentSyntax)operation.Syntax.Parent).RefOrOutKeyword.Value != null)))
            {
                var nextStmt = ObserveNextStatement();
                if (newTerm.Count == 1)
                    GetNextStatement(TraceType.EndMemberAccess);
                else
                {
                    var memberSymbol = _semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)operation.Syntax).GetSymbolInfo(operation.Syntax).Symbol;
                    var returnTerms = WaitForEnd(newTerm.Stmt.CSharpSyntaxNode, new List<Term>() { newTerm }, memberSymbol, null, TraceType.EndMemberAccess);
                    // XXX: Si hubo callbacks con cosas aplicamos una operación sino simplemente retornamos el término
                    if (returnTerms.Count > 0)
                        _broker.HandleNonInstrumentedMethod(new List<Term>(), newTerm.IsGlobal ? null : newTerm.DiscardLast(), returnTerms, newTerm, operation.Type);
                }
            }

            return newTerm;
        }

        Term VisitArgument(IArgumentOperation argument)
        {
            var term = Visit(argument.Value);
            if (argument.Parameter.RefKind != RefKind.None)
            {
                term.IsRef = true;
                term.IsOutOrRef = true;
            }
            return term;
        }
        #endregion

        #region Casos de variables o parámetros base
        Term VisitInstanceReferenceExpression(IInstanceReferenceOperation operation)
        {
            return _termFactory.Create(operation, ISlicerSymbol.Create(operation.Type), false, "this", false);
        }

        Term VisitParameterReferenceExpression(IParameterReferenceOperation operation)
        {
            return _termFactory.Create(operation, ISlicerSymbol.Create(operation.Parameter.Type, _typeArguments), false, operation.Parameter.Name, false);
        }

        Term VisitLocalReferenceExpression(ILocalReferenceOperation operation)
        {
            return _termFactory.Create(operation, ISlicerSymbol.Create(operation.Local.Type, _typeArguments), false, operation.Local.Name, false);
        }

        Term VisitInterpolatedStringOperation(IInterpolatedStringOperation operation)
        {
            var uses = new List<Term>();
            foreach (var part in operation.Parts)
            {
                var use = Visit(part);
                if (use != null)
                    uses.Add(use);
            }

            var slicerSymbol = operation.Type == null ? ISlicerSymbol.CreateNullTypeSymbol() : ISlicerSymbol.Create(operation.Type);
            var newTerm = _termFactory.Create(operation, slicerSymbol, false, TermFactory.GetFreshName());
            _broker.DefUseOperation(newTerm, uses.ToArray());
            return newTerm;
        }

        Term VisitLiteralExpression(ILiteralOperation literalExpression)
        {
            var slicerSymbol = literalExpression.Type == null ? ISlicerSymbol.CreateNullTypeSymbol() : ISlicerSymbol.Create(literalExpression.Type);
            var newTerm = _termFactory.Create(literalExpression, slicerSymbol, false, TermFactory.GetFreshName());
            _broker.DefUseOperation(newTerm);
            return newTerm;
        }

        Term VisitSizeOfOperation(ISizeOfOperation operation)
        {
            var symbol = ISlicerSymbol.Create(operation.Type);
            var newTerm = _termFactory.Create(operation, symbol, false, TermFactory.GetFreshName());
            _broker.DefUseOperation(newTerm);
            return newTerm;
        }
        #endregion
        #endregion

        #region Helpers
        bool HandleInstrumentedMethod(Stmt controlDependency, Term term = null, List<Term> argumentList = null, Term @this = null, IDictionary<ITypeSymbol, ITypeSymbol> typeArguments = null)
        {
            var nuevoProcesador = new ProcessConsumer(_traceConsumer, _broker, _semanticModelsContainer, _instrumentationResult, _termFactory, _executedStatements);
            try
            {
                return nuevoProcesador.Process(term, argumentList, @this, controlDependency, typeArguments);
            }
            catch (ProgramException)
            {
                ExceptionTerm = nuevoProcesador.ExceptionTerm;
                GetNextStatement(TraceType.EnterFinalFinally);
                CheckExceptions();
            }
            return true;
        }

        bool HandleInstrumentedMethod(IOperation operation, Term term = null, List<Term> argumentList = null, Term @this = null, IDictionary<ITypeSymbol, ITypeSymbol> typeArguments = null)
        {
            if (operation != null)
                return HandleInstrumentedMethod(Utils.StmtFromSyntaxNode((CSharpSyntaxNode)operation.Syntax, _instrumentationResult), term, argumentList, @this, typeArguments);
            else
                return HandleInstrumentedMethod((Stmt)null, term, argumentList, @this, typeArguments);
        }

        #region Exceptions
        static List<Tuple<int, int, int>> methodsExceptions = new List<Tuple<int, int, int>>() {
            new Tuple<int, int, int>(1560, 30029, 30046),
            new Tuple<int, int, int>(10213, 3780, 3800),
        };

        static List<Tuple<int, int, int>> structsExceptions = new List<Tuple<int, int, int>>() {
            new Tuple<int, int, int>(10071, 7149, 7223),
            new Tuple<int, int, int>(10077, 34345, 34421),
            new Tuple<int, int, int>(10030, 6397, 6422),
            new Tuple<int, int, int>(10040, 26366, 27083),
            new Tuple<int, int, int>(10073, 53010, 53078),
            new Tuple<int, int, int>(10073, 105776, 105890),
            new Tuple<int, int, int>(10319, 32472, 32517),
            new Tuple<int, int, int>(10064, 1017, 1102),
            new Tuple<int, int, int>(10030, 10447, 10459),
            new Tuple<int, int, int>(10030, 10472, 10484),
            new Tuple<int, int, int>(10052, 44037, 44091),
            new Tuple<int, int, int>(10073, 105920, 106034),
            new Tuple<int, int, int>(10052, 43043, 43108),
            new Tuple<int, int, int>(10286, 10292, 10329),
            new Tuple<int, int, int>(10319, 25009, 25038),
            new Tuple<int, int, int>(10002, 5805, 5831),
            new Tuple<int, int, int>(10270, 1727, 1749),
            new Tuple<int, int, int>(10049, 28367, 28426),
            new Tuple<int, int, int>(10287, 1860, 1890),
            new Tuple<int, int, int>(10345, 7237, 7259),
            new Tuple<int, int, int>(10135, 5308, 5355),
            new Tuple<int, int, int>(10053, 7033, 7107),
            new Tuple<int, int, int>(10273, 799, 824),
            new Tuple<int, int, int>(10073, 180496, 180586),
            new Tuple<int, int, int>(10003, 225778, 225807),
            new Tuple<int, int, int>(10071, 5415, 5469),
            new Tuple<int, int, int>(10073, 66493, 66515),
            new Tuple<int, int, int>(10073, 65800, 65857),
            new Tuple<int, int, int>(10056, 10750, 10805),
            new Tuple<int, int, int>(10395, 1534, 1587),
            new Tuple<int, int, int>(10064, 1600, 1638),
            new Tuple<int, int, int>(10268, 25407, 25433),
            new Tuple<int, int, int>(10268, 25461, 25483),
            new Tuple<int, int, int>(10039, 36167, 36190),
            new Tuple<int, int, int>(10226, 9711, 9821),
            new Tuple<int, int, int>(10225, 4791, 4899),
            new Tuple<int, int, int>(10269, 24666, 24713),
            new Tuple<int, int, int>(10194, 7416, 7529),
            new Tuple<int, int, int>(10218, 81555, 81624),
            new Tuple<int, int, int>(10401, 1406, 1463),
            new Tuple<int, int, int>(10255, 11945, 11973),
            new Tuple<int, int, int>(10318, 84425, 84448),
            new Tuple<int, int, int>(10119, 35089, 35159),
            new Tuple<int, int, int>(10232, 2336, 2356),
            new Tuple<int, int, int>(10073, 105998, 106112),
            new Tuple<int, int, int>(10319, 34367, 34396),
            new Tuple<int, int, int>(10176, 32069, 32081),
            new Tuple<int, int, int>(10250, 2095, 2139),
            new Tuple<int, int, int>(10176, 14969, 14984),
            new Tuple<int, int, int>(10002, 8373, 8445),
            new Tuple<int, int, int>(10261, 15825, 15876),
            new Tuple<int, int, int>(10073, 180574, 180664),
            new Tuple<int, int, int>(10010, 10345, 10366),
            new Tuple<int, int, int>(10218, 82961, 83028),
            new Tuple<int, int, int>(10203, 56959, 57054),
            new Tuple<int, int, int>(10225, 5084, 5166),
            new Tuple<int, int, int>(10073, 53101, 53155),
            new Tuple<int, int, int>(10318, 137557, 137580),
            new Tuple<int, int, int>(10318, 137583, 137603),
            new Tuple<int, int, int>(10032, 19638, 19659),
            new Tuple<int, int, int>(10272, 36403, 36435),
            new Tuple<int, int, int>(10272, 36438, 36471),
            new Tuple<int, int, int>(10073, 48481, 48503),
            new Tuple<int, int, int>(10579, 15417, 15437),
            new Tuple<int, int, int>(10073, 48481, 48555),
            new Tuple<int, int, int>(10707, 35191, 35218),
            new Tuple<int, int, int>(10698, 7170, 7179),
            new Tuple<int, int, int>(10715, 4533, 4568),
            new Tuple<int, int, int>(10300, 9341, 9408),
            new Tuple<int, int, int>(25019, 15126, 15167),
            new Tuple<int, int, int>(10440, 67802, 67861),
            new Tuple<int, int, int>(10712, 35075, 35102),
            new Tuple<int, int, int>(10310, 68728, 68834),
            new Tuple<int, int, int>(10709, 66482, 66618),
            new Tuple<int, int, int>(26001, 9811, 9823),
            new Tuple<int, int, int>(26001, 9913, 9925), // Probably this is the previous one
            new Tuple<int, int, int>(10781, 4589, 4614),
            new Tuple<int, int, int>(10781, 3960, 4039),
            new Tuple<int, int, int>(10713, 27564, 27581),
            new Tuple<int, int, int>(10073, 66571, 66593),
            new Tuple<int, int, int>(10073, 65878, 65935),
            new Tuple<int, int, int>(10047, 955, 999),
            new Tuple<int, int, int>(10159, 7698, 7739),
            new Tuple<int, int, int>(10286, 20078, 20100),
            new Tuple<int, int, int>(10874, 183141, 183160),
            new Tuple<int, int, int>(10899, 83436, 83450),
            new Tuple<int, int, int>(10159, 7698, 7739),
            new Tuple<int, int, int>(10159, 7698, 7790),
            new Tuple<int, int, int>(10128, 11653, 11735),
            new Tuple<int, int, int>(10286, 20381, 20403),
            new Tuple<int, int, int>(10065, 1352, 1390),
            new Tuple<int, int, int>(10957, 16894, 17003),
            new Tuple<int, int, int>(10899, 235789, 235814),
            new Tuple<int, int, int>(10849, 10749, 10772),
            new Tuple<int, int, int>(10849, 11336, 11357),
            new Tuple<int, int, int>(10874, 121095, 121126),
            new Tuple<int, int, int>(10874, 121220, 121251),
            new Tuple<int, int, int>(10899, 242659, 242691),
            new Tuple<int, int, int>(10899, 242694, 242727),
            new Tuple<int, int, int>(10318, 65992, 66019), // Aunque no le tengo fe
            new Tuple<int, int, int>(10314, 111604, 111633),
            new Tuple<int, int, int>(10899, 298030, 298098),
            new Tuple<int, int, int>(10899, 235816, 235878),
            new Tuple<int, int, int>(10899, 240197, 240228),
            new Tuple<int, int, int>(10967, 25027, 25056),
            new Tuple<int, int, int>(10319, 15782, 15866),
            new Tuple<int, int, int>(10319, 26411, 26453),
            new Tuple<int, int, int>(10889, 49027, 49051),
            new Tuple<int, int, int>(10899, 420505, 420528),
            new Tuple<int, int, int>(10889, 49027, 49051),
            new Tuple<int, int, int>(10899, 138225, 138277),
            new Tuple<int, int, int>(10462, 7620, 7674),
            new Tuple<int, int, int>(10035, 31260, 31266),
            new Tuple<int, int, int>(10899, 210245, 210259),
            new Tuple<int, int, int>(10462, 3943, 3983),
            new Tuple<int, int, int>(10462, 4597, 4619),
            new Tuple<int, int, int>(10751, 2779, 2796),
            new Tuple<int, int, int>(10035, 31260, 31266),
            new Tuple<int, int, int>(10591, 15533, 15551),
            new Tuple<int, int, int>(10591, 58469, 58496),
            new Tuple<int, int, int>(10314, 10344, 10369),
            new Tuple<int, int, int>(10473, 41610, 41663),
            new Tuple<int, int, int>(10452, 33297, 33313),
            new Tuple<int, int, int>(10330, 66195, 66214),
            new Tuple<int, int, int>(10259, 34214, 34260),
            new Tuple<int, int, int>(10073, 203262, 203319),
            new Tuple<int, int, int>(10073, 203428, 203487),
            new Tuple<int, int, int>(10040, 63249, 63313),
            new Tuple<int, int, int>(10040, 62463, 62509),
            new Tuple<int, int, int>(10040, 62991, 63054),
        };
        #endregion

        void HandleNonInstrumentedMethod(IOperation operation, List<Term> argumentList, Term @this, Term hub, ISymbol symbol, string methodName = null, SyntaxNode nodeToCheckException = null)
        {
            var dependentTerms = new List<Term>(argumentList);
            if (@this != null)
                dependentTerms.Add(@this);

            List<Term> returnedTerms = null;
            var thisStmt = ((hub ?? @this).Stmt);
            var spanStartToUse = nodeToCheckException != null ? nodeToCheckException.Span.Start : thisStmt.SpanStart;
            var spanEndToUse = nodeToCheckException != null ? nodeToCheckException.Span.End : thisStmt.SpanEnd;
            var isException = structsExceptions.Any(x => x.Item1 == thisStmt.FileId && x.Item2 < spanStartToUse && x.Item3 > spanEndToUse);
            if (isException)
                ;
            if (!Globals.wrap_structs_calls && symbol != null && symbol is IMethodSymbol && ((IMethodSymbol)symbol).MethodKind != MethodKind.Constructor && ((IMethodSymbol)symbol).CustomStructReceiver() && !isException)
                returnedTerms = new List<Term>();
            else
                returnedTerms = WaitForEnd(thisStmt.CSharpSyntaxNode, dependentTerms, symbol, methodName, TraceType.EndInvocation);

            // XXX: returnedTerms have to go with parameters... (for now)
            if (returnedTerms.Count > 0)
                argumentList.AddRange(returnedTerms);
            _broker.HandleNonInstrumentedMethod(argumentList, @this, returnedTerms, hub, symbol, methodName);
        }

        void CheckForSetCallbacks(Term def, Term use, List<Term> dependentTerms, IPropertySymbol propertySymbol)
        {
            var nextStmt = ObserveNextStatement();
            if (!Utils.IsEnterMethodOrConstructor(nextStmt.TraceType))
            {
                if (!Globals.properties_as_fields)
                    // Corresponde a la ejecución de código no instrumentado en una asignación // XXX: TODOSPEED (REVISAR)
                    _broker.HandleNonInstrumentedMethod(new List<Term>(), def.Parts.Count > 1 ? def.DiscardLast() : def, new List<Term>(), def, propertySymbol);
            }
            else
            {
                var receiver = def.Parts.Count > 1 ? def.DiscardLast() : def;

                var involvedTerms = dependentTerms != null ? new List<Term>(dependentTerms) : new List<Term>();
                involvedTerms.Add(receiver);
                involvedTerms.Add(use);
                var returnedTerms = WaitForEnd(def.Stmt.CSharpSyntaxNode, involvedTerms, propertySymbol, null, null);
                _broker.HandleNonInstrumentedMethod(dependentTerms ?? new List<Term>(), receiver, returnedTerms, null, propertySymbol);
            }
        }

        void CheckForMoveNextCallbacks(IForEachLoopOperation operation)
        {
            var term = _foreachHubsDictionary[(CSharpSyntaxNode)operation.Syntax];
            var currentStmt = term.Stmt;
            var returnedValues = WaitForEnd(term.Stmt.CSharpSyntaxNode, new List<Term>() { term }, operation.Collection.Type, "MoveNext");

            Term _definedVariable = null;
            List<Term> _definedVariables = new List<Term>();

            if (operation.LoopControlVariable is IDeclarationExpressionOperation)
            {
                var elements =
                    ((ITupleOperation)((IDeclarationExpressionOperation)operation.LoopControlVariable).Expression).Elements;
                foreach (var e in elements)
                    _definedVariables.Add(Visit(e));
            }
            else
                _definedVariable = _termFactory.Create((CSharpSyntaxNode)operation.Syntax,
                ISlicerSymbol.Create(((IVariableDeclaratorOperation)operation.LoopControlVariable).Symbol.Type), false, ((IVariableDeclaratorOperation)operation.LoopControlVariable).Symbol.Name, false);

            // XXX: O bien venimos del foreach y esperamos el entercondition o estamos en el exitcondition y esperamos un simple statement
            if (returnedValues.Count > 0)
            {
                if (Globals.foreach_annotation || true)
                {
                    if (_definedVariable == null)
                        throw new NotImplementedException();

                    if (returnedValues.Count == 1)
                        _broker.Assign(_definedVariable, returnedValues.Single());
                    else if (returnedValues.Where(x => x.Last.Symbol.Equals(_definedVariable.Last.Symbol)).Count() == 1)
                    {
                        // TODO
                        var selected = returnedValues.Where(x => x.Last.Symbol.Equals(_definedVariable.Last.Symbol)).Single();
                        _broker.Assign(_definedVariable, selected);
                    }
                    else
                        // TODO: XXX: 
                        _broker.Assign(_definedVariable, returnedValues.Last());
                    //throw new NotImplementedException();
                }
                else
                    // TODO XXX
                    _broker.CustomEvent(new List<Term>(), term, returnedValues, _definedVariable, "MoveNext");
            }
            else
            {
                if (Globals.foreach_annotation)
                {
                    _broker.CustomEvent(new List<Term>(), term, new List<Term>(), null, "MoveNext");
                    if (_definedVariable != null)
                        _broker.CustomEvent(new List<Term>(), term, new List<Term>(), _definedVariable, "Current");
                    else
                        foreach (var defVar in _definedVariables)
                            _broker.CustomEvent(new List<Term>(), term, new List<Term>(), defVar, "Current");
                }
                else
                {
                    if (_definedVariable != null)
                    {
                        var currentTerm = term.AddingField("Current", _definedVariable.Last.Symbol);
                        currentTerm.Stmt = currentStmt;
                        _broker.Assign(_definedVariable, currentTerm);
                    }
                    else
                    {
                        foreach (var defVar in _definedVariables)
                        {
                            var currentTerm = term.AddingField("Current", defVar.Last.Symbol);
                            currentTerm.Stmt = currentStmt;
                            _broker.Assign(defVar, currentTerm);
                        }
                    }
                }
            }
        }

        void HandleBaseConstructor(Term term, CSharpSyntaxNode syntaxNode)
        {
            var arguments = new List<Term>();
            // Caso llamado a base explicito
            if (syntaxNode is ConstructorDeclarationSyntax && ((ConstructorDeclarationSyntax)syntaxNode).Initializer != null)
                try {  // TODOTEMP
                    ((ConstructorDeclarationSyntax)syntaxNode).Initializer.ArgumentList.Arguments.ToList().ForEach(x => arguments.Add(CreateArgument(Visit(GetOperation(x.Expression)))));
                }
                catch (Exception ex)
                {
                    ;
                }

            // Caso llamado al base implicito.
            // Puede ocurrir que estés invocando a un constructor propio! Entonces no va a venir otro BeforeConstructor sino un EnterMethod de la misma clase.
            // XXX: Los chequeos de tipos "ClassDeclarationSyntax" por ahí están de más o deberían ir según distintos casos
            var nextStmt = ObserveNextStatement();
            var mayInitializerSyntax = nextStmt.CSharpSyntaxNode.GetContainerOrConstructorInitializerSyntax();
            if (nextStmt.TraceType == TraceType.EnterConstructor && nextStmt.CSharpSyntaxNode == syntaxNode)
            {
                // Se llamó a un base call, pero te encontrás con vos mismo, entonces podemos asumir que hubo un no instrumentado.
                // Pero no tiró callbacks,... no hay wait for end. 
                var execSymbol = _semanticModelsContainer.GetBySyntaxNode(syntaxNode).GetDeclaredSymbol(syntaxNode);
                _broker.HandleNonInstrumentedMethod(arguments, _thisObject, new List<Term>(), null, execSymbol);
            }
            else if (nextStmt.TraceType != TraceType.BeforeConstructor &&
                nextStmt.TraceType != TraceType.BaseCall &&
                nextStmt.TraceType != TraceType.EnterConstructor &&
                mayInitializerSyntax is ConstructorInitializerSyntax &&
                ((mayInitializerSyntax.Parent.Parent is ClassDeclarationSyntax &&
                ((ClassDeclarationSyntax)mayInitializerSyntax.Parent.Parent).Identifier.ValueText
                == ((ClassDeclarationSyntax)syntaxNode.Parent).Identifier.ValueText) ||
                (mayInitializerSyntax.Parent.Parent is StructDeclarationSyntax &&
                ((StructDeclarationSyntax)mayInitializerSyntax.Parent.Parent).Identifier.ValueText
                == ((StructDeclarationSyntax)syntaxNode.Parent).Identifier.ValueText)))
            {
                var enterConstructor = LookupForBaseCall((CSharpSyntaxNode)((ConstructorInitializerSyntax)mayInitializerSyntax).Parent, nextStmt.FileId);
                HandleInstrumentedMethod(Utils.StmtFromSyntaxNode(enterConstructor.CSharpSyntaxNode, _instrumentationResult), term, arguments, _thisObject, _typeArguments);
                nextStmt = ObserveNextStatement();
            }
            else if (nextStmt.TraceType == TraceType.BeforeConstructor ||
                nextStmt.TraceType == TraceType.BaseCall ||
                ((nextStmt.TraceType == TraceType.EnterConstructor) &&
                (
                (syntaxNode.Parent is ClassDeclarationSyntax &&
                (nextStmt.CSharpSyntaxNode).Parent is ClassDeclarationSyntax &&
                ((ClassDeclarationSyntax)syntaxNode.Parent).Identifier.ValueText ==
                ((ClassDeclarationSyntax)(nextStmt.CSharpSyntaxNode).Parent).Identifier.ValueText) ||
                (syntaxNode.Parent is StructDeclarationSyntax &&
                (nextStmt.CSharpSyntaxNode).Parent is StructDeclarationSyntax &&
                ((StructDeclarationSyntax)syntaxNode.Parent).Identifier.ValueText ==
                ((StructDeclarationSyntax)(nextStmt.CSharpSyntaxNode).Parent).Identifier.ValueText))

                ))
            {
                INamedTypeSymbol namedType = null;
                BaseTypeSyntax complexTypeName = null;
                if (syntaxNode is ClassDeclarationSyntax)
                    // TODO: Solo va a haber un único nombre de clase raro, los demás serán interfaces. CASO: .NET Frameworks test
                    complexTypeName = ((ClassDeclarationSyntax)syntaxNode).BaseList.Types.FirstOrDefault(x => x.Type is GenericNameSyntax);
                else if (syntaxNode is StructDeclarationSyntax)
                    complexTypeName = ((StructDeclarationSyntax)syntaxNode).BaseList.Types.FirstOrDefault(x => x.Type is GenericNameSyntax);
                if (complexTypeName != null)
                    namedType = (INamedTypeSymbol)_semanticModelsContainer.GetBySyntaxNode(complexTypeName).GetTypeInfo((GenericNameSyntax)complexTypeName.Type).Type;

                HandleInstrumentedMethod(Utils.StmtFromSyntaxNode(syntaxNode, _instrumentationResult), term, arguments, _thisObject, Utils.GetTypesDictionary(namedType, _typeArguments));
            }
            // Las clases heredan por default de object y los structs de System.ValueType
            else if (syntaxNode is ConstructorDeclarationSyntax || syntaxNode is ClassDeclarationSyntax)
            {
                var semanticModel = _semanticModelsContainer.GetBySyntaxNode(syntaxNode);
                INamedTypeSymbol typeSymbol = null;
                if (syntaxNode is ClassDeclarationSyntax)
                {
                    if (((ClassDeclarationSyntax)(syntaxNode)).BaseList != null)
                        foreach (var t in ((ClassDeclarationSyntax)(syntaxNode)).BaseList.Types)
                        {
                            var typeInfo = semanticModel.GetTypeInfo(t.Type);
                            if (typeInfo.Type != null && typeInfo.Type.TypeKind == TypeKind.Class)
                                typeSymbol = (INamedTypeSymbol)typeInfo.Type;
                        }
                }
                else
                {
                    var symbol = semanticModel.GetDeclaredSymbol((ConstructorDeclarationSyntax)syntaxNode);
                    typeSymbol = symbol.ReceiverType.BaseType;
                }

                if (typeSymbol != null && typeSymbol.ToString() != "object" && typeSymbol.ToString() != "System.ValueType")
                {
                    // XXX: Por default tomamos el 1ero que tiene
                    // Lo mejor es mandar el símbolo correcto pero no se puede, ya que hay que preguntar por el tipo de 
                    // los argumentos y el IsAssignable y el params[] y todo eso para que después el summaries no diferencie la aridad de los constructores
                    #region Guardar
                    //// TODO: Puede pinchar con el params[]...
                    //var constructorSymbols = symbol.ReceiverType.BaseType.Constructors.Where(x => x.Arity == baseArity);
                    //ISymbol mainConstructorSymbol = constructorSymbols.FirstOrDefault();
                    //if (baseCall != null)
                    //    foreach(var constructorSymbol in constructorSymbols)
                    //    {
                    //        var typeArguments = constructorSymbol.TypeArguments;
                    //        for(var i = 0; i < typeArguments.Count(); i++)
                    //        {
                    //            var arg = baseCall.ArgumentList.Arguments[i];
                    //            var typeArg = typeArguments[i];
                    //            // ACÁ QUERRÍA PREGUNTAR ISASSIGNABLEFROM POR CADA PARAM/ARG PERO NO SE PUEDE SABER EL TIPO, SOLO EL SÍMBOLO
                    //            // DEJO ACÁ, POR LA EXPLICACIÓN ANTERIOR (VER ESTA REGIÓN)
                    //        }
                    //    }
                    #endregion

                    var executedSymbol = typeSymbol.Constructors.FirstOrDefault();

                    // A esta altura no tiene inicializados los fields externos
                    _broker.DefUseOperation(_thisObject);
                    _broker.HandleNonInstrumentedMethod(arguments, _thisObject, new List<Term>(), null, executedSymbol);

                    var dependentTerms = new List<Term>(arguments);
                    dependentTerms.Add(_thisObject);
                    // TODO: Al estar mandando null en el returnValue si cae un callback pincha, 
                    // XXX: Por ahora mandamos returned values a argumentos
                    var returnTerms = WaitForEnd(_thisObject.Stmt.CSharpSyntaxNode, dependentTerms, typeSymbol, "ctor", (TraceType?)null);
                    if (returnTerms.Count > 0)
                        arguments.AddRange(returnTerms);

                    _broker.HandleNonInstrumentedMethod(arguments, _thisObject, returnTerms, null, executedSymbol);
                }
            }
        }

        List<Term> WaitForEnd(CSharpSyntaxNode node, List<Term> involvedTerms, ISymbol caller, string callerMethodName = null, TraceType? finalTraceType = null, bool consume = true)
        {
            var nextStmt = ObserveNextStatement();
            // Términos que se van retornando. Qué hacemos con eso.
            var returnTerms = new List<Term>();
            // REPRESENTARÁ LA UNIÓN DE LO QUE TENEMOS
            var regionHub = _termFactory.Create(node, ISlicerSymbol.CreateObjectSymbol(), false, TermFactory.GetFreshName(), true, true);
            regionHub.ReferencedTerm = regionHub;
            bool regionCreated = false;
            // Para chequear entrada a modo estático
            var enterCallbackTraces = new HashSet<Stmt>();
            Stmt lastCallback = null;
            var enterStaticLoop = false;

            while (nextStmt != null && Utils.IsEnterMethodOrConstructor(nextStmt.TraceType))
            {
                // Caso particular del callback del ToString
                if (nextStmt.TraceType == TraceType.EnterMethod && involvedTerms.Count == 1 && nextStmt.CSharpSyntaxNode is MethodDeclarationSyntax methodDeclarationSyntax && methodDeclarationSyntax.ParameterList.Parameters.Count == 0)
                {
                    var methodSymbol = _semanticModelsContainer.GetBySyntaxNode(nextStmt.CSharpSyntaxNode).GetDeclaredSymbol(nextStmt.CSharpSyntaxNode);
                    if (methodSymbol != null && methodSymbol.Name == "ToString")
                    {
                        var stringTerm = _termFactory.Create(node, ISlicerSymbol.Create(((IMethodSymbol)methodSymbol).ReturnType), false, TermFactory.GetFreshName());
                        HandleInstrumentedMethod(Utils.StmtFromSyntaxNode(node, _instrumentationResult), stringTerm, null, involvedTerms.Single(), _typeArguments);
                        returnTerms.Add(stringTerm);
                        nextStmt = ObserveNextStatement();
                        continue;
                    }
                }

                // Estamos repitiendo entrada, potencialmente podría haber un loop externo
                if (!enterStaticLoop && lastCallback != null && lastCallback.Equals(nextStmt))
                    enterStaticLoop = _broker.EnterStaticMode(true);

                if (enterStaticLoop && lastCallback != null && !lastCallback.Equals(nextStmt))
                {
                    _broker.ExitStaticMode();
                    enterStaticLoop = false;
                }

                lastCallback = nextStmt;

                // Obtenemos el nodo de la entrada al método
                CSharpSyntaxNode currentSyntaxNode = null;
                if (nextStmt.TraceType == TraceType.BeforeConstructor)
                {
                    var enterConstructorStatement = LookupForEnterConstructor(nextStmt, null, false);
                    if (enterConstructorStatement == null)
                    {
                        GetNextStatement();
                        nextStmt = _traceConsumer.HasNext() ? ObserveNextStatement(allowNulls: true) : null;
                        continue;
                    }
                    currentSyntaxNode = enterConstructorStatement.CSharpSyntaxNode;
                }
                else
                    currentSyntaxNode = nextStmt.CSharpSyntaxNode;

                ISlicerSymbol currentSymbol;
                bool isConstructor, returnsValue;
                int arity;
                // Obtenemos el símbolo del método, o puede ser "clase" si no existe en el código la entrada formal
                // Luego obtenemos el nuestro símbolo
                var isArrowExpression = false;
                if (currentSyntaxNode is ArrowExpressionClauseSyntax)
                {
                    isArrowExpression = true;
                    currentSyntaxNode = (CSharpSyntaxNode)currentSyntaxNode.Parent;
                }
                var declaredSymbol = _semanticModelsContainer.GetBySyntaxNode(currentSyntaxNode).GetDeclaredSymbol(currentSyntaxNode);
                if (declaredSymbol is IPropertySymbol && isArrowExpression)
                    declaredSymbol = ((IPropertySymbol)declaredSymbol).GetMethod;
                if (declaredSymbol is IMethodSymbol)
                {
                    isConstructor = ((IMethodSymbol)declaredSymbol).MethodKind == MethodKind.Constructor;
                    currentSymbol = ISlicerSymbol.Create(isConstructor ?
                        ((IMethodSymbol)declaredSymbol).ContainingType : ((IMethodSymbol)declaredSymbol).ReturnType);
                    arity = ((IMethodSymbol)declaredSymbol).Parameters.Count();
                    returnsValue = isConstructor || !((IMethodSymbol)declaredSymbol).ReturnsVoid;
                }
                else
                {
                    isConstructor = returnsValue = true;
                    arity = 0;
                    currentSymbol = ISlicerSymbol.Create(((INamedTypeSymbol)declaredSymbol).ConstructedFrom);
                }
                Broker.LogCallback(declaredSymbol is IMethodSymbol ? declaredSymbol : currentSymbol.Symbol, caller, callerMethodName);

                // Objeto que se retorna del callback
                var returnHub = _termFactory.Create(node, currentSymbol, false, TermFactory.GetFreshName(), true, true);
                // Si no hay argumentos y es constructor no hace falta crear ninguna fucking región
                bool needToCreateRegion = true;

                // Si es un constructor, lo tratamos como a nuestros object creation, es decir: lo alocamos, y definimos utilizando lo que podamos. Se entiende.
                if (isConstructor)
                {
                    _broker.Alloc(returnHub);
                    // Si la región está creada 
                    _broker.DefUseOperation(returnHub, regionCreated ? new Term[] { regionHub } : involvedTerms.ToArray());
                    needToCreateRegion = arity > 0;
                }

                if (!regionCreated && needToCreateRegion)
                {
                    // Supongamos que son varios constructores sin argumentos, nunca se creó la región. Ahora que se crea tenemos que incluir todos los objetos devueltos previamente.
                    _broker.CreateNonInstrumentedRegion(involvedTerms.Union(returnTerms).ToList(), regionHub);
                    regionCreated = true;
                }

                // Si la región no fue creada, no importa porque es que no hay argumentos y es un constructor
                var parameters = Enumerable.Repeat(regionHub, arity).ToList();
                // Ahora bien, si es constructor el @this es lo que creamos antes, sino el @this es la región y devolvemos el returnHub
                var localExceptionTerm = ExceptionTerm;
                ExceptionTerm = null;
                if (isConstructor)
                    HandleInstrumentedMethod(Utils.StmtFromSyntaxNode(node, _instrumentationResult), null, parameters, returnHub);
                else
                    HandleInstrumentedMethod(Utils.StmtFromSyntaxNode(node, _instrumentationResult), returnHub, parameters, regionHub);

                // Hubo una exceptión, no tenemos seteado nada
                if (ExceptionTerm != null)
                {
                    returnTerms.Add(ExceptionTerm);
                    if (regionCreated)
                        _broker.CatchReturnedValueIntoRegion(regionHub, ExceptionTerm);

                    _broker.SliceCriteriaReached = _traceConsumer.SliceCriteriaReached();
                }
                else if (returnsValue)
                {
                    returnTerms.Add(returnHub);
                    // Se devolvió algo, entonces si hay región tenemos que agregarlo
                    if (regionCreated)
                        _broker.CatchReturnedValueIntoRegion(regionHub, returnHub);
                }
                ExceptionTerm = localExceptionTerm;

                nextStmt = _traceConsumer.HasNext() ? ObserveNextStatement(allowNulls: true) : null;
            }

            if (enterStaticLoop)
                _broker.ExitStaticMode();

            if (nextStmt != null)
            {
                if (finalTraceType.HasValue && nextStmt.TraceType == finalTraceType.Value && consume)
                    GetNextStatement(finalTraceType.Value, false); // TODO: El false del final está para que no pinche IOP...
                // TODO: Soluciona TEMPORALMENTE el problema de Lazy Initialization y similares (test LazyInitialization)
                // POR FAVOR VER BIEN
                else if (consume && nextStmt.TraceType == TraceType.EndInvocation && nextStmt.CSharpSyntaxNode.Parent is ParenthesizedLambdaExpressionSyntax)
                {
                    GetNextStatement(TraceType.EndInvocation);
                    nextStmt = ObserveNextStatement();
                    if (finalTraceType.HasValue && nextStmt.TraceType == finalTraceType.Value)
                        GetNextStatement(finalTraceType.Value);
                }
            }
            else
                ;

            return returnTerms;
        }

        void EnterCondition(Stmt statement)
        {
            _broker.EnterCondition(statement);
            if (DynAbs.ControlManagement.IsLoopStatement(statement))
                if (!_enterLoopSet.ContainsKey(statement))
                {
                    _enterLoopSet.Add(statement, _broker.EnterStaticMode());
                    _broker.EnterLoop();
                }
                else
                    _broker.NextLoopIteration();

            //var nextStmt = ObserveNextStatement();
            //if (statement.CSharpSyntaxNode is SwitchStatementSyntax && 
            //    (nextStmt.CSharpSyntaxNode.Parent is SwitchSectionSyntax ||
            //    (nextStmt.CSharpSyntaxNode.Parent is BlockSyntax bs &&
            //    bs.Parent is SwitchSectionSyntax)))
            //{
            //    var switchSyntax = nextStmt.CSharpSyntaxNode.Parent is SwitchSectionSyntax ? 
            //        (SwitchSectionSyntax)nextStmt.CSharpSyntaxNode.Parent : (SwitchSectionSyntax)nextStmt.CSharpSyntaxNode.Parent.Parent;
            //    var switchOperation = (ISwitchCaseOperation)GetOperation(switchSyntax);
            //    if (switchOperation.Clauses.Length == 1 && switchOperation.Clauses.Single() is ICaseClauseOperation
            //        && ((ICaseClauseOperation)switchOperation.Clauses.Single()).CaseKind == CaseKind.Pattern)
            //    {
            //        var pattern = ((IPatternCaseClauseOperation)switchOperation.Clauses.Single()).Pattern;
            //        DealWithPatterns(temporarySwitchTerm, pattern, new List<Term>());
            //    }
            //}
        }

        void DealWithPatterns(Term lastTerm, IPatternOperation pattern, List<Term> uses)
        {
            if (pattern is null)
                return;

            uses.Add(lastTerm);
            if (pattern is IDeclarationPatternOperation)
            {
                if (!(((IDeclarationPatternOperation)pattern).DeclaredSymbol is null))
                {
                    var matchedType = pattern.NarrowedType;
                    var varName = ((IDeclarationPatternOperation)pattern).DeclaredSymbol.Name;
                    var newTerm = _termFactory.Create((CSharpSyntaxNode)pattern.Syntax, ISlicerSymbol.Create(matchedType, _typeArguments), false, varName, false, false);
                    _broker.Assign(newTerm, lastTerm);
                }
            }
            else if (pattern is IRecursivePatternOperation)
            {
                var tempReceiver = PatternOperationReceiver;
                PatternOperationReceiver = lastTerm;
                foreach (var propSupPat in ((IRecursivePatternOperation)pattern).PropertySubpatterns)
                {
                    var member = Visit(propSupPat.Member);
                    DealWithPatterns(member, propSupPat.Pattern, uses);
                }
                PatternOperationReceiver = tempReceiver;

                if (((IRecursivePatternOperation)pattern).DeclaredSymbol != null)
                {
                    var declaredVariable = _termFactory.Create(pattern, ISlicerSymbol.Create(((IRecursivePatternOperation)pattern).NarrowedType), false, ((IRecursivePatternOperation)pattern).DeclaredSymbol.Name, false, false);
                    _broker.Assign(declaredVariable, lastTerm, new List<Term>() { /*newTerm*/ });
                }
            }
        }

        void ExitCondition(Stmt statement)
        {
            _broker.ExitCondition(statement);
            if (statement.CSharpSyntaxNode is ForEachStatementSyntax)
                CheckForMoveNextCallbacks((IForEachLoopOperation)GetOperation(statement.CSharpSyntaxNode));
        }

        void ExitLoop(Stmt statement)
        {
            if (DynAbs.ControlManagement.IsLoopStatement(statement))
            {
                var tobj = _enterLoopSet.Where(x => x.Key.FileId == statement.FileId &&
                                x.Key.SpanStart == statement.SpanStart && x.Key.SpanEnd == statement.SpanEnd).FirstOrDefault();
                // Se puede aplicar porque la key es string, nullable
                if (tobj.Key != null)
                {
                    if (tobj.Value)
                        _broker.ExitStaticMode();
                    _enterLoopSet.Remove(tobj.Key);
                    _broker.ExitLoop();
                }
            }
        }

        void AssignRV(Term term)
        {
            _broker.AssignRV(term);
            _rv_assigned = true;
        }

        void ExitMethod(Stmt currentStatement)
        {
            if (!_rv_assigned && _methodNode is MethodDeclarationSyntax && yieldReturnValuesContainer == null)
            {
                var typeSymbol = ((IMethodSymbol)_semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)_methodNode).GetDeclaredSymbol((CSharpSyntaxNode)_methodNode)).ReturnType;
                var enumerableNames = new string[] { "IEnumerable", "IEnumerator" };
                var isEnumerable = enumerableNames.Contains(typeSymbol.Name) ||
                    typeSymbol.AllInterfaces.Any(x => enumerableNames.Any(y => x.Name.Contains(y)));
                if (isEnumerable)
                    InitializeYieldReturnContainer((CSharpSyntaxNode)_methodNode);
            }

            if (yieldReturnValuesContainer != null)
                AssignRV(yieldReturnValuesContainer);

            _broker.ExitMethod(currentStatement, _returnObject);
            _setReturn = true;
        }

        static string[] ClosingMethods = new string[] { "Dispose", "Close", "RemoveTemporaryDirectory" };

        void HandleExitUsing()
        {
            var nextStmt = ObserveNextStatement(false);
            var currentObject = _usingStack.Pop();
            if ((nextStmt.TraceType == TraceType.EnterMethod || nextStmt.TraceType == TraceType.EnterStaticMethod) &&
                ((nextStmt.CSharpSyntaxNode) is MethodDeclarationSyntax) &&
                ClosingMethods.Any(x => x.Equals(((MethodDeclarationSyntax)nextStmt.CSharpSyntaxNode).Identifier.ValueText)))
                HandleInstrumentedMethod(currentObject.Stmt, null, null, currentObject);
        }

        void HandleBodyUnexpectedTrace(Stmt statement)
        {
            // XXX: Se llama cuando hay un error de tipo de traza no esperada en el body
            // El único caso que admitimos son los callbacks del destructor que llaman al Dispose. 
            // Si es así, consumimos la traza sin darle mayor importancia
            // Según comprobaos puede caer un enter dentro de otro, por eso permitimos llamadas recursivas
            if (statement.TraceType == TraceType.EnterMethod &&
                (statement.CSharpSyntaxNode) is MethodDeclarationSyntax &&
                ClosingMethods.Any(x => x.Equals(((MethodDeclarationSyntax)statement.CSharpSyntaxNode).Identifier.ValueText)))
            {
                Stmt currentStatement = null;
                do
                {
                    currentStatement = GetNextStatement();
                    if (currentStatement.TraceType == TraceType.EnterMethod &&
                        (currentStatement.CSharpSyntaxNode) is MethodDeclarationSyntax &&
                        ClosingMethods.Any(x => x.Equals(((MethodDeclarationSyntax)currentStatement.CSharpSyntaxNode).Identifier.ValueText)))
                        HandleBodyUnexpectedTrace(currentStatement);

                } while (!(currentStatement.TraceType == TraceType.EnterFinalFinally &&
                (currentStatement.CSharpSyntaxNode) is MethodDeclarationSyntax &&
                ClosingMethods.Any(x => x.Equals(((MethodDeclarationSyntax)currentStatement.CSharpSyntaxNode).Identifier.ValueText))));
            }
            else
            {
                // TODOHACK
                if (statement.TraceType == TraceType.EndMemberAccess || statement.TraceType == TraceType.EndInvocation)
                    return;

                var lastStmt = _traceConsumer.Stack.ToList()[1];
                var localSpanStart = 0;
                var localSpanEnd = 0;
                var localFileId = lastStmt.FileId;
                if (lastStmt.CSharpSyntaxNode is ReturnStatementSyntax lastStmtRet)
                {
                    localSpanStart = lastStmtRet.Expression.Span.Start;
                    localSpanEnd = lastStmtRet.Expression.Span.End;
                } 
                else if (lastStmt.CSharpSyntaxNode is LocalDeclarationStatementSyntax lastStmtLoc)
                {
                    var lastLocN = lastStmtLoc.Declaration.Variables.FirstOrDefault().Initializer.Value;
                    localSpanStart = lastLocN.Span.Start;
                    localSpanEnd = lastLocN.Span.End;
                }
                else if (lastStmt.CSharpSyntaxNode is PrefixUnaryExpressionSyntax lastStmtPref)
                {
                    localSpanStart = lastStmtPref.Operand.Span.Start;
                    localSpanEnd = lastStmtPref.Operand.Span.End;
                } 
                else if (lastStmt.CSharpSyntaxNode is ExpressionStatementSyntax lastStmtExp)
                {
                    localSpanStart = lastStmtExp.Span.Start;
                    localSpanEnd = lastStmtExp.Span.End;
                }
                else if (lastStmt.CSharpSyntaxNode is InvocationExpressionSyntax lastStmtInv)
                {
                    localSpanStart = lastStmtInv.Span.Start;
                    localSpanEnd = lastStmtInv.Span.End;
                }

                if (localSpanStart > 0)
                { 
                    var newTuple = new Tuple<int, int, int>(localFileId, localSpanStart-1, localSpanEnd+1);
                    structsExceptions.Add(newTuple);
                    Console.WriteLine($"new Tuple<int, int, int>({localFileId}, {localSpanStart-1}, {localSpanEnd+1}),");
                }

                if (true)
                    throw new UnexpectedTrace();
            }
        }
        
        void HandleCatch(Stmt stmt)
        {
            var catchExpression = (CatchClauseSyntax)stmt.CSharpSyntaxNode;
            if (catchExpression.Declaration != null && catchExpression.Declaration.Identifier != null && catchExpression.Declaration.Identifier.Value != null)
            {
                // XXX: Para trabajar con IOperation no se puede obtener directamente el bloque del Catch. --> AHORA SI
                // Hay que obtener el bloque del TryCatch y luego seleccionar el Catch que entraste comparando el tipo sintáctico con el semántico
                // Para hacer la comparación bien tenés que comparar parte del nombre de la clase completo: Namespace1.Namespace2... etc 
                // Con parte del nombre incompleto: el sintáctico. Por eso el substring del final. Si es System.Exception el tipo posta y 
                // Dice "Exception" el sintáctico van a coincidir. Y si el sintáctico dice System.Exeption también.
                
                //var tryCatchOperation = (ITryOperation)GetOperation(catchExpression.Declaration);
                //var catchOperation = tryCatchOperation.Catches.First(x =>
                //    x.ExceptionType.ToString().Substring(
                //        x.ExceptionType.ToString().Length - catchExpression.Declaration.Type.ToString().Length,
                //        catchExpression.Declaration.Type.ToString().Length) == catchExpression.Declaration.Type.ToString());

                var catchOperation = (ICatchClauseOperation)GetOperation(catchExpression);

                var term = _termFactory.Create(catchOperation.ExceptionDeclarationOrExpression,
                    ISlicerSymbol.Create(((IVariableDeclaratorOperation)catchOperation.ExceptionDeclarationOrExpression).Symbol.Type), false, 
                    ((ILocalSymbol)((IVariableDeclaratorOperation)catchOperation.ExceptionDeclarationOrExpression).Symbol).Name,
                    false);

                //var term = _termFactory.Create(((CatchClauseSyntax)catchOperation.Syntax).Declaration,
                //    ISlicerSymbol.Create(catchOperation.Type), false, catchExpression.Declaration.Identifier.ValueText, false);
                
                if (ExceptionTerm != null)
                    _broker.Assign(term, ExceptionTerm);
                else
                    HandleNonInstrumentedMethod((IOperation)null, new List<Term>(), null, term, term.Last.Symbol.Symbol, "ctor");
            }
            throw new CatchedProgramException();
        }

        void HandleFinalCatch(Stmt currentStatement)
        {
            // XXX: Se sale del método actual inmediatamente
            _broker.ExitMethod(currentStatement, null);
            throw new ProgramException();
        }

        void HandleFinnaly(Stmt currentStatement)
        {
            bool hayOtroFinally = _traceConsumer.HasNext() && ObserveNextStatement().TraceType == TraceType.EnterFinally;
            if (_returnPostponed && !hayOtroFinally)
            {
                _sliceCriteriaReached = _broker.SliceCriteriaReached;
                _broker.ExitMethod(currentStatement, _returnObject);
                _setReturn = true;
            }
        }

        void InitializeYieldReturnContainer(CSharpSyntaxNode node)
        {
            var returnType = _methodNode 
                switch {
                    MethodDeclarationSyntax methodDeclarationSyntax => methodDeclarationSyntax.ReturnType,
                    LocalFunctionStatementSyntax localFunctionStatementSyntax => localFunctionStatementSyntax.ReturnType,
                    _ => ((PropertyDeclarationSyntax)_methodNode.Parent.Parent).Type,
                };

            yieldReturnValuesContainer = _termFactory.Create(node,
                    ISlicerSymbol.Create(((ITypeSymbol)_semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)_methodNode)
                    .GetSymbolInfo(returnType).Symbol)), false, TermFactory.GetFreshName(), false);

            _broker.HandleNonInstrumentedMethod(new List<Term>(), null, new List<Term>(), yieldReturnValuesContainer,
                ((ITypeSymbol)_semanticModelsContainer.GetBySyntaxNode((CSharpSyntaxNode)_methodNode)
                .GetSymbolInfo(returnType).Symbol), "ctor");
        }
        #endregion

        #region Utiles
        Term CreateArgument(IArgumentOperation operation)
        {
            var realTerm = Visit(operation);
            if (realTerm == null)
                return null;

            var newTerm = _termFactory.Create(operation, realTerm.Last.Symbol, realTerm.IsGlobal, TermFactory.GetFreshName());
            _broker.Assign(newTerm, realTerm);

            newTerm.IsOutOrRef = realTerm.IsOutOrRef;
            newTerm.IsRef = realTerm.IsRef;
            newTerm.ReferencedTerm = realTerm;
            return newTerm;
        }

        Term CreateArgument(ArgumentSyntax syntaxNode)
        {
            var realTerm = Visit(GetOperation(syntaxNode.Expression));
            if (realTerm == null)
                return null;

            var newTerm = _termFactory.Create(syntaxNode, realTerm.Last.Symbol, realTerm.IsGlobal, TermFactory.GetFreshName());
            _broker.Assign(newTerm, realTerm);

            newTerm.IsOutOrRef = realTerm.IsOutOrRef;
            newTerm.IsRef = realTerm.IsRef;
            newTerm.ReferencedTerm = realTerm;
            return newTerm;
        }

        Term CreateArgument(Term realTerm)
        {
            if (realTerm == null)
                return null;

            var newTerm = _termFactory.Create(realTerm.Stmt.CSharpSyntaxNode, realTerm.Last.Symbol, realTerm.IsGlobal, TermFactory.GetFreshName());
            _broker.Assign(newTerm, realTerm);

            newTerm.IsOutOrRef = realTerm.IsOutOrRef;
            newTerm.IsRef = realTerm.IsRef;
            newTerm.ReferencedTerm = realTerm;
            return newTerm;
        }

        bool HasAccesor(string Name, IDictionary<ITypeSymbol, ITypeSymbol> typesDictionary, out bool isSetAccessor)
        {
            var nextStatement = ObserveNextStatement(true, typesDictionary);
            var syntaxNode = nextStatement.CSharpSyntaxNode;
            isSetAccessor = false;

            if ((nextStatement.TraceType == TraceType.EnterMethod || nextStatement.TraceType == TraceType.EnterStaticMethod)
                && ((syntaxNode is ArrowExpressionClauseSyntax && (!(syntaxNode.Parent is MethodDeclarationSyntax)) &&
                ((syntaxNode.Parent is PropertyDeclarationSyntax && ((PropertyDeclarationSyntax)syntaxNode.Parent).Identifier.ValueText.Equals(Name))||
                (syntaxNode.Parent.Parent.Parent is PropertyDeclarationSyntax && ((PropertyDeclarationSyntax)syntaxNode.Parent.Parent.Parent).Identifier.ValueText.Equals(Name)))) ||
                (syntaxNode is AccessorDeclarationSyntax && ((syntaxNode.Parent.Parent is IndexerDeclarationSyntax) ||
                Name == "" || (((PropertyDeclarationSyntax)(syntaxNode).Parent.Parent).Identifier.ValueText.Equals(Name))))))
            {
                isSetAccessor = ((syntaxNode is AccessorDeclarationSyntax) && 
                    ((AccessorDeclarationSyntax)syntaxNode).Keyword.ValueText.Equals("set", StringComparison.OrdinalIgnoreCase)) ||
                    ((syntaxNode is ArrowExpressionClauseSyntax) && (syntaxNode.Parent is AccessorDeclarationSyntax) &&
                    ((AccessorDeclarationSyntax)syntaxNode.Parent).Keyword.ValueText.Equals("set", StringComparison.OrdinalIgnoreCase));
                return true;
            }
            
            return false;
        }

        bool IsInstrumented(string invokedFunc, IDictionary<ITypeSymbol, ITypeSymbol> typesDictionary = null, 
            bool throwExceptionOnUnexpectedTrace = true, bool structCall = false, 
            IObjectCreationOperation objectCreationOperation = null, int? @params = null, bool isStatic = false)
        {
            var stmt = ObserveNextStatement(true, typesDictionary);

            if (stmt.TraceType == TraceType.EndInvocation)
                return false;

            if (!Utils.IsEnterMethodOrConstructor(stmt.TraceType))
            {
                if (objectCreationOperation != null)
                {
                    var parentContainer = stmt.CSharpSyntaxNode.GetContainerOrConstructorInitializerSyntax();
                    if (parentContainer is ConstructorInitializerSyntax)
                    {
                        var constructor = parentContainer.GetContainer();
                        if (constructor is ConstructorDeclarationSyntax)
                        {
                            var constructorName = ((ConstructorDeclarationSyntax)constructor).Identifier.ValueText;
                            if (invokedFunc == constructorName)
                            {
                                // Look into the base call statement and get to the top
                                LookupForBaseCall((ConstructorInitializerSyntax)parentContainer);
                                return true;
                            }
                        }
                        else
                            throw new SlicerException("Unexpected behavior");
                    }
                }

                if (throwExceptionOnUnexpectedTrace && (Globals.wrap_structs_calls || !structCall))
                {
                    // TODOHACK
                    //if (stmt.TraceType == TraceType.EndMemberAccess)
                    //{
                    //    GetNextStatement();
                    //    return IsInstrumented(invokedFunc, typesDictionary, throwExceptionOnUnexpectedTrace, structCall, objectCreationOperation);
                    //}
                    return false;
                    throw new UnexpectedTrace();
                }
                else
                    return false;
            }

            CSharpSyntaxNode node = stmt.CSharpSyntaxNode;

            var methodName = "";

            if (node is ConstructorDeclarationSyntax)
                methodName = ((ConstructorDeclarationSyntax)node).Identifier.ValueText;
            else if (node is MethodDeclarationSyntax methodDeclarationSyntax)
            {
                methodName = methodDeclarationSyntax.Identifier.ValueText;
                if (invokedFunc == methodName && @params.HasValue &&
                    !methodDeclarationSyntax.ParameterList.Parameters.Any(x => x.ToString().Contains("params")))
                {
                    var paramCount = methodDeclarationSyntax.ParameterList.Parameters.Where(x => x.Default is null && !x.Modifiers.Any(y => y.ValueText == "this")).Count();
                    if (paramCount > @params.Value
                        //|| isStatic == methodDeclarationSyntax.IsStatic()
                        )
                        methodName = methodName + "!";
                }
            }
            else if (node is ArrowExpressionClauseSyntax && node.Parent is MethodDeclarationSyntax)
            {
                methodName = ((MethodDeclarationSyntax)((ArrowExpressionClauseSyntax)node).Parent).Identifier.ValueText;
                if (invokedFunc == methodName && isStatic != ((MethodDeclarationSyntax)((ArrowExpressionClauseSyntax)node).Parent).IsStatic())
                    methodName = methodName + "!";
            }
            else if (node is ArrowExpressionClauseSyntax && node.Parent is PropertyDeclarationSyntax)
                methodName = ((PropertyDeclarationSyntax)((ArrowExpressionClauseSyntax)node).Parent).Identifier.ValueText;
            else if (node is ArrowExpressionClauseSyntax && node.Parent is AccessorDeclarationSyntax && node.Parent.Parent.Parent is PropertyDeclarationSyntax)
                methodName = ((PropertyDeclarationSyntax)node.Parent.Parent.Parent).Identifier.ValueText;
            else if (node is LocalFunctionStatementSyntax)
                methodName = ((LocalFunctionStatementSyntax)node).Identifier.ValueText;
            else if (node is ArrowExpressionClauseSyntax && node.Parent is LocalFunctionStatementSyntax)
                methodName = ((LocalFunctionStatementSyntax)((ArrowExpressionClauseSyntax)node).Parent).Identifier.ValueText;
            else if (node is AccessorDeclarationSyntax)
                methodName = ((PropertyDeclarationSyntax)node.Parent.Parent).Identifier.ValueText;
            else if (node is ClassDeclarationSyntax)
                methodName = ((ClassDeclarationSyntax)node).Identifier.ValueText;
            else if (node is ConversionOperatorDeclarationSyntax)
                methodName = ((ConversionOperatorDeclarationSyntax)node).Type.ToString();
            else if (node is ArrowExpressionClauseSyntax && node.Parent is ConversionOperatorDeclarationSyntax)
                methodName = ((ConversionOperatorDeclarationSyntax)((ArrowExpressionClauseSyntax)node).Parent).Type.ToString();
            else if (node is OperatorDeclarationSyntax)
                methodName = ((OperatorDeclarationSyntax)node).GetName();
            else if (node is ArgumentSyntax)
                methodName = ((ArgumentSyntax)node).GetContainer().GetName();
            if (string.IsNullOrEmpty(methodName))
                throw new SlicerException("No se encontró el nombre del método de entrada");

            return invokedFunc == methodName;
        }

        void CheckExceptions()
        {
            if (_traceConsumer.HasNext())
            { 
                var nextStatement = ObserveNextStatement();
                if (nextStatement.TraceType == TraceType.EnterCatch)
                    HandleCatch(_traceConsumer.GetNextStatement());
                else if (nextStatement.TraceType == TraceType.EnterFinalCatch)
                    HandleFinalCatch(_traceConsumer.GetNextStatement());
                else if (nextStatement.TraceType == TraceType.ExitLoopByException)
                {
                    var tobj = _enterLoopSet.Where(x => x.Key.FileId == nextStatement.FileId && x.Key.SpanStart == nextStatement.SpanStart && x.Key.SpanEnd == nextStatement.SpanEnd).First();
                    if (tobj.Value)
                        _broker.ExitStaticMode();
                    _enterLoopSet.Remove(tobj.Key);
                    CheckExceptions();
                }
            }
        }

        List<Term> GetParameters(CSharpSyntaxNode syntaxNode, List<Term> argumentList)
        {
            var parameterSyntax = new SeparatedSyntaxList<ParameterSyntax>();
            //if (argumentList.Count > 0)
            //{
                if (syntaxNode is MethodDeclarationSyntax)
                    parameterSyntax = ((MethodDeclarationSyntax)syntaxNode).ParameterList.Parameters;
                if (syntaxNode is ArrowExpressionClauseSyntax && syntaxNode.Parent is MethodDeclarationSyntax)
                    parameterSyntax = ((MethodDeclarationSyntax)syntaxNode.Parent).ParameterList.Parameters;
                if (syntaxNode is LocalFunctionStatementSyntax)
                    parameterSyntax = ((LocalFunctionStatementSyntax)syntaxNode).ParameterList.Parameters;
                if (syntaxNode is ArrowExpressionClauseSyntax && syntaxNode.Parent is LocalFunctionStatementSyntax)
                    parameterSyntax = ((LocalFunctionStatementSyntax)syntaxNode.Parent).ParameterList.Parameters;
                if (syntaxNode is OperatorDeclarationSyntax)
                    parameterSyntax = ((OperatorDeclarationSyntax)syntaxNode).ParameterList.Parameters;
                if (syntaxNode is ConversionOperatorDeclarationSyntax)
                    parameterSyntax = ((ConversionOperatorDeclarationSyntax)syntaxNode).ParameterList.Parameters;
                if (syntaxNode is ArrowExpressionClauseSyntax && syntaxNode.Parent is ConversionOperatorDeclarationSyntax)
                    parameterSyntax = ((ConversionOperatorDeclarationSyntax)syntaxNode.Parent).ParameterList.Parameters;
                if (syntaxNode is AccessorDeclarationSyntax &&
                    ((AccessorDeclarationSyntax)syntaxNode).Keyword.ValueText.Equals("set", StringComparison.OrdinalIgnoreCase))
                {
                    if (syntaxNode.Parent.Parent is IndexerDeclarationSyntax)
                    {
                        parameterSyntax = ((IndexerDeclarationSyntax)syntaxNode.Parent.Parent).ParameterList.Parameters;
                        var parameters = parameterSyntax.Select(x => _termFactory.CreateParameterTerm(x,
                                ISlicerSymbol.Create(_semanticModelsContainer.GetBySyntaxNode(x.Type).GetTypeInfo(x.Type).Type))).ToList();
                        parameters.Add(_termFactory.CreateValueParameterTerm(argumentList.First()));
                        return parameters;
                    }
                    return new List<Term>() { _termFactory.CreateValueParameterTerm(argumentList.Last()) };
                }
                else if (syntaxNode is ArrowExpressionClauseSyntax && syntaxNode.Parent is AccessorDeclarationSyntax &&
                    ((AccessorDeclarationSyntax)syntaxNode.Parent).Keyword.ValueText.Equals("set", StringComparison.OrdinalIgnoreCase))
                    return new List<Term>() { _termFactory.CreateValueParameterTerm(argumentList.Last()) };
                if (syntaxNode is AccessorDeclarationSyntax &&
                    ((AccessorDeclarationSyntax)syntaxNode).Keyword.ValueText.Equals("get", StringComparison.OrdinalIgnoreCase) &&
                    ((AccessorDeclarationSyntax)syntaxNode).Parent.Parent is IndexerDeclarationSyntax)
                    parameterSyntax = ((IndexerDeclarationSyntax)(((AccessorDeclarationSyntax)syntaxNode).Parent.Parent)).ParameterList.Parameters;
                if (syntaxNode is ConstructorDeclarationSyntax)
                    parameterSyntax = ((ConstructorDeclarationSyntax)syntaxNode).ParameterList.Parameters;
            //}

            return parameterSyntax.Select(x => _termFactory.CreateParameterTerm(x,
                    ISlicerSymbol.Create(_semanticModelsContainer.GetBySyntaxNode(x.Type).GetTypeInfo(x.Type).Type))).ToList();
        }

        Stmt GetNextStatement(TraceType? traceType = null, bool throwException = true)
        {
            var stmt = ObserveNextStatement();
            if (traceType.HasValue && stmt.TraceType != traceType.Value)
            {
                if (stmt.TraceType == TraceType.EnterCatch)
                    HandleCatch(_traceConsumer.GetNextStatement());
                else if (stmt.TraceType == TraceType.EnterFinalCatch)
                    HandleFinalCatch(_traceConsumer.GetNextStatement());
                else if (throwException)
                    throw new SlicerException("Tipo de traza no esperada");
                else
                    return null;
            }
            return _traceConsumer.GetNextStatement();
        }

        Stmt OptionalGetNextStatement(TraceType traceType, int spanEnd)
        {
            var stmt = ObserveNextStatement();
            if (stmt.TraceType == traceType && stmt.SpanEnd == spanEnd)
                return _traceConsumer.GetNextStatement();
            return null;
        }

        Stmt ObserveNextStatement(bool consumeDispose = true, IDictionary<ITypeSymbol, ITypeSymbol> typesDictionary = null, bool allowNulls = false)
        {
            var tmp = _traceConsumer.ObserveNextStatement();
            while (tmp != null && (tmp.TraceType == TraceType.EnterStaticConstructor ||
                tmp.TraceType == TraceType.ExitLoopByException ||
                (consumeDispose && tmp.TraceType == TraceType.EnterMethod &&
                (tmp.CSharpSyntaxNode) is MethodDeclarationSyntax &&
                ((MethodDeclarationSyntax)tmp.CSharpSyntaxNode).Identifier.ValueText == "Dispose")
                
                // XXX TODO YYY IMPORTANTE
                //|| (tmp.TraceType == TraceType.SimpleStatement &&
                //tmp.CSharpSyntaxNode is VariableDeclaratorSyntax &&
                //tmp.CSharpSyntaxNode.Parent.Parent is FieldDeclarationSyntax &&
                //((VariableDeclaratorSyntax)tmp.CSharpSyntaxNode).CustomIsStatic())
                
                ))
            {
                if (tmp.TraceType == TraceType.EnterStaticConstructor)
                    HandleInstrumentedMethod((Stmt)null /*XXX: para mi está bien*/, null, null, null, typesDictionary);
                else if (tmp.TraceType == TraceType.ExitLoopByException)
                {
                    var tobj = _enterLoopSet.Where(x => x.Key.FileId == tmp.FileId && x.Key.SpanStart == tmp.SpanStart && x.Key.SpanEnd == tmp.SpanEnd).FirstOrDefault();
                    if (tobj.Key == null)
                        ;
                    if (tobj.Value)
                        _broker.ExitStaticMode();
                    _enterLoopSet.Remove(tobj.Key);
                    _traceConsumer.GetNextStatement();
                }
                //else if(tmp.TraceType == TraceType.SimpleStatement)
                //{
                //    _traceConsumer.GetNextStatement();
                //    _executedStatements.Add(tmp);
                //    VisitPropertyOrFieldDeclaration(tmp);
                //}
                else
                    HandleBodyUnexpectedTrace(_traceConsumer.GetNextStatement());

                if (allowNulls && !_traceConsumer.HasNext())
                    tmp = null;
                else
                    tmp = _traceConsumer.ObserveNextStatement();
            }
            return tmp;
        }

        void ConsumeExitLoops()
        {
            var nextStmt = ObserveNextStatement();
            while (nextStmt.TraceType == TraceType.ExitLoop)
            {
                GetNextStatement();
                nextStmt = ObserveNextStatement();
            }
        }

        Stmt LookupForEnterConstructor(Stmt enterMethodStatement, int? argsSize = null, bool consume = true)
        {
            // HACK: Por ahora, si el proximo es BeforeConstructor, lo consumimos.
            var className = ((ClassDeclarationSyntax)enterMethodStatement.CSharpSyntaxNode).Identifier.ValueText;
            var fullClassName = ((ClassDeclarationSyntax)enterMethodStatement.CSharpSyntaxNode).Identifier.ValueText + ((ClassDeclarationSyntax)enterMethodStatement.CSharpSyntaxNode).TypeParameterList?.ToString();
            Queue<Stmt> queue = new Queue<Stmt>();
            var firstTimeBefore = false;
            while (true)
            {
                Stmt lookedUpStmt = null;
                try
                { 
                    lookedUpStmt = _traceConsumer.GetNextStatement(false);
                }
                catch(Exception ex)
                {
                    // TODO: In this case is callback! (derived class outside the code non instrumented)
                    _traceConsumer.ReturnStatementsToBuffer(queue);
                    return null;
                }

                if (lookedUpStmt == null)
                {
                    _traceConsumer.ReturnStatementsToBuffer(queue);
                    return null;
                }

                var skip = false;
                if (lookedUpStmt.TraceType == TraceType.EnterConstructor ||
                    lookedUpStmt.TraceType == TraceType.BaseCall)
                {
                    string constructorClassName = null;
                    string fullConstructorClassName = null;
                    if (lookedUpStmt.CSharpSyntaxNode is ConstructorDeclarationSyntax)
                    { 
                        constructorClassName = ((ConstructorDeclarationSyntax)lookedUpStmt.CSharpSyntaxNode).Identifier.ValueText;
                        if (lookedUpStmt.CSharpSyntaxNode.Parent is ClassDeclarationSyntax)
                            fullConstructorClassName = constructorClassName + ((ClassDeclarationSyntax)lookedUpStmt.CSharpSyntaxNode.Parent).TypeParameterList?.ToString();
                        else
                            fullConstructorClassName = constructorClassName;
                            //throw new SlicerException("Unexpected");
                    }
                    else if (lookedUpStmt.CSharpSyntaxNode is ClassDeclarationSyntax)
                    { 
                        constructorClassName = ((ClassDeclarationSyntax)lookedUpStmt.CSharpSyntaxNode).Identifier.ValueText;
                        fullConstructorClassName = constructorClassName + ((ClassDeclarationSyntax)lookedUpStmt.CSharpSyntaxNode).TypeParameterList?.ToString();
                    }

                    // La condición larga es por si hay varios constructores, y uno llama a otro, queremos que coincidan la cantidad de argumentos.
                    // XXX: TODO: Creo que no cubre todos los casos, especialmente si se cumple la cantidad pero son de distinto tipo... (quiero pasar el test ComplexBase para un caso de Jolden)

                    var equalClassName = className == constructorClassName;
                    var newEqualClassName = fullClassName == fullConstructorClassName;
                    if (equalClassName != newEqualClassName)
                        ;

                    if (newEqualClassName && 
                        ((!(lookedUpStmt.CSharpSyntaxNode is ConstructorDeclarationSyntax)) 
                        || argsSize == null || (argsSize.Value == ((ConstructorDeclarationSyntax)lookedUpStmt.CSharpSyntaxNode).ParameterList.Parameters.Count) || 
                        (Utils.InRange(argsSize.Value, ((ConstructorDeclarationSyntax)lookedUpStmt.CSharpSyntaxNode).GetParametersRangeCount()))))
                    {
                        
                        if (lookedUpStmt.TraceType == TraceType.EnterConstructor)
                        {
                            enterMethodStatement = lookedUpStmt;
                            if (!consume)
                                queue.Enqueue(lookedUpStmt);
                            else
                                TraceConsumer.Instance.AppendToStack(lookedUpStmt);
                            break;
                        }
                        else
                            skip = true;
                    }
                }
                else if (lookedUpStmt.TraceType == TraceType.BeforeConstructor && 
                    lookedUpStmt.CSharpSyntaxNode == enterMethodStatement.CSharpSyntaxNode)
                {
                    if (!firstTimeBefore)
                        firstTimeBefore = true;
                    else
                    {
                        // There is a callback for derived class
                        queue.Enqueue(lookedUpStmt);
                        _traceConsumer.ReturnStatementsToBuffer(queue);
                        return null;
                    }
                }
                if (!skip)
                    queue.Enqueue(lookedUpStmt);
                else
                    TraceConsumer.Instance.AppendToStack(lookedUpStmt);
            }
            _traceConsumer.ReturnStatementsToBuffer(queue);
            return enterMethodStatement;
        }

        Stmt LookupForBaseCall(ConstructorInitializerSyntax constructorInitializerSyntax)
        {
            var constructorDeclarationSyntax = ((ConstructorDeclarationSyntax)constructorInitializerSyntax.GetContainer());
            var className = constructorDeclarationSyntax.Identifier.ValueText;
            var argSize = constructorDeclarationSyntax.GetParametersCount();
            Stmt enterMethodStatement = null;
            Queue<Stmt> queue = new Queue<Stmt>();
            while (enterMethodStatement == null)
            {
                var lookedUpStmt = _traceConsumer.GetNextStatement(false);
                if (lookedUpStmt.TraceType == TraceType.BaseCall)
                {
                    string constructorClassName = null;
                    if (lookedUpStmt.CSharpSyntaxNode is ConstructorDeclarationSyntax)
                        constructorClassName = ((ConstructorDeclarationSyntax)lookedUpStmt.CSharpSyntaxNode).Identifier.ValueText;
                    else if (lookedUpStmt.CSharpSyntaxNode is ClassDeclarationSyntax)
                        constructorClassName = ((ClassDeclarationSyntax)lookedUpStmt.CSharpSyntaxNode).Identifier.ValueText;
                    if (className == constructorClassName &&
                        ((!(lookedUpStmt.CSharpSyntaxNode is ConstructorDeclarationSyntax))
                        || argSize == ((ConstructorDeclarationSyntax)lookedUpStmt.CSharpSyntaxNode).ParameterList.Parameters.Count))
                    { 
                        enterMethodStatement = lookedUpStmt;
                        break;
                    }
                }
                queue.Enqueue(lookedUpStmt);
            }
            _traceConsumer.ReturnStatementsToBuffer(queue);
            _traceConsumer.ReturnStatementsToBuffer(new Queue<Stmt>(new Stmt[] { enterMethodStatement }));
            return enterMethodStatement;
        }

        Stmt LookupForBaseCall(CSharpSyntaxNode syntaxNode, int fileId)
        {
            Queue<Stmt> queue = new Queue<Stmt>();
            Stmt lookedUpStmt = null;
            while (true)
            {
                lookedUpStmt = _traceConsumer.GetNextStatement(false);
                //if (lookedUpStmt.TraceType == TraceType.EnterConstructor &&
                //    lookedUpStmt.SpanStart == constructorDeclarationSyntax.Span.Start
                //    && lookedUpStmt.SpanEnd == constructorDeclarationSyntax.Span.End
                //    && lookedUpStmt.FileId == fileId)
                if (lookedUpStmt == null)
                    throw new SlicerException($"Lookup for base call not found: {syntaxNode.ToString()}");
                
                if (lookedUpStmt.TraceType == TraceType.BaseCall &&
                    lookedUpStmt.SpanStart == syntaxNode.Span.Start
                    && lookedUpStmt.SpanEnd == syntaxNode.Span.End
                    && lookedUpStmt.FileId == fileId)
                {
                    _traceConsumer.ReturnStatementsToBuffer(queue);
                    var tempQueue = new Queue<Stmt>();
                    tempQueue.Enqueue(lookedUpStmt);
                    _traceConsumer.ReturnStatementsToBuffer(tempQueue);
                    break;
                }
                else
                    queue.Enqueue(lookedUpStmt);
            }
            return lookedUpStmt;
        }

        void ConsumeBeforeConstructor(CSharpSyntaxNode syntaxNode, int fileId)
        {
            Queue<Stmt> queue = new Queue<Stmt>();
            Stmt lookedUpStmt = null;
            while (true)
            {
                lookedUpStmt = _traceConsumer.GetNextStatement(false);
                if (lookedUpStmt == null)
                {
                    _traceConsumer.ReturnStatementsToBuffer(queue);
                    break;
                }

                if (lookedUpStmt.TraceType == TraceType.BeforeConstructor &&
                    lookedUpStmt.SpanStart == syntaxNode.Span.Start
                    && lookedUpStmt.SpanEnd == syntaxNode.Span.End
                    && lookedUpStmt.FileId == fileId)
                {
                    _traceConsumer.ReturnStatementsToBuffer(queue);
                    //var tempQueue = new Queue<Stmt>();
                    //tempQueue.Enqueue(lookedUpStmt);
                    //_traceConsumer.ReturnStatementsToBuffer(tempQueue);
                    break;
                }
                else
                    queue.Enqueue(lookedUpStmt);
            }
            //return lookedUpStmt;
        }

        List<Term> GetDependentTerms(CSharpSyntaxNode expression)
        {
            var returnTerms = new List<Term>();

            // Se entra en el caso de los diccionarios cuando hay 2 valores (key, value)
            if (expression is InitializerExpressionSyntax)
                foreach (var anotherExpression in ((InitializerExpressionSyntax)expression).Expressions)
                    returnTerms.AddRange(GetDependentTerms(anotherExpression));
            else
                returnTerms.Add(Visit(GetOperation(expression)));

            return returnTerms;
        }

        IOperation GetOperation(CSharpSyntaxNode syntaxNode)
        {
            if (syntaxNode is ParenthesizedExpressionSyntax)
                syntaxNode = ((ParenthesizedExpressionSyntax)syntaxNode).Expression;

            if (syntaxNode is RefExpressionSyntax)
                syntaxNode = ((RefExpressionSyntax)syntaxNode).Expression;

            if (syntaxNode is PostfixUnaryExpressionSyntax && ((PostfixUnaryExpressionSyntax)syntaxNode).OperatorToken.ValueText == "!")
                syntaxNode = ((PostfixUnaryExpressionSyntax)syntaxNode).Operand;

            var p_semanticModel = _semanticModelsContainer.GetBySyntaxNode(syntaxNode);
            var p_operation = p_semanticModel.GetOperation(syntaxNode);
            return p_operation;
        }
        #endregion
    }
}
