using System;
using System.Text;
using System.Windows.Forms;

namespace UniTester
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmUniTester : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox tbString;
		private System.Windows.Forms.TextBox tbUnicode;
		private System.Windows.Forms.Button btnSetTest;
		private System.Windows.Forms.Button btnConvert;
		private System.Windows.Forms.Label lblString;
		private System.Windows.Forms.Label lblUnicodes;
		private System.Windows.Forms.Button btnConvertDown;
		private System.Windows.Forms.Label lblCodepage;
		private System.Windows.Forms.TabControl tcUnitests;
		private System.Windows.Forms.TabPage tpUnicode;
		private System.Windows.Forms.TabPage tpCodePage;
		private System.Windows.Forms.Label lblSource;
		private System.Windows.Forms.TextBox tbSource;
		private System.Windows.Forms.TextBox tbDestination;
		private System.Windows.Forms.Label lblDestination;
		private System.Windows.Forms.Button btnConvertTo;
		private System.Windows.Forms.Button btnConvertFrom;
		private System.Windows.Forms.ComboBox cbCodepages;
		private System.Windows.Forms.Button btnArabic;
		private System.Windows.Forms.Button btnHebrew;
		private System.Windows.Forms.Button btnCyrillic;
		#region gui

		private System.ComponentModel.IContainer components;
		#endregion

		/// <summary>
		/// standard empty constructor
		/// </summary>
		public frmUniTester()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
				
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.tbString = new System.Windows.Forms.TextBox();
			this.tbUnicode = new System.Windows.Forms.TextBox();
			this.btnSetTest = new System.Windows.Forms.Button();
			this.btnConvert = new System.Windows.Forms.Button();
			this.lblString = new System.Windows.Forms.Label();
			this.lblUnicodes = new System.Windows.Forms.Label();
			this.btnConvertDown = new System.Windows.Forms.Button();
			this.lblCodepage = new System.Windows.Forms.Label();
			this.tcUnitests = new System.Windows.Forms.TabControl();
			this.tpUnicode = new System.Windows.Forms.TabPage();
			this.btnArabic = new System.Windows.Forms.Button();
			this.btnCyrillic = new System.Windows.Forms.Button();
			this.btnHebrew = new System.Windows.Forms.Button();
			this.tpCodePage = new System.Windows.Forms.TabPage();
			this.cbCodepages = new System.Windows.Forms.ComboBox();
			this.btnConvertFrom = new System.Windows.Forms.Button();
			this.btnConvertTo = new System.Windows.Forms.Button();
			this.lblDestination = new System.Windows.Forms.Label();
			this.tbDestination = new System.Windows.Forms.TextBox();
			this.tbSource = new System.Windows.Forms.TextBox();
			this.lblSource = new System.Windows.Forms.Label();
			this.tcUnitests.SuspendLayout();
			this.tpUnicode.SuspendLayout();
			this.tpCodePage.SuspendLayout();
			this.SuspendLayout();
			// 
			// tbString
			// 
			this.tbString.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbString.Location = new System.Drawing.Point(128, 48);
			this.tbString.Multiline = true;
			this.tbString.Name = "tbString";
			this.tbString.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbString.Size = new System.Drawing.Size(376, 88);
			this.tbString.TabIndex = 0;
			this.tbString.Text = "";
			// 
			// tbUnicode
			// 
			this.tbUnicode.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbUnicode.Location = new System.Drawing.Point(128, 208);
			this.tbUnicode.Multiline = true;
			this.tbUnicode.Name = "tbUnicode";
			this.tbUnicode.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbUnicode.Size = new System.Drawing.Size(376, 80);
			this.tbUnicode.TabIndex = 1;
			this.tbUnicode.Text = "";
			// 
			// btnSetTest
			// 
			this.btnSetTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnSetTest.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSetTest.Location = new System.Drawing.Point(128, 144);
			this.btnSetTest.Name = "btnSetTest";
			this.btnSetTest.Size = new System.Drawing.Size(64, 23);
			this.btnSetTest.TabIndex = 2;
			this.btnSetTest.Text = "Set greek";
			this.btnSetTest.Click += new System.EventHandler(this.btnSetTest_Click);
			// 
			// btnConvert
			// 
			this.btnConvert.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConvert.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnConvert.Location = new System.Drawing.Point(528, 208);
			this.btnConvert.Name = "btnConvert";
			this.btnConvert.Size = new System.Drawing.Size(96, 23);
			this.btnConvert.TabIndex = 3;
			this.btnConvert.Text = "convert up";
			this.btnConvert.Click += new System.EventHandler(this.btnConvert_Click);
			// 
			// lblString
			// 
			this.lblString.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblString.Location = new System.Drawing.Point(40, 56);
			this.lblString.Name = "lblString";
			this.lblString.Size = new System.Drawing.Size(80, 23);
			this.lblString.TabIndex = 4;
			this.lblString.Text = "String:";
			this.lblString.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lblUnicodes
			// 
			this.lblUnicodes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.lblUnicodes.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblUnicodes.Location = new System.Drawing.Point(40, 216);
			this.lblUnicodes.Name = "lblUnicodes";
			this.lblUnicodes.Size = new System.Drawing.Size(80, 23);
			this.lblUnicodes.TabIndex = 5;
			this.lblUnicodes.Text = "Unicodes:";
			this.lblUnicodes.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// btnConvertDown
			// 
			this.btnConvertDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnConvertDown.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnConvertDown.Location = new System.Drawing.Point(528, 48);
			this.btnConvertDown.Name = "btnConvertDown";
			this.btnConvertDown.Size = new System.Drawing.Size(96, 23);
			this.btnConvertDown.TabIndex = 6;
			this.btnConvertDown.Text = "convert down";
			this.btnConvertDown.Click += new System.EventHandler(this.btnConvertDown_Click);
			// 
			// lblCodepage
			// 
			this.lblCodepage.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblCodepage.Location = new System.Drawing.Point(72, 128);
			this.lblCodepage.Name = "lblCodepage";
			this.lblCodepage.Size = new System.Drawing.Size(80, 23);
			this.lblCodepage.TabIndex = 8;
			this.lblCodepage.Text = "Codepage:";
			this.lblCodepage.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tcUnitests
			// 
			this.tcUnitests.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tcUnitests.Controls.Add(this.tpUnicode);
			this.tcUnitests.Controls.Add(this.tpCodePage);
			this.tcUnitests.Location = new System.Drawing.Point(8, 16);
			this.tcUnitests.Name = "tcUnitests";
			this.tcUnitests.SelectedIndex = 0;
			this.tcUnitests.Size = new System.Drawing.Size(672, 336);
			this.tcUnitests.TabIndex = 9;
			// 
			// tpUnicode
			// 
			this.tpUnicode.Controls.Add(this.btnArabic);
			this.tpUnicode.Controls.Add(this.btnCyrillic);
			this.tpUnicode.Controls.Add(this.btnHebrew);
			this.tpUnicode.Controls.Add(this.btnSetTest);
			this.tpUnicode.Controls.Add(this.lblUnicodes);
			this.tpUnicode.Controls.Add(this.tbUnicode);
			this.tpUnicode.Controls.Add(this.btnConvertDown);
			this.tpUnicode.Controls.Add(this.btnConvert);
			this.tpUnicode.Controls.Add(this.tbString);
			this.tpUnicode.Controls.Add(this.lblString);
			this.tpUnicode.Location = new System.Drawing.Point(4, 22);
			this.tpUnicode.Name = "tpUnicode";
			this.tpUnicode.Size = new System.Drawing.Size(664, 310);
			this.tpUnicode.TabIndex = 0;
			this.tpUnicode.Text = "Unicode";
			// 
			// btnArabic
			// 
			this.btnArabic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnArabic.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnArabic.Location = new System.Drawing.Point(200, 144);
			this.btnArabic.Name = "btnArabic";
			this.btnArabic.Size = new System.Drawing.Size(64, 23);
			this.btnArabic.TabIndex = 10;
			this.btnArabic.Text = "Set arabic";
			this.btnArabic.Click += new System.EventHandler(this.btnArabic_Click);
			// 
			// btnCyrillic
			// 
			this.btnCyrillic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnCyrillic.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCyrillic.Location = new System.Drawing.Point(352, 144);
			this.btnCyrillic.Name = "btnCyrillic";
			this.btnCyrillic.Size = new System.Drawing.Size(64, 23);
			this.btnCyrillic.TabIndex = 8;
			this.btnCyrillic.Text = "Set cyrillic";
			this.btnCyrillic.Click += new System.EventHandler(this.btnCyrillic_Click);
			// 
			// btnHebrew
			// 
			this.btnHebrew.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnHebrew.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnHebrew.Location = new System.Drawing.Point(272, 144);
			this.btnHebrew.Name = "btnHebrew";
			this.btnHebrew.Size = new System.Drawing.Size(72, 23);
			this.btnHebrew.TabIndex = 7;
			this.btnHebrew.Text = "Set hebrew";
			this.btnHebrew.Click += new System.EventHandler(this.btnHebrew_Click);
			// 
			// tpCodePage
			// 
			this.tpCodePage.Controls.Add(this.cbCodepages);
			this.tpCodePage.Controls.Add(this.btnConvertFrom);
			this.tpCodePage.Controls.Add(this.btnConvertTo);
			this.tpCodePage.Controls.Add(this.lblDestination);
			this.tpCodePage.Controls.Add(this.tbDestination);
			this.tpCodePage.Controls.Add(this.tbSource);
			this.tpCodePage.Controls.Add(this.lblSource);
			this.tpCodePage.Controls.Add(this.lblCodepage);
			this.tpCodePage.Location = new System.Drawing.Point(4, 22);
			this.tpCodePage.Name = "tpCodePage";
			this.tpCodePage.Size = new System.Drawing.Size(664, 310);
			this.tpCodePage.TabIndex = 1;
			this.tpCodePage.Text = "CodePages";
			// 
			// cbCodepages
			// 
			this.cbCodepages.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbCodepages.Items.AddRange(new object[] {
															 "1250 (EE)",
															 "1251 (Cyrillic)",
															 "1252 (ANSI)",
															 "1253 (Greek)",
															 "1254 (Turk)",
															 "1255 (Hebrew)",
															 "1256 (Arabic)",
															 "1257 (BaltRim)",
															 "1258 (Viet Nam)"});
			this.cbCodepages.Location = new System.Drawing.Point(160, 128);
			this.cbCodepages.Name = "cbCodepages";
			this.cbCodepages.Size = new System.Drawing.Size(112, 21);
			this.cbCodepages.TabIndex = 15;
			// 
			// btnConvertFrom
			// 
			this.btnConvertFrom.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnConvertFrom.Location = new System.Drawing.Point(336, 128);
			this.btnConvertFrom.Name = "btnConvertFrom";
			this.btnConvertFrom.Size = new System.Drawing.Size(64, 23);
			this.btnConvertFrom.TabIndex = 14;
			this.btnConvertFrom.Text = "From CP";
			this.btnConvertFrom.Click += new System.EventHandler(this.btnConvertFrom_Click);
			// 
			// btnConvertTo
			// 
			this.btnConvertTo.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnConvertTo.Location = new System.Drawing.Point(280, 128);
			this.btnConvertTo.Name = "btnConvertTo";
			this.btnConvertTo.Size = new System.Drawing.Size(48, 23);
			this.btnConvertTo.TabIndex = 13;
			this.btnConvertTo.Text = "To CP";
			this.btnConvertTo.Click += new System.EventHandler(this.btnConvertTo_Click);
			// 
			// lblDestination
			// 
			this.lblDestination.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblDestination.Location = new System.Drawing.Point(72, 184);
			this.lblDestination.Name = "lblDestination";
			this.lblDestination.Size = new System.Drawing.Size(80, 24);
			this.lblDestination.TabIndex = 12;
			this.lblDestination.Text = "Destination:";
			this.lblDestination.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tbDestination
			// 
			this.tbDestination.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbDestination.Location = new System.Drawing.Point(160, 176);
			this.tbDestination.Multiline = true;
			this.tbDestination.Name = "tbDestination";
			this.tbDestination.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbDestination.Size = new System.Drawing.Size(456, 96);
			this.tbDestination.TabIndex = 11;
			this.tbDestination.Text = "";
			// 
			// tbSource
			// 
			this.tbSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbSource.Location = new System.Drawing.Point(160, 32);
			this.tbSource.Multiline = true;
			this.tbSource.Name = "tbSource";
			this.tbSource.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.tbSource.Size = new System.Drawing.Size(456, 72);
			this.tbSource.TabIndex = 10;
			this.tbSource.Text = "";
			// 
			// lblSource
			// 
			this.lblSource.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblSource.Location = new System.Drawing.Point(72, 40);
			this.lblSource.Name = "lblSource";
			this.lblSource.Size = new System.Drawing.Size(80, 23);
			this.lblSource.TabIndex = 9;
			this.lblSource.Text = "source:";
			this.lblSource.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// frmUniTester
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(688, 365);
			this.Controls.Add(this.tcUnitests);
			this.Name = "frmUniTester";
			this.Text = "UniTester";
			this.Load += new System.EventHandler(this.frmUniTester_Load);
			this.tcUnitests.ResumeLayout(false);
			this.tpUnicode.ResumeLayout(false);
			this.tpCodePage.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			try
			{
				Application.EnableVisualStyles();
				Application.Run(new frmUniTester());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}


		private string makeUnicode(string sInput)
		{
			StringBuilder sOutputBuilder = new StringBuilder(1000);
			foreach(char cc in sInput)
			{
				string sNumbers;
				sNumbers = Convert.ToString(cc,16);

				sOutputBuilder.Append(sNumbers.PadLeft(4,'0') +" ");
			}
			return sOutputBuilder.ToString().ToUpper();
		}

		private string makeStringFromUnicode(string sInput)
		{
			StringBuilder sOutputBuilder = new StringBuilder(1000);
			string sTrimmedInput = sInput.Replace(" ", "");

			if( (sTrimmedInput.Length%4)==0  ) 
			{
				for(int i=0;i<sTrimmedInput.Length; i+=4)
				{
					string sChar = sTrimmedInput.Substring(i,4);
					try
					{
						int iChar = Convert.ToInt32(sChar,16);
						char cChar = Convert.ToChar(iChar);
						sOutputBuilder.Append(cChar);
					}
					catch(Exception ex)
					{
						MessageBox.Show("Error with: "+ sChar +"\n\n"+ ex.ToString());
					}
				}
			}

			return sOutputBuilder.ToString();
		}


		private void btnConvert_Click(object sender, System.EventArgs e)
		{
			tbString.Text = makeStringFromUnicode(tbUnicode.Text.Trim());
		}		
		
		private void btnConvertDown_Click(object sender, System.EventArgs e)
		{
			tbUnicode.Text = makeUnicode(tbString.Text.Trim());
		
		}


		private void btnConvertTo_Click(object sender, System.EventArgs e)
		{
			string sSrc = tbSource.Text;
			
			Encoding encoding = Encoding.GetEncoding(getCodePage());

			Byte[] arSrc = encoding.GetBytes(sSrc);

			string sDst = encoding.GetString(arSrc);
			tbDestination.Text = sDst;
		}

		private int getCodePage()
		{
			string sCodePage = cbCodepages.SelectedItem.ToString();
			int iSpacePos = sCodePage.IndexOf(' ');
			string sCodePageNum = sCodePage.Substring(0,iSpacePos).Trim();
			
			return int.Parse(sCodePageNum);
		}

		private void btnConvertFrom_Click(object sender, System.EventArgs e)
		{
			string sDst = tbDestination.Text;

			try
			{
				Encoding encoder = Encoding.GetEncoding(getCodePage());
				Decoder decoder = encoder.GetDecoder();

				byte[] arBytes = encoder.GetBytes(sDst);
				char[] arChars = new char[arBytes.Length];
				int iCount = decoder.GetChars(encoder.GetBytes(sDst),0,arBytes.Length,arChars,0);

				string sSrc = new string(arChars);
				tbSource.Text = sSrc;
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void frmUniTester_Load(object sender, System.EventArgs e)
		{
			cbCodepages.SelectedIndex = 3;
		}


		private void btnSetTest_Click(object sender, System.EventArgs e)
		{
			tbString.Text += "\u03A0";
		}
		
		private void btnArabic_Click(object sender, System.EventArgs e)
		{
			tbString.Text += "\u062D";
		}

		private void btnHebrew_Click(object sender, System.EventArgs e)
		{
			tbString.Text += "\u05E7";
		}

		private void btnCyrillic_Click(object sender, System.EventArgs e)
		{
			tbString.Text += "\u044E";
		}
	}
}
