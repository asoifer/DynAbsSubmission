using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using System.Xml.Linq;
using System.Threading;
using System.Diagnostics;

namespace DynAbs
{
    class SourceCompiler
    {
        UserConfiguration Configuration { get; set; }
        Solution UserSolution;
        Solution InstrumentedSolution;
        bool ReturnInstrumentedSolution;
        static string FileTraceClientLocation = @"C:\Users\alexd\Desktop\Slicer\DynAbs\src\DynAbs.Tracing.FileTraceClient\bin\Debug\DynAbs.Tracing.FileTraceClient.dll";
        const string ResGenPath = @"C:\Users\alexd\Desktop\Slicer\netslicer\src\Slicer\ResGen.exe";


        public SourceCompiler(UserConfiguration userConfiguration, Solution userSolution, Solution instrumentedSolution = null, bool returnInstrumentedSolution = true)
        {
            Configuration = userConfiguration;
            UserSolution = userSolution;
            InstrumentedSolution = instrumentedSolution;
            ReturnInstrumentedSolution = returnInstrumentedSolution;
        }

        public InstrumentationResult GetInstrumentationResult(Type[] additionalTypes)
        {
            string originalRootPath = null;
            string newSolFile = null;
            bool copyFiles = false;

            bool instrumentAndRewrite = InstrumentedSolution == null && ReturnInstrumentedSolution;
            if (Configuration.solutionFiles.solutionPath != null)
            {
                if (instrumentAndRewrite || Configuration.IsLoadedResult)
                {
                    var fileInfo = new FileInfo(Configuration.solutionFiles.solutionPath);
                    originalRootPath = fileInfo.DirectoryName;
                    if (!Configuration.IsLoadedResult)
                    { 
                        if (!Configuration.criteria.onlyOverrideCodeFiles)
                            DirectoryCopy(originalRootPath, Configuration.solutionFiles.compilationOutputFolder, true);
                        newSolFile = Configuration.solutionFiles.compilationOutputFolder + "\\" + fileInfo.Name;
                        copyFiles = true;
                    }
                }
                else
                {
                    var fileInfo = new FileInfo(Configuration.solutionFiles.solutionPath);
                    originalRootPath = fileInfo.DirectoryName;
                    newSolFile = Configuration.solutionFiles.instrumentedSolutionPath;
                    copyFiles = false;
                }
            }

            var pathToSemanticModelDict = new Dictionary<string, SemanticModel>();
            var idsToSyntaxTreesDict = new Dictionary<int, CSharpSyntaxTree>();

            string compiledAssemblyName = null;
            CSharpSyntaxNode entryPoint = null;
            // TODO-NETCORE
            //var traceType = (Configuration.criteria.fileTraceInput) ? typeof(FileTraceSender) : typeof(PipeTraceSender);

            // TODO: Add pipe and file tracer

            // Step 1: look for the min framework version in the solution (I'll assume that every project is used)
            // Step 2: look for the closest library version of the tracer
            // Step 3: copy every tracer dll in the output folder
            // Step 4: add every dll to the csproj

            /*
             * assemblyReferences.Add(MetadataReference.CreateFromFile(typeof(ProtoBuf.ProtoWriter).Assembly.Location));
             * assemblyReferences.Add(MetadataReference.CreateFromFile(typeof(TraceType).Assembly.Location));
             * assemblyReferences.Add(MetadataReference.CreateFromFile(_senderType.Assembly.Location));
             */

            //var minVersion = getMinVersion(UserSolution);
            //var closestLibrary = getClosestVersion(minVersion);
            //var libraries = tracerLocations[closestLibrary];
            
            var instrumenter = instrumentAndRewrite ? 
                new SourceInstrumenter(new HashSet<string>() { FileTraceClientLocation }) : 
                (ISourceProcessor)new SourceLoader(InstrumentedSolution);
            
            var compilationFolderCreated = false;
            foreach (var project in UserSolution.Projects)
            {
                if (UserSliceConfiguration.CurrentUserConfiguration?.targetProjects?.excluded != null &&
                    ((UserSliceConfiguration.CurrentUserConfiguration.targetProjects.excluded.Any(x => x.name == project.Name && x.mode == UserConfiguration.ExcludedMode.All) || 
                    (UserSliceConfiguration.CurrentUserConfiguration.targetProjects.defaultMode == UserConfiguration.ExcludedMode.All && !UserSliceConfiguration.CurrentUserConfiguration.targetProjects.excluded.Any(x => x.name == project.Name && x.mode != UserConfiguration.ExcludedMode.All)))))
                    continue;

                var options = project.ParseOptions.WithFeatures(
                                project.ParseOptions.Features.Union(
                                    new KeyValuePair<string, string>[] { new KeyValuePair<string, string>("IOperation", "true") }));
                var IOperationProject = project.WithParseOptions(options);

                var originalCompilation = (CSharpCompilation)IOperationProject.GetCompilationAsync().Result;
                originalCompilation = originalCompilation.WithOptions(originalCompilation.Options.WithAllowUnsafe(true));
                var modifiedCompilation = instrumenter.Process(originalCompilation, project.Name);
                var instrumentedFiles = instrumenter.InstrumentedFiles;

                bool isNetCore = !IsNetFrameworkProject(project); 
                string projectFileName = Path.GetFileName(project.FilePath);
                string newProjectFilePath;
                if (Configuration.solutionFiles.compilationOutputFolder != null)
                    newProjectFilePath = Directory.GetFiles(Configuration.solutionFiles.compilationOutputFolder, projectFileName, SearchOption.AllDirectories).First();
                else
                    newProjectFilePath = Directory.GetFiles(Path.GetDirectoryName(Configuration.solutionFiles.instrumentedSolutionPath), projectFileName, SearchOption.AllDirectories).First();

                if (copyFiles)
                {
                    foreach (var st in modifiedCompilation.SyntaxTrees.Where(x => x.FilePath.StartsWith(originalRootPath) && instrumentedFiles.Contains(x.FilePath)))
                    {
                        var pathFromRoot = st.FilePath.Remove(0, originalRootPath.Length);
                        var str = Configuration.solutionFiles.compilationOutputFolder + pathFromRoot;
                        string sourceText = st.GetText().ToString();
                        File.WriteAllText(str, sourceText);
                    }

                    if (!Configuration.criteria.onlyOverrideCodeFiles)
                    {
                        if (isNetCore)
                        {
                            // TODO-NETCORE: Reemplazar con ref a un csproj
                            var traceFiles = new HashSet<string>() {
                                @"C:\Users\alexd\Desktop\Slicer\DynAbs\src\DynAbs.Tracing\TraceType.cs",
                                @"C:\Users\alexd\Desktop\Slicer\DynAbs\src\DynAbs.Tracing\TracerGlobals.cs",
                                @"C:\Users\alexd\Desktop\Slicer\DynAbs\src\DynAbs.Tracing\ITracerClient.cs",
                                @"C:\Users\alexd\Desktop\Slicer\DynAbs\src\DynAbs.Tracing\TraceSender.cs",
                                @"C:\Users\alexd\Desktop\Slicer\DynAbs\src\DynAbs.Tracing.FileTraceClient\FileTracerClient.cs",
                                @"C:\Users\alexd\Desktop\Slicer\DynAbs\src\DynAbs.Tracing.FileTraceClient\FileTraceSender.cs",
                            };
                            var basePathForFiles = Path.GetDirectoryName(newProjectFilePath);
                            foreach (var traceFile in traceFiles)
                            {
                                var newPath = Path.Combine(basePathForFiles, Path.GetFileName(traceFile));
                                File.Copy(traceFile, newPath);
                            }
                        }
                        else
                        {
                            if (!compilationFolderCreated)
                            {
                                CreateCompilationFolder(additionalTypes);
                                File.Copy(FileTraceClientLocation, Path.Combine(Configuration.solutionFiles.compilationOutputFolder, "DynAbs.Tracing.FileTraceClient.dll"));
                                compilationFolderCreated = true;
                            }

                            var projPath = project.FilePath.Remove(0, originalRootPath.Length);
                            AddDependenciesToCsproj(newProjectFilePath, Configuration.solutionFiles.compilationOutputFolder, Path.Combine(Configuration.solutionFiles.compilationOutputFolder, "DynAbs.Tracing.FileTraceClient.dll"));
                        }
                    }
                }

                // Replace the instrumented files in the original compilation
                var pathToIdDict = instrumenter.FilesIds().ToDictionary(x => x.Value, x => x.Key);
                foreach (var st in originalCompilation.SyntaxTrees)
                    if (pathToIdDict.ContainsKey(st.FilePath))
                    {
                        var annotation = new SyntaxAnnotation("FileId", pathToIdDict[st.FilePath].ToString());
                        originalCompilation = originalCompilation.ReplaceSyntaxTree(st, st.WithRootAndOptions(st.GetCompilationUnitRoot().WithAdditionalAnnotations(annotation), st.Options));
                    }

                // Semantic model cache and ids to syntax trees
                foreach (var entry in instrumenter.LastInstrumentedFileIds())
                {
                    string path = entry.Value;
                    var ast = originalCompilation.SyntaxTrees.Single(x => x.FilePath == path);
                    idsToSyntaxTreesDict.Add(entry.Key, (CSharpSyntaxTree)ast);
                    var curSemanticModel = originalCompilation.GetSemanticModel(ast);
                    pathToSemanticModelDict.Add(path, curSemanticModel);
                }

                #region Compilación con roslyn
                if (instrumentAndRewrite)
                {
                    if (isNetCore)
                    {
                        if (project.Name == Configuration.solutionFiles.executableProject)
                            compiledAssemblyName = newProjectFilePath;
                    }
                    else
                    {
                        //Compilacion con Roslyn (Emit por proyecto).
                        IList<ResourceDescription> resources = new List<ResourceDescription>();
                        if (project.FilePath != null)
                        {
                            /* Ojo, esto no funciona! Los *.resources generados de esta manera no son iguales que los
                             * generados por el msbuild, quizas hay que buscar el ResGen corresponiente a la version
                             * del Framework que se esta usando. */
                            var resgenExe = ResGenPath;
                            var resourcesFile = System.IO.Directory.GetFiles(Path.GetDirectoryName(project.FilePath), "*.resx", SearchOption.AllDirectories);
                            foreach (var resourcePath in resourcesFile)
                            {
                                // Puede haber recursos repetidos
                                var resourceName = Guid.NewGuid().ToString() + "." + Path.GetFileNameWithoutExtension(resourcePath) + ".resources";
                                var outputFile = Path.Combine(Configuration.solutionFiles.compilationOutputFolder, "COMPILATION", resourceName);

                                ProcessStartInfo startInfo = new ProcessStartInfo(resgenExe);
                                startInfo.WindowStyle = ProcessWindowStyle.Hidden;
                                startInfo.Arguments = "-usesourcepath \"" + resourcePath + "\" \"" + outputFile + "\"";
                                Process.Start(startInfo);

                                var resourceDescription = new ResourceDescription(resourceName, () => File.OpenRead(outputFile), true);
                                resources.Add(resourceDescription);
                            }

                            // EmbeddedResources
                            var embeddedResources = XDocument.Load(project.FilePath)
                                .Descendants().Where(x => x.Name.LocalName == "EmbeddedResource")
                                .Select(x => x.Attribute("Include")?.Value)
                                .Where(x => !string.IsNullOrWhiteSpace(x));
                            foreach (var embeddedResource in embeddedResources)
                            {
                                var resourcePath = Path.Combine(Path.GetDirectoryName(project.FilePath), embeddedResource);
                                var resourceName = Path.GetFileName(embeddedResource);
                                resources.Add(new ResourceDescription(resourceName, () => File.OpenRead(resourcePath), true));
                            }
                        }

                        string fileType = (IOperationProject.CompilationOptions.OutputKind == OutputKind.DynamicallyLinkedLibrary) ? ".dll" : ".exe";
                        string compiledAssemblyPath = Path.Combine(Configuration.solutionFiles.compilationOutputFolder, "COMPILATION", project.AssemblyName + fileType);
                        if (!UserSliceConfiguration.CurrentUserConfiguration.criteria.notCompile)
                        {
                            var compilationEmit = modifiedCompilation.Emit(compiledAssemblyPath, manifestResources: resources.ToArray());
                            if (!compilationEmit.Success)
                            {
                                var errores = compilationEmit.Diagnostics.Where(x => x.Severity != DiagnosticSeverity.Warning);
                                foreach (var diag in errores)
                                    Logger.Error(diag.ToString());
                                throw new Exception("Compilation error");
                            }
                            else
                            {
                                if (Configuration.solutionFiles.solutionPath != null)
                                {
                                    // Copy all the libraries in the same directory
                                    var mainPath = Path.GetDirectoryName(Configuration.solutionFiles.solutionPath);
                                    foreach (var reference in originalCompilation.References.Where(x => x.Display.StartsWith(mainPath)))
                                        File.Copy(reference.Display, Path.Combine(Configuration.solutionFiles.compilationOutputFolder, "COMPILATION", Path.GetFileName(reference.Display)), true);

                                    // App.Config for the project
                                    if (project.FilePath != null && File.Exists(Path.Combine(Path.GetDirectoryName(project.FilePath), "App.Config")))
                                        File.Copy(Path.Combine(Path.GetDirectoryName(project.FilePath), "App.Config"),
                                            Path.Combine(Configuration.solutionFiles.compilationOutputFolder, "COMPILATION", project.Name + ".exe.config"), true);
                                }
                            }
                        }
                        if (project.Name == Configuration.solutionFiles.executableProject)
                            compiledAssemblyName = compiledAssemblyPath;
                        //Fin compilacion Roslyn.
                    }
                }
                #endregion

                if (project.Name == Configuration.solutionFiles.executableProject)
                    entryPoint = (CSharpSyntaxNode)(originalCompilation.GetEntryPoint(new CancellationToken()).DeclaringSyntaxReferences.Single().GetSyntax());
            }

            if ((!instrumentAndRewrite) && ReturnInstrumentedSolution && string.IsNullOrWhiteSpace(Configuration.criteria?.fileTraceInputPath))
            {
                var project = InstrumentedSolution.Projects.Single(x => x.Name == Configuration.solutionFiles.executableProject);
                compiledAssemblyName = IsNetFrameworkProject(project) ? project.OutputFilePath : project.FilePath;
            }

            return new InstrumentationResult
            {
                Executable = compiledAssemblyName,
                IdToFileDictionary = instrumenter.FilesIds(),
                FileToIdDictionary = instrumenter.FilesIds().ToDictionary(x => x.Value, x => x.Key),
                fileIdToSyntaxTree = idsToSyntaxTreesDict,
                filePathToSemanticModel = pathToSemanticModelDict,
                EntryPoint = entryPoint
            };
        }

