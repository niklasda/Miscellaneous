using System.Windows.Forms;

namespace DahlNotes.Forms
{
    partial class FormAbout
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Label lblAbout;
        private LinkLabel lnkDg;
        
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
            this.lblAbout = new System.Windows.Forms.Label();
            this.lnkDg = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // lblAbout
            // 
            this.lblAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAbout.Location = new System.Drawing.Point(24, 24);
            this.lblAbout.Name = "lblAbout";
            this.lblAbout.Size = new System.Drawing.Size(154, 88);
            this.lblAbout.TabIndex = 1;
            this.lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lnkDg
            // 
            this.lnkDg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lnkDg.Location = new System.Drawing.Point(24, 133);
            this.lnkDg.Name = "lnkDg";
            this.lnkDg.Size = new System.Drawing.Size(146, 23);
            this.lnkDg.TabIndex = 0;
            this.lnkDg.TabStop = true;
            this.lnkDg.Text = "dahlman.biz";
            this.lnkDg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnkDg.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkDg_LinkClicked);
            // 
            // FormAbout
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(194, 162);
            this.Controls.Add(this.lnkDg);
            this.Controls.Add(this.lblAbout);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAbout";
            this.Text = "About";
            this.Load += new System.EventHandler(this.FormAbout_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}