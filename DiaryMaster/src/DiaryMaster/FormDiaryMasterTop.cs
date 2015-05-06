using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Security.Principal;
using System.Runtime.Serialization.Formatters.Binary;
//using System.Windows.Forms;

namespace DiaryMaster
{
	/// <summary>
	/// Summary description for PasswordManager.
	/// </summary>
	public class FormDiaryMasterTop : System.Windows.Forms.Form
	{
		#region gui
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.MenuItem mmiFile;
		private System.Windows.Forms.MenuItem miNew;
		private System.Windows.Forms.MenuItem miOpen;
		private System.Windows.Forms.MenuItem miSave;
		private System.Windows.Forms.MenuItem miImportCSV;
		private System.Windows.Forms.MenuItem mmiHelp;
		private System.Windows.Forms.MenuItem miAbout;
		private System.Windows.Forms.MenuItem miExit;
		private System.Windows.Forms.MenuItem miSep1;
		private System.Windows.Forms.MenuItem miSep2;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.MenuItem mmiOptions;
		private System.Windows.Forms.MenuItem miSetFont;
		private System.Windows.Forms.MenuItem miDisableEncryption;
		private System.Windows.Forms.MenuItem miExportTxt;
		private System.Windows.Forms.MenuItem mmiWindow;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem miSaveAll;
		#endregion

