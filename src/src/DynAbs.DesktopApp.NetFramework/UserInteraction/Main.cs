using Buildalyzer;
using Buildalyzer.Workspaces;
using DC.Slicer;
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
using System.Xml.Serialization;
using Tracer;

namespace SliceBrowser
{
    public partial class Main : Form
    {
        OpenFileDialog _ofd { get; set; }
        string _currentUserConfigurationPath { get; set; }

        Orchestrator orchestrator;

        string[] StatusText = { "Waiting for a job...", "Loading solution", "Executing", "Done" };

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            cmbMode.Items.Add("Normal");
            cmbMode.Items.Add("No break");
            cmbMode.Items.Add("Load results");

            CleanForm();
            
            _ofd = new OpenFileDialog();
            _ofd.InitialDirectory = "c:\\";
            _ofd.RestoreDirectory = true;

            var defaultConfigurationFile = System.Configuration.ConfigurationSettings.AppSettings["defaultConfigurationFile"];
            if (!string.IsNullOrWhiteSpace(defaultConfigurationFile) && System.IO.File.Exists(defaultConfigurationFile))
            {
                _currentUserConfigurationPath = defaultConfigurationFile;
                LoadFile(System.IO.File.OpenRead(defaultConfigurationFile));
            }
        }

        void CleanForm()
        {
            // Solution
            txtUserSolution.Text = "";
            txtInstrumentedSolution.Text = "";
            txtExecutableProject.Text = "";
            txtCompilationOutputFolder.Text = "";
            chkMSBuildCompilation.Checked = false;
            // Criteria
            txtFile.Text = "";
            txtLine.Text = "";
            chkRunAutomatically.Checked = false;
            cmbMode.SelectedValue = null;
            chkFileTraceInput.Checked = false;
            chkNotCompile.Checked = false;
            txtFileTraceInputPath.Text = "";
            // Results
            txtName.Text = "";
            txtOutputFolder.Text = "";
            txtSummary.Text = "";
            txtExecutedLinesForUser.Text = "";
            txtExecutedLines.Text = "";
            txtResultFile.Text = "";
            txtFilteredResultFile.Text = "";
            txtSliceDependenciesGraphFolder.Text = "";
            txtDependencyGraph.Text = "";
            txtDependencyGraphPlot.Text = "";
            txtPointsToGraphPlot.Text = "";
            chkPrintGraphForEachStatement.Checked = false;
            // Customization
            txtSummaries.Text = "";
            chkIncludeControlDependencies.Checked = true;
            chkIncludeAllUses.Checked = false;
            chkStaticMode.Checked = true;
            chkLoopsOptimization.Checked = true;
            // Program inputs
            txtInstances.Text = "";

            chkInstrumentAndCompile.Checked = true;
            chkInstrumentAndCompile_CheckedChanged(null, null);

            // Buttons
            orchestrator = null;
            lblStatus.Text = StatusText[0];
            btnStart.Enabled = true;
            btnNavigateDG.Enabled = false;
            btnNavigateSliceDG.Enabled = false;
            btnClean.Enabled = false;
        }

