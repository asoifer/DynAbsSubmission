namespace SliceBrowser
{
    partial class ComplexBrowser
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tvArchivos = new System.Windows.Forms.TreeView();
            this.cmTextEditorMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.backwardSlicingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.forwardSliceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showDependenciesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.showDetailsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.closeTabToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findagainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.findAgainreverseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tcContainer = new System.Windows.Forms.TabControl();
            this.cmTextEditorMenu.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvArchivos
            // 
            this.tvArchivos.Location = new System.Drawing.Point(12, 50);
            this.tvArchivos.Name = "tvArchivos";
            this.tvArchivos.Size = new System.Drawing.Size(284, 838);
            this.tvArchivos.TabIndex = 0;
            this.tvArchivos.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvArchivos_AfterSelect);
            // 
            // cmTextEditorMenu
            // 
            this.cmTextEditorMenu.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.cmTextEditorMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.backwardSlicingToolStripMenuItem,
            this.forwardSliceToolStripMenuItem,
            this.toolStripSeparator1,
            this.showDependenciesToolStripMenuItem,
            this.showDetailsToolStripMenuItem,
            this.toolStripSeparator2,
            this.closeTabToolStripMenuItem});
            this.cmTextEditorMenu.Name = "cmTextEditorMenu";
            this.cmTextEditorMenu.Size = new System.Drawing.Size(243, 166);
            // 
            // backwardSlicingToolStripMenuItem
            // 
            this.backwardSlicingToolStripMenuItem.Name = "backwardSlicingToolStripMenuItem";
            this.backwardSlicingToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.backwardSlicingToolStripMenuItem.Text = "Backward slice";
            this.backwardSlicingToolStripMenuItem.Click += new System.EventHandler(this.backwardSlicingToolStripMenuItem_Click);
            // 
            // forwardSliceToolStripMenuItem
            // 
            this.forwardSliceToolStripMenuItem.Name = "forwardSliceToolStripMenuItem";
            this.forwardSliceToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.forwardSliceToolStripMenuItem.Text = "Forward slice";
            this.forwardSliceToolStripMenuItem.Click += new System.EventHandler(this.forwardSliceToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(239, 6);
            // 
            // showDependenciesToolStripMenuItem
            // 
            this.showDependenciesToolStripMenuItem.Name = "showDependenciesToolStripMenuItem";
            this.showDependenciesToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.showDependenciesToolStripMenuItem.Text = "Show dependencies";
            this.showDependenciesToolStripMenuItem.Click += new System.EventHandler(this.showDependenciesToolStripMenuItem_Click);
            // 
            // showDetailsToolStripMenuItem
            // 
            this.showDetailsToolStripMenuItem.Name = "showDetailsToolStripMenuItem";
            this.showDetailsToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.showDetailsToolStripMenuItem.Text = "Show details";
            this.showDetailsToolStripMenuItem.Click += new System.EventHandler(this.showDetailsToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(239, 6);
            // 
            // closeTabToolStripMenuItem
            // 
            this.closeTabToolStripMenuItem.Name = "closeTabToolStripMenuItem";
            this.closeTabToolStripMenuItem.Size = new System.Drawing.Size(242, 30);
            this.closeTabToolStripMenuItem.Text = "Close tab";
            this.closeTabToolStripMenuItem.Click += new System.EventHandler(this.closeTabToolStripMenuItem_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.editToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1678, 33);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findToolStripMenuItem,
            this.findagainToolStripMenuItem,
            this.findAgainreverseToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(54, 29);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // findToolStripMenuItem
            // 
            this.findToolStripMenuItem.Name = "findToolStripMenuItem";
            this.findToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.F)));
            this.findToolStripMenuItem.Size = new System.Drawing.Size(280, 30);
            this.findToolStripMenuItem.Text = "&Find...";
            this.findToolStripMenuItem.Click += new System.EventHandler(this.menuEditFind_Click);
            // 
            // findagainToolStripMenuItem
            // 
            this.findagainToolStripMenuItem.Name = "findagainToolStripMenuItem";
            this.findagainToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.H)));
            this.findagainToolStripMenuItem.Size = new System.Drawing.Size(280, 30);
            this.findagainToolStripMenuItem.Text = "Find &again";
            this.findagainToolStripMenuItem.Click += new System.EventHandler(this.menuFindAgain_Click);
            // 
            // findAgainreverseToolStripMenuItem
            // 
            this.findAgainreverseToolStripMenuItem.Name = "findAgainreverseToolStripMenuItem";
            this.findAgainreverseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.findAgainreverseToolStripMenuItem.Size = new System.Drawing.Size(280, 30);
            this.findAgainreverseToolStripMenuItem.Text = "Find again (&reverse)";
            this.findAgainreverseToolStripMenuItem.Click += new System.EventHandler(this.menuFindAgainReverse_Click);
            // 
            // tcContainer
            // 
            this.tcContainer.Location = new System.Drawing.Point(315, 50);
            this.tcContainer.Name = "tcContainer";
            this.tcContainer.SelectedIndex = 0;
            this.tcContainer.Size = new System.Drawing.Size(1239, 838);
            this.tcContainer.TabIndex = 4;
            // 
            // ComplexBrowser
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1678, 1038);
            this.Controls.Add(this.tcContainer);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.tvArchivos);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ComplexBrowser";
            this.Text = "Slice Browser 2.0";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ComplexBrowser_FormClosing);
            this.Load += new System.EventHandler(this.ComplexBrowser_Load);
            this.cmTextEditorMenu.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvArchivos;
        private System.Windows.Forms.ContextMenuStrip cmTextEditorMenu;
        private System.Windows.Forms.ToolStripMenuItem backwardSlicingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem forwardSliceToolStripMenuItem;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findagainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem findAgainreverseToolStripMenuItem;
        private System.Windows.Forms.TabControl tcContainer;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem showDependenciesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem showDetailsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem closeTabToolStripMenuItem;
    }
}