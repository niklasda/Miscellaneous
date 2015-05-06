using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.Security.Principal;
//using System.Windows.Forms;

namespace DiaryMaster
{
	/// <summary>
	/// Summary description for PasswordManager.
	/// </summary>
	public class frmDiaryMasterTop : System.Windows.Forms.Form
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
		#endregion
		private System.Windows.Forms.MenuItem mmiWindow;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem4;

		private MRUMenuItem oMruItem = new MRUMenuItem("Recent files");
		
		/// <summary>
		/// standard empty constructor
		/// </summary>
		public frmDiaryMasterTop()
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
			this.menuItem1 = new System.Windows.Forms.MenuItem();
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
																					this.menuItem1,
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
			this.miNew.Text = "New...";
			this.miNew.Click += new System.EventHandler(this.miNew_Click);
			// 
			// miOpen
			// 
			this.miOpen.Index = 1;
			this.miOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
			this.miOpen.Text = "Open...";
			this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
			// 
			// miSave
			// 
			this.miSave.Index = 2;
			this.miSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
			this.miSave.Text = "Save";
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 3;
			this.menuItem1.Text = "Save all";
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
			this.miImportCSV.Text = "Import CSV...";
			// 
			// miExportTxt
			// 
			this.miExportTxt.Index = 7;
			this.miExportTxt.Text = "Export Txt...";
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
			this.miExit.Text = "Exit";
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
			this.miSetFont.Text = "Set font...";
			// 
			// miDisableEncryption
			// 
			this.miDisableEncryption.Index = 1;
			this.miDisableEncryption.Text = "Disable encryption";
			this.miDisableEncryption.Click += new System.EventHandler(this.miDisableEncryption_Click);
			// 
			// mmiWindow
			// 
			this.mmiWindow.Index = 2;
			this.mmiWindow.MdiList = true;
			this.mmiWindow.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3});
			this.mmiWindow.Text = "Window";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "Cascade";
			// 
			// menuItem3
			// 
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
			this.miAbout.Text = "About...";
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
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPasswordManager_Closing);
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
						System.Windows.Forms.Application.Run(new frmDiaryMasterTop());
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

	//	private DiaryDayDictionary dicDiaryDays = null;
		private static WindowsIdentity myIdentity;

//		private int GetMaxId()
//		{
//			int MaxId=0;
//			foreach(DictionaryEntry oDayEntry in dicDiaryDays)
//			{
//				DiaryDay oDay = (DiaryDay)oDayEntry.Value;
//
//				foreach(DictionaryEntry oEntry in oDay.dicEntries)
//				{
//					DiaryEntry oPassword = (DiaryEntry)oEntry.Value;
//					if(oPassword.iEntryId>MaxId)
//						MaxId = oPassword.iEntryId;
//				}
//			}
//			return MaxId;
//		}

		private void miAbout_Click(object sender, System.EventArgs e)
		{
			frmAbout oFrom = new frmAbout();
			oFrom.ShowDialog();
		}

		private void frmPasswordManager_Load(object sender, System.EventArgs e)
		{
			this.Text = Settings.sApplicationName +" - "+ myIdentity.Name;
			string[] arFiles = {"Dilbert.xml", "DiaryMasterSettings.xml", "", ""};

			oMruItem.Initialize(arFiles);
			mmiFile.MenuItems.Add(5, oMruItem );
			oMruItem.MRUClicked += new EventHandler(oMruItem_MRUClicked);

//			dicDiaryDays = Settings.ReadDiaryDays();
//			rtDatelessNotes.Text = Settings.ReadDatelessNote();
//			listDiaryDays(dicDiaryDays);
//			diaryCalendar.SetDate(DateTime.Now);
//			updateStatusBar();
		}

		private void oMruItem_MRUClicked(object sender, EventArgs e)
		{
			System.Windows.Forms.MenuItem oItem = (System.Windows.Forms.MenuItem)sender;
			string sFilename = oItem.Text;
			OpenDiaryFile(sFilename);
		}

//		private void updateStatusBar()
//		{
//			if(dicDiaryDays!=null)
//			{
//				sbpCount.Text = dicDiaryDays.Count.ToString();
//				sbpCrypto.Text = Encrypter.sCryptoName;
//				sbpFilename.Text = Settings.sSettingsFileName;
//			}
//		}

		private void frmPasswordManager_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
		//	Settings.WriteDiaryDays(dicDiaryDays, rtDatelessNotes.Text);
		}

		private void miExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

