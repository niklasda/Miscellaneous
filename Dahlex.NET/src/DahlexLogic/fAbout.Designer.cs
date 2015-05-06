namespace Dahlex
{
    partial class fAbout
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lAppName = new System.Windows.Forms.Label();
            this.lVersion = new System.Windows.Forms.Label();
            this.lWindowsVersion = new System.Windows.Forms.Label();
            this.lFxVersion = new System.Windows.Forms.Label();
            this.lUser = new System.Windows.Forms.Label();
            this.bClose = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lAppCopyright = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 120F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label3, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label4, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.lVersion, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lWindowsVersion, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lFxVersion, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lUser, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lAppName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.lAppCopyright, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(12, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 6;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(369, 119);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Application";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Compiled";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Windows version";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Fx version";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "User";
            // 
            // lAppName
            // 
            this.lAppName.AutoSize = true;
            this.lAppName.Location = new System.Drawing.Point(123, 0);
            this.lAppName.Name = "lAppName";
            this.lAppName.Size = new System.Drawing.Size(10, 13);
            this.lAppName.TabIndex = 5;
            this.lAppName.Text = "-";
            // 
            // lVersion
            // 
            this.lVersion.AutoSize = true;
            this.lVersion.Location = new System.Drawing.Point(123, 40);
            this.lVersion.Name = "lVersion";
            this.lVersion.Size = new System.Drawing.Size(10, 13);
            this.lVersion.TabIndex = 6;
            this.lVersion.Text = "-";
            // 
            // lWindowsVersion
            // 
            this.lWindowsVersion.AutoSize = true;
            this.lWindowsVersion.Location = new System.Drawing.Point(123, 60);
            this.lWindowsVersion.Name = "lWindowsVersion";
            this.lWindowsVersion.Size = new System.Drawing.Size(10, 13);
            this.lWindowsVersion.TabIndex = 7;
            this.lWindowsVersion.Text = "-";
            // 
            // lFxVersion
            // 
            this.lFxVersion.AutoSize = true;
            this.lFxVersion.Location = new System.Drawing.Point(123, 80);
            this.lFxVersion.Name = "lFxVersion";
            this.lFxVersion.Size = new System.Drawing.Size(10, 13);
            this.lFxVersion.TabIndex = 8;
            this.lFxVersion.Text = "-";
            // 
            // lUser
            // 
            this.lUser.AutoSize = true;
            this.lUser.Location = new System.Drawing.Point(123, 100);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(10, 13);
            this.lUser.TabIndex = 9;
            this.lUser.Text = "-";
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(306, 137);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 2;
            this.bClose.Text = "&Close";
            this.bClose.UseVisualStyleBackColor = true;
            this.bClose.Click += new System.EventHandler(this.bClose_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Copyright";
            // 
            // lAppCopyright
            // 
            this.lAppCopyright.AutoSize = true;
            this.lAppCopyright.Location = new System.Drawing.Point(123, 20);
            this.lAppCopyright.Name = "lAppCopyright";
            this.lAppCopyright.Size = new System.Drawing.Size(10, 13);
            this.lAppCopyright.TabIndex = 5;
            this.lAppCopyright.Text = "-";
            // 
            // fAbout
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 172);
            this.Controls.Add(this.bClose);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(401, 206);
            this.Name = "fAbout";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lAppName;
        private System.Windows.Forms.Label lVersion;
        private System.Windows.Forms.Label lWindowsVersion;
        private System.Windows.Forms.Label lFxVersion;
        private System.Windows.Forms.Label lUser;
        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lAppCopyright;
    }
}