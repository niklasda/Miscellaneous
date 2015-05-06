using System.Windows.Forms;

namespace PasswordManager
{
	/// <summary>
	/// Summary description for frmAbout.
	/// </summary>
	public class FormPasswordProperties : System.Windows.Forms.Form
	{
		#region gui

		private System.Windows.Forms.TextBox tbUrl;
		private System.Windows.Forms.Label lblUrl;
		private System.Windows.Forms.TextBox tbUserId;
		private System.Windows.Forms.TextBox tbPassword;
		private System.Windows.Forms.Label lblPassword;
		private System.Windows.Forms.TextBox tbDescription;
		private System.Windows.Forms.Label lvlDescription;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOk;
		private System.Windows.Forms.Button btnGotoUrl;
		private System.Windows.Forms.Label lblPasswordId;
		private System.Windows.Forms.Label lblTitle;
		private System.Windows.Forms.TextBox tbTitle;
		private System.Windows.Forms.Label lblUsername;
		private System.Windows.Forms.Label lblId;
		private System.Windows.Forms.ComboBox cbCategories;
		private System.Windows.Forms.Label label1;

		private System.ComponentModel.IContainer components;
		#endregion

		/// <summary>
		/// standard empty constructor
		/// </summary>
		public FormPasswordProperties()
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
			this.lblTitle = new System.Windows.Forms.Label();
			this.tbTitle = new System.Windows.Forms.TextBox();
			this.tbUrl = new System.Windows.Forms.TextBox();
			this.lblUrl = new System.Windows.Forms.Label();
			this.tbUserId = new System.Windows.Forms.TextBox();
			this.lblUsername = new System.Windows.Forms.Label();
			this.tbPassword = new System.Windows.Forms.TextBox();
			this.lblPassword = new System.Windows.Forms.Label();
			this.tbDescription = new System.Windows.Forms.TextBox();
			this.lvlDescription = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnGotoUrl = new System.Windows.Forms.Button();
			this.lblId = new System.Windows.Forms.Label();
			this.lblPasswordId = new System.Windows.Forms.Label();
			this.cbCategories = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// lblTitle
			// 
			this.lblTitle.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblTitle.Location = new System.Drawing.Point(16, 48);
			this.lblTitle.Name = "lblTitle";
			this.lblTitle.Size = new System.Drawing.Size(80, 23);
			this.lblTitle.TabIndex = 0;
			this.lblTitle.Text = "Title:";
			this.lblTitle.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tbTitle
			// 
			this.tbTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbTitle.Location = new System.Drawing.Point(104, 48);
			this.tbTitle.Name = "tbTitle";
			this.tbTitle.Size = new System.Drawing.Size(368, 20);
			this.tbTitle.TabIndex = 1;
			this.tbTitle.Text = "";
			// 
			// tbUrl
			// 
			this.tbUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbUrl.Location = new System.Drawing.Point(104, 80);
			this.tbUrl.Name = "tbUrl";
			this.tbUrl.Size = new System.Drawing.Size(312, 20);
			this.tbUrl.TabIndex = 3;
			this.tbUrl.Text = "";
			// 
			// lblUrl
			// 
			this.lblUrl.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblUrl.Location = new System.Drawing.Point(16, 80);
			this.lblUrl.Name = "lblUrl";
			this.lblUrl.Size = new System.Drawing.Size(80, 23);
			this.lblUrl.TabIndex = 2;
			this.lblUrl.Text = "url:";
			this.lblUrl.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tbUserId
			// 
			this.tbUserId.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbUserId.Location = new System.Drawing.Point(104, 112);
			this.tbUserId.Name = "tbUserId";
			this.tbUserId.Size = new System.Drawing.Size(368, 20);
			this.tbUserId.TabIndex = 5;
			this.tbUserId.Text = "";
			// 
			// lblUsername
			// 
			this.lblUsername.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblUsername.Location = new System.Drawing.Point(16, 112);
			this.lblUsername.Name = "lblUsername";
			this.lblUsername.Size = new System.Drawing.Size(80, 23);
			this.lblUsername.TabIndex = 4;
			this.lblUsername.Text = "Username:";
			this.lblUsername.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tbPassword
			// 
			this.tbPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbPassword.Location = new System.Drawing.Point(104, 144);
			this.tbPassword.Name = "tbPassword";
			this.tbPassword.Size = new System.Drawing.Size(368, 20);
			this.tbPassword.TabIndex = 7;
			this.tbPassword.Text = "";
			// 
			// lblPassword
			// 
			this.lblPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblPassword.Location = new System.Drawing.Point(16, 144);
			this.lblPassword.Name = "lblPassword";
			this.lblPassword.Size = new System.Drawing.Size(80, 23);
			this.lblPassword.TabIndex = 6;
			this.lblPassword.Text = "Password:";
			this.lblPassword.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// tbDescription
			// 
			this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tbDescription.Location = new System.Drawing.Point(104, 208);
			this.tbDescription.Multiline = true;
			this.tbDescription.Name = "tbDescription";
			this.tbDescription.Size = new System.Drawing.Size(368, 88);
			this.tbDescription.TabIndex = 9;
			this.tbDescription.Text = "";
			// 
			// lvlDescription
			// 
			this.lvlDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lvlDescription.Location = new System.Drawing.Point(16, 208);
			this.lvlDescription.Name = "lvlDescription";
			this.lvlDescription.Size = new System.Drawing.Size(80, 23);
			this.lvlDescription.TabIndex = 8;
			this.lvlDescription.Text = "Description:";
			this.lvlDescription.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(400, 312);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 10;
			this.btnCancel.Text = "Cancel";
			// 
			// btnOk
			// 
			this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnOk.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOk.Location = new System.Drawing.Point(312, 312);
			this.btnOk.Name = "btnOk";
			this.btnOk.TabIndex = 11;
			this.btnOk.Text = "Ok";
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnGotoUrl
			// 
			this.btnGotoUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnGotoUrl.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnGotoUrl.Location = new System.Drawing.Point(424, 80);
			this.btnGotoUrl.Name = "btnGotoUrl";
			this.btnGotoUrl.Size = new System.Drawing.Size(48, 20);
			this.btnGotoUrl.TabIndex = 12;
			this.btnGotoUrl.Text = "goto";
			this.btnGotoUrl.Click += new System.EventHandler(this.btnGotoUrl_Click);
			// 
			// lblId
			// 
			this.lblId.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblId.Location = new System.Drawing.Point(16, 16);
			this.lblId.Name = "lblId";
			this.lblId.Size = new System.Drawing.Size(80, 23);
			this.lblId.TabIndex = 13;
			this.lblId.Text = "id:";
			this.lblId.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// lblPasswordId
			// 
			this.lblPasswordId.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblPasswordId.Location = new System.Drawing.Point(104, 16);
			this.lblPasswordId.Name = "lblPasswordId";
			this.lblPasswordId.Size = new System.Drawing.Size(136, 23);
			this.lblPasswordId.TabIndex = 14;
			// 
			// cbCategories
			// 
			this.cbCategories.Location = new System.Drawing.Point(104, 176);
			this.cbCategories.Name = "cbCategories";
			this.cbCategories.Size = new System.Drawing.Size(121, 21);
			this.cbCategories.TabIndex = 15;
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(16, 176);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 23);
			this.label1.TabIndex = 16;
			this.label1.Text = "Category:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
			// 
			// frmPasswordProperties
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(488, 349);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.cbCategories);
			this.Controls.Add(this.lblPasswordId);
			this.Controls.Add(this.lblId);
			this.Controls.Add(this.btnGotoUrl);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.tbDescription);
			this.Controls.Add(this.lvlDescription);
			this.Controls.Add(this.tbPassword);
			this.Controls.Add(this.lblPassword);
			this.Controls.Add(this.tbUserId);
			this.Controls.Add(this.lblUsername);
			this.Controls.Add(this.tbUrl);
			this.Controls.Add(this.lblUrl);
			this.Controls.Add(this.tbTitle);
			this.Controls.Add(this.lblTitle);
			this.Name = "frmPasswordProperties";
			this.Text = "Password properties";
			this.ResumeLayout(false);

		}
		#endregion

		private Password m_oPassword;
		private string[] m_arCategories;
		
		/// <summary>
		/// categories to choose from
		/// </summary>
		public string[] arCategories
		{
			set { m_arCategories = value; }
		}

		/// <summary>
		/// Show a password in the GUI
		/// </summary>
		/// <param name="oNewPassword">The password to show</param>
		public void SetPassword(Password oNewPassword)
		{
			cbCategories.Items.Clear();
			foreach(string sCategoryName in m_arCategories)
			{
				int i = cbCategories.Items.Add(sCategoryName);
				if(oNewPassword.sCategory.Equals(sCategoryName))
					cbCategories.SelectedIndex = i;
			}

			m_oPassword = oNewPassword;

			lblPasswordId.Text = oNewPassword.iPasswordId.ToString();
			tbTitle.Text = oNewPassword.sTitle;
			tbUserId.Text = oNewPassword.sUsername;
			tbPassword.Text = oNewPassword.sPassword;
			tbDescription.Text = oNewPassword.sDescription;
			tbUrl.Text = oNewPassword.sUrl;
		}

		/// <summary>
		/// return the edited password
		/// </summary>
		/// <returns></returns>
		public Password GetPassword()
		{
			return m_oPassword;
		}

		private void btnGotoUrl_Click(object sender, System.EventArgs e)
		{
			string sPassword = tbUrl.Text;
			Remote.gotoUrl(sPassword);	
		}

		private void btnOk_Click(object sender, System.EventArgs e)
		{
			if(tbTitle.Text.Trim().Length>0)
			{
				m_oPassword.sTitle = tbTitle.Text;
				m_oPassword.sUrl = tbUrl.Text;
				m_oPassword.sUsername = tbUserId.Text;
				m_oPassword.sPassword = tbPassword.Text;
				m_oPassword.sDescription = tbDescription.Text;
				m_oPassword.sCategory = cbCategories.Text;
			}
			else
			{
				MessageBox.Show("Please specify a title");
				this.DialogResult = DialogResult.None;
			}
		}
	}
}
