using System;
using System.Collections;
using System.IO;
using System.Security.Principal;
using System.Windows.Forms;

namespace PasswordManager
{
	/// <summary>
	/// Summary description for PasswordManager.
	/// </summary>
	public class frmPasswordManager : System.Windows.Forms.Form
	{
		#region gui
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Button btnGotoUrl;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.StatusBarPanel sbpCount;
		private System.Windows.Forms.StatusBarPanel sbpCrypto;
		private System.Windows.Forms.StatusBarPanel sbpFilename;
		private System.Windows.Forms.GroupBox gbPasswordProperties;
		private System.Windows.Forms.Label lblSelectedCategory;
		private System.Windows.Forms.Label lblSelectedUrl;
		private System.Windows.Forms.Label lblSelectedDescription;
		private System.Windows.Forms.Label lblSelectedPassword;
		private System.Windows.Forms.Label lblSelectedUsername;
		private System.Windows.Forms.TreeView tvPasswords;
		private System.Windows.Forms.GroupBox gbPasswords;
		#endregion

		/// <summary>
		/// standard empty constructor
		/// </summary>
		public frmPasswordManager(string p_sSettingsFileName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			sSettingsFileName = p_sSettingsFileName;
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
			this.btnAdd = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnGotoUrl = new System.Windows.Forms.Button();
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.sbpCount = new System.Windows.Forms.StatusBarPanel();
			this.sbpCrypto = new System.Windows.Forms.StatusBarPanel();
			this.sbpFilename = new System.Windows.Forms.StatusBarPanel();
			this.gbPasswordProperties = new System.Windows.Forms.GroupBox();
			this.lblSelectedCategory = new System.Windows.Forms.Label();
			this.lblSelectedUrl = new System.Windows.Forms.Label();
			this.lblSelectedDescription = new System.Windows.Forms.Label();
			this.lblSelectedPassword = new System.Windows.Forms.Label();
			this.lblSelectedUsername = new System.Windows.Forms.Label();
			this.tvPasswords = new System.Windows.Forms.TreeView();
			this.gbPasswords = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.sbpCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpCrypto)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpFilename)).BeginInit();
			this.gbPasswordProperties.SuspendLayout();
			this.gbPasswords.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAdd.Location = new System.Drawing.Point(8, 312);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add...";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnEdit.Location = new System.Drawing.Point(88, 312);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.TabIndex = 2;
			this.btnEdit.Text = "Edit...";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDelete.Location = new System.Drawing.Point(168, 312);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "Delete...";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnGotoUrl
			// 
			this.btnGotoUrl.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnGotoUrl.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnGotoUrl.Location = new System.Drawing.Point(248, 312);
			this.btnGotoUrl.Name = "btnGotoUrl";
			this.btnGotoUrl.TabIndex = 4;
			this.btnGotoUrl.Text = "Goto URL";
			this.btnGotoUrl.Click += new System.EventHandler(this.btnGotoUrl_Click);
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 347);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.sbpCount,
																						 this.sbpCrypto,
																						 this.sbpFilename});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(592, 22);
			this.statusBar.TabIndex = 5;
			// 
			// sbpCount
			// 
			this.sbpCount.Text = "sbpCount";
			// 
			// sbpCrypto
			// 
			this.sbpCrypto.Text = "sbpCrypto";
			// 
			// sbpFilename
			// 
			this.sbpFilename.AutoSize = System.Windows.Forms.StatusBarPanelAutoSize.Spring;
			this.sbpFilename.Text = "sbpFilename";
			this.sbpFilename.Width = 376;
			// 
			// gbPasswordProperties
			// 
			this.gbPasswordProperties.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gbPasswordProperties.Controls.Add(this.lblSelectedCategory);
			this.gbPasswordProperties.Controls.Add(this.lblSelectedUrl);
			this.gbPasswordProperties.Controls.Add(this.lblSelectedDescription);
			this.gbPasswordProperties.Controls.Add(this.lblSelectedPassword);
			this.gbPasswordProperties.Controls.Add(this.lblSelectedUsername);
			this.gbPasswordProperties.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbPasswordProperties.Location = new System.Drawing.Point(304, 24);
			this.gbPasswordProperties.Name = "gbPasswordProperties";
			this.gbPasswordProperties.Size = new System.Drawing.Size(248, 248);
			this.gbPasswordProperties.TabIndex = 1;
			this.gbPasswordProperties.TabStop = false;
			this.gbPasswordProperties.Text = "Password properties";
			// 
			// lblSelectedCategory
			// 
			this.lblSelectedCategory.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblSelectedCategory.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblSelectedCategory.Location = new System.Drawing.Point(16, 128);
			this.lblSelectedCategory.Name = "lblSelectedCategory";
			this.lblSelectedCategory.Size = new System.Drawing.Size(208, 23);
			this.lblSelectedCategory.TabIndex = 4;
			// 
			// lblSelectedUrl
			// 
			this.lblSelectedUrl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblSelectedUrl.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblSelectedUrl.Location = new System.Drawing.Point(16, 96);
			this.lblSelectedUrl.Name = "lblSelectedUrl";
			this.lblSelectedUrl.Size = new System.Drawing.Size(208, 23);
			this.lblSelectedUrl.TabIndex = 3;
			// 
			// lblSelectedDescription
			// 
			this.lblSelectedDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblSelectedDescription.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblSelectedDescription.Location = new System.Drawing.Point(16, 160);
			this.lblSelectedDescription.Name = "lblSelectedDescription";
			this.lblSelectedDescription.Size = new System.Drawing.Size(208, 72);
			this.lblSelectedDescription.TabIndex = 2;
			// 
			// lblSelectedPassword
			// 
			this.lblSelectedPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblSelectedPassword.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblSelectedPassword.Location = new System.Drawing.Point(16, 64);
			this.lblSelectedPassword.Name = "lblSelectedPassword";
			this.lblSelectedPassword.Size = new System.Drawing.Size(208, 23);
			this.lblSelectedPassword.TabIndex = 1;
			// 
			// lblSelectedUsername
			// 
			this.lblSelectedUsername.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblSelectedUsername.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblSelectedUsername.Location = new System.Drawing.Point(16, 32);
			this.lblSelectedUsername.Name = "lblSelectedUsername";
			this.lblSelectedUsername.Size = new System.Drawing.Size(208, 23);
			this.lblSelectedUsername.TabIndex = 0;
			// 
			// tvPasswords
			// 
			this.tvPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left)));
			this.tvPasswords.FullRowSelect = true;
			this.tvPasswords.HideSelection = false;
			this.tvPasswords.ImageIndex = -1;
			this.tvPasswords.Location = new System.Drawing.Point(16, 24);
			this.tvPasswords.Name = "tvPasswords";
			this.tvPasswords.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
																					new System.Windows.Forms.TreeNode("Passwords", new System.Windows.Forms.TreeNode[] {
																																										   new System.Windows.Forms.TreeNode("Category 1"),
																																										   new System.Windows.Forms.TreeNode("Category 2")})});
			this.tvPasswords.SelectedImageIndex = -1;
			this.tvPasswords.Size = new System.Drawing.Size(280, 248);
			this.tvPasswords.Sorted = true;
			this.tvPasswords.TabIndex = 0;
			this.tvPasswords.DoubleClick += new System.EventHandler(this.tvPasswords_DoubleClick);
			this.tvPasswords.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvPasswords_AfterSelect);
			// 
			// gbPasswords
			// 
			this.gbPasswords.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gbPasswords.Controls.Add(this.gbPasswordProperties);
			this.gbPasswords.Controls.Add(this.tvPasswords);
			this.gbPasswords.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbPasswords.Location = new System.Drawing.Point(8, 16);
			this.gbPasswords.Name = "gbPasswords";
			this.gbPasswords.Size = new System.Drawing.Size(568, 288);
			this.gbPasswords.TabIndex = 7;
			this.gbPasswords.TabStop = false;
			this.gbPasswords.Text = "Passwords";
			// 
			// frmPasswordManager
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(592, 369);
			this.Controls.Add(this.gbPasswords);
			this.Controls.Add(this.statusBar);
			this.Controls.Add(this.btnGotoUrl);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.btnEdit);
			this.Controls.Add(this.btnAdd);
			this.Name = "frmPasswordManager";
			this.Text = "appName";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPasswordManager_Closing);
			this.Load += new System.EventHandler(this.frmPasswordManager_Load);
			((System.ComponentModel.ISupportInitialize)(this.sbpCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpCrypto)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpFilename)).EndInit();
			this.gbPasswordProperties.ResumeLayout(false);
			this.gbPasswords.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion


		private string sSettingsFileName = "PasswordManagerSettings.xml";
		private PasswordDictionary dicPasswords = null;

		private int GetMaxId()
		{
			int MaxId=0;
			foreach(DictionaryEntry oEntry in dicPasswords)
			{
				Password oPassword = (Password)oEntry.Value;
				if(oPassword.iPasswordId>MaxId)
					MaxId = oPassword.iPasswordId;
			}
			return MaxId;
		}

		private TreeNode getCategoryNode(string sCategoryName)
		{
			foreach(TreeNode oNode in tvPasswords.Nodes[0].Nodes)
			{
				if(oNode.Text.Trim().ToLower().Equals(sCategoryName.Trim().ToLower()))
					return oNode;
			}
		
			return tvPasswords.Nodes[0].Nodes.Add(sCategoryName);
		}

		private void listPasswords(PasswordDictionary dicPasswords)
		{
			tvPasswords.Nodes[0].Nodes.Clear();
			foreach(DictionaryEntry oEntry in dicPasswords)
			{
				Password oPassword = (Password)oEntry.Value;

				TreeNode oCategoryNode = getCategoryNode(oPassword.sCategory);				

				TreeNode oNode = new TreeNode(oPassword.sTitle);
				oNode.Tag = oPassword;
				oCategoryNode.Nodes.Add(oNode);
			}

			tvPasswords.Nodes[0].Expand();
		}

		private void miAbout_Click(object sender, System.EventArgs e)
		{
			frmAbout oFrom = new frmAbout();
			oFrom.ShowDialog();
		}

		private void frmPasswordManager_Load(object sender, System.EventArgs e)
		{
			this.Text = getFileNameFromPath(sSettingsFileName);

			dicPasswords = Settings.ReadPasswords(sSettingsFileName);
			listPasswords(dicPasswords);
			updateStatusBar();
		}

		private string getFileNameFromPath(string sFilePath)
		{
			FileInfo oInfo = new FileInfo(sFilePath);
			return oInfo.Name;
		}

		private void updateStatusBar()
		{
			if(dicPasswords!=null)
			{
				sbpCount.Text = dicPasswords.Count.ToString();
				sbpCrypto.Text = Encrypter.sCryptoName;
				sbpFilename.Text = getFileNameFromPath(sSettingsFileName);
			}
		}

		private void frmPasswordManager_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			savePasswords(dicPasswords, sSettingsFileName);
		}

		private void savePasswords(PasswordDictionary dicPasswords, string sFileName)
		{
			Settings.WritePasswords(dicPasswords, sFileName);
		}

		/// <summary>
		/// save the passwords
		/// </summary>
		public void savePasswords()
		{
			savePasswords(dicPasswords, sSettingsFileName);
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			frmPasswordProperties oForm = new frmPasswordProperties();
			int iNewPasswordId = GetMaxId()+1;
			Password oPassword = new Password(iNewPasswordId);
			oForm.arCategories = getCategoryArray();
			oForm.SetPassword(oPassword);
			if(oForm.ShowDialog()==DialogResult.OK)
			{
				oPassword = oForm.GetPassword();
				dicPasswords.Add(oPassword);
				listPasswords(dicPasswords);
			}
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			EditPassword();	
		}

		private string[] getCategoryArray()
		{
			string[] arNames = new string[tvPasswords.Nodes[0].Nodes.Count];
			foreach(TreeNode oNode in tvPasswords.Nodes[0].Nodes)
			{
				string sCategoryName = oNode.Text;
				arNames[oNode.Index] = sCategoryName;
			}
			return arNames;
		}

		private void EditPassword()
		{
			if(tvPasswords.SelectedNode!=null && tvPasswords.SelectedNode.Tag!=null)
			{
				TreeNode oNode = tvPasswords.SelectedNode;
				Password oPassword = dicPasswords[((Password)oNode.Tag).iPasswordId];
				frmPasswordProperties oForm = new frmPasswordProperties();
				oForm.arCategories = getCategoryArray();
				oForm.SetPassword(oPassword);
				if(oForm.ShowDialog() == DialogResult.OK)
				{
					oPassword = oForm.GetPassword();
					listPasswords(dicPasswords);
				}
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			if(tvPasswords.SelectedNode!=null && tvPasswords.SelectedNode.Tag!=null)
			{
				MessageBox.Show("Really delete selected password?", Settings.sApplicationName);
			}
		}

		private void btnGotoUrl_Click(object sender, System.EventArgs e)
		{
			if(tvPasswords.SelectedNode!=null && tvPasswords.SelectedNode.Tag!=null)
			{
				TreeNode oNode = tvPasswords.SelectedNode;
				Password oPassword = (Password)oNode.Tag;
				Remote.gotoUrl(oPassword.sUrl);
			}
		}

		private void miExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void tvPasswords_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			if(tvPasswords.SelectedNode!=null)
			{
				TreeNode oNode = tvPasswords.SelectedNode;
				if(oNode.Tag!=null)
				{
					Password oPassword = (Password)oNode.Tag;
					lblSelectedUsername.Text = "Username: "+ oPassword.sUsername;
				
					if(Settings.bShowPasswords)	
						lblSelectedPassword.Text = "Password: "+ oPassword.sPassword;
					else
						lblSelectedPassword.Text = "Password: ******";
	
					lblSelectedUrl.Text = "Url: "+ oPassword.sUrl;
					lblSelectedDescription.Text = "Description: "+ oPassword.sDescription;

					lblSelectedCategory.Text = "Category: "+ oPassword.sCategory;
				}
				else
				{
					lblSelectedUsername.Text = "Username: ";
					lblSelectedPassword.Text = "Password: ";
					lblSelectedUrl.Text = "Url: ";
					lblSelectedDescription.Text = "Description: ";
					lblSelectedCategory.Text = "Category: ";
				}
			}
		}

		private void tvPasswords_DoubleClick(object sender, System.EventArgs e)
		{
			EditPassword();
		}

//		private void miShowPasswords_Click(object sender, System.EventArgs e)
//		{
//			MenuItem oItem = (MenuItem)sender;
//			oItem.Checked = !oItem.Checked;
//		}

		
	}
}
