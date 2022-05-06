using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using DC.Slicer;
using System.Threading;
using Microsoft.CodeAnalysis.CSharp;
using QuickGraph;
using QuickGraph.Algorithms.Search;

namespace SliceBrowser
{
    public partial class SliceBrowser : Form
    {
        Dictionary<int, string> ExecutedFiles { get; set; }
        Dictionary<int, CSharpSyntaxTree> FileIdToSyntaxTree { get; set; }
        IEnumerable<Stmt> ExecutedStmts { get; set; }
        AdjacencyGraph<string, Edge<string>> SliceDG { get; set; }
        List<Stmt> SlicedStatements { get; set; }
        Dictionary<string, Tuple<int, int>> Data { get; set; }
        string CurrentCriteriaFile { get; set; }
        int CurrentCriteriaLine { get; set; }
        
        // Control
        Dictionary<int, List<Stmt>> StmtsInFile;
        Dictionary<int, Dictionary<Stmt, List<TextMarker>>> MarkersInFile;
        int CurrentFileId;
        int CurrentExecutedStmt;

        public static void Run(IEnumerable<Stmt> execStmts, Dictionary<int, string> files, Dictionary<int, CSharpSyntaxTree> fileIdToSyntaxTree, 
            ISet<Stmt> slicedStmts, 
            //Dictionary<string, ISet<Stmt>> sliceResult)
            AdjacencyGraph<string, Edge<string>> sliceDG, Dictionary<string, Tuple<int, int>> Data)
        {
            var thread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SliceBrowser(execStmts, files, fileIdToSyntaxTree, slicedStmts, sliceDG, Data));
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
        }

        public SliceBrowser(IEnumerable<Stmt> execStmts, Dictionary<int, string> files, Dictionary<int, CSharpSyntaxTree> fileIdToSyntaxTree, 
            ISet<Stmt> slicedStmts, 
            //Dictionary<string, ISet<Stmt>> sliceResult)
            AdjacencyGraph<string, Edge<string>> sliceDG, Dictionary<string, Tuple<int, int>> data)
        {
            ExecutedStmts = execStmts;
            ExecutedFiles = files;
            FileIdToSyntaxTree = fileIdToSyntaxTree;
            SlicedStatements = (slicedStmts ?? new HashSet<Stmt>()).ToList();
            //SliceResult = sliceResult;
            SliceDG = sliceDG;
            Data = data;
            CurrentCriteriaLine = -1;
            CurrentCriteriaFile = "";

            MarkersInFile = new Dictionary<int, Dictionary<Stmt, List<TextMarker>>>();
            StmtsInFile = SlicedStatements.GroupBy(x => x.FileId).ToDictionary(g => g.Key, g => g.ToList());
            InitializeComponent();
        }

        private void sliceViewer_Load(object sender, EventArgs e)
        {
            // Load the syntax highlighting for C#.
            sliceViewer.SetHighlighting("C#");
            loaded_files.DataSource = new BindingSource(ExecutedFiles, null);
            loaded_files.DisplayMember = "Value";
            loaded_files.ValueMember = "Key";
            //btnChangeCriteria.Visible = SliceResult != null;
            btnChangeCriteria.Visible = SliceDG != null;

            if (SlicedStatements.Count > 0)
            { 
                CurrentExecutedStmt = SlicedStatements.Count - 1;
                ShowStmt(SlicedStatements[CurrentExecutedStmt]);
                MarkCurrentStmt(SlicedStatements[CurrentExecutedStmt]);
            }
        }

        private void ShowStmt(Stmt stmt, bool reload = false)
        {
            if (CurrentFileId != stmt.FileId || reload)
                ChangeFile(stmt.FileId);
            MoveCursorToStmt(stmt);
            sliceViewer.ActiveTextAreaControl.ScrollTo(sliceViewer.ActiveTextAreaControl.Caret.Line);
            TextAreaRefresh();
        }