        void LoadFile(Stream stream)
        {
            var serializer = new XmlSerializer(typeof(UserConfiguration));
            var userConfiguration = (UserConfiguration)serializer.Deserialize(stream);

            // Solution
            txtUserSolution.Text = userConfiguration.solutionFiles.solutionPath;
            txtExecutableProject.Text = userConfiguration.solutionFiles.executableProject;
            if (string.IsNullOrWhiteSpace(userConfiguration.solutionFiles.instrumentedSolutionPath))
            {
                chkInstrumentAndCompile.Checked = true;
                chkInstrumentAndCompile_CheckedChanged(null, null);

                txtCompilationOutputFolder.Text = userConfiguration.solutionFiles.compilationOutputFolder;
                chkMSBuildCompilation.Checked = userConfiguration.solutionFiles.MSBuildCompilation;
            }
            else
            {
                chkInstrumentAndCompile.Checked = false;
                chkInstrumentAndCompile_CheckedChanged(null, null);

                txtInstrumentedSolution.Text = userConfiguration.solutionFiles.instrumentedSolutionPath;
            }

            // Criteria
            cmbMode.SelectedIndex = (int)userConfiguration.criteria.mode;
            if (userConfiguration.criteria.lines != null && userConfiguration.criteria.lines.Count() > 0)
            { 
                txtFile.Text = userConfiguration.criteria.lines.First().file;
                txtLine.Text = userConfiguration.criteria.lines.First().line.ToString();
            }
            chkFileTraceInput.Checked = userConfiguration.criteria.fileTraceInput;
            txtFileTraceInputPath.Text = userConfiguration.criteria.fileTraceInputPath;
            chkRunAutomatically.Checked = userConfiguration.criteria.runAutomatically;
            chkNotCompile.Checked = userConfiguration.criteria.notCompile;
            // Results
            txtName.Text = userConfiguration.results.name;
            txtOutputFolder.Text = userConfiguration.results.outputFolder;
            txtSummary.Text = userConfiguration.results.summaryResultFile;
            txtExecutedLinesForUser.Text = userConfiguration.results.executedLinesFileForUser;
            txtExecutedLines.Text = userConfiguration.results.executedLinesFile;
            txtResultFile.Text = userConfiguration.results.resultFile;
            txtFilteredResultFile.Text = userConfiguration.results.filteredResultFile;
            txtSliceDependenciesGraphFolder.Text = userConfiguration.results.sliceDependenciesGraphFolder;
            txtDependencyGraph.Text = userConfiguration.results.dependencyGraphFile;
            txtDependencyGraphPlot.Text = userConfiguration.results.dependencyGraphDot;
            txtPointsToGraphPlot.Text = userConfiguration.results.pointsToGraphDot;
            chkPrintGraphForEachStatement.Checked = userConfiguration.results.printGraphForEachStatement;
            // Customization
            if (userConfiguration.customization != null)
            { 
                txtSummaries.Text = userConfiguration.customization.summaries;
                chkIncludeControlDependencies.Checked = userConfiguration.customization.includeControlDependencies;
                chkIncludeAllUses.Checked = userConfiguration.customization.includeAllUses;
                chkStaticMode.Checked = userConfiguration.customization.staticMode;
                chkLoopsOptimization.Checked = userConfiguration.customization.loopsOptimization;
            }
            // Program inputs
            if (userConfiguration.instances != null &&
                userConfiguration.instances.Count() > 0 &&
                userConfiguration.instances.First().parameters != null)
                txtInstances.Text = string.Join(",", userConfiguration.instances.First().parameters);

            stream.Close();
        }

        void SaveFile(Stream stream)
        {
            var userConfiguration = GetCurrentUserConfiguration();
            var serializer = new XmlSerializer(typeof(UserConfiguration));
            serializer.Serialize(stream, userConfiguration);

            stream.Close();
        }

