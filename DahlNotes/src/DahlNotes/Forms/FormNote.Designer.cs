namespace DahlNotes.Forms
{
    partial class FormNote
    {
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.ContextMenu cmNoteMenu;
        private System.Windows.Forms.MenuItem cmiOpenDahlNotes;
        private System.Windows.Forms.MenuItem cmiClose;
        private System.Windows.Forms.ImageList ilIcons;
        private System.Windows.Forms.MenuItem menuItem1;
        private System.Windows.Forms.Label lblNow;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.MenuItem cmiAlwaysOnTop;
        private System.Windows.Forms.MenuItem cmiBackColor;
        private System.Windows.Forms.MenuItem cmiTextColor;
        private System.Windows.Forms.ColorDialog cdColor;
        private System.Windows.Forms.MenuItem cmiTextFont;
        private System.Windows.Forms.FontDialog fdFont;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNote));
            this.tbNote = new System.Windows.Forms.TextBox();
            this.cmNoteMenu = new System.Windows.Forms.ContextMenu();
            this.cmiOpenDahlNotes = new System.Windows.Forms.MenuItem();
            this.cmiAddNewNote = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.cmiAlwaysOnTop = new System.Windows.Forms.MenuItem();
            this.cmiTextFont = new System.Windows.Forms.MenuItem();
            this.cmiTextColor = new System.Windows.Forms.MenuItem();
            this.cmiBackColor = new System.Windows.Forms.MenuItem();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.cmiBall = new System.Windows.Forms.MenuItem();
            this.cmiCheck = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.cmiSelectAll = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.cmiClose = new System.Windows.Forms.MenuItem();
            this.ilIcons = new System.Windows.Forms.ImageList(this.components);
            this.lblNow = new System.Windows.Forms.Label();
            this.cdColor = new System.Windows.Forms.ColorDialog();
            this.fdFont = new System.Windows.Forms.FontDialog();
            this.timerStatus = new System.Windows.Forms.Timer(this.components);
            this.lblClose = new System.Windows.Forms.Label();
            this.lblAdd = new System.Windows.Forms.Label();
            this.ttStatus = new System.Windows.Forms.ToolTip(this.components);
            this.SuspendLayout();
            // 
            // tbNote
            // 
            this.tbNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNote.BackColor = System.Drawing.SystemColors.Control;
            this.tbNote.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.tbNote.ContextMenu = this.cmNoteMenu;
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNote.Location = new System.Drawing.Point(2, 2);
            this.tbNote.Margin = new System.Windows.Forms.Padding(5);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.Size = new System.Drawing.Size(181, 140);
            this.tbNote.TabIndex = 1;
            // 
            // cmNoteMenu
            // 
            this.cmNoteMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.cmiOpenDahlNotes,
            this.cmiAddNewNote,
            this.menuItem2,
            this.cmiAlwaysOnTop,
            this.cmiTextFont,
            this.cmiTextColor,
            this.cmiBackColor,
            this.menuItem3,
            this.cmiBall,
            this.cmiCheck,
            this.menuItem4,
            this.cmiSelectAll,
            this.menuItem1,
            this.cmiClose});
            this.cmNoteMenu.Popup += new System.EventHandler(this.cmNoteMenu_Popup);
            // 
            // cmiOpenDahlNotes
            // 
            this.cmiOpenDahlNotes.Index = 0;
            this.cmiOpenDahlNotes.Shortcut = System.Windows.Forms.Shortcut.CtrlO;
            this.cmiOpenDahlNotes.Text = "Open DahlNotes Configuration...";
            this.cmiOpenDahlNotes.Click += new System.EventHandler(this.cmiOpenDahlNotes_Click);
            // 
            // cmiAddNewNote
            // 
            this.cmiAddNewNote.Index = 1;
            this.cmiAddNewNote.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
            this.cmiAddNewNote.Text = "Add New Note...";
            this.cmiAddNewNote.Click += new System.EventHandler(this.cmiAddNewNote_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 2;
            this.menuItem2.Text = "-";
            // 
            // cmiAlwaysOnTop
            // 
            this.cmiAlwaysOnTop.Index = 3;
            this.cmiAlwaysOnTop.Text = "Always On Top";
            this.cmiAlwaysOnTop.Click += new System.EventHandler(this.cmiAlwaysOnTop_Click);
            // 
            // cmiTextFont
            // 
            this.cmiTextFont.Index = 4;
            this.cmiTextFont.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
            this.cmiTextFont.Text = "Select Text Font...";
            this.cmiTextFont.Click += new System.EventHandler(this.cmiTextFont_Click);
            // 
            // cmiTextColor
            // 
            this.cmiTextColor.Index = 5;
            this.cmiTextColor.Shortcut = System.Windows.Forms.Shortcut.CtrlT;
            this.cmiTextColor.Text = "Select Text Color...";
            this.cmiTextColor.Click += new System.EventHandler(this.cmiTextColor_Click);
            // 
            // cmiBackColor
            // 
            this.cmiBackColor.Index = 6;
            this.cmiBackColor.Shortcut = System.Windows.Forms.Shortcut.CtrlB;
            this.cmiBackColor.Text = "Select Back Color...";
            this.cmiBackColor.Click += new System.EventHandler(this.cmiBackColor_Click);
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 7;
            this.menuItem3.Text = "-";
            // 
            // cmiBall
            // 
            this.cmiBall.Index = 8;
            this.cmiBall.Text = "Insert Ball (∙)";
            this.cmiBall.Click += new System.EventHandler(this.cmiBall_Click);
            // 
            // cmiCheck
            // 
            this.cmiCheck.Index = 9;
            this.cmiCheck.Text = "Insert Check (√)";
            this.cmiCheck.Click += new System.EventHandler(this.cmiCheck_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 10;
            this.menuItem4.Text = "-";
            // 
            // cmiSelectAll
            // 
            this.cmiSelectAll.Index = 11;
            this.cmiSelectAll.Shortcut = System.Windows.Forms.Shortcut.CtrlA;
            this.cmiSelectAll.Text = "Select All";
            this.cmiSelectAll.Click += new System.EventHandler(this.cmiSelectAll_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 12;
            this.menuItem1.Text = "-";
            // 
            // cmiClose
            // 
            this.cmiClose.Index = 13;
            this.cmiClose.Shortcut = System.Windows.Forms.Shortcut.AltF4;
            this.cmiClose.Text = "Hide Note";
            this.cmiClose.Click += new System.EventHandler(this.cmiClose_Click);
            // 
            // ilIcons
            // 
            this.ilIcons.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ilIcons.ImageStream")));
            this.ilIcons.TransparentColor = System.Drawing.Color.Transparent;
            this.ilIcons.Images.SetKeyName(0, "");
            this.ilIcons.Images.SetKeyName(1, "");
            // 
            // lblNow
            // 
            this.lblNow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNow.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblNow.Location = new System.Drawing.Point(0, 139);
            this.lblNow.Margin = new System.Windows.Forms.Padding(3);
            this.lblNow.Name = "lblNow";
            this.lblNow.Size = new System.Drawing.Size(156, 21);
            this.lblNow.TabIndex = 0;
            this.lblNow.Text = "2003-12-12";
            this.lblNow.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblNow.DoubleClick += new System.EventHandler(this.lblNow_Click);
            this.lblNow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lblNow_MouseDown);
            this.lblNow.MouseMove += new System.Windows.Forms.MouseEventHandler(this.lblNow_MouseMove);
            this.lblNow.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lblNow_MouseUp);
            // 
            // cdColor
            // 
            this.cdColor.FullOpen = true;
            this.cdColor.SolidColorOnly = true;
            // 
            // fdFont
            // 
            this.fdFont.AllowVerticalFonts = false;
            this.fdFont.Color = System.Drawing.SystemColors.ControlText;
            this.fdFont.FontMustExist = true;
            this.fdFont.ShowEffects = false;
            // 
            // timerStatus
            // 
            this.timerStatus.Enabled = true;
            this.timerStatus.Interval = 750;
            this.timerStatus.Tick += new System.EventHandler(this.timerStatus_Tick);
            // 
            // lblClose
            // 
            this.lblClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblClose.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblClose.Location = new System.Drawing.Point(170, 139);
            this.lblClose.Margin = new System.Windows.Forms.Padding(3);
            this.lblClose.Name = "lblClose";
            this.lblClose.Size = new System.Drawing.Size(14, 21);
            this.lblClose.TabIndex = 2;
            this.lblClose.Text = "X";
            this.lblClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttStatus.SetToolTip(this.lblClose, "Hide Note");
            this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
            this.lblClose.MouseLeave += new System.EventHandler(this.lblClose_MouseLeave);
            this.lblClose.MouseHover += new System.EventHandler(this.lblClose_MouseHover);
            // 
            // lblAdd
            // 
            this.lblAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblAdd.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lblAdd.Location = new System.Drawing.Point(156, 139);
            this.lblAdd.Margin = new System.Windows.Forms.Padding(3);
            this.lblAdd.Name = "lblAdd";
            this.lblAdd.Size = new System.Drawing.Size(14, 21);
            this.lblAdd.TabIndex = 3;
            this.lblAdd.Text = "+";
            this.lblAdd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ttStatus.SetToolTip(this.lblAdd, "Add New Note");
            this.lblAdd.Click += new System.EventHandler(this.lblAdd_Click);
            this.lblAdd.MouseLeave += new System.EventHandler(this.lblAdd_MouseLeave);
            this.lblAdd.MouseHover += new System.EventHandler(this.lblAdd_MouseHover);
            // 
            // FormNote
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(184, 160);
            this.ContextMenu = this.cmNoteMenu;
            this.ControlBox = false;
            this.Controls.Add(this.lblAdd);
            this.Controls.Add(this.lblClose);
            this.Controls.Add(this.lblNow);
            this.Controls.Add(this.tbNote);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(200, 100);
            this.Name = "FormNote";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FormNote_Closing);
            this.Deactivate += new System.EventHandler(this.FormNote_Deactivate);
            this.Load += new System.EventHandler(this.FormNote_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer timerStatus;
        private System.Windows.Forms.Label lblClose;
        private System.Windows.Forms.Label lblAdd;
        private System.Windows.Forms.ToolTip ttStatus;
        private System.Windows.Forms.MenuItem cmiAddNewNote;
        private System.Windows.Forms.MenuItem menuItem3;
        private System.Windows.Forms.MenuItem cmiBall;
        private System.Windows.Forms.MenuItem cmiCheck;
        private System.Windows.Forms.MenuItem menuItem4;
        private System.Windows.Forms.MenuItem cmiSelectAll;
    }
}