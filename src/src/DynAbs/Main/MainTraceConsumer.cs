using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DynAbs.Tracing;
using System.IO;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using QuikGraph;

namespace DynAbs
{
    public class MainTraceConsumer
    {
        #region Properties
        // Estructuras principales
        public ITraceConsumer _traceConsumer;
        ITraceReceiver _traceReceiver;
        IAliasingSolver _aliasingSolver;
        IDependencyGraph _dependencyGraph;
        IBroker _broker;
        ISemanticModelsContainer _semanticModelsContainer;
        TermFactory _termFactory;
        ExecutedStatementsContainer _executedStatements;

        // Information
        public TimeSpan elapsedTime { internal set; get; }
        public double totalTraceLines { internal set; get; }
        public double? totalSkippedTrace { internal set; get; }
        public double? totalReceivedTrace { internal set; get; }
        public double totalStatementLines { internal set; get; }
        public double distinctStatementLines { internal set; get; }
        public string entryPointClassName { internal set; get; }
        public List<ResultSummaryData> resultSummarydata { internal set; get; }
        public static bool TimeMeasurement { internal set; get; }
        #endregion

        #region Constructor
        public MainTraceConsumer(InstrumentationResult instrumentationResult, List<Tuple<int, int>> fileLines, string traceInput) 
        {
            Globals.InstrumentationResult = instrumentationResult;
            var _tempDependencyGraph = new SubsumedDependencyGraph();

            IAliasingSolver _tempAliasingSolver = null;
            var memoryModelKind = UserSliceConfiguration.CurrentUserConfiguration?.customization != null ?
                UserSliceConfiguration.CurrentUserConfiguration?.customization.memoryModel : UserConfiguration.MemoryModelKind.Clusters;
            switch (memoryModelKind)
            {
                case UserConfiguration.MemoryModelKind.Default:
                    _tempAliasingSolver = new BasicSolver();
                    break;
                case UserConfiguration.MemoryModelKind.Annotations:
                    _tempAliasingSolver = new AnnotationsSolver();
                    break;
                case UserConfiguration.MemoryModelKind.Speed:
                    _tempAliasingSolver = new SpeedSolver();
                    break;
                case UserConfiguration.MemoryModelKind.Mixed:
                    _tempAliasingSolver = new MixedSolver();
                    break;
                case UserConfiguration.MemoryModelKind.Clusters:
                    _tempAliasingSolver = new DynAbs.Aliasing.CS.ClustersSolver();
                    break;
                default:
                    _tempAliasingSolver = new DynAbs.Aliasing.CS.ClustersSolver();
                    break;
            }

            _tempAliasingSolver = new TermInitializerSolver(_tempAliasingSolver);

            _traceReceiver = Globals.loops_optimization_enabled ? 
                new LOTraceReceiver(_tempAliasingSolver, traceInput) : (ITraceReceiver)new TraceReceiver(traceInput);
            var _tempTraceConsumer = (UserSliceConfiguration.CurrentUserConfiguration.criteria.mode == UserConfiguration.Criteria.CriteriaMode.AtEnd) 
                ? TraceConsumer.CreateInstance(_traceReceiver) : TraceConsumer.CreateInstance(_traceReceiver, fileLines);
            
            var _timeMeasurementOnDebugMode = true;
            #if DEBUG
                TimeMeasurement = _timeMeasurementOnDebugMode;
            #else
                TimeMeasurement = false;
            #endif
            if (TimeMeasurement)
            {
                // Limpiamos las globales (cuando corremos muchas instancias quedan sucias)
                GlobalPerformanceValues.Clean();
                _dependencyGraph = new PerformanceTestDependencyGraph(_tempDependencyGraph);
                _aliasingSolver = new PerformanceTestAliasingSolver(_tempAliasingSolver);
                _traceConsumer = new PerformanceTestTraceConsumer(_tempTraceConsumer);
                _broker = new PerformanceTestBroker(_aliasingSolver, _dependencyGraph, new ControlManagement());
            }
            else
            {
                _dependencyGraph = _tempDependencyGraph;
                _aliasingSolver = _tempAliasingSolver;
                _traceConsumer = _tempTraceConsumer;
                _broker = new TermInitializerBroker(_aliasingSolver, _dependencyGraph, new ControlManagement());
            }

            // TODO: Acomodar
            //_traceConsumer = new SkipFilesTraceConsumer(_traceConsumer);

            _semanticModelsContainer = new SemanticModelsContainer(instrumentationResult);
            _termFactory = new TermFactory();
            _executedStatements = new ExecutedStatementsContainer();
            
        }
        #endregion

