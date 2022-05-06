namespace SliceBrowser
{
	partial class FindAndReplaceForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtLookFor = new System.Windows.Forms.TextBox();
            this.btnFindNext = new System.Windows.Forms.Button();
            this.chkMatchWholeWord = new System.Windows.Forms.CheckBox();
            this.chkMatchCase = new System.Windows.Forms.CheckBox();
            this.btnHighlightAll = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFindPrevious = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 14);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fi&nd what:";
            // 
            // txtLookFor
            // 
            this.txtLookFor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtLookFor.Location = new System.Drawing.Point(135, 9);
            this.txtLookFor.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtLookFor.Name = "txtLookFor";
            this.txtLookFor.Size = new System.Drawing.Size(346, 26);
            this.txtLookFor.TabIndex = 1;
            // 
            // btnFindNext
            // 
            this.btnFindNext.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindNext.Location = new System.Drawing.Point(370, 75);
            this.btnFindNext.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFindNext.Name = "btnFindNext";
            this.btnFindNext.Size = new System.Drawing.Size(112, 35);
            this.btnFindNext.TabIndex = 6;
            this.btnFindNext.Text = "&Find next";
            this.btnFindNext.UseVisualStyleBackColor = true;
            this.btnFindNext.Click += new System.EventHandler(this.btnFindNext_Click);
            // 
            // chkMatchWholeWord
            // 
            this.chkMatchWholeWord.AutoSize = true;
            this.chkMatchWholeWord.Location = new System.Drawing.Point(267, 42);
            this.chkMatchWholeWord.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkMatchWholeWord.Name = "chkMatchWholeWord";
            this.chkMatchWholeWord.Size = new System.Drawing.Size(162, 24);
            this.chkMatchWholeWord.TabIndex = 5;
            this.chkMatchWholeWord.Text = "Match &whole word";
            this.chkMatchWholeWord.UseVisualStyleBackColor = true;
            // 
            // chkMatchCase
            // 
            this.chkMatchCase.AutoSize = true;
            this.chkMatchCase.Location = new System.Drawing.Point(135, 42);
            this.chkMatchCase.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkMatchCase.Name = "chkMatchCase";
            this.chkMatchCase.Size = new System.Drawing.Size(117, 24);
            this.chkMatchCase.TabIndex = 4;
            this.chkMatchCase.Text = "Match &case";
            this.chkMatchCase.UseVisualStyleBackColor = true;
            // 
            // btnHighlightAll
            // 
            this.btnHighlightAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHighlightAll.Location = new System.Drawing.Point(158, 119);
            this.btnHighlightAll.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnHighlightAll.Name = "btnHighlightAll";
            this.btnHighlightAll.Size = new System.Drawing.Size(204, 35);
            this.btnHighlightAll.TabIndex = 8;
            this.btnHighlightAll.Text = "Find && highlight &all";
            this.btnHighlightAll.UseVisualStyleBackColor = true;
            this.btnHighlightAll.Visible = false;
            this.btnHighlightAll.Click += new System.EventHandler(this.btnHighlightAll_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(370, 119);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(112, 35);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnFindPrevious
            // 
            this.btnFindPrevious.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFindPrevious.Location = new System.Drawing.Point(236, 75);
            this.btnFindPrevious.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnFindPrevious.Name = "btnFindPrevious";
            this.btnFindPrevious.Size = new System.Drawing.Size(126, 35);
            this.btnFindPrevious.TabIndex = 6;
            this.btnFindPrevious.Text = "Find pre&vious";
            this.btnFindPrevious.UseVisualStyleBackColor = true;
            this.btnFindPrevious.Click += new System.EventHandler(this.btnFindPrevious_Click);
            // 
            // FindAndReplaceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(501, 167);
            this.Controls.Add(this.chkMatchCase);
            this.Controls.Add(this.chkMatchWholeWord);
            this.Controls.Add(this.btnHighlightAll);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnFindPrevious);
            this.Controls.Add(this.btnFindNext);
            this.Controls.Add(this.txtLookFor);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FindAndReplaceForm";
            this.ShowIcon = false;
            this.Text = "Find and replace";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FindAndReplaceForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLookFor;
        private System.Windows.Forms.Button btnFindNext;
		private System.Windows.Forms.CheckBox chkMatchWholeWord;
		private System.Windows.Forms.CheckBox chkMatchCase;
		private System.Windows.Forms.Button btnHighlightAll;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnFindPrevious;
	}
}