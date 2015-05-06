using System;
using System.Collections;
using System.IO;
using System.Security.Principal;
//using System.Windows.Forms;

namespace DiaryMaster
{
	/// <summary>
	/// Specified recurrance for an entry
	/// </summary>
	public enum Recurrance {
		/// <summary>
		/// Never
		/// </summary>
		None=0, 
		/// <summary>
		/// Once every day
		/// </summary>
		Daily=1, 
		/// <summary>
		/// Once every week
		/// </summary>
		Weekly=7, 
		/// <summary>
		/// Once every month
		/// </summary>
		Monthly=30, 
		/// <summary>
		/// Once every three months
		/// </summary>
		Quarterly=90, 
		/// <summary>
		/// Once every four months
		/// </summary>
		Tertiarly=120, 
		/// <summary>
		/// Once a year
		/// </summary>
		Yearly=360
	}
	
	/// <summary>
	/// Summary description for PasswordManager.
	/// </summary>
	public class FormDiaryMaster : System.Windows.Forms.Form
	{
		#region gui
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.StatusBar statusBar;
		private System.Windows.Forms.StatusBarPanel sbpCount;
		private System.Windows.Forms.StatusBarPanel sbpCrypto;
		private System.Windows.Forms.StatusBarPanel sbpFilename;
		private System.Windows.Forms.MonthCalendar diaryCalendar;
		private System.Windows.Forms.RichTextBox rtEntry;
		private System.Windows.Forms.TabPage tpAllEntries;
		private System.Windows.Forms.TabPage tpSelectedDate;
		private System.Windows.Forms.TabPage tpSummary;
		private System.Windows.Forms.TabPage tpDatelessNotes;
		private System.Windows.Forms.RichTextBox rtDatelessNotes;
		private System.Windows.Forms.TabControl tcEntryInfo;
		private System.Windows.Forms.ColumnHeader chDate;
		private System.Windows.Forms.Button btnSaveEntry;
		private System.Windows.Forms.ComboBox cbDayEntries;
		private System.Windows.Forms.Button btnAddDayEntry;
		private System.Windows.Forms.Button btnDeleteEntry;
		private System.Windows.Forms.ColumnHeader chCount;
		private System.Windows.Forms.ListView lvDiaryDays;
		private System.Windows.Forms.Button btnEditDiaryDay;
		private System.Windows.Forms.Button btnDeleteDiaryDay;
		private System.Windows.Forms.RichTextBox rtSummary;
		private System.Windows.Forms.Button btnShowDiaryDay;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Panel pAttributes;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.CheckBox checkBox2;
		private System.Windows.Forms.CheckBox checkBox3;
		private System.Windows.Forms.CheckBox checkBox4;
		private System.Windows.Forms.CheckBox checkBox5;
		private System.Windows.Forms.CheckBox checkBox6;
		private System.Windows.Forms.CheckBox checkBox7;
		private System.Windows.Forms.Label lblCategories;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label lblNumberOfCharacters;
		#endregion

		/// <summary>
		/// standard empty constructor
		/// </summary>
		public FormDiaryMaster(string sFilename)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			sSettingsFileName = sFilename;

			m_sortMgr = new ListViewSortManager(lvDiaryDays, 
				new Type[] {
							   typeof(ListViewDateSort),
							   typeof(ListViewInt32Sort)
						   });

