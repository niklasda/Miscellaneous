namespace AutoPercy
{
    partial class Form1
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
            this.buttonOpen = new System.Windows.Forms.Button();
            this.buttonLogin = new System.Windows.Forms.Button();
            this.buttonLogout = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonBookStep1 = new System.Windows.Forms.Button();
            this.buttonBookStep2 = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonSwe = new System.Windows.Forms.Button();
            this.buttonGooglePurse = new System.Windows.Forms.Button();
            this.buttonFindCover = new System.Windows.Forms.Button();
            this.buttonGotoNext = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(6, 31);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(75, 23);
            this.buttonOpen.TabIndex = 0;
            this.buttonOpen.Text = "Open Site";
            this.buttonOpen.UseVisualStyleBackColor = true;
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonLogin
            // 
            this.buttonLogin.Location = new System.Drawing.Point(6, 61);
            this.buttonLogin.Name = "buttonLogin";
            this.buttonLogin.Size = new System.Drawing.Size(75, 23);
            this.buttonLogin.TabIndex = 1;
            this.buttonLogin.Text = "Login";
            this.buttonLogin.UseVisualStyleBackColor = true;
            this.buttonLogin.Click += new System.EventHandler(this.buttonLogin_Click);
            // 
            // buttonLogout
            // 
            this.buttonLogout.Location = new System.Drawing.Point(87, 61);
            this.buttonLogout.Name = "buttonLogout";
            this.buttonLogout.Size = new System.Drawing.Size(75, 23);
            this.buttonLogout.TabIndex = 1;
            this.buttonLogout.Text = "Logout";
            this.buttonLogout.UseVisualStyleBackColor = true;
            this.buttonLogout.Click += new System.EventHandler(this.buttonLogout_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(6, 113);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(90, 23);
            this.buttonAdd.TabIndex = 2;
            this.buttonAdd.Text = "Lägg till";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // buttonBookStep1
            // 
            this.buttonBookStep1.Location = new System.Drawing.Point(35, 143);
            this.buttonBookStep1.Name = "buttonBookStep1";
            this.buttonBookStep1.Size = new System.Drawing.Size(75, 23);
            this.buttonBookStep1.TabIndex = 3;
            this.buttonBookStep1.Text = "Bok - Steg 1";
            this.buttonBookStep1.UseVisualStyleBackColor = true;
            this.buttonBookStep1.Click += new System.EventHandler(this.buttonBookStep1_Click);
            // 
            // buttonBookStep2
            // 
            this.buttonBookStep2.Location = new System.Drawing.Point(35, 173);
            this.buttonBookStep2.Name = "buttonBookStep2";
            this.buttonBookStep2.Size = new System.Drawing.Size(75, 23);
            this.buttonBookStep2.TabIndex = 4;
            this.buttonBookStep2.Text = "Bok - Steg 2";
            this.buttonBookStep2.UseVisualStyleBackColor = true;
            this.buttonBookStep2.Click += new System.EventHandler(this.buttonBookStep2_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(6, 31);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(85, 23);
            this.buttonStart.TabIndex = 5;
            this.buttonStart.Text = "Starta App";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonSwe
            // 
            this.buttonSwe.Location = new System.Drawing.Point(16, 61);
            this.buttonSwe.Name = "buttonSwe";
            this.buttonSwe.Size = new System.Drawing.Size(99, 23);
            this.buttonSwe.TabIndex = 6;
            this.buttonSwe.Text = "Öppna Svenska";
            this.buttonSwe.UseVisualStyleBackColor = true;
            this.buttonSwe.Click += new System.EventHandler(this.buttonSwe_Click);
            // 
            // buttonGooglePurse
            // 
            this.buttonGooglePurse.Location = new System.Drawing.Point(31, 120);
            this.buttonGooglePurse.Name = "buttonGooglePurse";
            this.buttonGooglePurse.Size = new System.Drawing.Size(103, 23);
            this.buttonGooglePurse.TabIndex = 8;
            this.buttonGooglePurse.Text = "Google Bokbörsen";
            this.buttonGooglePurse.UseVisualStyleBackColor = true;
            this.buttonGooglePurse.Click += new System.EventHandler(this.buttonGooglePurse_Click);
            // 
            // buttonFindCover
            // 
            this.buttonFindCover.Location = new System.Drawing.Point(31, 149);
            this.buttonFindCover.Name = "buttonFindCover";
            this.buttonFindCover.Size = new System.Drawing.Size(103, 23);
            this.buttonFindCover.TabIndex = 9;
            this.buttonFindCover.Text = "Hitta Omslag";
            this.buttonFindCover.UseVisualStyleBackColor = true;
            this.buttonFindCover.Click += new System.EventHandler(this.buttonFindCover_Click);
            // 
            // buttonGotoNext
            // 
            this.buttonGotoNext.Location = new System.Drawing.Point(31, 178);
            this.buttonGotoNext.Name = "buttonGotoNext";
            this.buttonGotoNext.Size = new System.Drawing.Size(103, 23);
            this.buttonGotoNext.TabIndex = 10;
            this.buttonGotoNext.Text = "Gå till nästa";
            this.buttonGotoNext.UseVisualStyleBackColor = true;
            this.buttonGotoNext.Click += new System.EventHandler(this.buttonGotoNext_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.buttonSwe);
            this.groupBox1.Controls.Add(this.buttonGotoNext);
            this.groupBox1.Controls.Add(this.buttonStart);
            this.groupBox1.Controls.Add(this.buttonFindCover);
            this.groupBox1.Controls.Add(this.buttonGooglePurse);
            this.groupBox1.Location = new System.Drawing.Point(371, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(217, 306);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Clz";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.buttonOpen);
            this.groupBox2.Controls.Add(this.buttonLogin);
            this.groupBox2.Controls.Add(this.buttonBookStep2);
            this.groupBox2.Controls.Add(this.buttonLogout);
            this.groupBox2.Controls.Add(this.buttonBookStep1);
            this.groupBox2.Controls.Add(this.buttonAdd);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(326, 297);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Bokbörsen";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 225);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(293, 39);
            this.label1.TabIndex = 5;
            this.label1.Text = "5 kr (varav 1 kr moms) om du prissatt varan lägre än 25 kr. \r\n10 kr (varav 2 kr m" +
    "oms) om du prissatt varan i 25 kr eller mer.\r\n\r\n";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 323);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Bok Börsen <-> Clz";
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOpen;
        private System.Windows.Forms.Button buttonLogin;
        private System.Windows.Forms.Button buttonLogout;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonBookStep1;
        private System.Windows.Forms.Button buttonBookStep2;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonSwe;
        private System.Windows.Forms.Button buttonGooglePurse;
        private System.Windows.Forms.Button buttonFindCover;
        private System.Windows.Forms.Button buttonGotoNext;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
    }
}

