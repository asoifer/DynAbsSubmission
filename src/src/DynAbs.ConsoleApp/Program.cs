using DynAbs;
using Microsoft.CodeAnalysis;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Serialization;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SliceConsole
{
    class Program
    {
        enum ConsoleMode
        {
            Default=1,
            MultipleFiles=2,
            MultipleConfigurations=3,
            MultipleInputs=4
        }

        static string[] defaultConfigPaths;
        static bool useJustTheseFiles;
        static string[] justTheseFiles;
        static bool excludedFilesEnabled;
        static string[] excludedFolders;
        static bool useSameCompilation;
        static bool useTraces;
        static string[] traces;
        static bool useAnnotations;
        static bool addSkippedFilesResult;
        static bool justThisFolders;
        static Orchestrator defaultOrchestrator = null;

        static void Main(string[] args)
        {
            var appSettings = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();

            defaultConfigPaths = appSettings.GetSection("defaultConfigPaths").Get<string[]>();
            useJustTheseFiles = bool.Parse(appSettings["useJustTheseFiles"]);
            justTheseFiles = appSettings.GetSection("justTheseFiles").Get<string[]>();
            excludedFilesEnabled = bool.Parse(appSettings["excludedFilesEnabled"]);
            excludedFolders = appSettings.GetSection("excludedFolders").Get<string[]>() ?? new string[] { };
            useAnnotations = bool.Parse(appSettings["useAnnotations"]);
            addSkippedFilesResult = bool.Parse(appSettings["addSkippedFilesResult"]);
            useSameCompilation = bool.Parse(appSettings["useSameCompilation"]);            
            useTraces = bool.Parse(appSettings["useTraces"]);
            justThisFolders = bool.Parse(appSettings["justThisFolders"]);
            traces = appSettings.GetSection("traces").Get<string[]>();            
            Globals.skip_trace_enabled = excludedFilesEnabled || justThisFolders;
            Globals.include_receiver_use_on_calls = bool.Parse(appSettings["includeReceiverUseOnCalls"]);
            Globals.wrap_structs_calls = bool.Parse(appSettings["wrapStructCalls"]);
            UserSliceConfiguration.FoldersToSkip = new HashSet<string>(excludedFolders);            

            var configurations = new List<string>();
            if (args != null && args.Count() > 0)
                configurations = args.ToList();
            else
            {
                foreach (var fileOrFolder in defaultConfigPaths)
                {
                    if (Directory.Exists(fileOrFolder))
                        configurations.AddRange(Directory.GetFiles(fileOrFolder, "*.slc", SearchOption.AllDirectories).ToList());
                    else
                        configurations.Add(fileOrFolder);
                }
            }

            var filesOK = new List<string>();
            var filesWrong = new List<string>();
            foreach (var path in configurations.Where(x => System.IO.Path.GetExtension(x) == ".slc"))
            {
                if (useJustTheseFiles && !justTheseFiles.Any(x => path.Contains(x)))
                    continue;

                var stream = System.IO.File.OpenRead(path.Trim());
                var serializer = new XmlSerializer(typeof(UserConfiguration));
                var userConfiguration = (UserConfiguration)serializer.Deserialize(stream);
                if (!useAnnotations && userConfiguration.customization != null)
                    userConfiguration.customization.summaries = null;

                if (useTraces)
                {
                    var originalOutputFolder = userConfiguration.results.outputFolder;

                    var localTraces = new List<string>();
                    foreach (var trace in traces)
                        // TODO XXX: Hardcode
                        localTraces.AddRange(Directory.GetFiles(trace, "*_ORIG.txt", SearchOption.AllDirectories));

                    foreach (var localTrace in localTraces)
                    {
                        var currentDirectory = Path.GetFileName(Path.GetDirectoryName(localTrace));

                        userConfiguration.criteria.fileTraceInputPath = localTrace;
                        userConfiguration.results.outputFolder = Path.Combine(originalOutputFolder, currentDirectory);
                        userConfiguration.results.name = Path.GetFileNameWithoutExtension(localTrace);
                        ExecuteConfiguration(localTrace, userConfiguration, filesOK, filesWrong);
                    }
                }
                else
                    ExecuteConfiguration(path, userConfiguration, filesOK, filesWrong);

                #region Modes
                //else if (local_mode == ConsoleMode.MultipleFiles)
                //{
                //    // Powershell
                //    var traceFilesFolder = @"C:\Users\XXX\Desktop\Slicer\Powershell\TodoPowershell\Trazas2020\TestHost\";
                //    var orchestrator = new Orchestrator(userConfiguration);
                //    orchestrator.UserInteraction = false;

                //    var skip = new HashSet<string>() {

                //    };
                //    var toProcess = new HashSet<string>() {

                //    };

                //    // Para cada archivo de traza
                //    foreach (var traceFile in Directory.GetFiles(traceFilesFolder).Where(x => x.EndsWith("_ORIG.txt")))
                //    {
                //        var fileName = Path.GetFileNameWithoutExtension(traceFile);
                //        //if (!toProcess.Contains(fileName))
                //        //    continue;
                //        try
                //        { 
                //            Console.WriteLine($"Ejecutando el archivo {fileName}");
                //            userConfiguration.criteria.fileTraceInputPath = traceFile;
                //            userConfiguration.results.name = fileName;
                //            orchestrator.Orchestrate();
                //            filesOK.Add(fileName);
                //        }
                //        catch(Exception ex)
                //        {
                //            Console.WriteLine($"Falló el archivo {fileName}");
                //            Console.WriteLine(ex.Message);
                //            Console.WriteLine(ex.StackTrace);
                //            Console.WriteLine("--------------------");
                //            filesWrong.Add(fileName);
                //        }
                //    }
                //}
                //else if (local_mode == ConsoleMode.MultipleConfigurations)
                //{
                //    Orchestrator orchestrator = null;
                //    var possibleSummaries = new string[] {
                //        @"C:\temp\configurations\Annotations_Roslyn.xml",
                //        null
                //    };
                //    var staticModeOptions = new bool[] { false };
                //    var loopsOptimizationOptions = new bool[] { false };
                //    var linesToSlice = (UserConfiguration.Criteria.FileLine[])userConfiguration.criteria.lines.Clone();
                //    var initialFolder = userConfiguration.results.outputFolder;

                //    // All the configurations belong to the same proyect and use the same trace
                //    orchestrator = new Orchestrator(userConfiguration);
                //    orchestrator.UserInteraction = false;

                //    var executedDictionary = new Dictionary<UserConfiguration.Criteria.FileLine, int>();
                //    foreach (var summaryValue in possibleSummaries)
                //        foreach (var staticModeOPT in staticModeOptions)
                //            foreach (var loopsOPT in loopsOptimizationOptions)
                //                foreach (var fileLine in linesToSlice)
                //                {
                //                    if (loopsOPT && !staticModeOPT)
                //                        continue;

                //                    Console.WriteLine(string.Format("Ejecutando con los summaries {0}", summaryValue == null ? "-" : Path.GetFileNameWithoutExtension(userConfiguration.customization.summaries)));
                //                    Console.WriteLine(string.Format("Static Mode: {0}", staticModeOPT ? "SI" : "NO"));
                //                    Console.WriteLine(string.Format("Loops OPT: {0}", loopsOPT ? "SI" : "NO"));
                //                    Console.WriteLine(string.Format("Criteria: {0}:{1}", fileLine.file, fileLine.line));

                //                    userConfiguration.customization.summaries = summaryValue;
                //                    userConfiguration.customization.staticMode = staticModeOPT;
                //                    userConfiguration.customization.loopsOptimization = loopsOPT;
                //                    userConfiguration.criteria.lines = new UserConfiguration.Criteria.FileLine[] { fileLine };

                //                    if (!executedDictionary.ContainsKey(fileLine))
                //                        executedDictionary.Add(fileLine, 1);
                //                    var iterationTime = executedDictionary[fileLine];
                //                    executedDictionary[fileLine]++;

                //                    userConfiguration.results.outputFolder = Path.Combine(
                //                        initialFolder,
                //                        $"{(userConfiguration.customization.summaries != null ? "WithSummaries" : "WithoutSummaries")}_{fileLine.line.Value}_{iterationTime}");

                //                    orchestrator.Orchestrate();
                //                }
                //}
                //else if (local_mode == ConsoleMode.MultipleInputs)
                //{
                //    Orchestrator orchestrator = null;
                //    var values = new int[] { 10, 20, 50, 100, 150, 160, 200, 600 };
                //    for(var j = 0; j < values.Count(); j++)
                //    {
                //        userConfiguration.instances[0] = new UserConfiguration.Instance()
                //        {
                //            parameters = new string[]
                //            {
                //                string.Format("-c {0}", values[j])
                //            }
                //        };

                //        orchestrator = new Orchestrator(userConfiguration);
                //        orchestrator.UserInteraction = false;
                //        orchestrator.Orchestrate();
                //    }
                //}
                #endregion
            }

            #region Results
            Console.WriteLine("Files OK:");
            foreach (var f in filesOK)
                Console.WriteLine(f);
            Console.WriteLine("--------------------");
            Console.WriteLine("Files Wrong:");
            foreach (var f in filesWrong)
                Console.WriteLine(f);
            #endregion

            #if DEBUG
            Console.WriteLine("Press a key...");
            Console.ReadLine();
            //DynAbs.BugLogging.Save();
            #endif
        }

        static void ExecuteConfiguration(string pathOrFileName, UserConfiguration userConfiguration, List<string> filesOK, List<string> filesWrong)
        {
            // TODO: agrego esto temporalmente
            if (addSkippedFilesResult)
                userConfiguration.results.skippedFilesInfo = "SkippedFilesInfo.txt";

            Console.WriteLine("Procesando: " + pathOrFileName);
            Console.WriteLine("Archivo txt: " + userConfiguration.criteria.fileTraceInputPath);

            var userInteractionCriteria = false;
            var userInteractionOutput = false;
            var local_mode = ConsoleMode.Default;
            
            if (excludedFilesEnabled)
                foreach (var targetProject in userConfiguration.targetProjects.excluded)
                    for (var i = 0; i < targetProject.files?.Length; i++)
                        targetProject.files[i].skip = (excludedFolders.Any(x => targetProject.files[i].name.Contains(x)));

            if (justThisFolders)
            {
                var folders = LayerOneDic[Path.GetDirectoryName(pathOrFileName)];
                foreach (var targetProject in userConfiguration.targetProjects.excluded)
                    for (var i = 0; i < targetProject.files?.Length; i++)
                    {
                        if (targetProject.files[i].name == @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Compilation\CSharpCompilation.cs")
                            ;
                        targetProject.files[i].skip = !(folders.Any(x => targetProject.files[i].name.Contains(x)));
                    }
            }

            if (defaultOrchestrator == null || !useSameCompilation)
                defaultOrchestrator = new Orchestrator(userConfiguration);
            else
                defaultOrchestrator.Reset(userConfiguration, justThisFolders);
            defaultOrchestrator.UserInteraction = false;

            // Si el modo es normal solicitamos criterio. Caso contrario debemos seleccionar en el browser.
            #region Selección Line Modo interactivo
            if ((userConfiguration.criteria.mode == UserConfiguration.Criteria.CriteriaMode.Normal) && userInteractionCriteria)
            {
                //SliceBrowser.SliceCriteria.Run(orchestrator.InstrumentationResult.IdToFileDictionary.Select(x => x.Value).ToArray());
                //userConfiguration.criteria.lines.First().file = SliceBrowser.SliceCriteria.SliceCriteriaFile;
                //userConfiguration.criteria.lines.First().line = SliceBrowser.SliceCriteria.SliceCriteriaFileLine;
                throw new NotImplementedException();
            }
            #endregion

            try
            {
                defaultOrchestrator.Orchestrate();
                filesOK.Add(Path.GetFileName(pathOrFileName));

                Console.WriteLine("OK: " + pathOrFileName);
            }
            catch (Exception ex)
            {
                filesWrong.Add(Path.GetFileName(pathOrFileName) + ": " + ex.Message);
                Console.WriteLine("WRONG: " + pathOrFileName + ": " + ex.Message);
            }

            if (userInteractionOutput || userConfiguration.IsLoadedResult)
            {
                //throw new NotImplementedException();
                //if (userConfiguration.criteria.mode != UserConfiguration.Criteria.CriteriaMode.Normal)
                //{
                var reducedCompleteDG = defaultOrchestrator.GetReducedDependencyGraph();
                var reducedSliceDG = defaultOrchestrator.GetReducedSliceDependencyGraph();
                DynAbs.DesktopApp.Browser.ComplexBrowser.Run(
                    defaultOrchestrator.UserSolution,
                    reducedSliceDG,
                    defaultOrchestrator.InstrumentationResult.fileIdToSyntaxTree,
                    defaultOrchestrator.InstrumentationResult.IdToFileDictionary,
                    defaultOrchestrator.ExecutedStmts);
                //}
                //else
                //    DynAbs.DesktopApp.Browser.ComplexBrowser.SliceBrowser.Run(
                //        orchestrator.ExecutedStmts, 
                //        orchestrator.InstrumentationResult.IdToFileDictionary, 
                //        orchestrator.InstrumentationResult.fileIdToSyntaxTree, 
                //        orchestrator.SlicedStmts.First(), 
                //        orchestrator.CompleteDependencyGraph, 
                //        null);
            }
        }

        static Dictionary<string, List<string>> LayerOneDic = new Dictionary<string, List<string>>()
        {
            // ROSLYN
            {
                @"C:\Users\XXX\Desktop\Slicer\Roslyn\config\aut\BindingTests", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\eng\config\test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Binder"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Roslyn\config\aut\CompilationEmitTests", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\eng\config\test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Compilation",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Compiler",

                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\EditAndContinue",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\NoPia",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\TypeMemberReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\SpecializedNestedTypeReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\SpecializedMethodReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\SpecializedGenericNestedTypeInstanceReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\SpecializedGenericMethodInstanceReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\SpecializedFieldReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\PENetModuleBuilder.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\PEModuleBuilder.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\PEAssemblyBuilder.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\ParameterTypeInformation.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\NamedTypeReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\ModuleReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\MethodReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\GenericTypeInstanceReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\GenericNestedTypeInstanceReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\GenericNamespaceTypeInstanceReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\GenericMethodInstanceReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\ExpandedVarargsMethodReference.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\AssemblyReference.cs",
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Roslyn\config\aut\FlowTests", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\eng\config\test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\FlowAnalysis"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Roslyn\config\aut\PDBTests", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\eng\config\test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Binder",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Symbols",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\SymbolDisplay",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Compilation\CSharpCompilation.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\TypeParameterSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\SynthesizedPrivateImplementationDetailsStaticConstructor.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\SourceAssemblySymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\PropertySymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\PointerTypeSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\ParameterSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\NamespaceSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\NamedTypeSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\SymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\MethodSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\FunctionPointerTypeSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\FieldSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\EventSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\CustomModifierAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\AttributeDataAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\ArrayTypeSymbolAdapter.cs",
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Roslyn\config\aut\StatementParsingTests", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\eng\config\test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Parser",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Syntax"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Roslyn\config\aut\TypeTests", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\eng\config\test",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Binder",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Symbols",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\SymbolDisplay",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Compilation\CSharpCompilation.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\TypeParameterSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\SynthesizedPrivateImplementationDetailsStaticConstructor.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\SourceAssemblySymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\PropertySymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\PointerTypeSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\ParameterSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\NamespaceSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\NamedTypeSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\SymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\MethodSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\FunctionPointerTypeSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\FieldSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\EventSymbolAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\CustomModifierAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\AttributeDataAdapter.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Roslyn\src\src\Compilers\CSharp\Portable\Emitter\Model\ArrayTypeSymbolAdapter.cs",
                }
            },

            // POWERSHELL
            { 
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\Binders", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\runtime"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\CorePsPlatform", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\CoreCLR"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\ExtensionMethods", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\utils",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\utils.cs",
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\FileSystemProvider", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\namespaces",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\SessionStateNavigation.cs"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\MshSnapinInfo", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\singleshell"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\NamedPipe", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\remoting"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\PowerShellAPI", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\hostifaces",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\MshObject.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\AutomationNull.cs"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\PSConfiguration", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\PSConfiguration.cs"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\PSObject", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\MshObject.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\MshMemberInfo.cs",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\AutomationNull.cs"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\PSVersionInfo", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\Runspace", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\hostifaces",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\runtime",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\lang\scriptblock.cs"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\SecuritySupport", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\security"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\SessionState", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\Utils", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\utils.cs"
                }
            },
            {
                @"C:\Users\XXX\Desktop\Slicer\Powershell\config\tests\WildcardPattern", new List<string>()
                {
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\test\xUnit",
                    @"C:\Users\XXX\Desktop\Slicer\Powershell\src\src\System.Management.Automation\engine\regex.cs"
                }
            }
        };
    }
}
