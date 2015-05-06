using System;
using System.IO;
using System.Collections;
using System.Security.Principal;
using System.Runtime.Serialization.Formatters.Binary;
using System.Windows.Forms;

namespace PasswordManager
{
	/// <summary>
	/// Summary description for PasswordManagerTop.
	/// </summary>
	public class FormPasswordManagerTop : System.Windows.Forms.Form
	{
		#region gui
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem mmiFile;
		private System.Windows.Forms.MenuItem miNew;
		private System.Windows.Forms.MenuItem miOpen;
		private System.Windows.Forms.MenuItem miExit;
		private System.Windows.Forms.MenuItem miSep1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem mmiHelp;
		private System.Windows.Forms.MenuItem miAbout;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem mmiWindow;
		private System.Windows.Forms.MenuItem miCascade;
		private System.Windows.Forms.MenuItem miSave;
		private System.Windows.Forms.MenuItem miSaveAll;
		private System.Windows.Forms.MenuItem miImportCsv;
		private System.Windows.Forms.MenuItem miExportCsv;
		private System.Windows.Forms.MenuItem mmiOptions;
		private System.Windows.Forms.MenuItem miShowPasswords;
		#endregion

		
		private static WindowsIdentity myIdentity;	
		private MruMenuItem oMruItem = new MruMenuItem("&Recent files");

