namespace HerrValuta
{
    partial class frmValuta
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
            this.btnGetCurrency = new System.Windows.Forms.Button();
            this.btnSendCurrency = new System.Windows.Forms.Button();
            this.tbToUrl = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbSek = new System.Windows.Forms.TextBox();
            this.btnClearMessages = new System.Windows.Forms.Button();
            this.tbEur = new System.Windows.Forms.TextBox();
            this.tbGbp = new System.Windows.Forms.TextBox();
            this.tbNok = new System.Windows.Forms.TextBox();
            this.tbDkk = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.tDoItOnce = new System.Windows.Forms.Timer(this.components);
            this.gbCommands = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.gbCurrencies = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.bAuto = new System.Windows.Forms.Button();
            this.gbTest = new System.Windows.Forms.GroupBox();
            this.bTestMail = new System.Windows.Forms.Button();
            this.gbCommands.SuspendLayout();
            this.gbCurrencies.SuspendLayout();
            this.gbTest.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnGetCurrency
            // 
            this.btnGetCurrency.Location = new System.Drawing.Point(6, 22);
            this.btnGetCurrency.Name = "btnGetCurrency";
            this.btnGetCurrency.Size = new System.Drawing.Size(108, 23);
            this.btnGetCurrency.TabIndex = 0;
            this.btnGetCurrency.Text = "Hämta från forex";
            this.btnGetCurrency.UseVisualStyleBackColor = true;
            this.btnGetCurrency.Click += new System.EventHandler(this.btnGet_Click);
            // 
            // btnSendCurrency
            // 
            this.btnSendCurrency.Location = new System.Drawing.Point(6, 68);
            this.btnSendCurrency.Name = "btnSendCurrency";
            this.btnSendCurrency.Size = new System.Drawing.Size(75, 23);
            this.btnSendCurrency.TabIndex = 2;
            this.btnSendCurrency.Text = "Skicka till";
            this.btnSendCurrency.UseVisualStyleBackColor = true;
            this.btnSendCurrency.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // tbToUrl
            // 
            this.tbToUrl.Location = new System.Drawing.Point(39, 100);
            this.tbToUrl.Name = "tbToUrl";
            this.tbToUrl.Size = new System.Drawing.Size(150, 20);
            this.tbToUrl.TabIndex = 29;
            this.tbToUrl.TextChanged += new System.EventHandler(this.tbToUrl_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 13);
            this.label1.TabIndex = 30;
            this.label1.Text = "Mata in SEK";
            // 
            // tbSek
            // 
            this.tbSek.Enabled = false;
            this.tbSek.Location = new System.Drawing.Point(36, 47);
            this.tbSek.Name = "tbSek";
            this.tbSek.Size = new System.Drawing.Size(63, 20);
            this.tbSek.TabIndex = 31;
            this.tbSek.Text = "100";
            // 
            // btnClearMessages
            // 
            this.btnClearMessages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClearMessages.Location = new System.Drawing.Point(519, 155);
            this.btnClearMessages.Name = "btnClearMessages";
            this.btnClearMessages.Size = new System.Drawing.Size(75, 23);
            this.btnClearMessages.TabIndex = 32;
            this.btnClearMessages.Text = "Rensa log";
            this.btnClearMessages.UseVisualStyleBackColor = true;
            this.btnClearMessages.Click += new System.EventHandler(this.btnClearMessages_Click);
            // 
            // tbEur
            // 
            this.tbEur.Location = new System.Drawing.Point(176, 16);
            this.tbEur.Name = "tbEur";
            this.tbEur.Size = new System.Drawing.Size(56, 20);
            this.tbEur.TabIndex = 33;
            this.tbEur.Text = "11,16";
            // 
            // tbGbp
            // 
            this.tbGbp.Location = new System.Drawing.Point(176, 42);
            this.tbGbp.Name = "tbGbp";
            this.tbGbp.Size = new System.Drawing.Size(56, 20);
            this.tbGbp.TabIndex = 34;
            this.tbGbp.Text = "7,83";
            // 
            // tbNok
            // 
            this.tbNok.Location = new System.Drawing.Point(176, 68);
            this.tbNok.Name = "tbNok";
            this.tbNok.Size = new System.Drawing.Size(56, 20);
            this.tbNok.TabIndex = 35;
            this.tbNok.Text = "1,1";
            // 
            // tbDkk
            // 
            this.tbDkk.Location = new System.Drawing.Point(176, 94);
            this.tbDkk.Name = "tbDkk";
            this.tbDkk.Size = new System.Drawing.Size(56, 20);
            this.tbDkk.TabIndex = 36;
            this.tbDkk.Text = "1,2";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(138, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 37;
            this.label4.Text = "EUR:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(138, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 38;
            this.label5.Text = "GBP:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(138, 68);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 13);
            this.label6.TabIndex = 39;
            this.label6.Text = "NOK:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(138, 94);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(32, 13);
            this.label7.TabIndex = 40;
            this.label7.Text = "DKK:";
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbLog.Location = new System.Drawing.Point(13, 202);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.tbLog.Size = new System.Drawing.Size(581, 102);
            this.tbLog.TabIndex = 41;
            this.tbLog.WordWrap = false;
            // 
            // tDoItOnce
            // 
            this.tDoItOnce.Interval = 1000;
            this.tDoItOnce.Tick += new System.EventHandler(this.tDoItOnce_Tick);
            // 
            // gbCommands
            // 
            this.gbCommands.Controls.Add(this.label3);
            this.gbCommands.Controls.Add(this.tbToUrl);
            this.gbCommands.Controls.Add(this.btnGetCurrency);
            this.gbCommands.Controls.Add(this.btnSendCurrency);
            this.gbCommands.Location = new System.Drawing.Point(13, 12);
            this.gbCommands.Name = "gbCommands";
            this.gbCommands.Size = new System.Drawing.Size(208, 126);
            this.gbCommands.TabIndex = 42;
            this.gbCommands.TabStop = false;
            this.gbCommands.Text = "Kommando";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 102);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "till Url:";
            // 
            // gbCurrencies
            // 
            this.gbCurrencies.Controls.Add(this.label1);
            this.gbCurrencies.Controls.Add(this.tbSek);
            this.gbCurrencies.Controls.Add(this.tbEur);
            this.gbCurrencies.Controls.Add(this.label7);
            this.gbCurrencies.Controls.Add(this.tbGbp);
            this.gbCurrencies.Controls.Add(this.label6);
            this.gbCurrencies.Controls.Add(this.tbNok);
            this.gbCurrencies.Controls.Add(this.label5);
            this.gbCurrencies.Controls.Add(this.tbDkk);
            this.gbCurrencies.Controls.Add(this.label4);
            this.gbCurrencies.Location = new System.Drawing.Point(345, 12);
            this.gbCurrencies.Name = "gbCurrencies";
            this.gbCurrencies.Size = new System.Drawing.Size(249, 126);
            this.gbCurrencies.TabIndex = 43;
            this.gbCurrencies.TabStop = false;
            this.gbCurrencies.Text = "Valuta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 164);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 44;
            this.label2.Text = "Log";
            // 
            // bAuto
            // 
            this.bAuto.Location = new System.Drawing.Point(7, 51);
            this.bAuto.Name = "bAuto";
            this.bAuto.Size = new System.Drawing.Size(60, 23);
            this.bAuto.TabIndex = 45;
            this.bAuto.Text = "Auto";
            this.bAuto.UseVisualStyleBackColor = true;
            this.bAuto.Click += new System.EventHandler(this.bAuto_Click);
            // 
            // gbTest
            // 
            this.gbTest.Controls.Add(this.bTestMail);
            this.gbTest.Controls.Add(this.bAuto);
            this.gbTest.Location = new System.Drawing.Point(227, 12);
            this.gbTest.Name = "gbTest";
            this.gbTest.Size = new System.Drawing.Size(112, 126);
            this.gbTest.TabIndex = 46;
            this.gbTest.TabStop = false;
            this.gbTest.Text = "Test";
            // 
            // bTestMail
            // 
            this.bTestMail.Location = new System.Drawing.Point(6, 22);
            this.bTestMail.Name = "bTestMail";
            this.bTestMail.Size = new System.Drawing.Size(61, 23);
            this.bTestMail.TabIndex = 46;
            this.bTestMail.Text = "Mail";
            this.bTestMail.UseVisualStyleBackColor = true;
            this.bTestMail.Click += new System.EventHandler(this.bTestMail_Click);
            // 
            // frmValuta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 316);
            this.Controls.Add(this.gbTest);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.gbCurrencies);
            this.Controls.Add(this.gbCommands);
            this.Controls.Add(this.tbLog);
            this.Controls.Add(this.btnClearMessages);
            this.Name = "frmValuta";
            this.Text = "Herr Valuta.NET";
            this.gbCommands.ResumeLayout(false);
            this.gbCommands.PerformLayout();
            this.gbCurrencies.ResumeLayout(false);
            this.gbCurrencies.PerformLayout();
            this.gbTest.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetCurrency;
        private System.Windows.Forms.Button btnSendCurrency;
        private System.Windows.Forms.TextBox tbToUrl;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tbSek;
        private System.Windows.Forms.Button btnClearMessages;
        private System.Windows.Forms.TextBox tbEur;
        private System.Windows.Forms.TextBox tbGbp;
        private System.Windows.Forms.TextBox tbNok;
        private System.Windows.Forms.TextBox tbDkk;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.Timer tDoItOnce;
        private System.Windows.Forms.GroupBox gbCommands;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox gbCurrencies;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bAuto;
        private System.Windows.Forms.GroupBox gbTest;
        private System.Windows.Forms.Button bTestMail;
    }
}

