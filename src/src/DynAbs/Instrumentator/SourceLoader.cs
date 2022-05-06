using System.Collections.Generic;
using System.Diagnostics;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using DynAbs.Tracing;
using System.Threading;
using System;
using System.Linq;
using Microsoft.CodeAnalysis.Text;

namespace DynAbs
{
    public class SourceLoader : ISourceProcessor
    {
        private Dictionary<int, string> fileIdAssoc = new Dictionary<int, string>();
        private Dictionary<int, string> lastInstrumentedFileIdAssoc;
        private Dictionary<string, int> pathToIdAssoc = new Dictionary<string, int>();
        private ISet<string> files = new HashSet<string>();
        private Dictionary<string, int> predefinedIds = new Dictionary<string, int>();
        private Dictionary<int, bool> skipFileInfo = new Dictionary<int, bool>();
        private UserConfiguration.ExcludedMode mode = UserConfiguration.ExcludedMode.None;
        private int fileId = 0;
        public ISet<string> InstrumentedFiles { get; } = new HashSet<string>();

        Solution _solution;

        public SourceLoader(Solution solution)
        {
            _solution = solution;
        }

        /*
         * Input: Original Compilation.
         * Output: Instrumented Compilation.
         * Idea: I call rewriter with the tree for that instrument. Replacement compilation with the new instrumented modified tree. Write in C: \ temp \ Instrumentado.cs the instrumented code
         */
        public CSharpCompilation Process(CSharpCompilation compilation, string projectName)
        {
            lastInstrumentedFileIdAssoc = new Dictionary<int, string>();
            var temp = _solution.Projects.Where(x => x.AssemblyName == compilation.AssemblyName).First().GetCompilationAsync();
            temp.Wait();
            CSharpCompilation modifiedCompilation = (CSharpCompilation)temp.Result;

            var project = UserSliceConfiguration.CurrentUserConfiguration.targetProjects?.excluded?.FirstOrDefault(x => x.name == projectName);
            if (project != null && project.files != null)
            {
                mode = project.mode;
                files.UnionWith(project.files.Select(x => x.name));
                foreach (var file in project.files)
                {
                    if (file.id > 0 && !predefinedIds.ContainsKey(file.name))
                    {
                        predefinedIds[file.name] = file.id;
                        if (file.skip.HasValue)
                            skipFileInfo[file.id] = file.skip.Value;
                    }
                }
            }

            if (project != null && project.initialFileID > 0)
                fileId = project.initialFileID - 1;

            foreach (var tree in compilation.SyntaxTrees)
            {
                //Evita instrumentar de mas
                if (IgnoreSourceFile(tree.FilePath))
                    continue;          
                AssocIdToFile(tree.FilePath);
            }

            UserSliceConfiguration.FilesToSkip = new HashSet<int>(skipFileInfo.Where(x => x.Value).Select(x => x.Key));
            return modifiedCompilation;
        }

        /*
         *  Input: FilePath
         *  Output: false
         *  Idea: If exits AssemblyInfo.cs or AssemblyAtributes.cs files return true.
         */
        private bool IgnoreSourceFile(string filePath)
        {
            return System.IO.Path.GetFileName(filePath) == "AssemblyInfo.cs" ||
                    System.IO.Path.GetFileName(filePath) == "AssemblyAttributes.cs" ||
                    (mode == UserConfiguration.ExcludedMode.Custom && files.Contains(filePath)) ||
                    (mode == UserConfiguration.ExcludedMode.AllExcept && !files.Contains(filePath));
        }

        /*
         *  Input: FilePath
         *  Output: false
         *  Idea: Set dicctionaries with actual file id.
         */
        private void AssocIdToFile(string filePath)
        {
            if (!pathToIdAssoc.ContainsKey(filePath))
            {
                int id = 0;
                if (predefinedIds.ContainsKey(filePath))
                    id = predefinedIds[filePath];
                else
                {
                    id = ++fileId;
                    while (predefinedIds.Values.Contains(id))
                        id = ++fileId;
                }
                fileIdAssoc.Add(id, filePath);
                lastInstrumentedFileIdAssoc.Add(id, filePath);
                pathToIdAssoc.Add(filePath, id);
            }
        }

        /*
         *  Input: 
         *  Output: fileIdAssoc
         *  Idea: return fileIdAssoc
         */
        public Dictionary<int, string> FilesIds()
        {
            return fileIdAssoc;
        }

        /*
         *  Input: 
         *  Output: lastInstrumentedFileIdAssoc
         *  Idea: returna lastInstrumentedFileIdAssoc
         */
        public Dictionary<int, string> LastInstrumentedFileIds()
        {
            return lastInstrumentedFileIdAssoc;
        }
    }
}