        void CreateCompilationFolder(Type[] additionalTypes)
        {
            // Where to generate .exe
            var baseDirectory = Path.Combine(Configuration.solutionFiles.compilationOutputFolder, "COMPILATION");
            if (!Directory.Exists(baseDirectory))
                Directory.CreateDirectory(baseDirectory);

            // References
            var references = new HashSet<string>();
            foreach (Type additional in additionalTypes)
                references.Add(additional.Assembly.Location);
            references.Add(FileTraceClientLocation);

            // Copy references to compilation folder
            foreach (var dllOrigin in references)
            {
                var dllDestination = Path.Combine(Configuration.solutionFiles.compilationOutputFolder, "COMPILATION", Path.GetFileName(dllOrigin));

                if (File.Exists(dllDestination))
                    File.Delete(dllDestination);
                File.Copy(dllOrigin, dllDestination);
            }
        }

        static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();
            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
                Directory.CreateDirectory(destDirName);
            else
                Directory.GetFiles(destDirName).ToList().ForEach(x => File.Delete(x));

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                if (file.Name == "db.lock")
                    continue;
                string temppath = Path.Combine(destDirName, file.Name);
                try
                {
                    file.CopyTo(temppath, false);
                }
                catch { }   
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    //if (subdir.Name == ".git")
                    //    continue;
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        void AddDependenciesToCsproj(string csproj, string rootPath, string assemblyName)
        {
            //Fill a list with the lines from the txt file.
            List<string> lines = new List<string>();
            bool alreadyAdded = false;
            
            foreach (var line in File.ReadAllLines(csproj).ToList())
            {
                if (line.Contains("<Reference Include=") && line.Contains("/>") && !alreadyAdded)
                {
                    lines.Add(string.Format(@"<Reference Include=""{1}""><HintPath>{0}\{1}.dll</HintPath></Reference>", rootPath, Path.GetFileNameWithoutExtension(assemblyName)));
                    lines.Add(line);
                    alreadyAdded = true;
                }
                else
                {
                    lines.Add(line);
                }
            }

            //Add the lines including the new one.
            File.WriteAllLines(csproj, lines);
        }

        bool IsNetFrameworkProject(Project project)
        {
            var systemDll = project.MetadataReferences.Where(x => x.Display.EndsWith("System.dll")).FirstOrDefault();
            return systemDll != null && systemDll.Display.Contains(".NETFramework");
        }

        string getMinVersion(Solution solution)
        {
            // ...\.nuget\packages\microsoft.netcore.app\2.1.3\ref\netcoreapp2.1\System.dll
            var firstSystemDll = solution.Projects.First().MetadataReferences.Where(x => x.Display.EndsWith("System.dll")).First().Display;
            var fileInfo = new FileInfo(firstSystemDll);
            var firstVersion = fileInfo.Directory.Name;
            if (firstVersion.Contains('_'))
                firstVersion = firstVersion.Substring(0, firstVersion.IndexOf('_'));
            // TODO: Complete with the real min version comparison
            var minVersion = firstVersion;
            return minVersion;
        }

        string getClosestVersion(string minFrameworkVersion)
        {
            if (minFrameworkVersion.Contains("v4."))
                return "v4.0";

            // TODO: return the real closest available version
            return minFrameworkVersion;
        }
    }
}
