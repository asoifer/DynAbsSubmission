using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynAbs
{
    public class TermInitializerBroker : IBroker
    {
        IBroker broker;

        public TermInitializerBroker(IAliasingSolver aliasingSolver, IDependencyGraph dependencyGraph, IControlManagement controlManagement)
        {
            broker = Broker.CreateInstance(aliasingSolver, dependencyGraph, controlManagement);
        }

        public IAliasingSolver Solver
        {
            get { return broker.Solver; }
        }

        public IDependencyGraph DependencyGraph
        {
            get { return broker.DependencyGraph; }
        }

        public bool SliceCriteriaReached
        {
            get
            {
                return broker.SliceCriteriaReached;
            }
            set
            {
                broker.SliceCriteriaReached = value;
            }
        }

        public void Break()
        {
            broker.Break();
        }

        public void Continue()
        {
            broker.Continue();
        }

        public void EnterCondition(Stmt stmt)
        {
            broker.EnterCondition(stmt);
        }

        public void ExitCondition(Stmt stmt)
        {
            broker.ExitCondition(stmt);
        }

        public void EnterMethod(string methodSymbol, List<Term> argumentTermList, List<Term> parameterTermList, Term receiver, Term @this, Stmt invocationPoint, Stmt enterMethodStatement)
        {
            try
            {
                broker.EnterMethod(methodSymbol, argumentTermList, parameterTermList, receiver, @this, invocationPoint, enterMethodStatement);
            }
            catch (UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                EnterMethod(methodSymbol, argumentTermList, parameterTermList, receiver, @this, invocationPoint, enterMethodStatement);
            }
        }

        public void ExitMethod(Stmt exitMethodStatement, Term returnValue)
        {
            broker.ExitMethod(exitMethodStatement, returnValue);
        }

        public void Alloc(Term term)
        {
            try
            {
                broker.Alloc(term);
            }
            catch (UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                broker.Alloc(term);
            }
        }

        public void DefExternalOperation(Term defTerm)
        {
            throw new SlicerException("No se puede llamar desde otro lado");
        }

        public void DefUseOperation(ISet<Term> defTerms, ISet<Term> useTerms)
        {
            try
            { 
                broker.DefUseOperation(defTerms, useTerms);
            }
            catch(UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                DefUseOperation(defTerms, useTerms);
            }
        }

        public void DefUseOperation(Term defTerm, Term[] useTerms)
        {
            try
            {
                broker.DefUseOperation(defTerm, useTerms);
            }
            catch (UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                DefUseOperation(defTerm, useTerms);
            }
        }

        public void DefUseOperation(Term defTerm)
        {
            broker.DefUseOperation(defTerm);
        }

        public void UseOperation(Stmt stmt, List<Term> useTerms)
        {
            try
            {
                broker.UseOperation(stmt, useTerms);
            }
            catch (UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                UseOperation(stmt, useTerms);
            }
        }

        public void Assign(Term defTerm, Term useTerm)
        {
            try
            {
                broker.Assign(defTerm, useTerm);
            }
            catch (UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                Assign(defTerm, useTerm);
            }
        }

        public void Assign(Term defTerm, Term useTerm, List<Term> anotherUses)
        {
            try
            {
                broker.Assign(defTerm, useTerm, anotherUses);
            }
            catch (UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                Assign(defTerm, useTerm, anotherUses);
            }
        }

        public void RedefineType(Term term)
        {
            broker.RedefineType(term);
        }

        public void AssignRV(Term returnValue)
        {
            broker.AssignRV(returnValue);
        }

        public void HandleNonInstrumentedMethod(List<Term> argumentTermList, Term @this, List<Term> returnedValues, Term returnValue, ISymbol symbol, string methodName = null)
        {
            try
            {
                broker.HandleNonInstrumentedMethod(argumentTermList, @this, returnedValues, returnValue, symbol, methodName);
            }
            catch (UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                HandleNonInstrumentedMethod(argumentTermList, @this, returnedValues, returnValue, symbol, methodName);
            }
        }

        public void HandleArrayInitialization(List<Term> argumentTermList, List<Term> returnedValues, Term returnValue)
        {
            try
            {
                broker.HandleArrayInitialization(argumentTermList, returnedValues, returnValue);
            }
            catch (UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                HandleArrayInitialization(argumentTermList, returnedValues, returnValue);
            }
        }

        public void CreateNonInstrumentedRegion(List<Term> involvedTerms, Term returnValue)
        {
            try
            {
                broker.CreateNonInstrumentedRegion(involvedTerms, returnValue);
            }
            catch (UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                CreateNonInstrumentedRegion(involvedTerms, returnValue);
            }
        }

        public void CatchReturnedValueIntoRegion(Term region, Term returnedValue)
        {
            try
            {
                broker.CatchReturnedValueIntoRegion(region, returnedValue);
            }
            catch (UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                CatchReturnedValueIntoRegion(region, returnedValue);
            }
        }

        public void CustomEvent(List<Term> argumentTermList, Term @this, List<Term> returnedValues, Term returnValue, string EventName)
        {
            try
            {
                broker.CustomEvent(argumentTermList, @this, returnedValues, returnValue, EventName);
            }
            catch (UninitializedTerm uninitializedTerm)
            {
                InitializeTerm(uninitializedTerm.Term);
                CustomEvent(argumentTermList, @this, returnedValues, returnValue, EventName);
            }
        }

        public bool EnterStaticMode(bool EnterByCallbacks = false)
        {
            return broker.EnterStaticMode(EnterByCallbacks);
        }

        public void ExitStaticMode()
        {
            broker.ExitStaticMode();
        }

        public bool StaticMode { get { return broker.StaticMode; } }

        public void CleanTemporaryEntries()
        {
            broker.CleanTemporaryEntries();
        }

        public void Slice(ResultSummaryData data)
        {
            broker.Slice(data);
        }

        public List<ISet<Stmt>> GetSlices()
        {
            return broker.GetSlices();
        }

        ISet<string> termsToInit = new HashSet<string>();
        public void InitializeTerm(Term term)
        {
            var added = termsToInit.Add(term.ToString());
            if (!added)
                throw new NonGlobalUninitializedTerm(term);

            if (!term.IsGlobal)
            {
                if (term.Count > 1)
                {
                    broker.DefUseOperation(term, new Term[] { term.DiscardLast() });
                    return;
                }
                throw new NonGlobalUninitializedTerm(term);
            }

            //#if DEBUG
            //Utils.Print("InitializeTerm: " + term.ToString());
            //#endif

            if (!term.IsScalar)
                Alloc(term);
            broker.DefExternalOperation(term);
        }

        public void EnterLoop()
        {
            broker.EnterLoop();
        }
        public void NextLoopIteration()
        {
            broker.NextLoopIteration();
        }
        public void ExitLoop()
        {
            broker.ExitLoop();
        }

        public List<ResultSummaryData> SlicesSummaryData { get { return broker.SlicesSummaryData; } }
    }
}
