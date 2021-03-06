namespace SliceBrowser
{
    partial class SliceCriteria
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
            this.sliceViewer = new ICSharpCode.TextEditor.TextEditorControl();
            this.loaded_files = new System.Windows.Forms.ComboBox();
            this.next_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // sliceViewer
            // 
            this.sliceViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sliceViewer.IsReadOnly = false;
            this.sliceViewer.Location = new System.Drawing.Point(18, 66);
            this.sliceViewer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.sliceViewer.Name = "sliceViewer";
            this.sliceViewer.Size = new System.Drawing.Size(1122, 769);
            this.sliceViewer.TabIndex = 0;
            this.sliceViewer.Load += new System.EventHandler(this.sliceViewer_Load);
            // 
            // loaded_files
            // 
            this.loaded_files.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.loaded_files.FormattingEnabled = true;
            this.loaded_files.Location = new System.Drawing.Point(18, 18);
            this.loaded_files.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.loaded_files.Name = "loaded_files";
            this.loaded_files.Size = new System.Drawing.Size(960, 28);
            this.loaded_files.TabIndex = 3;
            this.loaded_files.SelectedIndexChanged += new System.EventHandler(this.loaded_files_SelectedIndexChanged);
            // 
            // next_button
            // 
            this.next_button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.next_button.Location = new System.Drawing.Point(988, 18);
            this.next_button.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.next_button.Name = "next_button";
            this.next_button.Size = new System.Drawing.Size(152, 35);
            this.next_button.TabIndex = 4;
            this.next_button.Text = "Mark To Slice";
            this.next_button.UseVisualStyleBackColor = true;
            this.next_button.Click += new System.EventHandler(this.next_button_Click);
            // 
            // SliceCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1158, 854);
            this.Controls.Add(this.next_button);
            this.Controls.Add(this.loaded_files);
            this.Controls.Add(this.sliceViewer);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "SliceCriteria";
            this.Text = "SliceCriteria";
            this.ResumeLayout(false);

        }

        #endregion

        private ICSharpCode.TextEditor.TextEditorControl sliceViewer;
        private System.Windows.Forms.ComboBox loaded_files;
        private System.Windows.Forms.Button next_button;
    }
}

