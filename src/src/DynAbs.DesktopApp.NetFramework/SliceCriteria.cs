using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using ICSharpCode.TextEditor;
using ICSharpCode.TextEditor.Document;
using Tracer;
using System.Threading;

namespace SliceBrowser
{
    public partial class SliceCriteria : Form
    {
        private readonly string[] files;
        public static string SliceCriteriaFile { get; set; }
        public static int SliceCriteriaFileLine { get; set; }
        TextMarker lineMarker;

        public static void Run(string[] files)
        {
            var thread = new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new SliceCriteria(files));
            });
            thread.SetApartmentState(ApartmentState.STA);
            thread.Start();
            thread.Join();
        }

        public SliceCriteria(string[] files)
        {
            this.files = files;
            InitializeComponent();
        }

        private void sliceViewer_Load(object sender, EventArgs e)
        {
            // Load the syntax highlighting for C#.
            sliceViewer.SetHighlighting("C#");
            loaded_files.DataSource = files;

            ChangeFile(files.First());
            sliceViewer.ActiveTextAreaControl.JumpTo(0);
            sliceViewer.ActiveTextAreaControl.TextArea.MouseClick += new MouseEventHandler(this.mouseClick);
        }

        private void mouseClick(object sender, MouseEventArgs e)
        {
            if (lineMarker != null)
            {
                sliceViewer.Document.MarkerStrategy.RemoveMarker(lineMarker);
            }
            var loc = sliceViewer.ActiveTextAreaControl.Caret.Position;
            var line = sliceViewer.ActiveTextAreaControl.Caret.Line;
            var nextLine = sliceViewer.ActiveTextAreaControl.Caret.Line + 1;
            var lineOffset = getLineOffset(line);
            var nextLineOffset = getLineOffset(nextLine);
            var length = nextLineOffset - lineOffset;
            lineMarker = new TextMarker(lineOffset, length, TextMarkerType.SolidBlock, Color.LightBlue);
            sliceViewer.Document.MarkerStrategy.AddMarker(lineMarker);
            sliceViewer.ActiveTextAreaControl.Caret.Position = loc;
            TextAreaUpdate updatedArea = new TextAreaUpdate(TextAreaUpdateType.WholeTextArea);
            sliceViewer.Document.RequestUpdate(updatedArea);
            sliceViewer.Document.CommitUpdate();
        }

        private int getLineOffset(int line)
        {
            TextLocation loc = new TextLocation(0, line);
            sliceViewer.ActiveTextAreaControl.Caret.Position = loc;
            int offset = sliceViewer.ActiveTextAreaControl.Caret.Offset;
            return offset;
        }

        private void ChangeFile(string file)
        {
            using (var reader = new StreamReader(file))
            {
                // Clean text area.
                sliceViewer.Text = "";

                // Load new file.
                sliceViewer.ActiveTextAreaControl.TextArea.InsertString(reader.ReadToEnd());

                // Update current file id.
                SliceCriteriaFile = file;
            }
            sliceViewer.ActiveTextAreaControl.ScrollTo(1);
            loaded_files.SelectedIndex = loaded_files.FindStringExact(file);
        }

        private void loaded_files_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (loaded_files.SelectedItem != null)
            {
                var selectedFile = loaded_files.SelectedText;
                if (!string.IsNullOrWhiteSpace(selectedFile) && selectedFile != SliceCriteriaFile)
                {
                    ChangeFile(selectedFile);
                }
            }
        }

        private void next_button_Click(object sender, EventArgs e)
        {
            var line = sliceViewer.ActiveTextAreaControl.Caret.Line + 1;
            var confirmResult = MessageBox.Show("Are you sure to slice until this line? (Line: " + line + ")", "Line To Slice", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                SliceCriteriaFileLine = line;
                this.Close();
            }
            else
            {
                return;
            }
        }
    }
}