        private void TextAreaRefresh()
        {
            TextAreaUpdate updatedArea = new TextAreaUpdate(TextAreaUpdateType.WholeTextArea);
            sliceViewer.Document.RequestUpdate(updatedArea);
            sliceViewer.Document.CommitUpdate();
        }

        private void MarkCurrentStmt(Stmt stmt)
        {
            RemoveSolidMarkerForStmt(stmt);
            AddCurrentMarkerToStmt(stmt);
        }

        private void UnMarkCurrentStmt(Stmt stmt)
        {
            RemoveSolidMarkerForStmt(stmt);
            AddExecutedMarkerToStmt(stmt);
        }

        private void RemoveSolidMarkerForStmt(Stmt stmt)
        {
            var markersForStmts = MarkersInFile[stmt.FileId];
            var stmtMarkers = markersForStmts[stmt];
            var markers = stmtMarkers.Where(x => x.TextMarkerType == TextMarkerType.SolidBlock);
            
            foreach (var mark in markers)
                sliceViewer.Document.MarkerStrategy.RemoveMarker(mark);

            stmtMarkers.RemoveAll(x => x.TextMarkerType == TextMarkerType.SolidBlock);
        }

        private void ChangeFile(int fileId)
        {
            var file = ExecutedFiles.Single(x => x.Key == fileId);
            ChangeFile(file);
        }

        private void ChangeFile(KeyValuePair<int, string> file)
        {
            using (var reader = new StreamReader(file.Value))
            {
                // Clean text area.
                sliceViewer.Text = "";

                // Load new file.
                sliceViewer.ActiveTextAreaControl.TextArea.InsertString(reader.ReadToEnd());

                // Mark all executed spans in file.
                var executedStmtsInFile = ExecutedStmts.Where(x => x.FileId == file.Key).ToList();
                foreach (var stmt in executedStmtsInFile)
                {
                    AddExecutedMarkerToStmt(stmt);
                }

                // Mark sliced spans.
                if (StmtsInFile.ContainsKey(file.Key))
                {
                    foreach (var stmt in StmtsInFile[file.Key])
                    {
                        AddSlicedMarkerToStmt(stmt);
                    }
                }

                // Update current file id.
                CurrentFileId = file.Key;
            }
            sliceViewer.ActiveTextAreaControl.ScrollTo(1);
            loaded_files.SelectedIndex = loaded_files.FindStringExact(file.Value);
        }

        public void AddExecutedMarkerToStmt(Stmt stmt)
        {
            TextMarker marker = ExecutedStmtMarker(stmt);
            AddMarkerForStmt(stmt, marker);
            sliceViewer.Document.MarkerStrategy.AddMarker(marker);
        }

        public void AddCurrentMarkerToStmt(Stmt stmt)
        {
            TextMarker marker = CurrentStmtMarker(stmt);
            AddMarkerForStmt(stmt, marker);
            sliceViewer.Document.MarkerStrategy.AddMarker(marker);
        }

        public void AddSlicedMarkerToStmt(Stmt stmt)
        {
            TextMarker marker = SlicedStmtMarker(stmt);
            AddMarkerForStmt(stmt, marker);
            sliceViewer.Document.MarkerStrategy.AddMarker(marker);
        }

        public TextMarker ExecutedStmtMarker(Stmt stmt)
        {
            var spanStart = stmt.SpanStart;
            var spanEnd = stmt.SpanEnd;
            var length = spanEnd - spanStart;
            TextMarker marker = new TextMarker(spanStart, length, TextMarkerType.SolidBlock, Color.LightGoldenrodYellow);
            return marker;
        }

        public TextMarker SlicedStmtMarker(Stmt stmt)
        {
            int spanStart = stmt.SpanStart;
            int spanEnd = stmt.SpanEnd;
            int length = spanEnd - spanStart;
            TextMarker marker = new TextMarker(spanStart, length, TextMarkerType.Underlined, Color.Red);
            return marker;
        }
        