		/// <summary>
		/// standard empty constructor
		/// </summary>
		public FormPasswordManagerTop()
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
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.mmiFile = new System.Windows.Forms.MenuItem();
			this.miNew = new System.Windows.Forms.MenuItem();
			this.miOpen = new System.Windows.Forms.MenuItem();
			this.miSave = new System.Windows.Forms.MenuItem();
			this.miSaveAll = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.miSep1 = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.miImportCsv = new System.Windows.Forms.MenuItem();
			this.miExportCsv = new System.Windows.Forms.MenuItem();
			this.mmiOptions = new System.Windows.Forms.MenuItem();
			this.miShowPasswords = new System.Windows.Forms.MenuItem();
			this.mmiWindow = new System.Windows.Forms.MenuItem();
			this.miCascade = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.mmiHelp = new System.Windows.Forms.MenuItem();
			this.miAbout = new System.Windows.Forms.MenuItem();
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.mmiFile,
																					 this.mmiOptions,
																					 this.mmiWindow,
																					 this.mmiHelp});
			// 
			// mmiFile
			// 
			this.mmiFile.Index = 0;
			this.mmiFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miNew,
																					this.miOpen,
																					this.miSave,
																					this.miSaveAll,
																					this.menuItem1,
																					this.miSep1,
																					this.miExit,
																					this.miImportCsv,
																					this.miExportCsv});
			this.mmiFile.Text = "&File";
			// 
			// miNew
			// 
			this.miNew.Index = 0;
			this.miNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
			this.miNew.Text = "&New...";
			this.miNew.Click += new System.EventHandler(this.miNew_Click);
			// 
			// miOpen
			// 
			this.miOpen.Index = 1;
			this.miOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.miOpen.Text = "&Open...";
			this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
			// 
			// miSave
			// 
			this.miSave.Index = 2;
			this.miSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.miSave.Text = "&Save";
			this.miSave.Click += new System.EventHandler(this.miSave_Click);
			// 
			// miSaveAll
			// 
			this.miSaveAll.Index = 3;
			this.miSaveAll.Shortcut = System.Windows.Forms.Shortcut.CtrlShiftS;
			this.miSaveAll.Text = "Save &all";
			this.miSaveAll.Click += new System.EventHandler(this.miSaveAll_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 4;
			this.menuItem1.Text = "-";
			// 
			// miSep1
			// 
			this.miSep1.Index = 5;
			this.miSep1.Text = "-";
			// 
			// miExit
			// 
			this.miExit.Index = 6;
			this.miExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
			this.miExit.Text = "E&xit";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// miImportCsv
			// 
			this.miImportCsv.Index = 7;
			this.miImportCsv.Text = "Import CSV...";
			// 
			// miExportCsv
			// 
			this.miExportCsv.Index = 8;
			this.miExportCsv.Text = "Export CSV...";
			// 
			// mmiOptions
			// 
			this.mmiOptions.Index = 1;
			this.mmiOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.miShowPasswords});
			this.mmiOptions.Text = "&Options";
			// 
			// miShowPasswords
			// 
			this.miShowPasswords.Checked = true;
			this.miShowPasswords.Index = 0;
			this.miShowPasswords.Shortcut = System.Windows.Forms.Shortcut.CtrlP;
			this.miShowPasswords.Text = "Show &passwords";
			this.miShowPasswords.Click += new System.EventHandler(this.miShowPasswords_Click);
			// 
			// mmiWindow
			// 
			this.mmiWindow.Index = 2;
			this.mmiWindow.MdiList = true;
			this.mmiWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.miCascade,
																					  this.menuItem4});
			this.mmiWindow.Text = "&Window";
			// 
			// miCascade
			// 
			this.miCascade.Enabled = false;
			this.miCascade.Index = 0;
			this.miCascade.Text = "Cascade";
			// 
			// menuItem4
			// 
			this.menuItem4.Enabled = false;
			this.menuItem4.Index = 1;
			this.menuItem4.Text = "Tile";
			// 
			// mmiHelp
			// 
			this.mmiHelp.Index = 3;
			this.mmiHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					this.miAbout});
			this.mmiHelp.Text = "&Help";
			// 
			// miAbout
			// 
			this.miAbout.Index = 0;
			this.miAbout.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
			this.miAbout.Text = "&About...";
			this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
			// 
			// frmPasswordManagerTop
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(640, 409);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu;
			this.Name = "frmPasswordManagerTop";
			this.Text = "appName";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPasswordManagerTop_Closing);
			this.Load += new System.EventHandler(this.frmPasswordManager_Load);

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
				AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
				myIdentity = WindowsIdentity.GetCurrent();

				if(Environment.OSVersion.Platform == PlatformID.Win32NT)
				{
					if( myIdentity.IsAuthenticated ) 
					{
						Application.EnableVisualStyles();
						Application.Run(new FormPasswordManagerTop());
					}
					else 
						MessageBox.Show("You are not authenticated!", Settings.sApplicationName);
				}
				else
					MessageBox.Show("This application only supports NT", Settings.sApplicationName);

			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString(), Settings.sApplicationName);
			}
		}

		private void miAbout_Click(object sender, System.EventArgs e)
		{
			FormAbout oFrom = new FormAbout();
			oFrom.ShowDialog(this);
		}

		private void frmPasswordManager_Load(object sender, System.EventArgs e)
		{
			this.Text = Settings.sApplicationName +" - "+ myIdentity.Name;
			//string[] arFiles = {"PasswordManagerSettings.xml", "", "", ""};

			//oMruItem.Initialize(arFiles);

			MruMenuItem oLoadedMruItem = loadSerializedMenu();
			if(oLoadedMruItem!=null)
			{
				oMruItem = oLoadedMruItem;
			}
			else
			{
				string[] arFiles = {"", "", "", ""};
				oMruItem.Initialize(arFiles);
			}
			mmiFile.MenuItems.Add(5, oMruItem );
			oMruItem.MruClicked += new EventHandler(oMruItem_MruClicked);
		}

		private void saveSerializedMenu(MruMenuItem oMruItem)
		{
			FileStream fs = new FileStream(Settings.sMruDataFileName, FileMode.Create);

			try 
			{
				BinaryFormatter formatter = new BinaryFormatter();

				formatter.Serialize(fs, oMruItem);
			}   
			catch(Exception e) 
			{
				System.Windows.Forms.MessageBox.Show(e.ToString());
			}
			finally 
			{
				fs.Close();
			}
		}

		private MruMenuItem loadSerializedMenu()
		{
			if(File.Exists(Settings.sMruDataFileName))
			{
				FileStream fs = new FileStream(Settings.sMruDataFileName, FileMode.Open);

				try 
				{
					BinaryFormatter formatter = new BinaryFormatter();

					return (MruMenuItem)formatter.Deserialize(fs);
				}   
				catch(Exception e) 
				{
					System.Windows.Forms.MessageBox.Show(e.ToString());
				}
				finally 
				{
					fs.Close();
				}
			}
			return null;
		}

		private void miExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

