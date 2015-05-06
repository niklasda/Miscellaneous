using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FourInRow
{
	/// <summary>
	/// Summary description for formAbout.
	/// </summary>
	public class FormAbout : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label lblAbout;
		private System.Windows.Forms.LinkLabel lnkDg;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// standard empty constructor
		/// </summary>
		public FormAbout()
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
				if(components != null)
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
			this.lblAbout = new System.Windows.Forms.Label();
			this.lnkDg = new System.Windows.Forms.LinkLabel();
			this.SuspendLayout();
			// 
			// lblAbout
			// 
			this.lblAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblAbout.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblAbout.Location = new System.Drawing.Point(24, 24);
			this.lblAbout.Name = "lblAbout";
			this.lblAbout.Size = new System.Drawing.Size(154, 88);
			this.lblAbout.TabIndex = 0;
			this.lblAbout.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lnkDg
			// 
			this.lnkDg.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lnkDg.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lnkDg.Location = new System.Drawing.Point(24, 133);
			this.lnkDg.Name = "lnkDg";
			this.lnkDg.Size = new System.Drawing.Size(146, 23);
			this.lnkDg.TabIndex = 1;
			this.lnkDg.TabStop = true;
			this.lnkDg.Text = "dahlman-group.com";
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

		private void FormAbout_Load(object sender, System.EventArgs e)
		{
			lblAbout.Text = Settings.sApplicationName +"\n\nCopyright (C) 2004\n\nby Niklas Dahlman\n";
		}

		private void lnkDg_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			try
			{
				Process.Start("http://dahlman-group.com/");
			}
			catch(Exception ex)
			{
				MessageBox.Show("Failed to launch site\n\n"+ ex.ToString(), Settings.sApplicationName);
			}
		}
	}
}