        public TextMarker CurrentStmtMarker(Stmt stmt)
        {
            int spanStart = stmt.SpanStart;
            int spanEnd = stmt.SpanEnd;
            int length = spanEnd - spanStart;
            TextMarker marker = new TextMarker(spanStart, length, TextMarkerType.SolidBlock, Color.Yellow);
            return marker;
        }

        public void AddMarkerForStmt(Stmt stmt, TextMarker marker)
        {
            if (MarkersInFile.ContainsKey(stmt.FileId))
            {
                var markersForStmts = MarkersInFile[stmt.FileId];
                if (markersForStmts.ContainsKey(stmt))
                {
                    markersForStmts[stmt].Add(marker);
                }
                else
                {
                    List<TextMarker> stmtMarkers = new List<TextMarker>();
                    stmtMarkers.Add(marker);
                    markersForStmts.Add(stmt, stmtMarkers);
                }
            }
            else
            {
                var markersForStmts = new Dictionary<Stmt, List<TextMarker>>(new StmtEqualityComparer());
                List<TextMarker> stmtMarkers = new List<TextMarker>();
                stmtMarkers.Add(marker);
                markersForStmts.Add(stmt, stmtMarkers);
                MarkersInFile.Add(stmt.FileId, markersForStmts);
            }
        }

        private void MoveCursorToStmt(Stmt stmt)
        {
            var startCol = stmt.SpanStart;
            int startLine = sliceViewer.Document.GetLineNumberForOffset(stmt.SpanStart);
            TextLocation loc = new TextLocation(startCol, startLine);
            sliceViewer.ActiveTextAreaControl.Caret.Position = loc;
        }