			m_sortMgr.Sort(0);
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
			this.statusBar = new System.Windows.Forms.StatusBar();
			this.sbpCount = new System.Windows.Forms.StatusBarPanel();
			this.sbpCrypto = new System.Windows.Forms.StatusBarPanel();
			this.sbpFilename = new System.Windows.Forms.StatusBarPanel();
			this.lvDiaryDays = new System.Windows.Forms.ListView();
			this.chDate = new System.Windows.Forms.ColumnHeader();
			this.chCount = new System.Windows.Forms.ColumnHeader();
			this.diaryCalendar = new System.Windows.Forms.MonthCalendar();
			this.rtEntry = new System.Windows.Forms.RichTextBox();
			this.btnSaveEntry = new System.Windows.Forms.Button();
			this.tcEntryInfo = new System.Windows.Forms.TabControl();
			this.tpAllEntries = new System.Windows.Forms.TabPage();
			this.btnEditDiaryDay = new System.Windows.Forms.Button();
			this.btnDeleteDiaryDay = new System.Windows.Forms.Button();
			this.btnShowDiaryDay = new System.Windows.Forms.Button();
			this.tpSelectedDate = new System.Windows.Forms.TabPage();
			this.lblCategories = new System.Windows.Forms.Label();
			this.pAttributes = new System.Windows.Forms.Panel();
			this.checkBox7 = new System.Windows.Forms.CheckBox();
			this.checkBox6 = new System.Windows.Forms.CheckBox();
			this.checkBox5 = new System.Windows.Forms.CheckBox();
			this.checkBox4 = new System.Windows.Forms.CheckBox();
			this.checkBox3 = new System.Windows.Forms.CheckBox();
			this.checkBox2 = new System.Windows.Forms.CheckBox();
			this.checkBox1 = new System.Windows.Forms.CheckBox();
			this.btnDeleteEntry = new System.Windows.Forms.Button();
			this.btnAddDayEntry = new System.Windows.Forms.Button();
			this.cbDayEntries = new System.Windows.Forms.ComboBox();
			this.tpSummary = new System.Windows.Forms.TabPage();
			this.rtSummary = new System.Windows.Forms.RichTextBox();
			this.tpDatelessNotes = new System.Windows.Forms.TabPage();
			this.btnSave = new System.Windows.Forms.Button();
			this.lblNumberOfCharacters = new System.Windows.Forms.Label();
			this.rtDatelessNotes = new System.Windows.Forms.RichTextBox();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.sbpCount)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpCrypto)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpFilename)).BeginInit();
			this.tcEntryInfo.SuspendLayout();
			this.tpAllEntries.SuspendLayout();
			this.tpSelectedDate.SuspendLayout();
			this.pAttributes.SuspendLayout();
			this.tpSummary.SuspendLayout();
			this.tpDatelessNotes.SuspendLayout();
			this.SuspendLayout();
			// 
			// statusBar
			// 
			this.statusBar.Location = new System.Drawing.Point(0, 315);
			this.statusBar.Name = "statusBar";
			this.statusBar.Panels.AddRange(new System.Windows.Forms.StatusBarPanel[] {
																						 this.sbpCount,
																						 this.sbpCrypto,
																						 this.sbpFilename});
			this.statusBar.ShowPanels = true;
			this.statusBar.Size = new System.Drawing.Size(664, 22);
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
			this.sbpFilename.Width = 448;
			// 
			// lvDiaryDays
			// 
			this.lvDiaryDays.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lvDiaryDays.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						  this.chDate,
																						  this.chCount});
			this.lvDiaryDays.FullRowSelect = true;
			this.lvDiaryDays.GridLines = true;
			this.lvDiaryDays.Location = new System.Drawing.Point(16, 16);
			this.lvDiaryDays.Name = "lvDiaryDays";
			this.lvDiaryDays.Size = new System.Drawing.Size(392, 224);
			this.lvDiaryDays.TabIndex = 6;
			this.lvDiaryDays.View = System.Windows.Forms.View.Details;
			this.lvDiaryDays.DoubleClick += new System.EventHandler(this.lvEntryList_DoubleClick);
			// 
			// chDate
			// 
			this.chDate.Text = "date";
			this.chDate.Width = 100;
			// 
			// chCount
			// 
			this.chCount.Text = "count";
			this.chCount.Width = 120;
			// 
			// diaryCalendar
			// 
			this.diaryCalendar.CausesValidation = false;
			this.diaryCalendar.Location = new System.Drawing.Point(8, 16);
			this.diaryCalendar.MaxDate = new System.DateTime(3001, 12, 31, 0, 0, 0, 0);
			this.diaryCalendar.MaxSelectionCount = 1;
			this.diaryCalendar.Name = "diaryCalendar";
			this.diaryCalendar.ShowWeekNumbers = true;
			this.diaryCalendar.TabIndex = 8;
			this.diaryCalendar.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.diaryCalendar_DateChanged);
			// 
			// rtEntry
			// 
			this.rtEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.rtEntry.HideSelection = false;
			this.rtEntry.Location = new System.Drawing.Point(16, 48);
			this.rtEntry.Name = "rtEntry";
			this.rtEntry.Size = new System.Drawing.Size(232, 208);
			this.rtEntry.TabIndex = 9;
			this.rtEntry.Text = "";
			// 
			// btnSaveEntry
			// 
			this.btnSaveEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSaveEntry.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSaveEntry.Location = new System.Drawing.Point(296, 240);
			this.btnSaveEntry.Name = "btnSaveEntry";
			this.btnSaveEntry.Size = new System.Drawing.Size(56, 23);
			this.btnSaveEntry.TabIndex = 10;
			this.btnSaveEntry.Text = "&Save";
			this.btnSaveEntry.Click += new System.EventHandler(this.btnSaveEntry_Click);
			// 
			// tcEntryInfo
			// 
			this.tcEntryInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.tcEntryInfo.Controls.Add(this.tpAllEntries);
			this.tcEntryInfo.Controls.Add(this.tpSelectedDate);
			this.tcEntryInfo.Controls.Add(this.tpSummary);
			this.tcEntryInfo.Controls.Add(this.tpDatelessNotes);
			this.tcEntryInfo.Location = new System.Drawing.Point(216, 8);
			this.tcEntryInfo.Name = "tcEntryInfo";
			this.tcEntryInfo.SelectedIndex = 0;
			this.tcEntryInfo.Size = new System.Drawing.Size(432, 304);
			this.tcEntryInfo.TabIndex = 14;
			this.tcEntryInfo.SelectedIndexChanged += new System.EventHandler(this.tcEntryInfo_SelectedIndexChanged);
			// 
			// tpAllEntries
			// 
			this.tpAllEntries.Controls.Add(this.btnEditDiaryDay);
			this.tpAllEntries.Controls.Add(this.lvDiaryDays);
			this.tpAllEntries.Controls.Add(this.btnDeleteDiaryDay);
			this.tpAllEntries.Controls.Add(this.btnShowDiaryDay);
			this.tpAllEntries.Location = new System.Drawing.Point(4, 22);
			this.tpAllEntries.Name = "tpAllEntries";
			this.tpAllEntries.Size = new System.Drawing.Size(424, 278);
			this.tpAllEntries.TabIndex = 0;
			this.tpAllEntries.Text = "All dates";
			// 
			// btnEditDiaryDay
			// 
			this.btnEditDiaryDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEditDiaryDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnEditDiaryDay.Location = new System.Drawing.Point(360, 248);
			this.btnEditDiaryDay.Name = "btnEditDiaryDay";
			this.btnEditDiaryDay.Size = new System.Drawing.Size(48, 23);
			this.btnEditDiaryDay.TabIndex = 7;
			this.btnEditDiaryDay.Text = "&Edit";
			this.btnEditDiaryDay.Click += new System.EventHandler(this.btnEditDiaryDay_Click);
			// 
			// btnDeleteDiaryDay
			// 
			this.btnDeleteDiaryDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteDiaryDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDeleteDiaryDay.Location = new System.Drawing.Point(296, 248);
			this.btnDeleteDiaryDay.Name = "btnDeleteDiaryDay";
			this.btnDeleteDiaryDay.Size = new System.Drawing.Size(56, 23);
			this.btnDeleteDiaryDay.TabIndex = 7;
			this.btnDeleteDiaryDay.Text = "&Delete";
			this.btnDeleteDiaryDay.Click += new System.EventHandler(this.btnDeleteDiaryDay_Click);
			// 
			// btnShowDiaryDay
			// 
			this.btnShowDiaryDay.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnShowDiaryDay.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnShowDiaryDay.Location = new System.Drawing.Point(224, 248);
			this.btnShowDiaryDay.Name = "btnShowDiaryDay";
			this.btnShowDiaryDay.Size = new System.Drawing.Size(64, 23);
			this.btnShowDiaryDay.TabIndex = 7;
			this.btnShowDiaryDay.Text = "&Show";
			this.btnShowDiaryDay.Click += new System.EventHandler(this.btnShowDiaryDay_Click);
			// 
			// tpSelectedDate
			// 
			this.tpSelectedDate.Controls.Add(this.lblCategories);
			this.tpSelectedDate.Controls.Add(this.pAttributes);
			this.tpSelectedDate.Controls.Add(this.btnDeleteEntry);
			this.tpSelectedDate.Controls.Add(this.btnAddDayEntry);
			this.tpSelectedDate.Controls.Add(this.cbDayEntries);
			this.tpSelectedDate.Controls.Add(this.rtEntry);
			this.tpSelectedDate.Controls.Add(this.btnSaveEntry);
			this.tpSelectedDate.Location = new System.Drawing.Point(4, 22);
			this.tpSelectedDate.Name = "tpSelectedDate";
			this.tpSelectedDate.Size = new System.Drawing.Size(424, 278);
			this.tpSelectedDate.TabIndex = 1;
			this.tpSelectedDate.Text = "Selected date";
			// 
			// lblCategories
			// 
			this.lblCategories.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.lblCategories.Location = new System.Drawing.Point(280, 24);
			this.lblCategories.Name = "lblCategories";
			this.lblCategories.TabIndex = 20;
			this.lblCategories.Text = "Categories:";
			// 
			// pAttributes
			// 
			this.pAttributes.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pAttributes.AutoScroll = true;
			this.pAttributes.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pAttributes.Controls.Add(this.checkBox7);
			this.pAttributes.Controls.Add(this.checkBox6);
			this.pAttributes.Controls.Add(this.checkBox5);
			this.pAttributes.Controls.Add(this.checkBox4);
			this.pAttributes.Controls.Add(this.checkBox3);
			this.pAttributes.Controls.Add(this.checkBox2);
			this.pAttributes.Controls.Add(this.checkBox1);
			this.pAttributes.Location = new System.Drawing.Point(264, 48);
			this.pAttributes.Name = "pAttributes";
			this.pAttributes.Size = new System.Drawing.Size(144, 168);
			this.pAttributes.TabIndex = 19;
			// 
			// checkBox7
			// 
			this.checkBox7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox7.Location = new System.Drawing.Point(16, 152);
			this.checkBox7.Name = "checkBox7";
			this.checkBox7.TabIndex = 6;
			this.checkBox7.Text = "checkBox7";
			// 
			// checkBox6
			// 
			this.checkBox6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox6.Location = new System.Drawing.Point(16, 128);
			this.checkBox6.Name = "checkBox6";
			this.checkBox6.TabIndex = 5;
			this.checkBox6.Text = "checkBox6";
			// 
			// checkBox5
			// 
			this.checkBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox5.Location = new System.Drawing.Point(16, 104);
			this.checkBox5.Name = "checkBox5";
			this.checkBox5.TabIndex = 4;
			this.checkBox5.Text = "checkBox5";
			// 
			// checkBox4
			// 
			this.checkBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox4.Location = new System.Drawing.Point(16, 80);
			this.checkBox4.Name = "checkBox4";
			this.checkBox4.TabIndex = 3;
			this.checkBox4.Text = "checkBox4";
			// 
			// checkBox3
			// 
			this.checkBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox3.Location = new System.Drawing.Point(16, 56);
			this.checkBox3.Name = "checkBox3";
			this.checkBox3.TabIndex = 2;
			this.checkBox3.Text = "checkBox3";
			// 
			// checkBox2
			// 
			this.checkBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox2.Location = new System.Drawing.Point(16, 32);
			this.checkBox2.Name = "checkBox2";
			this.checkBox2.TabIndex = 1;
			this.checkBox2.Text = "checkBox2";
			// 
			// checkBox1
			// 
			this.checkBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.checkBox1.Location = new System.Drawing.Point(16, 8);
			this.checkBox1.Name = "checkBox1";
			this.checkBox1.TabIndex = 0;
			this.checkBox1.Text = "checkBox1";
			// 
			// btnDeleteEntry
			// 
			this.btnDeleteEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDeleteEntry.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDeleteEntry.Location = new System.Drawing.Point(360, 240);
			this.btnDeleteEntry.Name = "btnDeleteEntry";
			this.btnDeleteEntry.Size = new System.Drawing.Size(56, 23);
			this.btnDeleteEntry.TabIndex = 18;
			this.btnDeleteEntry.Text = "&Delete";
			this.btnDeleteEntry.Click += new System.EventHandler(this.btnDeleteEntry_Click);
			// 
			// btnAddDayEntry
			// 
			this.btnAddDayEntry.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAddDayEntry.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAddDayEntry.Location = new System.Drawing.Point(192, 16);
			this.btnAddDayEntry.Name = "btnAddDayEntry";
			this.btnAddDayEntry.Size = new System.Drawing.Size(56, 23);
			this.btnAddDayEntry.TabIndex = 17;
			this.btnAddDayEntry.Text = "Add &new";
			this.btnAddDayEntry.Click += new System.EventHandler(this.btnAddDayEntry_Click);
			// 
			// cbDayEntries
			// 
			this.cbDayEntries.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.cbDayEntries.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbDayEntries.Location = new System.Drawing.Point(16, 16);
			this.cbDayEntries.Name = "cbDayEntries";
			this.cbDayEntries.Size = new System.Drawing.Size(168, 21);
			this.cbDayEntries.TabIndex = 16;
			this.cbDayEntries.SelectedIndexChanged += new System.EventHandler(this.cbDayEntries_SelectedIndexChanged);
			// 
			// tpSummary
			// 
			this.tpSummary.Controls.Add(this.label1);
			this.tpSummary.Controls.Add(this.comboBox1);
			this.tpSummary.Controls.Add(this.rtSummary);
			this.tpSummary.Location = new System.Drawing.Point(4, 22);
			this.tpSummary.Name = "tpSummary";
			this.tpSummary.Size = new System.Drawing.Size(424, 278);
			this.tpSummary.TabIndex = 2;
			this.tpSummary.Text = "Summary";
			// 
			// rtSummary
			// 
			this.rtSummary.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.rtSummary.Location = new System.Drawing.Point(16, 40);
			this.rtSummary.Name = "rtSummary";
			this.rtSummary.ReadOnly = true;
			this.rtSummary.Size = new System.Drawing.Size(392, 224);
			this.rtSummary.TabIndex = 0;
			this.rtSummary.Text = "";
			// 
			// tpDatelessNotes
			// 
			this.tpDatelessNotes.Controls.Add(this.btnSave);
			this.tpDatelessNotes.Controls.Add(this.lblNumberOfCharacters);
			this.tpDatelessNotes.Controls.Add(this.rtDatelessNotes);
			this.tpDatelessNotes.Location = new System.Drawing.Point(4, 22);
			this.tpDatelessNotes.Name = "tpDatelessNotes";
			this.tpDatelessNotes.Size = new System.Drawing.Size(424, 278);
			this.tpDatelessNotes.TabIndex = 3;
			this.tpDatelessNotes.Text = "Dateless notes";
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnSave.Location = new System.Drawing.Point(336, 248);
			this.btnSave.Name = "btnSave";
			this.btnSave.TabIndex = 3;
			this.btnSave.Text = "&Save";
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// lblNumberOfCharacters
			// 
			this.lblNumberOfCharacters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblNumberOfCharacters.Location = new System.Drawing.Point(24, 248);
			this.lblNumberOfCharacters.Name = "lblNumberOfCharacters";
			this.lblNumberOfCharacters.Size = new System.Drawing.Size(288, 16);
			this.lblNumberOfCharacters.TabIndex = 2;
			// 
			// rtDatelessNotes
			// 
			this.rtDatelessNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.rtDatelessNotes.Location = new System.Drawing.Point(16, 15);
			this.rtDatelessNotes.Name = "rtDatelessNotes";
			this.rtDatelessNotes.Size = new System.Drawing.Size(392, 225);
			this.rtDatelessNotes.TabIndex = 1;
			this.rtDatelessNotes.Text = "";
			this.rtDatelessNotes.WordWrap = false;
			this.rtDatelessNotes.TextChanged += new System.EventHandler(this.rtDatelessNotes_TextChanged);
			// 
			// comboBox1
			// 
			this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.comboBox1.Location = new System.Drawing.Point(128, 16);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(160, 21);
			this.comboBox1.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label1.Location = new System.Drawing.Point(24, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(96, 23);
			this.label1.TabIndex = 2;
			this.label1.Text = "Filter on category:";
			// 
			// FormDiaryMaster
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(664, 337);
			this.Controls.Add(this.tcEntryInfo);
			this.Controls.Add(this.diaryCalendar);
			this.Controls.Add(this.statusBar);
			this.Name = "FormDiaryMaster";
			this.Text = "appName";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.frmPasswordManager_Closing);
			this.Load += new System.EventHandler(this.frmPasswordManager_Load);
			((System.ComponentModel.ISupportInitialize)(this.sbpCount)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpCrypto)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sbpFilename)).EndInit();
			this.tcEntryInfo.ResumeLayout(false);
			this.tpAllEntries.ResumeLayout(false);
			this.tpSelectedDate.ResumeLayout(false);
			this.pAttributes.ResumeLayout(false);
			this.tpSummary.ResumeLayout(false);
			this.tpDatelessNotes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private string sSettingsFileName = "DiaryMasterSettings.diary";
		private Diary oDiary = null;
		private ListViewSortManager m_sortMgr;

		private int GetMaxId()
		{
			int MaxId=0;
			foreach(DictionaryEntry oDayEntry in oDiary.dicDiaryDays)
			{
				DiaryDay oDay = (DiaryDay)oDayEntry.Value;

				foreach(DictionaryEntry oEntry in oDay.dicEntries)
				{
					DiaryEntry oPassword = (DiaryEntry)oEntry.Value;
					if(oPassword.iEntryId>MaxId)
						MaxId = oPassword.iEntryId;
				}
			}
			return MaxId;
		}

		private void listDiaryDays(DiaryDayDictionary dicDiaryDays)
		{
			diaryCalendar.RemoveAllBoldedDates();
			lvDiaryDays.Items.Clear();
			if(dicDiaryDays!=null)
			{
				foreach(DictionaryEntry oEntry in dicDiaryDays)
				{
					DiaryDay oDiaryDay = (DiaryDay)oEntry.Value;

					System.Windows.Forms.ListViewItem oItem = new System.Windows.Forms.ListViewItem(oDiaryDay.dtEntryDate.ToShortDateString());
					oItem.Tag = oDiaryDay;
					oItem.SubItems.Add(oDiaryDay.dicEntries.Count.ToString());				

					lvDiaryDays.Items.Add(oItem);
					
					diaryCalendar.AddBoldedDate(oDiaryDay.dtEntryDate);
				}
				diaryCalendar.UpdateBoldedDates();
			}
		}

		private void frmPasswordManager_Load(object sender, System.EventArgs e)
		{
			this.Text = getFileNameFromPath(sSettingsFileName);

			oDiary = new Diary(sSettingsFileName);

			rtDatelessNotes.Text = oDiary.sDatelessNote;

			listDiaryDays(oDiary.dicDiaryDays);
			diaryCalendar.SetDate(DateTime.Now);
			updateStatusBar();
		}

		private string getFileNameFromPath(string sFilePath)
		{
			FileInfo oInfo = new FileInfo(sFilePath);
			return oInfo.Name;
		}

		private void updateStatusBar()
		{
			if(oDiary!=null)
			{
				sbpCount.Text = oDiary.DayCount.ToString() +" days";
				sbpCrypto.Text = Encrypter.sCryptoName;
				sbpFilename.Text = getFileNameFromPath(sSettingsFileName);
			}
		}

		private void frmPasswordManager_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			saveDiary();
		}

		/// <summary>
		/// Save the diary open in this form
		/// </summary>
		public void saveDiary()
		{
			oDiary.Save();
		}

