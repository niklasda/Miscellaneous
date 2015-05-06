namespace WindowsApplication1
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.bGetLists = new System.Windows.Forms.Button();
            this.lbLists = new System.Windows.Forms.ListBox();
            this.bExtract = new System.Windows.Forms.Button();
            this.lbEmailAdresses = new System.Windows.Forms.ListBox();
            this.lbBooks = new System.Windows.Forms.ListBox();
            this.bGetBooks = new System.Windows.Forms.Button();
            this.tbError = new System.Windows.Forms.TextBox();
            this.bGetDrafts = new System.Windows.Forms.Button();
            this.lbDrafts = new System.Windows.Forms.ListBox();
            this.bProcessDraft = new System.Windows.Forms.Button();
            this.lbNewDrafts = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // bGetLists
            // 
            this.bGetLists.Location = new System.Drawing.Point(12, 139);
            this.bGetLists.Name = "bGetLists";
            this.bGetLists.Size = new System.Drawing.Size(252, 23);
            this.bGetLists.TabIndex = 0;
            this.bGetLists.Text = "Get distribution lists";
            this.bGetLists.UseVisualStyleBackColor = true;
            this.bGetLists.Click += new System.EventHandler(this.bGetLists_Click);
            // 
            // lbLists
            // 
            this.lbLists.FormattingEnabled = true;
            this.lbLists.Location = new System.Drawing.Point(12, 169);
            this.lbLists.Name = "lbLists";
            this.lbLists.Size = new System.Drawing.Size(252, 95);
            this.lbLists.TabIndex = 1;
            // 
            // bExtract
            // 
            this.bExtract.Location = new System.Drawing.Point(12, 271);
            this.bExtract.Name = "bExtract";
            this.bExtract.Size = new System.Drawing.Size(147, 23);
            this.bExtract.TabIndex = 2;
            this.bExtract.Text = "Extract selected list";
            this.bExtract.UseVisualStyleBackColor = true;
            this.bExtract.Click += new System.EventHandler(this.bExtract_Click);
            // 
            // lbEmailAdresses
            // 
            this.lbEmailAdresses.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbEmailAdresses.FormattingEnabled = true;
            this.lbEmailAdresses.Location = new System.Drawing.Point(12, 301);
            this.lbEmailAdresses.Name = "lbEmailAdresses";
            this.lbEmailAdresses.Size = new System.Drawing.Size(147, 95);
            this.lbEmailAdresses.TabIndex = 3;
            // 
            // lbBooks
            // 
            this.lbBooks.FormattingEnabled = true;
            this.lbBooks.Location = new System.Drawing.Point(12, 38);
            this.lbBooks.Name = "lbBooks";
            this.lbBooks.Size = new System.Drawing.Size(252, 95);
            this.lbBooks.TabIndex = 5;
            // 
            // bGetBooks
            // 
            this.bGetBooks.Location = new System.Drawing.Point(12, 8);
            this.bGetBooks.Name = "bGetBooks";
            this.bGetBooks.Size = new System.Drawing.Size(252, 23);
            this.bGetBooks.TabIndex = 4;
            this.bGetBooks.Text = "Get address books";
            this.bGetBooks.UseVisualStyleBackColor = true;
            this.bGetBooks.Click += new System.EventHandler(this.bGetBooks_Click);
            // 
            // tbError
            // 
            this.tbError.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbError.Location = new System.Drawing.Point(12, 420);
            this.tbError.Multiline = true;
            this.tbError.Name = "tbError";
            this.tbError.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbError.Size = new System.Drawing.Size(607, 54);
            this.tbError.TabIndex = 6;
            // 
            // bGetDrafts
            // 
            this.bGetDrafts.Location = new System.Drawing.Point(340, 8);
            this.bGetDrafts.Name = "bGetDrafts";
            this.bGetDrafts.Size = new System.Drawing.Size(279, 23);
            this.bGetDrafts.TabIndex = 7;
            this.bGetDrafts.Text = "Get drafts";
            this.bGetDrafts.UseVisualStyleBackColor = true;
            this.bGetDrafts.Click += new System.EventHandler(this.bGetDrafts_Click);
            // 
            // lbDrafts
            // 
            this.lbDrafts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbDrafts.FormattingEnabled = true;
            this.lbDrafts.Location = new System.Drawing.Point(340, 38);
            this.lbDrafts.Name = "lbDrafts";
            this.lbDrafts.Size = new System.Drawing.Size(279, 95);
            this.lbDrafts.TabIndex = 8;
            // 
            // bProcessDraft
            // 
            this.bProcessDraft.Location = new System.Drawing.Point(340, 139);
            this.bProcessDraft.Name = "bProcessDraft";
            this.bProcessDraft.Size = new System.Drawing.Size(279, 23);
            this.bProcessDraft.TabIndex = 9;
            this.bProcessDraft.Text = "Process draft";
            this.bProcessDraft.UseVisualStyleBackColor = true;
            this.bProcessDraft.Click += new System.EventHandler(this.bProcessDraft_Click);
            // 
            // lbNewDrafts
            // 
            this.lbNewDrafts.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lbNewDrafts.FormattingEnabled = true;
            this.lbNewDrafts.Location = new System.Drawing.Point(340, 169);
            this.lbNewDrafts.Name = "lbNewDrafts";
            this.lbNewDrafts.Size = new System.Drawing.Size(279, 95);
            this.lbNewDrafts.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(187, 301);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(432, 95);
            this.label1.TabIndex = 11;
            this.label1.Text = resources.GetString("label1.Text");
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(631, 486);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbNewDrafts);
            this.Controls.Add(this.bProcessDraft);
            this.Controls.Add(this.lbDrafts);
            this.Controls.Add(this.bGetDrafts);
            this.Controls.Add(this.tbError);
            this.Controls.Add(this.lbBooks);
            this.Controls.Add(this.bGetBooks);
            this.Controls.Add(this.lbEmailAdresses);
            this.Controls.Add(this.bExtract);
            this.Controls.Add(this.lbLists);
            this.Controls.Add(this.bGetLists);
            this.Name = "FormMain";
            this.Text = "Outlook distribution list expander";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button bGetLists;
        private System.Windows.Forms.ListBox lbLists;
        private System.Windows.Forms.Button bExtract;
        private System.Windows.Forms.ListBox lbEmailAdresses;
        private System.Windows.Forms.ListBox lbBooks;
        private System.Windows.Forms.Button bGetBooks;
        private System.Windows.Forms.TextBox tbError;
        private System.Windows.Forms.Button bGetDrafts;
        private System.Windows.Forms.ListBox lbDrafts;
        private System.Windows.Forms.Button bProcessDraft;
        private System.Windows.Forms.ListBox lbNewDrafts;
        private System.Windows.Forms.Label label1;
    }
}

