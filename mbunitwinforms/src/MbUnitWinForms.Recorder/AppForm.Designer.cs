#region Copyright (c) 2003-2005, Luke T. Maxon

/********************************************************************************************************************
'
' Copyright (c) 2003-2005, Luke T. Maxon
' All rights reserved.
' 
' Redistribution and use in source and binary forms, with or without modification, are permitted provided
' that the following conditions are met:
' 
' * Redistributions of source code must retain the above copyright notice, this list of conditions and the
' 	following disclaimer.
' 
' * Redistributions in binary form must reproduce the above copyright notice, this list of conditions and
' 	the following disclaimer in the documentation and/or other materials provided with the distribution.
' 
' * Neither the name of the author nor the names of its contributors may be used to endorse or 
' 	promote products derived from this software without specific prior written permission.
' 
' THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
' WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
' PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT OWNER OR CONTRIBUTORS BE LIABLE FOR
' ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT
' LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS
' INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY,
' OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN
' IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE.
'
'*******************************************************************************************************************/

#endregion

using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace MbUnitWinForms.Recorder
{
	/// <summary>
	/// The main form for the Recorder application.
	/// </summary>
	public partial class AppForm 
	{
		private Form form;

		private TextBox tbTestCode;

		private MainMenu mainMenu1;

		private MenuItem mmiFile;

		private ComboBox cbForms;

		private MenuItem miNew;

        private MenuItem miLoad;
		private PictureBox pbScreenshot;

		private IContainer components;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
				{
					components.Dispose();
				}
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
            this.tbTestCode = new System.Windows.Forms.TextBox();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.mmiFile = new System.Windows.Forms.MenuItem();
            this.miNew = new System.Windows.Forms.MenuItem();
            this.miLoad = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miClose = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.miCapture = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.cbForms = new System.Windows.Forms.ComboBox();
            this.pbScreenshot = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).BeginInit();
            this.SuspendLayout();
            // 
            // tbTestCode
            // 
            this.tbTestCode.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbTestCode.Font = new System.Drawing.Font("Courier New", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTestCode.Location = new System.Drawing.Point(0, 24);
            this.tbTestCode.Multiline = true;
            this.tbTestCode.Name = "tbTestCode";
            this.tbTestCode.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbTestCode.Size = new System.Drawing.Size(496, 432);
            this.tbTestCode.TabIndex = 0;
            // 
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mmiFile,
            this.menuItem2,
            this.menuItem3});
            // 
            // mmiFile
            // 
            this.mmiFile.Index = 0;
            this.mmiFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miNew,
            this.miLoad,
            this.menuItem1,
            this.miClose});
            this.mmiFile.Text = "&File";
            // 
            // miNew
            // 
            this.miNew.Index = 0;
            this.miNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.miNew.Text = "&New";
            this.miNew.Click += new System.EventHandler(this.miNew_Click);
            // 
            // miLoad
            // 
            this.miLoad.Index = 1;
            this.miLoad.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.miLoad.Text = "&Open Assemblies...";
            this.miLoad.Click += new System.EventHandler(this.miLoad_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 2;
            this.menuItem1.Text = "-";
            // 
            // miClose
            // 
            this.miClose.Index = 3;
            this.miClose.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.miClose.Text = "&Close";
            this.miClose.Click += new System.EventHandler(this.miClose_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miCapture});
            this.menuItem2.Text = "&Tools";
            // 
            // miCapture
            // 
            this.miCapture.Index = 0;
            this.miCapture.Shortcut = System.Windows.Forms.Shortcut.CtrlC;
            this.miCapture.Text = "&Capture";
            this.miCapture.Click += new System.EventHandler(this.miCapture_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 2;
            this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4});
            this.menuItem3.Text = "Demo";
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "Test";
            this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
            // 
            // cbForms
            // 
            this.cbForms.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbForms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbForms.Location = new System.Drawing.Point(0, 0);
            this.cbForms.Name = "cbForms";
            this.cbForms.Size = new System.Drawing.Size(496, 21);
            this.cbForms.TabIndex = 1;
            this.cbForms.SelectedIndexChanged += new System.EventHandler(this.combo_SelectedIndexChanged);
            // 
            // pbScreenshot
            // 
            this.pbScreenshot.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.pbScreenshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbScreenshot.Location = new System.Drawing.Point(502, 102);
            this.pbScreenshot.Name = "pbScreenshot";
            this.pbScreenshot.Size = new System.Drawing.Size(369, 340);
            this.pbScreenshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbScreenshot.TabIndex = 1;
            this.pbScreenshot.TabStop = false;
            // 
            // AppForm
            // 
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(883, 454);
            this.Controls.Add(this.pbScreenshot);
            this.Controls.Add(this.cbForms);
            this.Controls.Add(this.tbTestCode);
            this.Menu = this.mainMenu1;
            this.Name = "AppForm";
            this.Text = "MbUnitWinForms Recorder";
            ((System.ComponentModel.ISupportInitialize)(this.pbScreenshot)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

        private MenuItem menuItem1;
        private MenuItem miClose;
        private MenuItem menuItem2;
        private MenuItem miCapture;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
	}
}