//		private void diaryCalendar_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
//		{
//			DateTime dtDate = e.Start;
//			DiaryDay oDiaryDay;
//			if(dicDiaryDays.Contains(dtDate))
//			{
//				oDiaryDay = dicDiaryDays[dtDate];
//			}
//			else
//			{
//				oDiaryDay = new DiaryDay(dtDate);
//				dicDiaryDays.Add(oDiaryDay);
//			}
//
//			ShowSelectedDay(oDiaryDay);
//		}
//
//		private void btnSaveEntry_Click(object sender, System.EventArgs e)
//		{
//			DiaryDay oDiaryDay = (DiaryDay)tpSelectedDate.Tag;
//			if(cbDayEntries.SelectedItem!=null)
//			{
//				DiaryEntry oDiaryEntry = (DiaryEntry)cbDayEntries.SelectedItem;
//				oDiaryEntry.sEntry = rtEntry.Text;
//			}
//			else
//			{
//				DiaryEntry oDiaryEntry = new DiaryEntry(3, rtEntry.Text, Recurrance.None);
//				oDiaryDay.dicEntries.Add(oDiaryEntry);
//			}
//			ShowSelectedDay(oDiaryDay);
//		}
//
//
//		private void btnTextFormat_Click(object sender, System.EventArgs e)
//		{
//			FontDialog dlgSelectFont = new FontDialog();
//			dlgSelectFont.FontMustExist = true;
//			dlgSelectFont.ShowEffects = true;
//			dlgSelectFont.ShowHelp = true;
//			
//
//			if(dlgSelectFont.ShowDialog() == DialogResult.OK)
//			{
//				rtEntry.SelectionFont = dlgSelectFont.Font;
//			}
//		}
//
//		private void btnTextColor_Click(object sender, System.EventArgs e)
//		{
//			ColorDialog dlgSelectColor = new ColorDialog();
//			dlgSelectColor.ShowHelp = true;
//			dlgSelectColor.AllowFullOpen = true;
//			dlgSelectColor.FullOpen = true;
//			dlgSelectColor.SolidColorOnly = true;
//
//			if(dlgSelectColor.ShowDialog() == DialogResult.OK)
//			{
//				rtEntry.SelectionColor = dlgSelectColor.Color;
//			}
//		}
//
//		private void lvEntryList_DoubleClick(object sender, System.EventArgs e)
//		{
//			if(lvDiaryDays.SelectedItems.Count>0)
//			{
//				DiaryDay oDiaryDay = (DiaryDay)lvDiaryDays.SelectedItems[0].Tag;
//				diaryCalendar.SetDate(oDiaryDay.dtEntryDate);
//				//				ShowSelectedDay(oDiaryDay);
//			}
//		}

//		private void ShowSelectedDay(DiaryDay oDiaryDay)
//		{
//			cbDayEntries.Items.Clear();
//			if(oDiaryDay.dicEntries.Count>0)
//			{
//				foreach(DictionaryEntry oEntry in oDiaryDay.dicEntries)
//				{
//					DiaryEntry oDiaryEntry = (DiaryEntry)oEntry.Value;
//					cbDayEntries.Items.Add(oDiaryEntry);
//				}
//
//				cbDayEntries.SelectedIndex=0;
//			}
//			else
//			{
//				rtEntry.Text = "";
//			}
//
//			diaryCalendar.SelectionStart = oDiaryDay.dtEntryDate;
//			diaryCalendar.SetDate(oDiaryDay.dtEntryDate);
//			tpSelectedDate.Text = oDiaryDay.dtEntryDate.ToLongDateString();
//			tpSelectedDate.Tag = oDiaryDay;
//			if(tcEntryInfo.SelectedTab != tpSelectedDate)
//				tcEntryInfo.SelectedTab = tpSelectedDate;
//		}
//
//		private void ShowSelectedEntry(DiaryEntry oEntry)
//		{
//			rtEntry.Text = oEntry.sEntry;
//			SetRecurranceRadio(oEntry. eRecurring);
//		}
//
//		private void SetRecurranceRadio(Recurrance eRecurance)
//		{
//			rbRecDaily.Checked = (eRecurance == Recurrance.Daily);
//			rbRecMonthly.Checked = (eRecurance == Recurrance.Monthly);
//			rbRecNone.Checked = (eRecurance == Recurrance.None);
//			rbRecQuarterly.Checked = (eRecurance == Recurrance.Quarterly);
//			//	rbRecT.Checked = (eRecurance == Recurrance.Tertiarly);
//			rbRecWeekly.Checked = (eRecurance == Recurrance.Weekly);
//			rbRecYearly.Checked = (eRecurance == Recurrance.Yearly);
//		}
//
//		private void tcEntryInfo_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			if(tcEntryInfo.SelectedTab == tpAllEntries)
//			{
//				listDiaryDays(dicDiaryDays);
//			}
//			else if(tcEntryInfo.SelectedTab == tpSummary)
//			{
//				GenerateSummary(dicDiaryDays);
//			}
//		}
//
//		private void GenerateSummary(DiaryDayDictionary dicDiaryDays)
//		{
//			rtSummary.Text = "";
//
//			foreach(DictionaryEntry oDayEntry in dicDiaryDays)
//			{
//				DiaryDay oDay = (DiaryDay)oDayEntry.Value;
//				rtSummary.Text += oDay.dtEntryDate.ToString() + Environment.NewLine;
//
//				foreach(DictionaryEntry oEntry in oDay.dicEntries)
//				{
//					DiaryEntry oDiaryEntry = (DiaryEntry)oEntry.Value;
//
//					rtSummary.Text += oDiaryEntry.sEntry + Environment.NewLine + Environment.NewLine;
//				}
//			}
//		}