        private void loaded_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded_files.SelectedItem != null)
            {
                var selectedFile = (KeyValuePair<int, string>) loaded_files.SelectedItem;
                if (selectedFile.Key != CurrentFileId)
                {
                    ChangeFile(selectedFile);
                }
            }
        }

        private void back_button_Click(object sender, EventArgs e)
        {
            UnMarkCurrentStmt(SlicedStatements[CurrentExecutedStmt]);

            int tmp = CurrentExecutedStmt - 1;
            if (tmp < 0)
            {
                var confirmResult =
                    MessageBox.Show("Beginning of the execution trace reached. Do you want to go to the end?",
                        "Begining reached!",
                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                    CurrentExecutedStmt = SlicedStatements.Count - 1;
                else
                    return;
            }
            else
                CurrentExecutedStmt--;
            ShowStmt(SlicedStatements[CurrentExecutedStmt]);
            MarkCurrentStmt(SlicedStatements[CurrentExecutedStmt]);
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            UnMarkCurrentStmt(SlicedStatements[CurrentExecutedStmt]);

            int tmp = CurrentExecutedStmt + 1;
            if (tmp >= SlicedStatements.Count)
            {
                var confirmResult =
                    MessageBox.Show("End of the execution trace reached. Do you want to go to the beginning?",
                        "End reached!",
                        MessageBoxButtons.YesNo);
                if (confirmResult == DialogResult.Yes)
                    CurrentExecutedStmt = 0;
                else
                    return;
            }
            else
                CurrentExecutedStmt++;
            ShowStmt(SlicedStatements[CurrentExecutedStmt]);
            MarkCurrentStmt(SlicedStatements[CurrentExecutedStmt]);
        }

        private void begin_button_Click(object sender, EventArgs e)
        {
            UnMarkCurrentStmt(SlicedStatements[CurrentExecutedStmt]);
            CurrentExecutedStmt = 0;
            ShowStmt(SlicedStatements[CurrentExecutedStmt]);
            MarkCurrentStmt(SlicedStatements[CurrentExecutedStmt]);
        }

        private void end_button_Click(object sender, EventArgs e)
        {
            UnMarkCurrentStmt(SlicedStatements[CurrentExecutedStmt]);
            CurrentExecutedStmt = SlicedStatements.Count - 1;
            ShowStmt(SlicedStatements[CurrentExecutedStmt]);
            MarkCurrentStmt(SlicedStatements[CurrentExecutedStmt]);
        }

        private void btnChangeCriteria_Click(object sender, EventArgs e)
        {
            var sliceCriteria = new SliceCriteria(this.ExecutedFiles.Select(x => x.Value).ToArray());
            sliceCriteria.ShowDialog();

            var selectedLine = SliceCriteria.SliceCriteriaFileLine;
            var selectedFile = SliceCriteria.SliceCriteriaFile;
            if (selectedFile != CurrentCriteriaFile || selectedLine != CurrentCriteriaLine)
            {
                CurrentCriteriaFile = selectedFile;
                CurrentCriteriaLine = selectedLine;

                SlicedStatements = GetByFileIdAndLine(SliceDG, CurrentCriteriaFile, CurrentCriteriaLine).ToList();
                StmtsInFile = SlicedStatements.GroupBy(x => x.FileId).ToDictionary(g => g.Key, g => g.ToList());
                if (SlicedStatements.Count > 0)
                {
                    CurrentExecutedStmt = SlicedStatements.Count - 1;
                    ShowStmt(SlicedStatements[CurrentExecutedStmt], true);
                    MarkCurrentStmt(SlicedStatements[CurrentExecutedStmt]);
                }
                else
                {
                    ChangeFile(CurrentFileId);
                }
            }
        }

        ISet<Stmt> GetByFileIdAndLine(AdjacencyGraph<string, Edge<string>> graph, string file, int line)
        {
            var fileId = ExecutedFiles.Where(x => x.Value == file).Single().Key;
            if (Data != null)
            {
                var vertice = fileId + "." + line;
                var returnSet = new HashSet<Stmt>();
                if (!graph.Vertices.Contains(vertice))
                    return returnSet;

                var edges = BFS(graph, vertice);
                foreach (var edge in edges)
                {
                    var data = Data[edge];
                    var splitResult = edge.Split('.');
                    var tempStmt = new Stmt();
                    tempStmt.FileId = Convert.ToInt32(splitResult[0]);
                    tempStmt.Line = Convert.ToInt32(splitResult[1]);
                    tempStmt.SpanStart = data.Item1;
                    tempStmt.SpanEnd = data.Item2;
                    returnSet.Add(tempStmt);
                }
                return returnSet;
            }
            else
            { 
                // 1. Nos quedamos con las líneas del archivo (es pesado pero es necesario)
                var strFileId = fileId.ToString();
                var fileKeys = graph.Vertices.Where(x => x.Substring(0, x.IndexOf(':')) == strFileId);
                // 2. Nos quedamos con las líneas que nos interesan
                // Así es el formato actual: stmt.FileId + ":[" + stmt.SpanStart + ".." + stmt.SpanEnd + ")." + stmtOccurrenceCounter[stmt]
                var ast = FileIdToSyntaxTree[fileId];
                var selectedKey = "";
                var maxSpanSelectedKey = 0;
                var maxOcurrence = 0;
                foreach (var fileKey in fileKeys)
                {
                    var initSpanStart = fileKey.IndexOf('[') + 1;
                    var endSpanEnd = fileKey.IndexOf(')');
                    var difference = endSpanEnd - initSpanStart;
                    var keyValues = fileKey.Substring(initSpanStart, difference).Split('.');
                    var spanStart = Convert.ToInt32(keyValues[0]);
                    var spanEnd = Convert.ToInt32(keyValues[2]);
                    var span = Microsoft.CodeAnalysis.Text.TextSpan.FromBounds(spanStart, spanEnd);
                    var node = ast.GetCompilationUnitRoot().FindNode(span);
                    var lineInRoslyn = node.GetLocation().GetLineSpan().StartLinePosition.Line;
                    var fileKeyLine = lineInRoslyn + 1;
                    if (fileKeyLine == line)
                    {
                        // Nos quedamos con el máximo (el que más abarca) y la última ocurrencia
                        var stmtLong = spanEnd - spanStart;
                        var ocurrence = Convert.ToInt32(fileKey.Split('.')[3]);
                        if (spanEnd - spanStart >= maxSpanSelectedKey && ocurrence > maxOcurrence)
                        {
                            selectedKey = fileKey;
                            maxSpanSelectedKey = stmtLong;
                            maxOcurrence = ocurrence;
                        }
                    }
                }

                if (selectedKey == "")
                    return new HashSet<Stmt>();

                //var dfs = new BreadthFirstSearchAlgorithm<string, Edge<string>>(SliceDG);
                //dfs.Compute(selectedKey);
                var result = new List<Stmt>();
                //foreach (var v in dfs.VisitedGraph.Vertices)
                var bfs = BFS(graph, selectedKey);
                foreach (var v in bfs)
                {
                    var currentFileId = Convert.ToInt32(v.Substring(0, v.IndexOf(':')));
                    var initSpanStart = v.IndexOf('[') + 1;
                    var endSpanEnd = v.IndexOf(')');
                    var difference = endSpanEnd - initSpanStart;
                    var keyValues = v.Substring(initSpanStart, difference).Split('.');
                    var spanStart = Convert.ToInt32(keyValues[0]);
                    var spanEnd = Convert.ToInt32(keyValues[2]);
                    var span = Microsoft.CodeAnalysis.Text.TextSpan.FromBounds(spanStart, spanEnd);
                    var currentAst = FileIdToSyntaxTree[currentFileId];
                    var node = currentAst.GetCompilationUnitRoot().FindNode(span);
                    var lineInRoslyn = node.GetLocation().GetLineSpan().StartLinePosition.Line;
                    var fileKeyLine = lineInRoslyn + 1;
                    result.Add(new Stmt() { FileId = currentFileId, Line = fileKeyLine, SpanStart = spanStart, SpanEnd = spanEnd });
                }
                return new HashSet<Stmt>(result);
            }
        }

        public ISet<string> BFS(AdjacencyGraph<string, Edge<string>> graph, string initial)
        {
            var vertices = new HashSet<string>(new string[] { initial });
            var visited = new HashSet<string>();
            var toVisit = new HashSet<string>();
            toVisit.UnionWith(vertices);
            bool firstLoop = true;

            while (toVisit.Count > 0)
            {
                var visiting = new HashSet<string>();
                foreach (var v in toVisit)
                {
                    if (visited.Contains(v)) continue;

                    if (chkForward.Checked)
                    {
                        var inEdges = GetInEdges(graph, v);
                        foreach (var v2 in inEdges)
                            visiting.Add(v2.Source);
                    }
                    else
                        foreach (var v2 in graph.OutEdges(v))
                            visiting.Add(v2.Target);
                }
                //if (!firstLoop)
                    visited.UnionWith(toVisit);
                firstLoop = false;
                toVisit.Clear();
                toVisit.UnionWith(visiting);
            }

            return visited;
        }

        public List<Edge<string>> GetInEdges(AdjacencyGraph<string, Edge<string>> graph, string vertex)
        {
            var returnList = new List<Edge<string>>();
            foreach (var v in graph.Vertices)
            {
                Edge<string> edge;
                if (graph.TryGetEdge(v, vertex, out edge))
                    returnList.Add(edge);
            }
            return returnList;
        }
    }

    public class StmtEqualityComparer : EqualityComparer<Stmt>
    {
        public override bool Equals(Stmt x, Stmt y)
        {
            return x.FileId == y.FileId && x.SpanStart == y.SpanStart && x.SpanEnd == y.SpanEnd;
        }

        public override int GetHashCode(Stmt obj)
        {
            return System.Runtime.CompilerServices.RuntimeHelpers.GetHashCode(obj);
        }
    }
}