namespace Nida.Dfb
{
    partial class FormOptions
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
            this.grpOptions = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtComparer = new System.Windows.Forms.TextBox();
            this.lblComparer = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.lblRenamer = new System.Windows.Forms.Label();
            this.txtRenamer = new System.Windows.Forms.TextBox();
            this.btnRenamer = new System.Windows.Forms.Button();
            this.lblNotepad = new System.Windows.Forms.Label();
            this.txtNotepad = new System.Windows.Forms.TextBox();
            this.btnNotepad = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.grpOptions.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpOptions
            // 
            this.grpOptions.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpOptions.Controls.Add(this.tableLayoutPanel1);
            this.grpOptions.Location = new System.Drawing.Point(12, 12);
            this.grpOptions.Name = "grpOptions";
            this.grpOptions.Size = new System.Drawing.Size(466, 137);
            this.grpOptions.TabIndex = 0;
            this.grpOptions.TabStop = false;
            this.grpOptions.Text = "Options";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel2, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 39F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(460, 118);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnSelect);
            this.panel1.Controls.Add(this.txtComparer);
            this.panel1.Controls.Add(this.lblComparer);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(454, 28);
            this.panel1.TabIndex = 1;
            // 
            // txtComparer
            // 
            this.txtComparer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComparer.Location = new System.Drawing.Point(64, 5);
            this.txtComparer.Name = "txtComparer";
            this.txtComparer.Size = new System.Drawing.Size(304, 20);
            this.txtComparer.TabIndex = 1;
            this.txtComparer.Text = "D:\\Program Files\\Beyond Compare 2";
            // 
            // lblComparer
            // 
            this.lblComparer.AutoSize = true;
            this.lblComparer.Location = new System.Drawing.Point(3, 8);
            this.lblComparer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblComparer.Name = "lblComparer";
            this.lblComparer.Size = new System.Drawing.Size(55, 13);
            this.lblComparer.TabIndex = 0;
            this.lblComparer.Text = "Comparer:";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(403, 166);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(322, 166);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // lblRenamer
            // 
            this.lblRenamer.AutoSize = true;
            this.lblRenamer.Location = new System.Drawing.Point(3, 3);
            this.lblRenamer.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblRenamer.Name = "lblRenamer";
            this.lblRenamer.Size = new System.Drawing.Size(53, 13);
            this.lblRenamer.TabIndex = 0;
            this.lblRenamer.Text = "Renamer:";
            // 
            // txtRenamer
            // 
            this.txtRenamer.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRenamer.Location = new System.Drawing.Point(62, 3);
            this.txtRenamer.Name = "txtRenamer";
            this.txtRenamer.Size = new System.Drawing.Size(306, 20);
            this.txtRenamer.TabIndex = 1;
            this.txtRenamer.Text = "D:\\Tools\\ReNamer";
            // 
            // btnRenamer
            // 
            this.btnRenamer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRenamer.Location = new System.Drawing.Point(374, 3);
            this.btnRenamer.Name = "btnRenamer";
            this.btnRenamer.Size = new System.Drawing.Size(75, 23);
            this.btnRenamer.TabIndex = 2;
            this.btnRenamer.Text = "&Select...";
            this.btnRenamer.UseVisualStyleBackColor = true;
            this.btnRenamer.Click += new System.EventHandler(this.btnRenamer_Click);
            // 
            // lblNotepad
            // 
            this.lblNotepad.AutoSize = true;
            this.lblNotepad.Location = new System.Drawing.Point(3, 3);
            this.lblNotepad.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.lblNotepad.Name = "lblNotepad";
            this.lblNotepad.Size = new System.Drawing.Size(112, 13);
            this.lblNotepad.TabIndex = 0;
            this.lblNotepad.Text = "Notepad replacement:";
            // 
            // txtNotepad
            // 
            this.txtNotepad.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.txtNotepad.Location = new System.Drawing.Point(121, 3);
            this.txtNotepad.Name = "txtNotepad";
            this.txtNotepad.Size = new System.Drawing.Size(247, 20);
            this.txtNotepad.TabIndex = 1;
            this.txtNotepad.Text = "notepad.exe";
            // 
            // btnNotepad
            // 
            this.btnNotepad.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNotepad.Location = new System.Drawing.Point(374, 1);
            this.btnNotepad.Name = "btnNotepad";
            this.btnNotepad.Size = new System.Drawing.Size(75, 23);
            this.btnNotepad.TabIndex = 2;
            this.btnNotepad.Text = "&Select...";
            this.btnNotepad.UseVisualStyleBackColor = true;
            this.btnNotepad.Click += new System.EventHandler(this.btnNotepad_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelect.Location = new System.Drawing.Point(374, 2);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(75, 23);
            this.btnSelect.TabIndex = 3;
            this.btnSelect.Text = "&Select...";
            this.btnSelect.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.lblRenamer);
            this.panel2.Controls.Add(this.txtRenamer);
            this.panel2.Controls.Add(this.btnRenamer);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(3, 37);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(454, 28);
            this.panel2.TabIndex = 2;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.lblNotepad);
            this.panel3.Controls.Add(this.txtNotepad);
            this.panel3.Controls.Add(this.btnNotepad);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 71);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(454, 44);
            this.panel3.TabIndex = 3;
            // 
            // FormOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(490, 200);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.grpOptions);
            this.Name = "FormOptions";
            this.Text = "Options...";
            this.grpOptions.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpOptions;
        private System.Windows.Forms.Label lblComparer;
        private System.Windows.Forms.TextBox txtComparer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lblRenamer;
        private System.Windows.Forms.TextBox txtRenamer;
        private System.Windows.Forms.Button btnRenamer;
        private System.Windows.Forms.Label lblNotepad;
        private System.Windows.Forms.TextBox txtNotepad;
        private System.Windows.Forms.Button btnNotepad;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
    }
}