//		private void miShowPasswords_Click(object sender, System.EventArgs e)
//		{
//			MenuItem oItem = (MenuItem)sender;
//			oItem.Checked = !oItem.Checked;
//		}

		private void OpenPasswordFile(string sFilename)
		{
			if(Settings.isFileWritable(sFilename))
			{
				FormPasswordManager oFormPasswordManager = new FormPasswordManager(sFilename);
				oFormPasswordManager.MdiParent = this;
				oFormPasswordManager.Show();

				this.oMruItem.FileOpened(sFilename);
			}
			else
				MessageBox.Show("File "+ sFilename +" does not exist or is read only", Settings.sApplicationName);
		}

		private void miOpen_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlgOpen = new OpenFileDialog();
			dlgOpen.Multiselect = false;
			dlgOpen.Filter = "Password files (*.passwords)|*.passwords|All files (*.*)|*.*";
			dlgOpen.CheckFileExists = true;
			dlgOpen.Title = "Select a passwords to open";
			dlgOpen.InitialDirectory = Application.StartupPath;
			if(dlgOpen.ShowDialog(this) == DialogResult.OK)
			{
				string sFilename = dlgOpen.FileName;
				OpenPasswordFile(sFilename);
			}
		}

		private void oMruItem_MruClicked(object sender, EventArgs e)
		{
			MenuItem oItem = (MenuItem)sender;
			string sFilename = oItem.Text;
			OpenPasswordFile(sFilename);
		}

		private void miSave_Click(object sender, System.EventArgs e)
		{
			FormPasswordManager oForm = (FormPasswordManager)this.ActiveMdiChild;
			oForm.savePasswords();
		}

		private void miSaveAll_Click(object sender, System.EventArgs e)
		{
			foreach(Form oEntryForm in this.MdiChildren)
			{
				FormPasswordManager oForm = (FormPasswordManager)oEntryForm;
				oForm.savePasswords();
			}
		}

		private void miShowPasswords_Click(object sender, System.EventArgs e)
		{
			MenuItem oItem = (MenuItem)sender;
			oItem.Checked = !oItem.Checked;

			Settings.bShowPasswords = oItem.Checked;
		}

		private void miNew_Click(object sender, System.EventArgs e)
		{
			OpenFileDialog dlgNew = new OpenFileDialog();
			dlgNew.Multiselect = false;
			dlgNew.Filter = "Password files (*.passwords)|*.passwords|All files (*.*)|*.*";
			//dlgNew.Filter = "Diary files (*.diary)|*.diary|All files (*.*)|*.*";
			dlgNew.CheckFileExists = false;
			dlgNew.Title = "Create a new diary";
			dlgNew.AddExtension = true;
			dlgNew.InitialDirectory = Application.StartupPath;
			if(dlgNew.ShowDialog(this) == DialogResult.OK)
			{
				string sFilename = dlgNew.FileName;
				FileInfo oInfo = new FileInfo(sFilename);
				StreamWriter oStream = oInfo.CreateText();
				oStream.Write("<passwordmanager><passwords></passwords></passwordmanager>");
				oStream.Close();
				OpenPasswordFile(sFilename);
			}
		}

		private void frmPasswordManagerTop_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			saveSerializedMenu(oMruItem);		
		}
	}
}
