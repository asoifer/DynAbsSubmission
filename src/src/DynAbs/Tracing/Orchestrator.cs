using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using QuikGraph;
using Microsoft.CodeAnalysis;
using Microsoft.Build.Locator;
using Microsoft.CodeAnalysis.MSBuild;

namespace DynAbs
{
    public class Orchestrator
    {
        public UserConfiguration Configuration { get { return UserSliceConfiguration.CurrentUserConfiguration; }}
        public Solution UserSolution { get; set; }
        public Solution InstrumentedSolution { get; set; }
        public InstrumentationResult InstrumentationResult { get; private set; }
        SlicerResultsManager ResultsManager { get; set; }

        public ISet<Stmt> ExecutedStmts { get; private set; }
        public ExecutedStatementsContainer ExecutedStmtsContainer { get; private set; }
        public List<ISet<Stmt>> SlicedStmts { get; private set; }
        public AdjacencyGraph<string, Edge<string>> CompleteDependencyGraph { get; private set; }
        public List<AdjacencyGraph<string, Edge<string>>> SlicedDependencyGraphs { get; private set; }
        public bool UserInteraction { get; set; }
        public double totalSecondsInstrumentation { get; set; }

        public Orchestrator(UserConfiguration userConfiguration, params Type[] additionalTypes) : this (userConfiguration, null, additionalTypes) { }

        public Orchestrator(UserConfiguration userConfiguration, Solution userSolution, params Type[] additionalTypes)
        {
            UserSliceConfiguration.CurrentUserConfiguration = userConfiguration;
            if (userSolution == null)
            {
                if (MSBuildLocator.CanRegister)
                    MSBuildLocator.RegisterDefaults();
                var msBuildWorkspace = MSBuildWorkspace.Create();
                UserSolution = msBuildWorkspace.OpenSolutionAsync(Configuration.solutionFiles.solutionPath).Result;
            }
            else
                UserSolution = userSolution;
            Globals.UserSolution = UserSolution;
            LoadSources(additionalTypes);            
        }

        void LoadSources(params Type[] additionalTypes)
        {
            var start = System.DateTime.Now;
            if (!string.IsNullOrWhiteSpace(Configuration.solutionFiles.instrumentedSolutionPath) && File.Exists(Configuration.solutionFiles.instrumentedSolutionPath))
            {
                var msBuildWorkspace = MSBuildWorkspace.Create();
                InstrumentedSolution = msBuildWorkspace.OpenSolutionAsync(Configuration.solutionFiles.instrumentedSolutionPath).Result;
            }
            else if (string.IsNullOrWhiteSpace(Configuration.solutionFiles.compilationOutputFolder))
                throw new SlicerException("Ingrese una carpeta para guardar la compilación (tag:compilationOutputFolder)");

            var compiler = new SourceCompiler(Configuration, UserSolution, InstrumentedSolution, Configuration.criteria.mode != UserConfiguration.Criteria.CriteriaMode.LoadResults);
            InstrumentationResult = compiler.GetInstrumentationResult(additionalTypes);
            totalSecondsInstrumentation = DateTime.Now.Subtract(start).TotalSeconds;
            ResultsManager = new SlicerResultsManager(InstrumentationResult);
        }

        public void Reset(UserConfiguration userConfiguration, bool refreshSkipInfo = false)
        {
            Broker.CleanCallsInformation();

            UserSliceConfiguration.CurrentUserConfiguration = userConfiguration;
            ResultsManager = new SlicerResultsManager(InstrumentationResult);

            foreach (var project in UserSolution.Projects)
            {
                if (UserSliceConfiguration.CurrentUserConfiguration?.targetProjects?.excluded != null &&
                    ((UserSliceConfiguration.CurrentUserConfiguration.targetProjects.excluded.Any(x => x.name == project.Name && x.mode == UserConfiguration.ExcludedMode.All) ||
                    (UserSliceConfiguration.CurrentUserConfiguration.targetProjects.defaultMode == UserConfiguration.ExcludedMode.All && !UserSliceConfiguration.CurrentUserConfiguration.targetProjects.excluded.Any(x => x.name == project.Name && x.mode != UserConfiguration.ExcludedMode.All)))))
                    continue;

                var configProject = UserSliceConfiguration.CurrentUserConfiguration.targetProjects?.excluded?.FirstOrDefault(x => x.name == project.Name);
                if (configProject != null && configProject.files != null)
                {
                    foreach (var file in configProject.files)
                    {
                        if (InstrumentationResult.FileToIdDictionary.ContainsKey(file.name))
                        { 
                            var id = InstrumentationResult.FileToIdDictionary[file.name];
                            if (file.skip == true)
                                UserSliceConfiguration.FilesToSkip.Add(id);
                            else
                                UserSliceConfiguration.FilesToSkip.Remove(id);
                        }
                    }
                }
            }
        }