		/// <summary>
		/// standard empty constructor
		/// </summary>
		public FormDiaryMasterTop()
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
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.miSep1 = new System.Windows.Forms.MenuItem();
			this.miImportCSV = new System.Windows.Forms.MenuItem();
			this.miExportTxt = new System.Windows.Forms.MenuItem();
			this.miSep2 = new System.Windows.Forms.MenuItem();
			this.miExit = new System.Windows.Forms.MenuItem();
			this.mmiOptions = new System.Windows.Forms.MenuItem();
			this.miSetFont = new System.Windows.Forms.MenuItem();
			this.miDisableEncryption = new System.Windows.Forms.MenuItem();
			this.mmiWindow = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
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
																					this.menuItem4,
																					this.miSep1,
																					this.miImportCSV,
																					this.miExportTxt,
																					this.miSep2,
																					this.miExit});
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
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.menuItem4.Text = "-";
			// 
			// miSep1
			// 
			this.miSep1.Index = 5;
			this.miSep1.Text = "-";
			// 
			// miImportCSV
			// 
			this.miImportCSV.Enabled = false;
			this.miImportCSV.Index = 6;
			this.miImportCSV.Shortcut = System.Windows.Forms.Shortcut.CtrlI;
			this.miImportCSV.Text = "&Import CSV...";
			// 
			// miExportTxt
			// 
			this.miExportTxt.Index = 7;
			this.miExportTxt.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
			this.miExportTxt.Text = "&Export Txt...";
			// 
			// miSep2
			// 
			this.miSep2.Index = 8;
			this.miSep2.Text = "-";
			// 
			// miExit
			// 
			this.miExit.Index = 9;
			this.miExit.Shortcut = System.Windows.Forms.Shortcut.AltF4;
			this.miExit.Text = "E&xit";
			this.miExit.Click += new System.EventHandler(this.miExit_Click);
			// 
			// mmiOptions
			// 
			this.mmiOptions.Index = 1;
			this.mmiOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.miSetFont,
																					   this.miDisableEncryption});
			this.mmiOptions.Text = "&Options";
			// 
			// miSetFont
			// 
			this.miSetFont.Enabled = false;
			this.miSetFont.Index = 0;
			this.miSetFont.Text = "&Set font...";
			// 
			// miDisableEncryption
			// 
			this.miDisableEncryption.Index = 1;
			this.miDisableEncryption.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
			this.miDisableEncryption.Text = "&Disable encryption";
			this.miDisableEncryption.Click += new System.EventHandler(this.miDisableEncryption_Click);
			// 
			// mmiWindow
			// 
			this.mmiWindow.Index = 2;
			this.mmiWindow.MdiList = true;
			this.mmiWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3});
			this.mmiWindow.Text = "&Window";
			// 
			// menuItem2
			// 
			this.menuItem2.Enabled = false;
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Cascade";
			// 
			// menuItem3
			// 
			this.menuItem3.Enabled = false;
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "Tile";
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
			// frmDiaryMasterTop
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(680, 377);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu;
			this.Name = "frmDiaryMasterTop";
			this.Text = "appName";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmDiaryMasterTop_Closing);
			this.Load += new System.EventHandler(this.frmPasswordManager_Load);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			System.Windows.Forms.Application.EnableVisualStyles();
			try
			{
				AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
				myIdentity = WindowsIdentity.GetCurrent();

				if(Environment.OSVersion.Platform == PlatformID.Win32NT)
				{
					if( myIdentity.IsAuthenticated ) 
					{
						System.Windows.Forms.Application.Run(new FormDiaryMasterTop());
					}
					else 
						System.Windows.Forms.MessageBox.Show("You are not authenticated!", Settings.sApplicationName);
				}
				else
					System.Windows.Forms.MessageBox.Show("This application only supports NT", Settings.sApplicationName);

			}
			catch(Exception ex)
			{
				System.Windows.Forms.MessageBox.Show(ex.ToString(), Settings.sApplicationName);
			}
		}

		private static WindowsIdentity myIdentity;
		private MruMenuItem oMruItem = new MruMenuItem("&Recent files");

		private void miAbout_Click(object sender, System.EventArgs e)
		{
			FormAbout oForm = new FormAbout();
			oForm.ShowDialog(this);
		}

		private void frmPasswordManager_Load(object sender, System.EventArgs e)
		{
			this.Text = Settings.sApplicationName +" - "+ myIdentity.Name;

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

		private void oMruItem_MruClicked(object sender, EventArgs e)
		{
			System.Windows.Forms.MenuItem oItem = (System.Windows.Forms.MenuItem)sender;
			string sFilename = oItem.Text;
			OpenDiaryFile(sFilename);
		}

		private void miExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void miDisableEncryption_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.MenuItem oItem = (System.Windows.Forms.MenuItem)sender;
			oItem.Checked = !oItem.Checked;

			Settings.bUseEncryption = !oItem.Checked;
		}

		private void OpenDiaryFile(string sFilename)
		{
			if(Settings.isFileWritable(sFilename))
			{
				FormDiaryMaster oFormDiaryMaster = new FormDiaryMaster(sFilename);
				oFormDiaryMaster.MdiParent = this;
				oFormDiaryMaster.Show();

				this.oMruItem.FileOpened(sFilename);
			}
			else
				System.Windows.Forms.MessageBox.Show("File "+ sFilename +" does not exist or is read only", Settings.sApplicationName);
		}

		private void miOpen_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.OpenFileDialog dlgOpen = new System.Windows.Forms.OpenFileDialog();
			dlgOpen.Multiselect = false;
			dlgOpen.Filter = "Diary files (*.diary)|*.diary|All files (*.*)|*.*";
			dlgOpen.CheckFileExists = true;
			dlgOpen.Title = "Select a diary to open";
			dlgOpen.InitialDirectory = System.Windows.Forms.Application.StartupPath;
			if(dlgOpen.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				string sFilename = dlgOpen.FileName;
				OpenDiaryFile(sFilename);
			}
		}

		private void miNew_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.OpenFileDialog dlgNew = new System.Windows.Forms.OpenFileDialog();
			dlgNew.Multiselect = false;
			dlgNew.Filter = "Diary files (*.diary)|*.diary|All files (*.*)|*.*";
			dlgNew.CheckFileExists = false;
			dlgNew.Title = "Create a new diary";
			dlgNew.AddExtension = true;
			dlgNew.InitialDirectory = System.Windows.Forms.Application.StartupPath;
			if(dlgNew.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				string sFilename = dlgNew.FileName;
				FileInfo oInfo = new FileInfo(sFilename);
				StreamWriter oStream = oInfo.CreateText();
				oStream.Write("<passwordmanager><passwords></passwords></passwordmanager>");
				oStream.Close();
				OpenDiaryFile(sFilename);
			}
		}

		private void miSaveAll_Click(object sender, System.EventArgs e)
		{
			foreach(System.Windows.Forms.Form oChildForm in MdiChildren)
			{
				FormDiaryMaster oForm = (FormDiaryMaster)oChildForm;
				oForm.saveDiary();
			}
		}

		private void miSave_Click(object sender, System.EventArgs e)
		{
			FormDiaryMaster oForm = (FormDiaryMaster)this.ActiveMdiChild;
			oForm.saveDiary();
		}

		private void frmDiaryMasterTop_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			saveSerializedMenu(oMruItem);
		}
	}
}