        UserConfiguration GetCurrentUserConfiguration()
        {
            var userConfiguration = new UserConfiguration();
            // Solution
            userConfiguration.solutionFiles = new UserConfiguration.SolutionFiles();
            userConfiguration.solutionFiles.solutionPath = txtUserSolution.Text;
            userConfiguration.solutionFiles.instrumentedSolutionPath = txtInstrumentedSolution.Text;
            userConfiguration.solutionFiles.executableProject = txtExecutableProject.Text;
            userConfiguration.solutionFiles.compilationOutputFolder = txtCompilationOutputFolder.Text;
            userConfiguration.solutionFiles.MSBuildCompilation = chkMSBuildCompilation.Checked;
            // Criteria
            userConfiguration.criteria = new UserConfiguration.Criteria();
            userConfiguration.criteria.mode = (UserConfiguration.Criteria.CriteriaMode)((int)cmbMode.SelectedIndex);
            userConfiguration.criteria.lines = new UserConfiguration.Criteria.FileLine[] { 
                new DC.Slicer.UserConfiguration.Criteria.FileLine { file = txtFile.Text, line = string.IsNullOrWhiteSpace(txtLine.Text) ? (int?)null : Convert.ToInt32(txtLine.Text) } };
            userConfiguration.criteria.fileTraceInput = chkFileTraceInput.Checked;
            userConfiguration.criteria.fileTraceInputPath = txtFileTraceInputPath.Text;
            userConfiguration.criteria.runAutomatically = chkRunAutomatically.Checked;
            userConfiguration.criteria.notCompile = chkNotCompile.Checked;
            // Results
            userConfiguration.results = new UserConfiguration.Results();
            userConfiguration.results.name = txtName.Text;
            userConfiguration.results.outputFolder = txtOutputFolder.Text;
            userConfiguration.results.summaryResultFile = txtSummary.Text;
            userConfiguration.results.executedLinesFileForUser = txtExecutedLinesForUser.Text;
            userConfiguration.results.executedLinesFile = txtExecutedLines.Text;
            userConfiguration.results.resultFile = txtResultFile.Text;
            userConfiguration.results.filteredResultFile = txtFilteredResultFile.Text;
            userConfiguration.results.sliceDependenciesGraphFolder = txtSliceDependenciesGraphFolder.Text;
            userConfiguration.results.dependencyGraphFile = txtDependencyGraph.Text;
            userConfiguration.results.dependencyGraphDot = txtDependencyGraphPlot.Text;
            userConfiguration.results.pointsToGraphDot = txtPointsToGraphPlot.Text;
            userConfiguration.results.printGraphForEachStatement = chkPrintGraphForEachStatement.Checked;
            // Customization
            userConfiguration.customization = new UserConfiguration.Customization();
            userConfiguration.customization.summaries = txtSummaries.Text;
            userConfiguration.customization.includeControlDependencies = chkIncludeControlDependencies.Checked;
            userConfiguration.customization.includeAllUses = chkIncludeAllUses.Checked;
            userConfiguration.customization.staticMode = chkStaticMode.Checked;
            userConfiguration.customization.loopsOptimization = chkLoopsOptimization.Checked;
            // Inputs
            if (txtInstances.Text.Trim() != "")
                userConfiguration.instances = new UserConfiguration.Instance[] { new UserConfiguration.Instance() { parameters = txtInstances.Text.Split(',').Select(x => x.Trim()).ToArray() } };

            return userConfiguration;
        }