        public void Orchestrate()
        {
            if (InstrumentationResult == null)
                return;

            if (Configuration.criteria.mode == UserConfiguration.Criteria.CriteriaMode.OnlyInstrument)
                return;

            if (Configuration.criteria.mode != UserConfiguration.Criteria.CriteriaMode.LoadResults)
            {
                var instancesList = (Configuration.instances ?? new UserConfiguration.Instance[]{ new UserConfiguration.Instance() }).ToList();
                for (var i = 0; i < instancesList.Count; i++)
                {
                    double? tiempoGeneracionTraza = null;
                    string name = Configuration.results.name ?? "NN";
                    string arguments = instancesList[i].parameters != null ? string.Join(" ", instancesList[i].parameters) : "";
                    #region Result folder and files
                    if (!string.IsNullOrEmpty(Configuration.results.outputFolder))
                    {
                        var outputFolderForInstance = Path.Combine(Configuration.results.outputFolder, $"{name} {arguments}".Trim());
                        if (!Directory.Exists(outputFolderForInstance))
                            Directory.CreateDirectory(outputFolderForInstance);
                        // Setear los paths de la configuración completos (TODO: Completar)
                        if (!string.IsNullOrEmpty(Configuration.results.summaryResultFile))
                            Configuration.results.summaryResultFile = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.summaryResultFile));
                        if (!string.IsNullOrEmpty(Configuration.results.executedLinesFile))
                            Configuration.results.executedLinesFile = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.executedLinesFile));
                        if (!string.IsNullOrEmpty(Configuration.results.executedLinesFileForUser))
                            Configuration.results.executedLinesFileForUser = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.executedLinesFileForUser));
                        if (!string.IsNullOrEmpty(Configuration.results.resultFile))
                            Configuration.results.resultFile = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.resultFile));
                        if (!string.IsNullOrEmpty(Configuration.results.filteredResultFile))
                            Configuration.results.filteredResultFile = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.filteredResultFile));
                        if (!string.IsNullOrEmpty(Configuration.results.sliceDependenciesGraphFolder))
                            Configuration.results.sliceDependenciesGraphFolder = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.sliceDependenciesGraphFolder));
                        if (!string.IsNullOrEmpty(Configuration.results.dependencyGraphFile))
                            Configuration.results.dependencyGraphFile = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.dependencyGraphFile));
                        if (!string.IsNullOrEmpty(Configuration.results.dependencyGraphDot))
                            Configuration.results.dependencyGraphDot = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.dependencyGraphDot));
                        if (!string.IsNullOrEmpty(Configuration.results.pointsToGraphDot))
                            Configuration.results.pointsToGraphDot = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.pointsToGraphDot));
                        if (!string.IsNullOrEmpty(Configuration.results.callGraphPath))
                            Configuration.results.callGraphPath = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.callGraphPath));
                        if (!string.IsNullOrEmpty(Configuration.results.executedMethodsInfo))
                            Configuration.results.executedMethodsInfo = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.executedMethodsInfo));
                        if (!string.IsNullOrEmpty(Configuration.results.executedCallbacksInfo))
                            Configuration.results.executedCallbacksInfo = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.executedCallbacksInfo));
                        if (!string.IsNullOrEmpty(Configuration.results.skippedFilesInfo))
                            Configuration.results.skippedFilesInfo = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.skippedFilesInfo));
                        if (!string.IsNullOrEmpty(Configuration.results.debugProfileDataFile))
                            Configuration.results.debugProfileDataFile = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.debugProfileDataFile));
                        if (!string.IsNullOrEmpty(Configuration.results.debugInternalSolverProfileFile))
                            Configuration.results.debugInternalSolverProfileFile = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.debugInternalSolverProfileFile));
                        if (!string.IsNullOrEmpty(Configuration.results.debugPTGEvolutionFile))
                            Configuration.results.debugPTGEvolutionFile = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.debugPTGEvolutionFile));
                        if (!string.IsNullOrEmpty(Configuration.results.mainResultsFolder))
                        {
                            Configuration.results.mainResultsFolder = Path.Combine(outputFolderForInstance, Path.GetFileName(Configuration.results.mainResultsFolder));
                            if (!Directory.Exists(Configuration.results.mainResultsFolder))
                                Directory.CreateDirectory(Configuration.results.mainResultsFolder);
                        }
                    }
                    #endregion

                    #region Corrida y generación de traza
                    if (Configuration.criteria.runAutomatically && string.IsNullOrWhiteSpace(Configuration.criteria.fileTraceInputPath))
                    {
                        if (InstrumentationResult.Executable.EndsWith(".csproj"))
                        {
                            var execResult = Utils.RunProject(InstrumentationResult.Executable, arguments, 60000);
                            tiempoGeneracionTraza = execResult.Timeout ? int.MaxValue : execResult.ElapsedTime.TotalSeconds;
                        }
                        else
                        {
                            var windowsStyle = UserInteraction ? ProcessWindowStyle.Normal : ProcessWindowStyle.Hidden;
                            var process = new Process { StartInfo = { FileName = InstrumentationResult.Executable, WindowStyle = windowsStyle, Arguments = arguments } };
                            process.Start();

                            // Si usamos archivo, hay que esperar a que el proceso termine y escriba toda la traza.
                            if (Configuration.criteria.fileTraceInput)
                            {
                                process.WaitForExit();
                                tiempoGeneracionTraza = process.ExitTime.Subtract(process.StartTime).TotalSeconds;
                            }
                        }
                    }

                    string fileTraceInputPath = null;
                    if (Configuration.criteria.fileTraceInput)
                    {
                        if (string.IsNullOrWhiteSpace(Configuration.criteria.fileTraceInputPath))
                            fileTraceInputPath = Path.Combine(Path.GetDirectoryName(InstrumentationResult.Executable), Tracing.TracerGlobals.FileTraceInput);
                        else
                            fileTraceInputPath = Configuration.criteria.fileTraceInputPath;
                    }
                    #endregion

                    #region Consumo de traza
                    var filesLines = new List<Tuple<int, int>>();
                    if (Configuration.criteria.lines != null)
                        foreach (var fileLine in Configuration.criteria.lines)
                            filesLines.Add(new Tuple<int, int>(InstrumentationResult.IdToFileDictionary.Single(x => 
                                System.IO.Path.GetFileName(fileLine.file) == fileLine.file ?
                                System.IO.Path.GetFileName(x.Value).Equals(System.IO.Path.GetFileName(fileLine.file)) :
                                x.Value == System.IO.Path.GetFullPath(fileLine.file)).Key, fileLine.line.Value));

                    var atEndModes = new UserConfiguration.Criteria.CriteriaMode[] { 
                        UserConfiguration.Criteria.CriteriaMode.AtEnd, UserConfiguration.Criteria.CriteriaMode.AtEndWithCriteria };
                    var mainTraceConsumer = new MainTraceConsumer(InstrumentationResult, 
                        Configuration.criteria.mode == UserConfiguration.Criteria.CriteriaMode.AtEnd ? (List<Tuple<int, int>>)null : filesLines, fileTraceInputPath);
                    var hasError = false;
                    var errMsg = "";
                    try
                    {
                        mainTraceConsumer.Launch(Configuration.criteria.mode == UserConfiguration.Criteria.CriteriaMode.TraceAnalysis);
                    }
                    catch(Exception ex)
                    {
                        hasError = true;
                        errMsg = ex.Message;
                    }

                    if (hasError)
                    {
                        var processed = mainTraceConsumer._traceConsumer.Stack.Count;
                        var total = System.IO.File.ReadAllLines(fileTraceInputPath).Length - 1;
                        var percentage = Math.Round((decimal)processed * (decimal)100 / (decimal)total, 0);

                        throw new SlicerException(errMsg + $" - {processed}/{total} ({percentage}%)"); 
                        // ("Se produjo una excepción no controlada");
                    }
                    #endregion

                    #region Guardado de datos
                    #region Datos principales de la corrida
                    var slicesSummaryData = mainTraceConsumer.GetDataForeachSlice();
                    foreach (var data in slicesSummaryData)
                    {
                        var executionSeconds = data.ElapsedTime.TotalSeconds;
                        var totalTraceLines = data.TotalTraceLines;
                        var totalSkippedTrace = data.TotalSkippedTrace;
                        var totalReceivedTrace = data.TotalReceivedTrace;
                        var totalStatementsLines = data.TotalStatements;
                        var distinctStatementLines = data.DistinctStatements;
                        var slicedStatements = data.SlicedStatements.Count;
                        var generationTraceTime = (tiempoGeneracionTraza.HasValue ? tiempoGeneracionTraza.Value.ToString() : "");
                        var skippedTrace = totalSkippedTrace.HasValue ? totalSkippedTrace.ToString() : "";
                        var skippedLinesPercent = totalSkippedTrace.HasValue ? Math.Round(totalSkippedTrace.Value * (double)100 / totalReceivedTrace.Value, 0).ToString() : "";
                        var traceSize = fileTraceInputPath != null ? Math.Round(new System.IO.FileInfo(fileTraceInputPath).Length / (double)1024).ToString() : "";

                        Console.WriteLine("Instrumentación: " + totalSecondsInstrumentation);
                        Console.WriteLine("Tiempo generación traza: " + generationTraceTime);
                        Console.WriteLine("Ejecución Total: " + executionSeconds);
                        Console.WriteLine("Cantidad de Stmt: " + totalStatementsLines);
                        Console.WriteLine("Cantidad de Stmt Distintos: " + distinctStatementLines);
                        Console.WriteLine("Cantidad de Stmt Slice: " + slicedStatements);
                        Console.WriteLine("Líneas de traza: " + totalTraceLines);
                        Console.WriteLine("Líneas salteadas: " + (!totalSkippedTrace.HasValue ? "-" : string.Format("{0}/{1} ({2}%)", totalSkippedTrace, totalReceivedTrace, skippedLinesPercent)));
                        Console.WriteLine("----------------------------");
                        
                        // Nombre|Inputs|#Stmt|#UniqueStmt|#Slice|T. Instr|T. traza|T. Ejecución|Size Traza|Traza Total|Traza Salteada|%Salteado
                        if (!string.IsNullOrWhiteSpace(Configuration.results.summaryResultFile))
                            System.IO.File.AppendAllLines(string.Format(Configuration.results.summaryResultFile, i),
                                new string[] { $"{name}|{arguments}|{totalStatementsLines}|{distinctStatementLines}|{slicedStatements}|{totalSecondsInstrumentation}|" +
                                            $"{generationTraceTime}|{executionSeconds}|{traceSize}|{totalTraceLines}|{skippedTrace}|{skippedLinesPercent}" });
                    }
                    #endregion

                    #region Datos de medición (solo disponibles en modo DEBUG)
                    if (MainTraceConsumer.TimeMeasurement)
                    {
                        // Esta información la guardamos siempre en modo debug (por ahora)
                        var debugProfileDataFile = string.IsNullOrWhiteSpace(Configuration.results.debugProfileDataFile) ? @"C:\temp\tiempos\totalTimes.txt" : Configuration.results.debugProfileDataFile;
                        GlobalPerformanceValues.Save(debugProfileDataFile, mainTraceConsumer.entryPointClassName, mainTraceConsumer.elapsedTime, mainTraceConsumer.totalStatementLines, fileTraceInputPath);

                        if (Configuration.criteria.mode != UserConfiguration.Criteria.CriteriaMode.TraceAnalysis)
                        { 
                            if (!string.IsNullOrWhiteSpace(Configuration.results.debugMemoryConsumptionFile))
                                GlobalPerformanceValues.MemoryConsumptionValues.Save(string.Format(Configuration.results.debugMemoryConsumptionFile, i));

                            mainTraceConsumer.SaveBrokerAndAliasingSolverData(Configuration.results.debugMethodsCounterFile, Configuration.results.debugPTGEvolutionFile, Configuration.results.debugInternalSolverProfileFile);
                        }
                    }
                    else if (Configuration.criteria.mode != UserConfiguration.Criteria.CriteriaMode.TraceAnalysis)
                        mainTraceConsumer.SaveBrokerAndAliasingSolverData(string.Empty, Configuration.results.debugPTGEvolutionFile, Configuration.results.debugInternalSolverProfileFile);
                    #endregion 

                    ExecutedStmtsContainer = mainTraceConsumer.GetExecutedStatements();
                    ExecutedStmts = ExecutedStmtsContainer.ExecutedStatements;
                    if (!string.IsNullOrWhiteSpace(Configuration.results.executedLinesFile))
                        ResultsManager.SaveExecutedStatements(ExecutedStmts, string.Format(Configuration.results.executedLinesFile, i));

                    if (!string.IsNullOrWhiteSpace(Configuration.results.executedLinesFileForUser))
                        ResultsManager.SaveExecutedStatementsForUser(ExecutedStmtsContainer, string.Format(Configuration.results.executedLinesFileForUser, i));

                    if (Configuration.criteria.mode != UserConfiguration.Criteria.CriteriaMode.TraceAnalysis)
                    {
                        CompleteDependencyGraph = mainTraceConsumer.GetSliceDependencyGraph();
                        if (!string.IsNullOrWhiteSpace(Configuration.results.dependencyGraphFile))
                            ResultsManager.SaveDependencyGraph(CompleteDependencyGraph, Configuration.results.dependencyGraphFile);

                        if (!string.IsNullOrWhiteSpace(Configuration.results.debugLOTraceConsumer))
                            mainTraceConsumer.SaveLOTraceData(Configuration.results.debugLOTraceConsumer);

                        if (!string.IsNullOrWhiteSpace(Configuration.results.callGraphPath))
                            mainTraceConsumer.PrintCallGraph(Configuration.results.callGraphPath);

                        mainTraceConsumer.SaveExecutedMethodsAndCallbacks(Configuration.results.executedMethodsInfo, Configuration.results.executedCallbacksInfo);

                        Utils.SaveSkippedFilesInfo(Configuration?.results?.skippedFilesInfo, fileTraceInputPath, InstrumentationResult, UserSolution);

                        if (Configuration.criteria.mode != UserConfiguration.Criteria.CriteriaMode.AtEnd)
                        {
                            SlicedStmts = new List<ISet<Stmt>>(mainTraceConsumer.resultSummarydata.Select(x => x.SlicedStatements));
                            if (!string.IsNullOrWhiteSpace(Configuration.results.resultFile))
                                Utils.SaveSliceResult(mainTraceConsumer.resultSummarydata, string.Format(Configuration.results.resultFile, i));

                            if (!string.IsNullOrWhiteSpace(Configuration.results.filteredResultFile))
                                Utils.SaveFilteredSliceResult(mainTraceConsumer.resultSummarydata, ExecutedStmtsContainer, string.Format(Configuration.results.filteredResultFile, i));

                            SlicedDependencyGraphs = mainTraceConsumer.GetSliceDependenciesGraph();
                            if (!string.IsNullOrWhiteSpace(Configuration.results.sliceDependenciesGraphFolder))
                            {
                                Utils.SaveSliceDependenciesGraphResult(SlicedDependencyGraphs, mainTraceConsumer.GetDependencyGraphVertexLabels(), Configuration.results.sliceDependenciesGraphFolder);
                                ResultsManager.SaveDependencyGraph(SlicedDependencyGraphs, Configuration.results.sliceDependenciesGraphFolder);
                            }
                        }

                        #region DOT
                        try
                        {
                            if (!string.IsNullOrWhiteSpace(Configuration.results.dependencyGraphDot))
                                mainTraceConsumer.PrintGraph(string.Format(Configuration.results.dependencyGraphDot, i));
                            if (!string.IsNullOrWhiteSpace(Configuration.results.pointsToGraphDot))
                                mainTraceConsumer.PrintPTG(string.Format(Configuration.results.pointsToGraphDot, i));
                        }
                        catch (Exception)
                        {

                        }
                    }
                    #endregion
                    #endregion
                }
            }
            else
            {
                ExecutedStmts = ResultsManager.LoadExecutedStatements(Configuration.results.executedLinesFile);
                CompleteDependencyGraph = ResultsManager.LoadDependencyGraph(Configuration.results.dependencyGraphFile);
                if (!string.IsNullOrWhiteSpace(Configuration.results.sliceDependenciesGraphFolder))
                    SlicedDependencyGraphs = new List<AdjacencyGraph<string, Edge<string>>>() { ResultsManager.LoadDependencyGraph(
                        System.IO.Directory.GetFiles(Configuration.results.sliceDependenciesGraphFolder).First(x => x.EndsWith(".dg"))) };
            }
        }

        public BrowsingData GetReducedDependencyGraph()
        {
            return new BrowsingData(ResultsManager, CompleteDependencyGraph);
        }

        public BrowsingData GetReducedSliceDependencyGraph()
        {
            if (SlicedDependencyGraphs.Count > 0)
                return new BrowsingData(ResultsManager, SlicedDependencyGraphs.First());
            return null;
        }
    }
}
