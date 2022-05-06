using DC.Slicer;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using QuickGraph;
using SliceBrowser.UserInteraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tracer;

namespace SliceBrowser
{
    public partial class ComplexBrowser : Form
    {
        #region Properties
        Solution _currentSolution { get; set; }
        BrowsingData _browsingData { get; set; }
        AdjacencyGraph<string, Edge<string>> _reverseDependencyGraph { get; set; }
        Dictionary<int, CSharpSyntaxTree> _fileIdToSyntaxTree { get; set; }
        Dictionary<int, string> _idToFiles { get; set; }
        IEnumerable<Stmt> _executedStatements { get; set; }
        ISet<Stmt> _currentResult { get; set; }

        LineDetail _lineDetail;
        SourcesAndTargets _sourcesAndTargets;
        FindAndReplaceForm _findForm;
        TextEditorControl _currentTextEditorControl { get { return (TextEditorControl)tcContainer.SelectedTab.Controls[0]; } }
        #endregion

        public static void Run(Solution solution,
            BrowsingData reduced,
            Dictionary<int, CSharpSyntaxTree> fileIdToSyntaxTree,
            Dictionary<int, string> idToFiles,
            IEnumerable<Stmt> executedStatements)
        {
            var thread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new ComplexBrowser(solution, reduced, fileIdToSyntaxTree, idToFiles, executedStatements));
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public ComplexBrowser(Solution solution, 
            BrowsingData reducedDG,
            Dictionary<int, CSharpSyntaxTree> fileIdToSyntaxTree,
            Dictionary<int, string> idToFiles,
            IEnumerable<Stmt> executedStatements)
        {
            _currentSolution = solution;
            _browsingData = reducedDG;
            _fileIdToSyntaxTree = fileIdToSyntaxTree;
            _idToFiles = idToFiles;
            _executedStatements = executedStatements;

            AdjacencyGraph<string, Edge<string>> tempDG;
            GraphUtils.LoadReverseDependencyGraph(_browsingData.ReducedDG, out tempDG);
            _reverseDependencyGraph = tempDG;

            InitializeComponent();
        }

        private void ComplexBrowser_Load(object sender, EventArgs e)
        {
            var nodos = ObtenerNodosTreeView();
            Utils.MarcarArchivos(_idToFiles, nodos, _executedStatements, (x => x.BackColor = Color.Yellow));
            tvArchivos.Nodes.AddRange(nodos.ToArray());
            _currentResult = new HashSet<Stmt>();
            _lineDetail = new LineDetail(this, nodos, _idToFiles, _browsingData.RealDG, _browsingData.VertexToStatement);
            _sourcesAndTargets = new SourcesAndTargets(this, _idToFiles, nodos);
            _findForm = new FindAndReplaceForm();
        }

        #region TreeView
        // Toma el arbol de los proyectos y arma el árbol
        List<TreeNode> ObtenerNodosTreeView()
        {
            var result = new List<TreeNode>();
            // Por cada proyecto:
            foreach (var proyect in _currentSolution.Projects)
            {
                var proyectNode = new TreeNode();
                var proyectDirectory = Path.GetDirectoryName(proyect.FilePath);
                proyectNode.Text = proyect.Name;
                foreach (var document in proyect.Documents)
                {
                    var documentNode = new TreeNode();
                    documentNode.Text = document.Name;
                    documentNode.ToolTipText = document.FilePath;

                    // Verificamos que el path del documento sea parte del path del project
                    // Si es path del project, creamos los nodos intermedios necesarios 
                    // para llegar al archivo desde el path del project
                    var documentDirectory = Path.GetDirectoryName(document.FilePath);
                    if (!documentDirectory.Contains(proyectDirectory))
                        proyectNode.Nodes.Add(documentNode);
                    else
                    {
                        var difference = documentDirectory.Substring(proyectDirectory.Length,
                            documentDirectory.Length - proyectDirectory.Length);
                        var lastFolder = proyectNode;
                        if (!string.IsNullOrWhiteSpace(difference))
                        {
                            var folders = difference.Substring(1, difference.Length - 1)
                                                    .Split(new[] { "\\" }, StringSplitOptions.None);
                            foreach (var folder in folders)
                            {
                                var nextNode = GetNodeByName(lastFolder.Nodes, folder);
                                if (nextNode == null)
                                {
                                    nextNode = new TreeNode();
                                    nextNode.Text = folder;
                                    lastFolder.Nodes.Add(nextNode);
                                }
                                lastFolder = nextNode;
                            }
                        }
                        lastFolder.Nodes.Add(documentNode);
                    }
                }
                result.Add(proyectNode);
            }
            return result;
        }

