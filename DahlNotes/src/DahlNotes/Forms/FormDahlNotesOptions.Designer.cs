namespace DahlNotes.Forms
{
    partial class FormDahlNotesOptions
    {
        private System.Windows.Forms.NotifyIcon niTrayIcon;
        private System.Windows.Forms.ContextMenu cmTrayMenu;
        private System.Windows.Forms.MenuItem cmiConfiguration;
        private System.Windows.Forms.MenuItem cmiExit;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ListView lvNotes;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnShowAll;
        private System.Windows.Forms.MainMenu mmMenu;
        private System.Windows.Forms.MenuItem mmiFile;
        private System.Windows.Forms.MenuItem miReload;
        private System.Windows.Forms.MenuItem miHide;
        private System.Windows.Forms.MenuItem miAbout;
        private System.Windows.Forms.MenuItem miSaveExit;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.Button btnCloseAll;
        private System.Windows.Forms.MenuItem smiNotesSeparator;
        private System.Windows.Forms.MenuItem smiNotes;
        private System.Windows.Forms.MenuItem menuItem5;
        private System.Windows.Forms.Timer timerHide;
        private System.Windows.Forms.MenuItem cmiNotesShowAll;
        private System.Windows.Forms.MenuItem cmiNotesCloseAll;
        private System.Windows.Forms.ColumnHeader chId;
        private System.Windows.Forms.ColumnHeader chOpacity;
        private System.Windows.Forms.ColumnHeader chColorFont;
        private System.Windows.Forms.ColumnHeader chNote;
        private System.Windows.Forms.ColumnHeader chArea;
        private System.Windows.Forms.ColumnHeader chStartOpen;
        private System.Windows.Forms.ColumnHeader chOnTop;
        private System.Windows.Forms.MenuItem menuItem7;
        private System.Windows.Forms.MenuItem mmiNotes;
        private System.Windows.Forms.MenuItem miNoteAdd;
        private System.Windows.Forms.MenuItem miNoteEdit;
        private System.Windows.Forms.MenuItem miNoteDelete;
        private System.Windows.Forms.MenuItem miNoteShow;
        private System.Windows.Forms.MenuItem miNoteShowAll;
        private System.Windows.Forms.MenuItem miNoteCloseAll;
        private System.Windows.Forms.MenuItem mmiHelp;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem cmiNoteBringToFront;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                niTrayIcon.Visible = false;
                niTrayIcon.Dispose();

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDahlNotesOptions));
            this.niTrayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.cmTrayMenu = new System.Windows.Forms.ContextMenu();
            this.cmiConfiguration = new System.Windows.Forms.MenuItem();
            this.smiNotesSeparator = new System.Windows.Forms.MenuItem();
            this.smiNotes = new System.Windows.Forms.MenuItem();
            this.cmiAddNote = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.cmiNotesShowAll = new System.Windows.Forms.MenuItem();
            this.cmiNotesCloseAll = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.cmiNoteBringToFront = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.cmiExit = new System.Windows.Forms.MenuItem();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lvNotes = new System.Windows.Forms.ListView();
            this.chId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOpacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chColorFont = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chNote = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chArea = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chStartOpen = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chOnTop = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chReadOnly = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnShowAll = new System.Windows.Forms.Button();
            this.mmMenu = new System.Windows.Forms.MainMenu(this.components);
            this.mmiFile = new System.Windows.Forms.MenuItem();
            this.miReload = new System.Windows.Forms.MenuItem();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.miOpen = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.miHide = new System.Windows.Forms.MenuItem();
            this.miSaveExit = new System.Windows.Forms.MenuItem();
            this.mmiNotes = new System.Windows.Forms.MenuItem();
            this.miNoteAdd = new System.Windows.Forms.MenuItem();
            this.miNoteEdit = new System.Windows.Forms.MenuItem();
            this.miNoteDelete = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.miNoteShow = new System.Windows.Forms.MenuItem();
            this.miNoteShowAll = new System.Windows.Forms.MenuItem();
            this.miNoteCloseAll = new System.Windows.Forms.MenuItem();
            this.mmiHelp = new System.Windows.Forms.MenuItem();
            this.miAbout = new System.Windows.Forms.MenuItem();
            this.btnCloseAll = new System.Windows.Forms.Button();
            this.timerHide = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // niTrayIcon
            // 
            this.niTrayIcon.ContextMenu = this.cmTrayMenu;
            this.niTrayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("niTrayIcon.Icon")));
            this.niTrayIcon.Text = "AppName";
            this.niTrayIcon.Visible = true;
            this.niTrayIcon.DoubleClick += new System.EventHandler(this.niTrayIcon_DoubleClick);
            // 
            // cmTrayMenu
            // 
            this.cmTrayMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmiConfiguration,
            this.smiNotesSeparator,
            this.smiNotes,
            this.menuItem5,
            this.cmiExit});
            // 
            // cmiConfiguration
            // 
            this.cmiConfiguration.Index = 0;
            this.cmiConfiguration.Text = "&Configuration...";
            this.cmiConfiguration.Click += new System.EventHandler(this.cmiOptions_Click);
            // 
            // smiNotesSeparator
            // 
            this.smiNotesSeparator.Index = 1;
            this.smiNotesSeparator.Text = "-";
            // 
            // smiNotes
            // 
            this.smiNotes.Index = 2;
            this.smiNotes.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmiAddNote,
            this.menuItem2,
            this.cmiNotesShowAll,
            this.cmiNotesCloseAll,
            this.menuItem3,
            this.cmiNoteBringToFront});
            this.smiNotes.Text = "Notes";
            // 
            // cmiAddNote
            // 
            this.cmiAddNote.Index = 0;
            this.cmiAddNote.Text = "Add Note...";
            this.cmiAddNote.Click += new System.EventHandler(this.cmiAddNote_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "-";
            // 
            // cmiNotesShowAll
            // 
            this.cmiNotesShowAll.Index = 2;
            this.cmiNotesShowAll.Text = "Show All";
            this.cmiNotesShowAll.Click += new System.EventHandler(this.cmiNotesShowAll_Click);
            // 
            // cmiNotesCloseAll
            // 
            this.cmiNotesCloseAll.Index = 3;
            this.cmiNotesCloseAll.Text = "Close All";
            this.cmiNotesCloseAll.Click += new System.EventHandler(this.cmiNotesCloseAll_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 4;
            this.menuItem3.Text = "-";
            // 
            // cmiNoteBringToFront
            // 
            this.cmiNoteBringToFront.Index = 5;
            this.cmiNoteBringToFront.Text = "Bring All Open To Front";
            this.cmiNoteBringToFront.Click += new System.EventHandler(this.cmiNoteBringToFront_Click);
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 3;
            this.menuItem5.Text = "-";
            // 
            // cmiExit
            // 
            this.cmiExit.Index = 4;
            this.cmiExit.Text = "Exit";
            this.cmiExit.Click += new System.EventHandler(this.cmiExit_Click);
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdd.Location = new System.Drawing.Point(8, 172);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 30);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "&Add...";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // lvNotes
            // 
            this.lvNotes.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lvNotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chId,
            this.chOpacity,
            this.chColorFont,
            this.chNote,
            this.chArea,
            this.chStartOpen,
            this.chOnTop,
            this.chReadOnly});
            this.lvNotes.FullRowSelect = true;
            this.lvNotes.GridLines = true;
            this.lvNotes.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvNotes.HideSelection = false;
            this.lvNotes.Location = new System.Drawing.Point(8, 8);
            this.lvNotes.MultiSelect = false;
            this.lvNotes.Name = "lvNotes";
            this.lvNotes.Size = new System.Drawing.Size(653, 157);
            this.lvNotes.Sorting = System.Windows.Forms.SortOrder.Ascending;
            this.lvNotes.TabIndex = 0;
            this.lvNotes.UseCompatibleStateImageBehavior = false;
            this.lvNotes.View = System.Windows.Forms.View.Details;
            this.lvNotes.DoubleClick += new System.EventHandler(this.lvNotes_DoubleClick);
            // 
            // chId
            // 
            this.chId.Text = "Id";
            this.chId.Width = 35;
            // 
            // chOpacity
            // 
            this.chOpacity.Text = "Opacity";
            this.chOpacity.Width = 53;
            // 
            // chColorFont
            // 
            this.chColorFont.Text = "Color/Font";
            this.chColorFont.Width = 140;
            // 
            // chNote
            // 
            this.chNote.Text = "Note";
            this.chNote.Width = 130;
            // 
            // chArea
            // 
            this.chArea.Text = "Area";
            this.chArea.Width = 105;
            // 
            // chStartOpen
            // 
            this.chStartOpen.Text = "StartOpen";
            this.chStartOpen.Width = 64;
            // 
            // chOnTop
            // 
            this.chOnTop.Text = "OnTop";
            this.chOnTop.Width = 56;
            // 
            // chReadOnly
            // 
            this.chReadOnly.Text = "Shared";
            this.chReadOnly.Width = 50;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(89, 172);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 30);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "&Edit...";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(170, 172);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(75, 30);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "&Delete";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShow.Location = new System.Drawing.Point(424, 172);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(75, 30);
            this.btnShow.TabIndex = 4;
            this.btnShow.Text = "&Show";
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnShowAll
            // 
            this.btnShowAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnShowAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnShowAll.Location = new System.Drawing.Point(505, 172);
            this.btnShowAll.Name = "btnShowAll";
            this.btnShowAll.Size = new System.Drawing.Size(75, 30);
            this.btnShowAll.TabIndex = 5;
            this.btnShowAll.Text = "Show All";
            this.btnShowAll.Click += new System.EventHandler(this.btnShowAll_Click);
            // 
            // mmMenu
            // 
            this.mmMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mmiFile,
            this.mmiNotes,
            this.mmiHelp});
            // 
            // mmiFile
            // 
            this.mmiFile.Index = 0;
            this.mmiFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miReload,
            this.menuItem6,
            this.miOpen,
            this.menuItem1,
            this.miHide,
            this.miSaveExit});
            this.mmiFile.Text = "&File";
            // 
            // miReload
            // 
            this.miReload.Index = 0;
            this.miReload.Shortcut = System.Windows.Forms.Shortcut.CtrlR;
            this.miReload.Text = "&Reload";
            this.miReload.Click += new System.EventHandler(this.miReload_Click);
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 1;
            this.menuItem6.Text = "-";
            // 
            // miOpen
            // 
            this.miOpen.Index = 2;
            this.miOpen.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.miOpen.Text = "&Open as read only...";
            this.miOpen.Click += new System.EventHandler(this.miOpen_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 3;
            this.menuItem1.Text = "-";
            // 
            // miHide
            // 
            this.miHide.Index = 4;
            this.miHide.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.miHide.Text = "&Hide";
            this.miHide.Click += new System.EventHandler(this.miHide_Click);
            // 
            // miSaveExit
            // 
            this.miSaveExit.Index = 5;
            this.miSaveExit.Text = "&Exit";
            this.miSaveExit.Click += new System.EventHandler(this.miSaveExit_Click);
            // 
            // mmiNotes
            // 
            this.mmiNotes.Index = 1;
            this.mmiNotes.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miNoteAdd,
            this.miNoteEdit,
            this.miNoteDelete,
            this.menuItem7,
            this.miNoteShow,
            this.miNoteShowAll,
            this.miNoteCloseAll});
            this.mmiNotes.Text = "&Notes";
            // 
            // miNoteAdd
            // 
            this.miNoteAdd.Index = 0;
            this.miNoteAdd.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.miNoteAdd.Text = "&Add...";
            this.miNoteAdd.Click += new System.EventHandler(this.miNoteAdd_Click);
            // 
            // miNoteEdit
            // 
            this.miNoteEdit.Index = 1;
            this.miNoteEdit.Shortcut = System.Windows.Forms.Shortcut.CtrlE;
            this.miNoteEdit.Text = "&Edit...";
            this.miNoteEdit.Click += new System.EventHandler(this.miNoteEdit_Click);
            // 
            // miNoteDelete
            // 
            this.miNoteDelete.Index = 2;
            this.miNoteDelete.Shortcut = System.Windows.Forms.Shortcut.CtrlD;
            this.miNoteDelete.Text = "&Delete";
            this.miNoteDelete.Click += new System.EventHandler(this.miNoteDelete_Click);
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 3;
            this.menuItem7.Text = "-";
            // 
            // miNoteShow
            // 
            this.miNoteShow.Index = 4;
            this.miNoteShow.Text = "&Show";
            this.miNoteShow.Click += new System.EventHandler(this.miNoteShow_Click);
            // 
            // miNoteShowAll
            // 
            this.miNoteShowAll.Index = 5;
            this.miNoteShowAll.Text = "Show All";
            this.miNoteShowAll.Click += new System.EventHandler(this.miNoteShowAll_Click);
            // 
            // miNoteCloseAll
            // 
            this.miNoteCloseAll.Index = 6;
            this.miNoteCloseAll.Text = "Close All";
            this.miNoteCloseAll.Click += new System.EventHandler(this.miNoteCloseAll_Click);
            // 
            // mmiHelp
            // 
            this.mmiHelp.Index = 2;
            this.mmiHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.miAbout});
            this.mmiHelp.Text = "&Help";
            // 
            // miAbout
            // 
            this.miAbout.Index = 0;
            this.miAbout.Shortcut = System.Windows.Forms.Shortcut.F1;
            this.miAbout.Text = "&About...";
            this.miAbout.Click += new System.EventHandler(this.miAbout_Click);
            // 
            // btnCloseAll
            // 
            this.btnCloseAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCloseAll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCloseAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCloseAll.Location = new System.Drawing.Point(586, 172);
            this.btnCloseAll.Name = "btnCloseAll";
            this.btnCloseAll.Size = new System.Drawing.Size(75, 30);
            this.btnCloseAll.TabIndex = 6;
            this.btnCloseAll.Text = "Close All";
            this.btnCloseAll.Click += new System.EventHandler(this.btnCloseAll_Click);
            // 
            // timerHide
            // 
            this.timerHide.Tick += new System.EventHandler(this.timerHide_Tick);
            // 
            // FormDahlNotesOptions
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(673, 210);
            this.Controls.Add(this.btnCloseAll);
            this.Controls.Add(this.btnShowAll);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.lvNotes);
            this.Controls.Add(this.btnAdd);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Menu = this.mmMenu;
            this.MinimumSize = new System.Drawing.Size(600, 200);
            this.Name = "FormDahlNotesOptions";
            this.ShowInTaskbar = false;
            this.Text = "AppName config";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormDahlNotesOptions_Closing);
            this.Load += new System.EventHandler(this.FormDahlNotesOptions_Load);
            this.Resize += new System.EventHandler(this.FormDahlNotesOptions_Resize);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.MenuItem cmiAddNote;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem menuItem6;
        private System.Windows.Forms.MenuItem miOpen;
        private System.Windows.Forms.ColumnHeader chReadOnly;
    }
}