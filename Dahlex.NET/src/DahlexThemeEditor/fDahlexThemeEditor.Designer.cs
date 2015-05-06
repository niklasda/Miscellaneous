namespace DahlexThemeEditor
{
    partial class fDahlexThemeEditor
    {
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
            this.msEditor = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiNew = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.msmiOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.msmiOpenEmbedded = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmiClose = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.msmiSave = new System.Windows.Forms.ToolStripMenuItem();
            this.msmiSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.msmiExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msmiCheckIntegrity = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msmiAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.gbThemeInfo = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lThemesFolder = new System.Windows.Forms.Label();
            this.tbThemeName = new System.Windows.Forms.TextBox();
            this.tbThemeAuthor = new System.Windows.Forms.TextBox();
            this.numBoardWidth = new System.Windows.Forms.NumericUpDown();
            this.numBoardHeight = new System.Windows.Forms.NumericUpDown();
            this.tbThemeVersion = new System.Windows.Forms.TextBox();
            this.tcThemeEditor = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.bExploreThemeFolder = new System.Windows.Forms.Button();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.bRefreshThemeImages = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lvRobotImages = new System.Windows.Forms.ListView();
            this.ilRobots = new System.Windows.Forms.ImageList(this.components);
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lvHeapImages = new System.Windows.Forms.ListView();
            this.ilHeaps = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvProfessorImages = new System.Windows.Forms.ListView();
            this.ilProfessors = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbLevels = new System.Windows.Forms.ListBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.bDesignLevel = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numImageWidth = new System.Windows.Forms.NumericUpDown();
            this.numImageHeight = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bPickLineColor = new System.Windows.Forms.Button();
            this.bPickBackgroundColor = new System.Windows.Forms.Button();
            this.numLineWidth = new System.Windows.Forms.NumericUpDown();
            this.pbPreviewLineColor = new System.Windows.Forms.PictureBox();
            this.pbPreviewBgColor = new System.Windows.Forms.PictureBox();
            this.ssEditor = new System.Windows.Forms.StatusStrip();
            this.cdBoardColors = new System.Windows.Forms.ColorDialog();
            this.msEditor.SuspendLayout();
            this.gbThemeInfo.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardHeight)).BeginInit();
            this.tcThemeEditor.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImageHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewLineColor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBgColor)).BeginInit();
            this.SuspendLayout();
            // 
            // msEditor
            // 
            this.msEditor.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.msEditor.Location = new System.Drawing.Point(0, 0);
            this.msEditor.Name = "msEditor";
            this.msEditor.Size = new System.Drawing.Size(720, 24);
            this.msEditor.TabIndex = 0;
            this.msEditor.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiNew,
            this.toolStripMenuItem3,
            this.msmiOpen,
            this.msmiOpenEmbedded,
            this.toolStripMenuItem4,
            this.tsmiClose,
            this.toolStripMenuItem2,
            this.msmiSave,
            this.msmiSaveAs,
            this.toolStripMenuItem1,
            this.msmiExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // tsmiNew
            // 
            this.tsmiNew.Name = "tsmiNew";
            this.tsmiNew.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.tsmiNew.Size = new System.Drawing.Size(203, 22);
            this.tsmiNew.Text = "New...";
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(200, 6);
            // 
            // msmiOpen
            // 
            this.msmiOpen.Name = "msmiOpen";
            this.msmiOpen.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.msmiOpen.Size = new System.Drawing.Size(203, 22);
            this.msmiOpen.Text = "Open...";
            this.msmiOpen.Click += new System.EventHandler(this.msmiOpen_Click);
            // 
            // msmiOpenEmbedded
            // 
            this.msmiOpenEmbedded.Name = "msmiOpenEmbedded";
            this.msmiOpenEmbedded.Size = new System.Drawing.Size(203, 22);
            this.msmiOpenEmbedded.Text = "Open embedded...";
            this.msmiOpenEmbedded.Click += new System.EventHandler(this.msmiOpenEmbedded_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(200, 6);
            // 
            // tsmiClose
            // 
            this.tsmiClose.Name = "tsmiClose";
            this.tsmiClose.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.tsmiClose.Size = new System.Drawing.Size(203, 22);
            this.tsmiClose.Text = "Close";
            this.tsmiClose.Click += new System.EventHandler(this.tsmiClose_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(200, 6);
            // 
            // msmiSave
            // 
            this.msmiSave.Name = "msmiSave";
            this.msmiSave.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.msmiSave.Size = new System.Drawing.Size(203, 22);
            this.msmiSave.Text = "Save";
            this.msmiSave.Click += new System.EventHandler(this.msmiSave_Click);
            // 
            // msmiSaveAs
            // 
            this.msmiSaveAs.Name = "msmiSaveAs";
            this.msmiSaveAs.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift)
                        | System.Windows.Forms.Keys.S)));
            this.msmiSaveAs.Size = new System.Drawing.Size(203, 22);
            this.msmiSaveAs.Text = "Save as...";
            this.msmiSaveAs.Click += new System.EventHandler(this.msmiSaveAs_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(200, 6);
            // 
            // msmiExit
            // 
            this.msmiExit.Name = "msmiExit";
            this.msmiExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.msmiExit.Size = new System.Drawing.Size(203, 22);
            this.msmiExit.Text = "Exit";
            this.msmiExit.Click += new System.EventHandler(this.msmiExit_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msmiCheckIntegrity});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // msmiCheckIntegrity
            // 
            this.msmiCheckIntegrity.Name = "msmiCheckIntegrity";
            this.msmiCheckIntegrity.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.msmiCheckIntegrity.Size = new System.Drawing.Size(205, 22);
            this.msmiCheckIntegrity.Text = "Check integrity...";
            this.msmiCheckIntegrity.Click += new System.EventHandler(this.msmiCheckIntegrity_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msmiAbout});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // msmiAbout
            // 
            this.msmiAbout.Name = "msmiAbout";
            this.msmiAbout.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.msmiAbout.Size = new System.Drawing.Size(165, 22);
            this.msmiAbout.Text = "About...";
            this.msmiAbout.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // gbThemeInfo
            // 
            this.gbThemeInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbThemeInfo.Controls.Add(this.tableLayoutPanel1);
            this.gbThemeInfo.Location = new System.Drawing.Point(16, 9);
            this.gbThemeInfo.Name = "gbThemeInfo";
            this.gbThemeInfo.Size = new System.Drawing.Size(520, 328);
            this.gbThemeInfo.TabIndex = 1;
            this.gbThemeInfo.TabStop = false;
            this.gbThemeInfo.Text = "Information";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.65306F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 67.34694F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label9, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.label11, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.label12, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.label10, 0, 7);
            this.tableLayoutPanel1.Controls.Add(this.lThemesFolder, 1, 7);
            this.tableLayoutPanel1.Controls.Add(this.tbThemeName, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tbThemeAuthor, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.numBoardWidth, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.numBoardHeight, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.tbThemeVersion, 1, 2);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 20);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 8;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(507, 302);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Theme name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(41, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "Author:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(3, 50);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(45, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Version:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(3, 75);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(69, 13);
            this.label11.TabIndex = 6;
            this.label11.Text = "Board Width:";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(3, 100);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 13);
            this.label12.TabIndex = 7;
            this.label12.Text = "Board Height:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(3, 175);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(77, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Themes folder:";
            // 
            // lThemesFolder
            // 
            this.lThemesFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lThemesFolder.Location = new System.Drawing.Point(168, 175);
            this.lThemesFolder.Name = "lThemesFolder";
            this.lThemesFolder.Size = new System.Drawing.Size(336, 47);
            this.lThemesFolder.TabIndex = 13;
            this.lThemesFolder.Text = " ";
            // 
            // tbThemeName
            // 
            this.tbThemeName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbThemeName.Location = new System.Drawing.Point(168, 3);
            this.tbThemeName.Name = "tbThemeName";
            this.tbThemeName.ReadOnly = true;
            this.tbThemeName.Size = new System.Drawing.Size(336, 20);
            this.tbThemeName.TabIndex = 14;
            // 
            // tbThemeAuthor
            // 
            this.tbThemeAuthor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbThemeAuthor.Location = new System.Drawing.Point(168, 28);
            this.tbThemeAuthor.Name = "tbThemeAuthor";
            this.tbThemeAuthor.Size = new System.Drawing.Size(336, 20);
            this.tbThemeAuthor.TabIndex = 15;
            // 
            // numBoardWidth
            // 
            this.numBoardWidth.Location = new System.Drawing.Point(168, 78);
            this.numBoardWidth.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numBoardWidth.Name = "numBoardWidth";
            this.numBoardWidth.Size = new System.Drawing.Size(86, 20);
            this.numBoardWidth.TabIndex = 17;
            this.numBoardWidth.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // numBoardHeight
            // 
            this.numBoardHeight.Location = new System.Drawing.Point(168, 103);
            this.numBoardHeight.Minimum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numBoardHeight.Name = "numBoardHeight";
            this.numBoardHeight.Size = new System.Drawing.Size(86, 20);
            this.numBoardHeight.TabIndex = 18;
            this.numBoardHeight.Value = new decimal(new int[] {
            4,
            0,
            0,
            0});
            // 
            // tbThemeVersion
            // 
            this.tbThemeVersion.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tbThemeVersion.Location = new System.Drawing.Point(168, 53);
            this.tbThemeVersion.Name = "tbThemeVersion";
            this.tbThemeVersion.Size = new System.Drawing.Size(336, 20);
            this.tbThemeVersion.TabIndex = 19;
            // 
            // tcThemeEditor
            // 
            this.tcThemeEditor.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tcThemeEditor.Controls.Add(this.tabPage1);
            this.tcThemeEditor.Controls.Add(this.tabPage5);
            this.tcThemeEditor.Controls.Add(this.tabPage2);
            this.tcThemeEditor.Location = new System.Drawing.Point(12, 36);
            this.tcThemeEditor.Name = "tcThemeEditor";
            this.tcThemeEditor.SelectedIndex = 0;
            this.tcThemeEditor.Size = new System.Drawing.Size(696, 375);
            this.tcThemeEditor.TabIndex = 2;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.bExploreThemeFolder);
            this.tabPage1.Controls.Add(this.gbThemeInfo);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(688, 349);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Information";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // bExploreThemeFolder
            // 
            this.bExploreThemeFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.bExploreThemeFolder.Location = new System.Drawing.Point(558, 28);
            this.bExploreThemeFolder.Name = "bExploreThemeFolder";
            this.bExploreThemeFolder.Size = new System.Drawing.Size(75, 23);
            this.bExploreThemeFolder.TabIndex = 2;
            this.bExploreThemeFolder.Text = "E&xplore";
            this.bExploreThemeFolder.UseVisualStyleBackColor = true;
            this.bExploreThemeFolder.Click += new System.EventHandler(this.bExploreThemeFolder_Click);
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.bRefreshThemeImages);
            this.tabPage5.Controls.Add(this.groupBox4);
            this.tabPage5.Controls.Add(this.groupBox3);
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(688, 349);
            this.tabPage5.TabIndex = 2;
            this.tabPage5.Text = "Images";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // bRefreshThemeImages
            // 
            this.bRefreshThemeImages.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.bRefreshThemeImages.Location = new System.Drawing.Point(20, 290);
            this.bRefreshThemeImages.Name = "bRefreshThemeImages";
            this.bRefreshThemeImages.Size = new System.Drawing.Size(75, 23);
            this.bRefreshThemeImages.TabIndex = 3;
            this.bRefreshThemeImages.Text = "&Refresh";
            this.bRefreshThemeImages.UseVisualStyleBackColor = true;
            this.bRefreshThemeImages.Click += new System.EventHandler(this.bRefreshThemeImages_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.lvRobotImages);
            this.groupBox4.Location = new System.Drawing.Point(417, 4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(263, 236);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Robots";
            // 
            // lvRobotImages
            // 
            this.lvRobotImages.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvRobotImages.LargeImageList = this.ilRobots;
            this.lvRobotImages.Location = new System.Drawing.Point(7, 20);
            this.lvRobotImages.MultiSelect = false;
            this.lvRobotImages.Name = "lvRobotImages";
            this.lvRobotImages.Size = new System.Drawing.Size(250, 106);
            this.lvRobotImages.SmallImageList = this.ilRobots;
            this.lvRobotImages.TabIndex = 0;
            this.lvRobotImages.UseCompatibleStateImageBehavior = false;
            // 
            // ilRobots
            // 
            this.ilRobots.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilRobots.ImageSize = new System.Drawing.Size(16, 16);
            this.ilRobots.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lvHeapImages);
            this.groupBox3.Location = new System.Drawing.Point(211, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 236);
            this.groupBox3.TabIndex = 1;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Heaps";
            // 
            // lvHeapImages
            // 
            this.lvHeapImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvHeapImages.LargeImageList = this.ilHeaps;
            this.lvHeapImages.Location = new System.Drawing.Point(7, 20);
            this.lvHeapImages.Name = "lvHeapImages";
            this.lvHeapImages.Size = new System.Drawing.Size(187, 106);
            this.lvHeapImages.TabIndex = 0;
            this.lvHeapImages.UseCompatibleStateImageBehavior = false;
            // 
            // ilHeaps
            // 
            this.ilHeaps.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilHeaps.ImageSize = new System.Drawing.Size(16, 16);
            this.ilHeaps.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lvProfessorImages);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 236);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Professors";
            // 
            // lvProfessorImages
            // 
            this.lvProfessorImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.lvProfessorImages.LargeImageList = this.ilProfessors;
            this.lvProfessorImages.Location = new System.Drawing.Point(7, 20);
            this.lvProfessorImages.Name = "lvProfessorImages";
            this.lvProfessorImages.Size = new System.Drawing.Size(187, 106);
            this.lvProfessorImages.TabIndex = 0;
            this.lvProfessorImages.UseCompatibleStateImageBehavior = false;
            // 
            // ilProfessors
            // 
            this.ilProfessors.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
            this.ilProfessors.ImageSize = new System.Drawing.Size(16, 16);
            this.ilProfessors.TransparentColor = System.Drawing.Color.Transparent;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.groupBox1);
            this.tabPage2.Controls.Add(this.groupBox6);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(688, 349);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Levels";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbLevels);
            this.groupBox1.Controls.Add(this.groupBox7);
            this.groupBox1.Location = new System.Drawing.Point(17, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 273);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Levels";
            // 
            // lbLevels
            // 
            this.lbLevels.FormattingEnabled = true;
            this.lbLevels.Location = new System.Drawing.Point(7, 20);
            this.lbLevels.Name = "lbLevels";
            this.lbLevels.Size = new System.Drawing.Size(163, 147);
            this.lbLevels.TabIndex = 0;
            this.lbLevels.DoubleClick += new System.EventHandler(this.lbLevels_DoubleClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.bDesignLevel);
            this.groupBox7.Location = new System.Drawing.Point(7, 178);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(174, 65);
            this.groupBox7.TabIndex = 6;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Static levels";
            // 
            // bDesignLevel
            // 
            this.bDesignLevel.Enabled = false;
            this.bDesignLevel.Location = new System.Drawing.Point(6, 19);
            this.bDesignLevel.Name = "bDesignLevel";
            this.bDesignLevel.Size = new System.Drawing.Size(116, 23);
            this.bDesignLevel.TabIndex = 0;
            this.bDesignLevel.Text = "&Design...";
            this.bDesignLevel.UseVisualStyleBackColor = true;
            this.bDesignLevel.Click += new System.EventHandler(this.bDesignLevel_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tableLayoutPanel2);
            this.groupBox6.Location = new System.Drawing.Point(327, 13);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(218, 273);
            this.groupBox6.TabIndex = 5;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Level board properties";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 55F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 45F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.label2, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.numImageWidth, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.numImageHeight, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.label3, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.label4, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.label5, 0, 5);
            this.tableLayoutPanel2.Controls.Add(this.bPickLineColor, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.bPickBackgroundColor, 1, 5);
            this.tableLayoutPanel2.Controls.Add(this.numLineWidth, 1, 2);
            this.tableLayoutPanel2.Controls.Add(this.pbPreviewLineColor, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.pbPreviewBgColor, 1, 6);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 20);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 9;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 21F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(200, 198);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Piece Width";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 26);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Piece Height";
            // 
            // numImageWidth
            // 
            this.numImageWidth.Enabled = false;
            this.numImageWidth.Location = new System.Drawing.Point(113, 3);
            this.numImageWidth.Name = "numImageWidth";
            this.numImageWidth.Size = new System.Drawing.Size(84, 20);
            this.numImageWidth.TabIndex = 2;
            // 
            // numImageHeight
            // 
            this.numImageHeight.Enabled = false;
            this.numImageHeight.Location = new System.Drawing.Point(113, 29);
            this.numImageHeight.Name = "numImageHeight";
            this.numImageHeight.Size = new System.Drawing.Size(84, 20);
            this.numImageHeight.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 52);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Line width";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 78);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Line color";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(3, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Background color";
            // 
            // bPickLineColor
            // 
            this.bPickLineColor.Enabled = false;
            this.bPickLineColor.Location = new System.Drawing.Point(113, 81);
            this.bPickLineColor.Name = "bPickLineColor";
            this.bPickLineColor.Size = new System.Drawing.Size(75, 23);
            this.bPickLineColor.TabIndex = 7;
            this.bPickLineColor.Text = "&Pick...";
            this.bPickLineColor.UseVisualStyleBackColor = true;
            this.bPickLineColor.Click += new System.EventHandler(this.bPickLineColor_Click);
            // 
            // bPickBackgroundColor
            // 
            this.bPickBackgroundColor.Enabled = false;
            this.bPickBackgroundColor.Location = new System.Drawing.Point(113, 129);
            this.bPickBackgroundColor.Name = "bPickBackgroundColor";
            this.bPickBackgroundColor.Size = new System.Drawing.Size(75, 23);
            this.bPickBackgroundColor.TabIndex = 8;
            this.bPickBackgroundColor.Text = "P&ick...";
            this.bPickBackgroundColor.UseVisualStyleBackColor = true;
            this.bPickBackgroundColor.Click += new System.EventHandler(this.bPickBackgroundColor_Click);
            // 
            // numLineWidth
            // 
            this.numLineWidth.Enabled = false;
            this.numLineWidth.Location = new System.Drawing.Point(113, 55);
            this.numLineWidth.Name = "numLineWidth";
            this.numLineWidth.Size = new System.Drawing.Size(84, 20);
            this.numLineWidth.TabIndex = 9;
            // 
            // pbPreviewLineColor
            // 
            this.pbPreviewLineColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreviewLineColor.Location = new System.Drawing.Point(113, 110);
            this.pbPreviewLineColor.Name = "pbPreviewLineColor";
            this.pbPreviewLineColor.Size = new System.Drawing.Size(84, 13);
            this.pbPreviewLineColor.TabIndex = 13;
            this.pbPreviewLineColor.TabStop = false;
            // 
            // pbPreviewBgColor
            // 
            this.pbPreviewBgColor.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pbPreviewBgColor.Location = new System.Drawing.Point(113, 158);
            this.pbPreviewBgColor.Name = "pbPreviewBgColor";
            this.pbPreviewBgColor.Size = new System.Drawing.Size(84, 15);
            this.pbPreviewBgColor.TabIndex = 14;
            this.pbPreviewBgColor.TabStop = false;
            // 
            // ssEditor
            // 
            this.ssEditor.Location = new System.Drawing.Point(0, 414);
            this.ssEditor.Name = "ssEditor";
            this.ssEditor.Size = new System.Drawing.Size(720, 22);
            this.ssEditor.TabIndex = 3;
            this.ssEditor.Text = "statusStrip1";
            // 
            // fDahlexThemeEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 436);
            this.Controls.Add(this.ssEditor);
            this.Controls.Add(this.tcThemeEditor);
            this.Controls.Add(this.msEditor);
            this.MainMenuStrip = this.msEditor;
            this.Name = "fDahlexThemeEditor";
            this.Text = "Dahlex.NET Editor";
            this.msEditor.ResumeLayout(false);
            this.msEditor.PerformLayout();
            this.gbThemeInfo.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numBoardHeight)).EndInit();
            this.tcThemeEditor.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numImageWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numImageHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewLineColor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbPreviewBgColor)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msEditor;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msmiOpen;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem msmiSave;
        private System.Windows.Forms.ToolStripMenuItem msmiSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem msmiExit;
        private System.Windows.Forms.GroupBox gbThemeInfo;
        private System.Windows.Forms.TabControl tcThemeEditor;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msmiCheckIntegrity;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msmiAbout;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.StatusStrip ssEditor;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListView lvRobotImages;
        private System.Windows.Forms.ImageList ilRobots;
        private System.Windows.Forms.ImageList ilHeaps;
        private System.Windows.Forms.ImageList ilProfessors;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView lvHeapImages;
        private System.Windows.Forms.ListView lvProfessorImages;
        private System.Windows.Forms.ColorDialog cdBoardColors;
        private System.Windows.Forms.ToolStripMenuItem tsmiNew;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem tsmiClose;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lThemesFolder;
        private System.Windows.Forms.TextBox tbThemeName;
        private System.Windows.Forms.TextBox tbThemeAuthor;
        private System.Windows.Forms.NumericUpDown numBoardWidth;
        private System.Windows.Forms.NumericUpDown numBoardHeight;
        private System.Windows.Forms.TextBox tbThemeVersion;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListBox lbLevels;
        private System.Windows.Forms.GroupBox groupBox7;
        private System.Windows.Forms.Button bDesignLevel;
        private System.Windows.Forms.GroupBox groupBox6;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown numImageWidth;
        private System.Windows.Forms.NumericUpDown numImageHeight;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button bPickLineColor;
        private System.Windows.Forms.Button bPickBackgroundColor;
        private System.Windows.Forms.NumericUpDown numLineWidth;
        private System.Windows.Forms.PictureBox pbPreviewLineColor;
        private System.Windows.Forms.PictureBox pbPreviewBgColor;
        private System.Windows.Forms.ToolStripMenuItem msmiOpenEmbedded;
        private System.Windows.Forms.Button bRefreshThemeImages;
        private System.Windows.Forms.Button bExploreThemeFolder;
    }
}