        TreeNode GetNodeByName(TreeNodeCollection nodeCollection, string name)
        {
            var enumerator = nodeCollection.GetEnumerator();
            while (enumerator.MoveNext())
                if (((TreeNode)enumerator.Current).Text == name)
                    return ((TreeNode)enumerator.Current);
            return null;
        }
        #endregion

        #region MarcarEditor
        void RefrescarSlice()
        {
            var tabEnumerator = tcContainer.Controls.GetEnumerator();
            while (tabEnumerator.MoveNext())
                if (tabEnumerator.Current is TabPage)
                    RefrescarSlice((TextEditorControl)((TabPage)tabEnumerator.Current).Controls[0]);
        }
        
        void RefrescarSlice(TextEditorControl editor)
        {
            // Le sacamos el slice a cada línea
            editor.ActiveTextAreaControl.Document.MarkerStrategy.RemoveAll(x => x.TextMarkerType == ICSharpCode.TextEditor.Document.TextMarkerType.Underlined);
            // Agregamos el slice de este archivo
            var fileId = getCurrentDocumentId(editor);
            var lineasActuales = _currentResult.GroupBy(x => x.FileId).FirstOrDefault(x => x.Key == fileId);
            if (lineasActuales != null)
            {
                //var lineNumbers = string.Join("\n", lineasActuales.Select(x => x.Line).OrderBy(x => x).Select(x => x.ToString()));
                foreach(var linea in lineasActuales)
                    editor.ActiveTextAreaControl.Document.MarkerStrategy.AddMarker(
                        new TextMarker(linea.SpanStart, linea.SpanEnd - linea.SpanStart, TextMarkerType.Underlined, Color.Red));
            }

            editor.ActiveTextAreaControl.Refresh();
        }

        void RefrescarExecutedLines(TextEditorControl editor)
        {
            var fileId = getCurrentDocumentId(editor);
            foreach (var linea in _executedStatements.Where(x => x.FileId == fileId))
                editor.ActiveTextAreaControl.Document.MarkerStrategy.AddMarker(
                        new TextMarker(linea.SpanStart, linea.SpanEnd - linea.SpanStart, TextMarkerType.SolidBlock, Color.LightGoldenrodYellow));
        }
        #endregion

        void CargarDocumento(string filePath)
        {
            if (!string.IsNullOrWhiteSpace(filePath))
            {
                // No queremos agregar 2 veces el mismo
                var tabEnumerator = tcContainer.Controls.GetEnumerator();
                while (tabEnumerator.MoveNext())
                    if (tabEnumerator.Current is TabPage && ((TabPage)tabEnumerator.Current).Name == "tab:" + filePath)
                    {
                        tcContainer.SelectedTab = (TabPage)tabEnumerator.Current;
                        return;
                    }

                var newTab = new TabPage(Path.GetFileName(filePath.Split('.')[0]));
                newTab.Name = "tab:" + filePath;

                var newEditor = new TextEditorControl();
                newEditor.Name = "tec:" + filePath;
                newEditor.Dock = System.Windows.Forms.DockStyle.Fill;
                newEditor.IsReadOnly = true;
                newEditor.ContextMenuStrip = cmTextEditorMenu;
                newEditor.SetHighlighting("C#");
                newEditor.ShowTabs = true;

                newEditor.LoadFile(filePath);
                RefrescarExecutedLines(newEditor);
                RefrescarSlice(newEditor);

                newTab.Controls.Add(newEditor);
                tcContainer.Controls.Add(newTab);
                tcContainer.SelectedTab = tcContainer.TabPages[tcContainer.TabPages.Count - 1];
            }
        }

        public void CargarDocumentoByVertex(string vertex)
        {
            var document = _idToFiles[Convert.ToInt32(vertex.Split('.')[0])];
            CargarDocumento(document);
            ((TextEditorControl)tcContainer.SelectedTab.Controls[0]).ActiveTextAreaControl.Caret.Line 
                = Convert.ToInt32(vertex.Split('.')[1]) - 1;
        }

        private void tvArchivos_AfterSelect(object sender, TreeViewEventArgs e)
        {
            CargarDocumento(tvArchivos.SelectedNode.ToolTipText);
        }

        private void backwardSlicingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentLine = _currentTextEditorControl.ActiveTextAreaControl.Caret.Line + 1;
            _currentResult = GetByFileIdAndLine(_browsingData.ReducedDG, getCurrentDocumentId(), currentLine);
            RefrescarSlice();
            Utils.RefrescarMenuSlice(_idToFiles, tvArchivos, _currentResult);
        }

