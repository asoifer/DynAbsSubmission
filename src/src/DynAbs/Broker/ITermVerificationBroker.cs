using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DynAbs
{
    public class TermVerificationBroker : IBroker
    {
        IBroker broker;

        public TermVerificationBroker(IAliasingSolver aliasingSolver, IDependencyGraph dependencyGraph, IControlManagement controlManagement)
        {
            broker = new PerformanceTestBroker(aliasingSolver, dependencyGraph, controlManagement);
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
            argumentTermList.ToList().ForEach(x => CheckTerm(x));
            parameterTermList.ToList().ForEach(x => CheckTerm(x));
            CheckTerm(@this);
            CheckTerm(receiver);
            broker.EnterMethod(methodSymbol, argumentTermList, parameterTermList, receiver, @this, invocationPoint, enterMethodStatement);
        }

        public void ExitMethod(Stmt exitMethodStatement, Term returnValue)
        {
            CheckTerm(returnValue);
            broker.ExitMethod(exitMethodStatement, returnValue);
        }

        public void Alloc(Term term)
        {
            CheckTerm(term);
            broker.Alloc(term);
        }

        public void DefExternalOperation(Term defTerm)
        {
            throw new SlicerException("No puede llamarse desde afuera");
        }

        public void DefUseOperation(ISet<Term> defTerms, ISet<Term> useTerms)
        {
            defTerms.ToList().ForEach(x => CheckTerm(x));
            useTerms.ToList().ForEach(x => CheckTerm(x));
            broker.DefUseOperation(defTerms, useTerms);
        }

        public void DefUseOperation(Term defTerm, Term[] useTerms)
        {
            CheckTerm(defTerm);
            useTerms.ToList().ForEach(x => CheckTerm(x));
            broker.DefUseOperation(defTerm, useTerms);
        }

        public void DefUseOperation(Term defTerm)
        {
            CheckTerm(defTerm);
            broker.DefUseOperation(defTerm);
        }

        public void UseOperation(Stmt stmt, List<Term> useTerms)
        {
            useTerms.ToList().ForEach(x => CheckTerm(x));
            broker.UseOperation(stmt, useTerms);
        }

        public void Assign(Term defTerm, Term useTerm)
        {
            CheckTerm(defTerm);
            CheckTerm(useTerm);
            broker.Assign(defTerm, useTerm);
        }

        public void Assign(Term defTerm, Term useTerm, List<Term> anotherUses)
        {
            CheckTerm(defTerm);
            CheckTerm(useTerm);
            if (anotherUses != null)
                foreach (var t in anotherUses)
                    CheckTerm(t);
            broker.Assign(defTerm, useTerm, anotherUses);
        }

        public void RedefineType(Term term)
        {
            CheckTerm(term);
            broker.RedefineType(term);
        }

        public void AssignRV(Term returnValue)
        {
            CheckTerm(returnValue);
            broker.AssignRV(returnValue);
        }

        public void HandleNonInstrumentedMethod(List<Term> argumentTermList, Term @this, List<Term> returnedValues, Term returnValue, ISymbol symbol, string methodName = null)
        {
            argumentTermList.ForEach(x => CheckTerm(x));
            returnedValues.ForEach(x => CheckTerm(x));
            CheckTerm(@this);
            CheckTerm(returnValue);
            broker.HandleNonInstrumentedMethod(argumentTermList, @this, returnedValues, returnValue, symbol, methodName);
        }

        public void CatchReturnedValueIntoRegion(Term region, Term returnedValue)
        {
            broker.CatchReturnedValueIntoRegion(region, returnedValue);
        }

        public void HandleArrayInitialization(List<Term> argumentTermList, List<Term> returnedValues, Term returnValue)
        {
            argumentTermList.ForEach(x => CheckTerm(x));
            CheckTerm(returnValue);
            broker.HandleArrayInitialization(argumentTermList, returnedValues, returnValue);
        }

        public void CreateNonInstrumentedRegion(List<Term> involvedTerms, Term returnValue)
        {
            involvedTerms.ForEach(x => CheckTerm(x));
            CheckTerm(returnValue);
            broker.CreateNonInstrumentedRegion(involvedTerms, returnValue);
        }

        public void CustomEvent(List<Term> argumentTermList, Term @this, List<Term> returnedValues, Term returnValue, string EventName)
        {
            broker.CustomEvent(argumentTermList, @this, returnedValues, returnValue, EventName);
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

        void CheckTerm(Term term)
        {
            if (term != null && term.Parts.Any(x => x.Symbol == null || (!x.Symbol.IsAnonymous && !x.Symbol.IsNullSymbol && !x.Symbol.IsObject && x.Symbol.Symbol == null)))
                throw new SlicerException("Todos los fields tienen que tener símbolo");
        }

        public List<ResultSummaryData> SlicesSummaryData { get { return broker.SlicesSummaryData; } }
    }
}