//		private void miExit_Click(object sender, System.EventArgs e)
//		{
//			this.Close();
//		}

		private void diaryCalendar_DateChanged(object sender, System.Windows.Forms.DateRangeEventArgs e)
		{
			DateTime dtDate = e.Start;
			DiaryDay oDiaryDay;
			if(oDiary.dicDiaryDays.Contains(dtDate))
			{
				oDiaryDay = oDiary.dicDiaryDays[dtDate];
			}
			else
			{
				oDiaryDay = new DiaryDay(dtDate);
				oDiary.dicDiaryDays.Add(oDiaryDay);

				diaryCalendar.AddBoldedDate(oDiaryDay.dtEntryDate);
				// updateBoldedDates cannot be used here, screws up monthnavigation
			}

			ShowSelectedDay(oDiaryDay);
		}

		private void btnSaveEntry_Click(object sender, System.EventArgs e)
		{
			DiaryDay oDiaryDay = (DiaryDay)tpSelectedDate.Tag;
			if(cbDayEntries.SelectedItem!=null)
			{
				DiaryEntry oDiaryEntry = (DiaryEntry)cbDayEntries.SelectedItem;
				oDiaryEntry.sEntry = rtEntry.Text;
			}
			else
			{
				DiaryEntry oDiaryEntry = new DiaryEntry(3, rtEntry.Text, Recurrance.None);
				oDiaryDay.dicEntries.Add(oDiaryEntry);
			}
			updateStatusBar();
			ShowSelectedDay(oDiaryDay);
		
		}

		private void btnTextFormat_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.FontDialog dlgSelectFont = new System.Windows.Forms.FontDialog();
			dlgSelectFont.FontMustExist = true;
			dlgSelectFont.ShowEffects = true;
			dlgSelectFont.ShowHelp = true;
			

			if(dlgSelectFont.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				rtEntry.SelectionFont = dlgSelectFont.Font;
			}
		}

		private void btnTextColor_Click(object sender, System.EventArgs e)
		{
			System.Windows.Forms.ColorDialog dlgSelectColor = new System.Windows.Forms.ColorDialog();
			dlgSelectColor.ShowHelp = true;
			dlgSelectColor.AllowFullOpen = true;
			dlgSelectColor.FullOpen = true;
			dlgSelectColor.SolidColorOnly = true;

			if(dlgSelectColor.ShowDialog(this) == System.Windows.Forms.DialogResult.OK)
			{
				rtEntry.SelectionColor = dlgSelectColor.Color;
			}
		}

		private void lvEntryList_DoubleClick(object sender, System.EventArgs e)
		{
			if(lvDiaryDays.SelectedItems.Count>0)
			{
				DiaryDay oDiaryDay = (DiaryDay)lvDiaryDays.SelectedItems[0].Tag;
				diaryCalendar.SetDate(oDiaryDay.dtEntryDate);
			}
		}

		private void ShowSelectedDay(DiaryDay oDiaryDay)
		{
			cbDayEntries.Items.Clear();
			if(oDiaryDay.dicEntries.Count>0)
			{
				foreach(DictionaryEntry oEntry in oDiaryDay.dicEntries)
				{
					DiaryEntry oDiaryEntry = (DiaryEntry)oEntry.Value;
					cbDayEntries.Items.Add(oDiaryEntry);
				}

				cbDayEntries.SelectedIndex=0;
			}
			else
			{
				rtEntry.Text = "";
			}

			diaryCalendar.SelectionStart = oDiaryDay.dtEntryDate;
			diaryCalendar.SetDate(oDiaryDay.dtEntryDate);

			tpSelectedDate.Text = oDiaryDay.dtEntryDate.ToLongDateString();
			tpSelectedDate.Tag = oDiaryDay;
			if(tcEntryInfo.SelectedTab.Text != tpSelectedDate.Text)
				tcEntryInfo.SelectedTab = tpSelectedDate;
		}

		private void ShowSelectedEntry(DiaryEntry oEntry)
		{
			rtEntry.Text = oEntry.sEntry;
			SetRecurranceRadio(oEntry. eRecurring);
		}

		private void SetRecurranceRadio(Recurrance eRecurance)
		{
		}

		private void tcEntryInfo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(tcEntryInfo.SelectedTab == tpAllEntries)
			{
				listDiaryDays(oDiary.dicDiaryDays);
			}
			else if(tcEntryInfo.SelectedTab == tpSummary)
			{
				GenerateSummary(oDiary.dicDiaryDays);
			}
		}

		private void GenerateSummary(DiaryDayDictionary dicDiaryDays)
		{
			rtSummary.Text = "";

			ArrayList alKeys = new ArrayList(dicDiaryDays.getKeys());
			alKeys.Sort();

			foreach(string sShortDate in alKeys)
			//foreach(DictionaryEntry oDayEntry in dicDiaryDays)
			{
				DiaryDay oDay = dicDiaryDays[DateTime.Parse(sShortDate)];
				rtSummary.Text += oDay.dtEntryDate.ToString() + Environment.NewLine;

				foreach(DictionaryEntry oEntry in oDay.dicEntries)
				{
					DiaryEntry oDiaryEntry = (DiaryEntry)oEntry.Value;

					rtSummary.Text += oDiaryEntry.sEntry + Environment.NewLine + Environment.NewLine;
				}
			}
		}

		private void btnEditDiaryDay_Click(object sender, System.EventArgs e)
		{
			if(lvDiaryDays.SelectedItems.Count>0)
			{
				DiaryDay oDiaryDay = (DiaryDay)lvDiaryDays.SelectedItems[0].Tag;
				ShowSelectedDay(oDiaryDay);
			}
		}

		private void cbDayEntries_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(cbDayEntries.SelectedItem!=null)
			{
				DiaryEntry oDiaryEntry = (DiaryEntry)cbDayEntries.SelectedItem;
				ShowSelectedEntry(oDiaryEntry);
			}
			else
			{
				SetRecurranceRadio(Recurrance.None);
			}
		}

		private void btnDeleteEntry_Click(object sender, System.EventArgs e)
		{
			if(cbDayEntries.SelectedItem!=null)
			{
				DiaryEntry oDiaryEntry = (DiaryEntry)cbDayEntries.SelectedItem;
				DiaryDay oDiaryDay = (DiaryDay)tpSelectedDate.Tag;

				oDiaryDay.dicEntries.Remove(oDiaryEntry);
				ShowSelectedDay(oDiaryDay);
			}
		}

		private void btnDeleteDiaryDay_Click(object sender, System.EventArgs e)
		{
			foreach(System.Windows.Forms.ListViewItem oItem in lvDiaryDays.SelectedItems)
			{
				DiaryDay oDay = (DiaryDay)oItem.Tag;
				oDiary.dicDiaryDays.Remove(oDay);
			}

			listDiaryDays(oDiary.dicDiaryDays);
		}

		private void btnShowDiaryDay_Click(object sender, System.EventArgs e)
		{
			if(lvDiaryDays.SelectedItems.Count>0)
			{
				DiaryDay oDiaryDay = (DiaryDay)lvDiaryDays.SelectedItems[0].Tag;
				diaryCalendar.SetDate(oDiaryDay.dtEntryDate);
			}
		}

//		private void miDisableEncryption_Click(object sender, System.EventArgs e)
//		{
//			System.Windows.Forms.MenuItem oItem = (System.Windows.Forms.MenuItem)sender;
//			oItem.Checked = !oItem.Checked;
//		}

		private void btnAddDayEntry_Click(object sender, System.EventArgs e)
		{
			DiaryDay oDiaryDay = (DiaryDay)tpSelectedDate.Tag;
			DiaryEntry oDiaryEntry = new DiaryEntry(GetMaxId()+1,"",Recurrance.None);
			oDiaryDay.dicEntries.Add(oDiaryEntry);

			ShowSelectedDay(oDiaryDay);
		}

		private void rtDatelessNotes_TextChanged(object sender, System.EventArgs e)
		{
			lblNumberOfCharacters.Text="Number of characters: "+ rtDatelessNotes.Text.Length +"/10000";
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			oDiary.sDatelessNote = rtDatelessNotes.Text;
		}

		private void rbRecYearly_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}
	}
}