        private void forwardSliceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentLine = _currentTextEditorControl.ActiveTextAreaControl.Caret.Line + 1;
            _currentResult = GetByFileIdAndLine(_reverseDependencyGraph, getCurrentDocumentId(), currentLine);
            RefrescarSlice();
            Utils.RefrescarMenuSlice(_idToFiles, tvArchivos, _currentResult);
        }

        private void showDependenciesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentLine = _currentTextEditorControl.ActiveTextAreaControl.Caret.Line + 1;
            var currentDocumentId = getCurrentDocumentId();
            var vertex = currentDocumentId + "." + currentLine;

            if (_browsingData.LineSpans.ContainsKey(vertex))
            {
                ISet<Stmt> sourcesSet;
                ISet<Stmt> targetsSet;
                if (_browsingData.ReducedDG.Vertices.Contains(vertex))
                {
                    var sources = _browsingData.ReducedDG.OutEdges(vertex);
                    var targets = _reverseDependencyGraph.OutEdges(vertex);

                    sourcesSet = GetStmtFromVertices(sources.Select(x => x.Target));
                    targetsSet = GetStmtFromVertices(targets.Select(x => x.Target));
                }
                else
                {
                    sourcesSet = new HashSet<Stmt>();
                    targetsSet = new HashSet<Stmt>();
                }

                var nombreArchivo =
                    Path.GetFileName(_currentTextEditorControl.Name.Substring(4, _currentTextEditorControl.Name.Length - 4));
                var data = _browsingData.LineSpans[vertex];
                var textoLinea = _currentTextEditorControl.Text.Substring(data.Item1, data.Item2 - data.Item1 + 1);
                var textoAMostrar = nombreArchivo + " - " + textoLinea;

                _sourcesAndTargets.ShowFor(textoAMostrar, sourcesSet, targetsSet);
            }
        }

        private void showDetailsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var currentLine = _currentTextEditorControl.ActiveTextAreaControl.Caret.Line + 1;
            var currentDocumentId = getCurrentDocumentId();
            var vertex = currentDocumentId + "." + currentLine;

            if (_browsingData.LineSpans.ContainsKey(vertex))
            {
                var nombreArchivo =
                    Path.GetFileName(_currentTextEditorControl.Name.Substring(4, _currentTextEditorControl.Name.Length - 4));
                var data = _browsingData.LineSpans[vertex];
                var textoLinea = _currentTextEditorControl.Text.Substring(data.Item1, data.Item2 - data.Item1 + 1);
                var textoAMostrar = nombreArchivo + " - " + textoLinea;

                var statementsToShow = _browsingData.LineStatements[vertex];

                _lineDetail.ShowFor(textoAMostrar, statementsToShow);
            }
        }

        private void closeTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tcContainer.TabPages.RemoveAt(tcContainer.SelectedIndex);
        }

        #region Manejo del resultado
        ISet<Stmt> GetByFileIdAndLine(AdjacencyGraph<string, Edge<string>> graph, int fileId, int line)
        {
            var vertice = fileId + "." + line;
            if (!graph.Vertices.Contains(vertice))
                return new HashSet<Stmt>();

            var edges = DC.Slicer.GraphUtils.BFS(graph, vertice);
            return GetStmtFromVertices(edges);
        }

        ISet<Stmt> GetStmtFromVertices(IEnumerable<string> vertices)
        {
            var returnSet = new HashSet<Stmt>();
            foreach(var vertex in vertices)
            { 
                var data = _browsingData.LineSpans[vertex];
                var splitResult = vertex.Split('.');
                var tempStmt = new Stmt();
                tempStmt.FileId = Convert.ToInt32(splitResult[0]);
                tempStmt.Line = Convert.ToInt32(splitResult[1]);
                tempStmt.SpanStart = data.Item1;
                tempStmt.SpanEnd = data.Item2;
                returnSet.Add(tempStmt);
            }
            return returnSet;
        }
        #endregion

        #region Helpers
        int getCurrentDocumentId(TextEditorControl textEditorControl = null)
        {
            var currentEC = textEditorControl ?? _currentTextEditorControl;
            var entry = _idToFiles.Where(x => "tec:" + x.Value == currentEC.Name);
            if (entry.Count() == 0)
                return 0;
            return entry.Single().Key;
        }

        private void menuEditFind_Click(object sender, EventArgs e)
        {
            _findForm.ShowFor(_currentTextEditorControl);
        }

        private void menuFindAgain_Click(object sender, EventArgs e)
        {
            _findForm.FindNext(true, false,
                string.Format("Search text «{0}» not found.", _findForm.LookFor));
        }

        private void menuFindAgainReverse_Click(object sender, EventArgs e)
        {
            _findForm.FindNext(true, true,
                string.Format("Search text «{0}» not found.", _findForm.LookFor));
        }

        private void ComplexBrowser_FormClosing(object sender, FormClosingEventArgs e)
        {
            _sourcesAndTargets.Close();
        }
        #endregion
    }
}