        void RunProgram()
        {
            var userConfiguration = GetCurrentUserConfiguration();
            var errors = new List<string>(); // ValidateUserConfiguration(userConfiguration);
            if (errors.Count == 0)
            {
                btnStart.Enabled = false;
                btnStart.Refresh();
                lblStatus.Text = StatusText[1];
                lblStatus.Refresh();

                try
                {
                    // XXXXXXXXXXXXXXXXXX

                    var stream = System.IO.File.OpenRead(_currentUserConfigurationPath);
                    var serializer = new XmlSerializer(typeof(UserConfiguration));
                    var currentUserConfiguration = (UserConfiguration)serializer.Deserialize(stream);

                    // XXXXXXXXXXXXXXXXXX

                    orchestrator = new Orchestrator(currentUserConfiguration);
                    orchestrator.UserInteraction = true;

                    lblStatus.Text = StatusText[2];
                    lblStatus.Refresh();
                    orchestrator.Orchestrate();

                    lblStatus.Text = StatusText[3];
                    btnClean.Enabled = true;
                    btnNavigateDG.Enabled = true;
                    btnNavigateSliceDG.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("There was an application failure");
                    MessageBox.Show(ex.Message);
                    MessageBox.Show(ex.StackTrace);
                    btnClean.Enabled = false;
                    btnNavigateDG.Enabled = false;
                    btnNavigateSliceDG.Enabled = false;
                    btnStart.Enabled = true;
                }
            }
            else
                MessageBox.Show("There are configuration errors: \r\n" + string.Join("\r\n", errors));
        }

        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            CleanForm();
            _currentUserConfigurationPath = "";
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Stream myStream = null;
            openFileDialog.FileName = "";
            openFileDialog.InitialDirectory = System.IO.Directory.GetCurrentDirectory();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog.OpenFile()) != null)
                    {
                        LoadFile(myStream);
                        _currentUserConfigurationPath = openFileDialog.FileName;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("No se ha podido abrir el archivo. Error: " + ex.Message);
                }
            }
        }

        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(_currentUserConfigurationPath))
            {
                var stream = System.IO.File.OpenWrite(_currentUserConfigurationPath);
                SaveFile(stream);
            }
            else
                saveAsToolStripMenuItem1_Click(null, null);
        }

        private void saveAsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Slicer files|*.slc";
            saveFileDialog.Title = "Slicer configuration";
            saveFileDialog.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog.FileName != "")
            {
                // Saves the Image via a FileStream created by the OpenFile method.
                System.IO.FileStream fs =
                   (System.IO.FileStream)saveFileDialog.OpenFile();

                SaveFile(fs);

                fs.Close();

                _currentUserConfigurationPath = Path.GetExtension(saveFileDialog.FileName).ToLower() == ".slc" ? saveFileDialog.FileName : saveFileDialog.FileName + ".slc";
            }
        }

        private void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void chkInstrumentAndCompile_CheckedChanged(object sender, EventArgs e)
        {
            if (chkInstrumentAndCompile.Checked)
            {
                txtInstrumentedSolution.Enabled = false;
                txtInstrumentedSolution.Text = "";
                lblInstrumentedSolution.Visible = false;
                btnInstrumentedSolution.Enabled = false;

                txtCompilationOutputFolder.Enabled = true;
                chkMSBuildCompilation.Enabled = true;
                lblCompilationOutputFolder.Visible = true;
                lblMSBuildCompilation.Visible = true;
                btnCompilationOutputFolder.Enabled = true;
            }
            else
            {
                txtCompilationOutputFolder.Enabled = false;
                chkMSBuildCompilation.Enabled = false;
                txtCompilationOutputFolder.Text = "";
                chkMSBuildCompilation.Checked = false;
                lblCompilationOutputFolder.Visible = false;
                lblMSBuildCompilation.Visible = false;
                btnCompilationOutputFolder.Enabled = false;

                txtInstrumentedSolution.Enabled = true;
                lblInstrumentedSolution.Visible = true;
                btnInstrumentedSolution.Enabled = true;
            }
        }

        void LoadControlWithOpenFileDialog(TextBox textBox, string filter)
        {
            _ofd.Filter = filter;
            if (_ofd.ShowDialog() == DialogResult.OK)
                textBox.Text = _ofd.FileName;
        }

        private void btnUserSolution_Click(object sender, EventArgs e)
        {
            LoadControlWithOpenFileDialog(txtUserSolution, "Visual Studio Solution File (*.sln)|*.sln");
        }

        private void btnCompilationOutputFolder_Click(object sender, EventArgs e)
        {
            var fbd = new System.Windows.Forms.FolderBrowserDialog();
            fbd.RootFolder = Environment.SpecialFolder.Desktop;
            if (fbd.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                txtCompilationOutputFolder.Text = fbd.SelectedPath;
        }

        private void btnInstrumentedSolution_Click(object sender, EventArgs e)
        {
            LoadControlWithOpenFileDialog(txtInstrumentedSolution, "Visual Studio Solution File (*.sln)|*.sln");
        }

        private void btnFileTraceInput_Click(object sender, EventArgs e)
        {
            LoadControlWithOpenFileDialog(txtFileTraceInputPath, "Text (*.txt)|*.txt|All Files|*.*");
        }

        private void btnExecutedLines_Click(object sender, EventArgs e)
        {
            LoadControlWithOpenFileDialog(txtExecutedLines, "Text (*.txt)|*.txt|All Files|*.*");
        }

        private void btnDependencyGraph_Click(object sender, EventArgs e)
        {
            LoadControlWithOpenFileDialog(txtDependencyGraph, "Text (*.txt)|*.txt|All Files|*.*");
        }

        private void btnSummaries_Click(object sender, EventArgs e)
        {
            LoadControlWithOpenFileDialog(txtSummaries, "XML (*.xml)|*.xml");
        }

        private void btnFile_Click(object sender, EventArgs e)
        {
            var currentConfiguration = GetCurrentUserConfiguration();
            if (!string.IsNullOrWhiteSpace(currentConfiguration.solutionFiles.solutionPath))
            {
                var manager = new AnalyzerManager(currentConfiguration.solutionFiles.solutionPath);
                var workspace = manager.GetWorkspace();
                var solution = workspace.CurrentSolution;

                var files = solution.Projects.SelectMany(x => x.Documents).Where(x => Path.GetExtension(x.FilePath) == ".cs"
                    && Path.GetFileName(x.FilePath) != "AssemblyInfo.cs" && Path.GetFileName(x.FilePath) != "AssemblyAttributes.cs")
                    .Select(x => x.FilePath);
                SliceCriteria.Run(files.ToArray());
                txtFile.Text = SliceCriteria.SliceCriteriaFile;
                txtLine.Text = SliceCriteria.SliceCriteriaFileLine.ToString();
            }
            else
                MessageBox.Show("Seleccione una solución para poder visualizar los archivos disponibles");
        }

        private void startToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunProgram();
        }

        List<string> ValidateUserConfiguration(UserConfiguration userConfiguration)
        {
            var errors = new List<string>();
            if (string.IsNullOrWhiteSpace(userConfiguration.solutionFiles.solutionPath) || !System.IO.File.Exists(userConfiguration.solutionFiles.solutionPath))
                errors.Add("A solution must be defined");
            if (string.IsNullOrWhiteSpace(userConfiguration.solutionFiles.executableProject))
                errors.Add("An executable project must be defined");
            if ((string.IsNullOrWhiteSpace(userConfiguration.solutionFiles.instrumentedSolutionPath)||(!System.IO.File.Exists(userConfiguration.solutionFiles.instrumentedSolutionPath)))
                && (string.IsNullOrWhiteSpace(userConfiguration.solutionFiles.compilationOutputFolder)))
                errors.Add("Specify the insturmented solution path or a compilation output folder");

            // Modos
            if (userConfiguration.criteria.mode == UserConfiguration.Criteria.CriteriaMode.LoadResults)
            {
                if (string.IsNullOrWhiteSpace(userConfiguration.results.executedLinesFile) || !System.IO.File.Exists(userConfiguration.results.executedLinesFile))
                    errors.Add("Executed lines files must be defined");
                if (string.IsNullOrWhiteSpace(userConfiguration.results.dependencyGraphFile) || !System.IO.File.Exists(userConfiguration.results.dependencyGraphFile))
                    errors.Add("Dependency graph file must be defined");
            }
            else if (userConfiguration.criteria.mode == UserConfiguration.Criteria.CriteriaMode.Normal)
            {
                if (userConfiguration.criteria.lines == null ||
                    (string.IsNullOrWhiteSpace(userConfiguration.criteria.lines.First().file) || !System.IO.File.Exists(userConfiguration.criteria.lines.First().file))
                    ||(userConfiguration.criteria.lines.First().line == null))
                    errors.Add("A criteria has to be defined");
            }

            // Customization
            if (chkLoopsOptimization.Checked && !chkStaticMode.Checked)
                errors.Add("Loops optimization requires PTG Compression");
            return errors;
        }

        private void cmdResultFile_Click(object sender, EventArgs e)
        {
            LoadControlWithOpenFileDialog(txtResultFile, "Text (*.txt)|*.txt|All Files|*.*");
        }

        private void btnSummary_Click(object sender, EventArgs e)
        {
            LoadControlWithOpenFileDialog(txtSummary, "Text (*.txt)|*.txt|All Files|*.*");
        }

        private void chkLoopsOptimization_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLoopsOptimization.Checked)
                chkStaticMode.Checked = true;
        }

        private void chkStaticMode_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkStaticMode.Checked)
                chkLoopsOptimization.Checked = false;
        }

        private void btnClean_Click(object sender, EventArgs e)
        {
            CleanForm();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            RunProgram();
        }

        private void btnNavigateDG_Click(object sender, EventArgs e)
        {
            var reducedCompleteDG = orchestrator.GetReducedDependencyGraph();
            var result = new ComplexBrowser(orchestrator.UserSolution, reducedCompleteDG, orchestrator.InstrumentationResult.fileIdToSyntaxTree,
                orchestrator.InstrumentationResult.IdToFileDictionary, orchestrator.ExecutedStmts);
            result.Show();
        }

        private void btnNavigateSliceDG_Click(object sender, EventArgs e)
        {
            var reducedSlicedDG = orchestrator.GetReducedSliceDependencyGraph();
            if (reducedSlicedDG != null)
            {
                var result = new ComplexBrowser(orchestrator.UserSolution, reducedSlicedDG, orchestrator.InstrumentationResult.fileIdToSyntaxTree,
                  orchestrator.InstrumentationResult.IdToFileDictionary, orchestrator.ExecutedStmts);
                result.Show();
            }
            else
                MessageBox.Show("There is not sliced dependency graph loaded");
        }
    }
}