        #region Interface implementation
        public void Launch(bool onlyTraceAnalysis)
        {
            Utils.Print("Starting... " + DateTime.Now.ToString("HH:mm"));
            Globals.start_time = DateTime.Now;
            ProcessConsumer.lastTraceAmount = 0;
            string tempEntryPointClassName;
            if (onlyTraceAnalysis)
            {
                var traceAnalyzer = new TraceAnalyzer(_traceConsumer, _semanticModelsContainer, Globals.InstrumentationResult, _executedStatements);
                traceAnalyzer.Analyze(out tempEntryPointClassName);
                resultSummarydata = traceAnalyzer.SlicesSummaryData;
            }
            else
            {
                var processconsumer = new ProcessConsumer(_traceConsumer, _broker, _semanticModelsContainer, Globals.InstrumentationResult, _termFactory, _executedStatements);
                processconsumer.FirstProcess(out tempEntryPointClassName);
                resultSummarydata = _broker.SlicesSummaryData;
            }
            Utils.Print("Finalizing... " + DateTime.Now.ToString("HH:mm"));
            entryPointClassName = tempEntryPointClassName;
            elapsedTime = DateTime.Now.Subtract(Globals.start_time);
            totalTraceLines = _traceConsumer.TotalTracedLines;
            totalSkippedTrace = _traceReceiver is LOTraceReceiver ? ((LOTraceReceiver)_traceReceiver).SkippedCounter : (double?)null;
            totalReceivedTrace = _traceReceiver is LOTraceReceiver ? ((LOTraceReceiver)_traceReceiver).Past.Count : (double?)null;
            totalStatementLines = _executedStatements.ExecutedStatmentsCounter;
            distinctStatementLines = _executedStatements.DistinctExecutedLines;

            if (UserSliceConfiguration.CurrentUserConfiguration.criteria.mode == UserConfiguration.Criteria.CriteriaMode.AtEnd)
            {
                var data = new ResultSummaryData(_traceConsumer, _executedStatements, DateTime.Now.Subtract(Globals.start_time));
                data.SlicedStatements = new HashSet<Stmt>();
                resultSummarydata = new List<ResultSummaryData>() { data };
            }
        }

        public List<ResultSummaryData> GetDataForeachSlice() { return resultSummarydata; }
        public List<ISet<Stmt>> GetSlicedStatements() { return _broker.GetSlices(); }
        public List<AdjacencyGraph<string, Edge<string>>> GetSliceDependenciesGraph() { return _dependencyGraph.GetDependenciesGraphs(); }
        public AdjacencyGraph<string, Edge<string>> GetSliceDependencyGraph() { return _dependencyGraph.GetCompleteDependencyGraph(); }
        public IDictionary<string, string> GetDependencyGraphVertexLabels() { return _dependencyGraph.GetVertexLabels(); }
        public ExecutedStatementsContainer GetExecutedStatements() { return _executedStatements; }
        public void PrintGraph(string writeToFile) { _dependencyGraph.PrintGraph(writeToFile); }
        public void PrintPTG(string writeToFile) { _aliasingSolver.DumpPTG(writeToFile); }
        public void SaveBrokerAndAliasingSolverData(string methodsFile, string pointsToEvolutionFile, string internalSolverProfileFile)
        {
            _aliasingSolver.SaveResults(pointsToEvolutionFile, internalSolverProfileFile);
            //if (_broker is PerformanceTestBroker)
            //    ((PerformanceTestBroker)_broker).SaveResults(methodsFile);
        }
        public void SaveLOTraceData(string writeToFile)
        {
            if (_traceReceiver is LOTraceReceiver)
                ((LOTraceReceiver)_traceReceiver).PrintValues(writeToFile);
        }
        public void SaveExecutedMethodsAndCallbacks(string executedMethodsFile, string executedCallbacksFile)
        {
            Broker.SaveCallsInformation(executedMethodsFile, executedCallbacksFile);
        }
        public void PrintCallGraph(string path) { Broker.Instance.PrintCallGraph(path); }
        #endregion
    }
}

