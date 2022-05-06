namespace SliceBrowser.UserInteraction
{
    partial class SourcesAndTargets
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
            this.tvSource = new System.Windows.Forms.TreeView();
            this.lbSource = new System.Windows.Forms.ListBox();
            this.tvTarget = new System.Windows.Forms.TreeView();
            this.lbTarget = new System.Windows.Forms.ListBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.lblCurrentLine = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tvSource
            // 
            this.tvSource.Location = new System.Drawing.Point(15, 36);
            this.tvSource.Name = "tvSource";
            this.tvSource.Size = new System.Drawing.Size(250, 624);
            this.tvSource.TabIndex = 0;
            this.tvSource.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSource_AfterSelect);
            // 
            // lbSource
            // 
            this.lbSource.FormattingEnabled = true;
            this.lbSource.ItemHeight = 20;
            this.lbSource.Location = new System.Drawing.Point(271, 36);
            this.lbSource.Name = "lbSource";
            this.lbSource.Size = new System.Drawing.Size(400, 624);
            this.lbSource.TabIndex = 1;
            this.lbSource.SelectedIndexChanged += new System.EventHandler(this.lbSource_SelectedIndexChanged);
            // 
            // tvTarget
            // 
            this.tvTarget.Location = new System.Drawing.Point(16, 36);
            this.tvTarget.Name = "tvTarget";
            this.tvTarget.Size = new System.Drawing.Size(250, 624);
            this.tvTarget.TabIndex = 2;
            this.tvTarget.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTarget_AfterSelect);
            // 
            // lbTarget
            // 
            this.lbTarget.FormattingEnabled = true;
            this.lbTarget.ItemHeight = 20;
            this.lbTarget.Location = new System.Drawing.Point(272, 36);
            this.lbTarget.Name = "lbTarget";
            this.lbTarget.Size = new System.Drawing.Size(400, 624);
            this.lbTarget.TabIndex = 3;
            this.lbTarget.SelectedIndexChanged += new System.EventHandler(this.lbTarget_SelectedIndexChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.tvSource);
            this.panel1.Controls.Add(this.lbSource);
            this.panel1.Location = new System.Drawing.Point(12, 45);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(709, 673);
            this.panel1.TabIndex = 4;
            this.panel1.Tag = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 29);
            this.label1.TabIndex = 2;
            this.label1.Text = "Depende de...";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.lbTarget);
            this.panel2.Controls.Add(this.tvTarget);
            this.panel2.Location = new System.Drawing.Point(728, 45);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(738, 673);
            this.panel2.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 4);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(252, 29);
            this.label2.TabIndex = 3;
            this.label2.Text = "Es dependencia de...";
            // 
            // lblCurrentLine
            // 
            this.lblCurrentLine.AutoSize = true;
            this.lblCurrentLine.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCurrentLine.Location = new System.Drawing.Point(13, 11);
            this.lblCurrentLine.Name = "lblCurrentLine";
            this.lblCurrentLine.Size = new System.Drawing.Size(149, 29);
            this.lblCurrentLine.TabIndex = 6;
            this.lblCurrentLine.Text = "Analizando:";
            // 
            // SourcesAndTargets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1678, 731);
            this.Controls.Add(this.lblCurrentLine);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SourcesAndTargets";
            this.Text = "Edges From | Edges To";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.sourcesAndTargets_FormClosing);
            this.Load += new System.EventHandler(this.SourcesAndTargets_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TreeView tvSource;
        private System.Windows.Forms.ListBox lbSource;
        private System.Windows.Forms.TreeView tvTarget;
        private System.Windows.Forms.ListBox lbTarget;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblCurrentLine;       
    }
}