//		private void btnEditDiaryDay_Click(object sender, System.EventArgs e)
//		{
//			if(lvDiaryDays.SelectedItems.Count>0)
//			{
//				DiaryDay oDiaryDay = (DiaryDay)lvDiaryDays.SelectedItems[0].Tag;
//				ShowSelectedDay(oDiaryDay);
//			}
//		}
//
//		private void cbDayEntries_SelectedIndexChanged(object sender, System.EventArgs e)
//		{
//			if(cbDayEntries.SelectedItem!=null)
//			{
//				DiaryEntry oDiaryEntry = (DiaryEntry)cbDayEntries.SelectedItem;
//				ShowSelectedEntry(oDiaryEntry);
//			}
//			else
//			{
//				SetRecurranceRadio(Recurrance.None);
//			}
//		}
//
//		private void btnDeleteEntry_Click(object sender, System.EventArgs e)
//		{
//			if(cbDayEntries.SelectedItem!=null)
//			{
//				DiaryEntry oDiaryEntry = (DiaryEntry)cbDayEntries.SelectedItem;
//				DiaryDay oDiaryDay = (DiaryDay)tpSelectedDate.Tag;
//
//				oDiaryDay.dicEntries.Remove(oDiaryEntry);
//				ShowSelectedDay(oDiaryDay);
//			}
//		}
//
//		private void btnDeleteDiaryDay_Click(object sender, System.EventArgs e)
//		{
//			foreach(ListViewItem oItem in lvDiaryDays.SelectedItems)
//			{
//				DiaryDay oDay = (DiaryDay)oItem.Tag;
//				dicDiaryDays.Remove(oDay);
//			}
//
//			listDiaryDays(dicDiaryDays);
//		}
//
//		private void btnShowDiaryDay_Click(object sender, System.EventArgs e)
//		{
//			if(lvDiaryDays.SelectedItems.Count>0)
//			{
//				DiaryDay oDiaryDay = (DiaryDay)lvDiaryDays.SelectedItems[0].Tag;
//				diaryCalendar.SetDate(oDiaryDay.dtEntryDate);
//			}
//		}

		private void miDisableEncryption_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.MenuItem oItem = (System.Windows.Forms.MenuItem)sender;
			oItem.Checked = !oItem.Checked;

			Settings.bUseEncryption = !oItem.Checked;
		}

//		private void btnAddDayEntry_Click(object sender, System.EventArgs e)
//		{
//			DiaryDay oDiaryDay = (DiaryDay)tpSelectedDate.Tag;
//			DiaryEntry oDiaryEntry = new DiaryEntry(GetMaxId()+1,"",Recurrance.None);
//			oDiaryDay.dicEntries.Add(oDiaryEntry);
//
//			ShowSelectedDay(oDiaryDay);
//		}

		private void OpenDiaryFile(string sFilename)
		{
			if(Settings.isFileWritable(sFilename))
			{
				frmDiaryMaster oFrmDiaryMaster = new frmDiaryMaster(sFilename);
				oFrmDiaryMaster.MdiParent = this;
				oFrmDiaryMaster.Show();

				this.oMruItem.FileOpened(sFilename);
			}
			else
				System.Windows.Forms.MessageBox.Show("File "+ sFilename +" does not exist or is read only", Settings.sApplicationName);
		}

		private void miOpen_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.OpenFileDialog dlgOpen = new System.Windows.Forms.OpenFileDialog();
			dlgOpen.Multiselect = false;
			dlgOpen.InitialDirectory = System.Windows.Forms.Application.StartupPath;
			if(dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				string sFilename = dlgOpen.FileName;
				OpenDiaryFile(sFilename);
			}
		}

		private void miNew_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.OpenFileDialog dlgOpen = new System.Windows.Forms.OpenFileDialog();
			dlgOpen.Multiselect = false;
			dlgOpen.CheckFileExists = false;
			dlgOpen.InitialDirectory = System.Windows.Forms.Application.StartupPath;
			if(dlgOpen.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				string sFilename = dlgOpen.FileName;
				FileInfo oInfo = new FileInfo(sFilename);
				StreamWriter oStream = oInfo.CreateText();
				oStream.Write("<passwordmanager><passwords></passwords></passwordmanager>");
				oStream.Close();
				OpenDiaryFile(sFilename);
			}

		}
	}
}