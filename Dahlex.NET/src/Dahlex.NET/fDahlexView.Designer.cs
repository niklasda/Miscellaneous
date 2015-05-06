namespace Dahlex
{
    partial class fDahlexView
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
            this.gbBoardContainer = new System.Windows.Forms.GroupBox();
            this.pBoard = new System.Windows.Forms.Panel();
            this.gbControls = new System.Windows.Forms.GroupBox();
            this.lHeight = new System.Windows.Forms.Label();
            this.lWidth = new System.Windows.Forms.Label();
            this.numHeight = new System.Windows.Forms.NumericUpDown();
            this.numWidth = new System.Windows.Forms.NumericUpDown();
            this.bTeleport = new System.Windows.Forms.Button();
            this.bBomb = new System.Windows.Forms.Button();
            this.bHighScores = new System.Windows.Forms.Button();
            this.bSettings = new System.Windows.Forms.Button();
            this.bNextLevel = new System.Windows.Forms.Button();
            this.bAbout = new System.Windows.Forms.Button();
            this.bHelp = new System.Windows.Forms.Button();
            this.nNorthWest = new System.Windows.Forms.Button();
            this.bNorthEast = new System.Windows.Forms.Button();
            this.bSouthEast = new System.Windows.Forms.Button();
            this.bSouthWest = new System.Windows.Forms.Button();
            this.bEast = new System.Windows.Forms.Button();
            this.bSouth = new System.Windows.Forms.Button();
            this.bStand = new System.Windows.Forms.Button();
            this.bWest = new System.Windows.Forms.Button();
            this.bNorth = new System.Windows.Forms.Button();
            this.bStart = new System.Windows.Forms.Button();
            this.tbLog = new System.Windows.Forms.TextBox();
            this.gbLog = new System.Windows.Forms.GroupBox();
            this.gbTime = new System.Windows.Forms.GroupBox();
            this.lElapsedTime = new System.Windows.Forms.Label();
            this.tElapsedTime = new System.Windows.Forms.Timer(this.components);
            this.gbStatus = new System.Windows.Forms.GroupBox();
            this.lMoves = new System.Windows.Forms.Label();
            this.lTeleports = new System.Windows.Forms.Label();
            this.lLevel = new System.Windows.Forms.Label();
            this.lBombs = new System.Windows.Forms.Label();
            this.lRobots = new System.Windows.Forms.Label();
            this.tRandomPlayer = new System.Windows.Forms.Timer(this.components);
            this.gbDemo = new System.Windows.Forms.GroupBox();
            this.bTest = new System.Windows.Forms.Button();
            this.gbBoardContainer.SuspendLayout();
            this.gbControls.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).BeginInit();
            this.gbLog.SuspendLayout();
            this.gbTime.SuspendLayout();
            this.gbStatus.SuspendLayout();
            this.gbDemo.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbBoardContainer
            // 
            this.gbBoardContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbBoardContainer.Controls.Add(this.pBoard);
            this.gbBoardContainer.Location = new System.Drawing.Point(13, 13);
            this.gbBoardContainer.Name = "gbBoardContainer";
            this.gbBoardContainer.Size = new System.Drawing.Size(659, 489);
            this.gbBoardContainer.TabIndex = 0;
            this.gbBoardContainer.TabStop = false;
            this.gbBoardContainer.Text = "Dahlex board";
            // 
            // pBoard
            // 
            this.pBoard.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBoard.Location = new System.Drawing.Point(7, 20);
            this.pBoard.Name = "pBoard";
            this.pBoard.Size = new System.Drawing.Size(646, 356);
            this.pBoard.TabIndex = 0;
            this.pBoard.Resize += new System.EventHandler(this.pBoard_Resize);
            this.pBoard.Paint += new System.Windows.Forms.PaintEventHandler(this.pBoard_Paint);
            // 
            // gbControls
            // 
            this.gbControls.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbControls.Controls.Add(this.lHeight);
            this.gbControls.Controls.Add(this.lWidth);
            this.gbControls.Controls.Add(this.numHeight);
            this.gbControls.Controls.Add(this.numWidth);
            this.gbControls.Controls.Add(this.bTeleport);
            this.gbControls.Controls.Add(this.bBomb);
            this.gbControls.Controls.Add(this.bHighScores);
            this.gbControls.Controls.Add(this.bSettings);
            this.gbControls.Controls.Add(this.bNextLevel);
            this.gbControls.Controls.Add(this.bAbout);
            this.gbControls.Controls.Add(this.bHelp);
            this.gbControls.Controls.Add(this.nNorthWest);
            this.gbControls.Controls.Add(this.bNorthEast);
            this.gbControls.Controls.Add(this.bSouthEast);
            this.gbControls.Controls.Add(this.bSouthWest);
            this.gbControls.Controls.Add(this.bEast);
            this.gbControls.Controls.Add(this.bSouth);
            this.gbControls.Controls.Add(this.bStand);
            this.gbControls.Controls.Add(this.bWest);
            this.gbControls.Controls.Add(this.bNorth);
            this.gbControls.Controls.Add(this.bStart);
            this.gbControls.Location = new System.Drawing.Point(678, 13);
            this.gbControls.Name = "gbControls";
            this.gbControls.Size = new System.Drawing.Size(255, 200);
            this.gbControls.TabIndex = 1;
            this.gbControls.TabStop = false;
            this.gbControls.Text = "Game controls";
            // 
            // lHeight
            // 
            this.lHeight.AutoSize = true;
            this.lHeight.Location = new System.Drawing.Point(82, 24);
            this.lHeight.Name = "lHeight";
            this.lHeight.Size = new System.Drawing.Size(16, 13);
            this.lHeight.TabIndex = 23;
            this.lHeight.Text = "h:";
            // 
            // lWidth
            // 
            this.lWidth.AutoSize = true;
            this.lWidth.Location = new System.Drawing.Point(13, 24);
            this.lWidth.Name = "lWidth";
            this.lWidth.Size = new System.Drawing.Size(18, 13);
            this.lWidth.TabIndex = 22;
            this.lWidth.Text = "w:";
            // 
            // numHeight
            // 
            this.numHeight.Location = new System.Drawing.Point(101, 22);
            this.numHeight.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numHeight.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numHeight.Name = "numHeight";
            this.numHeight.ReadOnly = true;
            this.numHeight.Size = new System.Drawing.Size(44, 20);
            this.numHeight.TabIndex = 7;
            this.numHeight.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // numWidth
            // 
            this.numWidth.Location = new System.Drawing.Point(33, 22);
            this.numWidth.Maximum = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numWidth.Minimum = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.numWidth.Name = "numWidth";
            this.numWidth.ReadOnly = true;
            this.numWidth.Size = new System.Drawing.Size(44, 20);
            this.numWidth.TabIndex = 6;
            this.numWidth.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // bTeleport
            // 
            this.bTeleport.Location = new System.Drawing.Point(61, 162);
            this.bTeleport.Name = "bTeleport";
            this.bTeleport.Size = new System.Drawing.Size(39, 23);
            this.bTeleport.TabIndex = 19;
            this.bTeleport.Text = "&T";
            this.bTeleport.UseVisualStyleBackColor = true;
            this.bTeleport.Click += new System.EventHandler(this.bTeleport_Click);
            // 
            // bBomb
            // 
            this.bBomb.Location = new System.Drawing.Point(18, 163);
            this.bBomb.Name = "bBomb";
            this.bBomb.Size = new System.Drawing.Size(37, 23);
            this.bBomb.TabIndex = 18;
            this.bBomb.Text = "&B";
            this.bBomb.UseVisualStyleBackColor = true;
            this.bBomb.Click += new System.EventHandler(this.bBomb_Click);
            // 
            // bHighScores
            // 
            this.bHighScores.Location = new System.Drawing.Point(166, 163);
            this.bHighScores.Name = "bHighScores";
            this.bHighScores.Size = new System.Drawing.Size(75, 23);
            this.bHighScores.TabIndex = 5;
            this.bHighScores.Text = "H&igh scores";
            this.bHighScores.UseVisualStyleBackColor = true;
            this.bHighScores.Click += new System.EventHandler(this.bHighScores_Click);
            // 
            // bSettings
            // 
            this.bSettings.Location = new System.Drawing.Point(166, 77);
            this.bSettings.Name = "bSettings";
            this.bSettings.Size = new System.Drawing.Size(75, 23);
            this.bSettings.TabIndex = 2;
            this.bSettings.Text = "&Options";
            this.bSettings.UseVisualStyleBackColor = true;
            this.bSettings.Click += new System.EventHandler(this.bSettings_Click);
            // 
            // bNextLevel
            // 
            this.bNextLevel.Location = new System.Drawing.Point(166, 48);
            this.bNextLevel.Name = "bNextLevel";
            this.bNextLevel.Size = new System.Drawing.Size(75, 23);
            this.bNextLevel.TabIndex = 1;
            this.bNextLevel.Text = "&Next level";
            this.bNextLevel.UseVisualStyleBackColor = true;
            this.bNextLevel.Click += new System.EventHandler(this.bNextLevel_Click);
            // 
            // bAbout
            // 
            this.bAbout.Location = new System.Drawing.Point(166, 134);
            this.bAbout.Name = "bAbout";
            this.bAbout.Size = new System.Drawing.Size(75, 23);
            this.bAbout.TabIndex = 4;
            this.bAbout.Text = "&About";
            this.bAbout.UseVisualStyleBackColor = true;
            this.bAbout.Click += new System.EventHandler(this.bAbout_Click);
            // 
            // bHelp
            // 
            this.bHelp.Location = new System.Drawing.Point(166, 105);
            this.bHelp.Name = "bHelp";
            this.bHelp.Size = new System.Drawing.Size(75, 23);
            this.bHelp.TabIndex = 3;
            this.bHelp.Text = "&Help";
            this.bHelp.UseVisualStyleBackColor = true;
            this.bHelp.Click += new System.EventHandler(this.bHelp_Click);
            // 
            // nNorthWest
            // 
            this.nNorthWest.Location = new System.Drawing.Point(18, 76);
            this.nNorthWest.Name = "nNorthWest";
            this.nNorthWest.Size = new System.Drawing.Size(23, 23);
            this.nNorthWest.TabIndex = 8;
            this.nNorthWest.Text = "&7";
            this.nNorthWest.UseVisualStyleBackColor = true;
            this.nNorthWest.Click += new System.EventHandler(this.nNorthWest_Click);
            // 
            // bNorthEast
            // 
            this.bNorthEast.Location = new System.Drawing.Point(77, 76);
            this.bNorthEast.Name = "bNorthEast";
            this.bNorthEast.Size = new System.Drawing.Size(23, 23);
            this.bNorthEast.TabIndex = 10;
            this.bNorthEast.Text = "&9";
            this.bNorthEast.UseVisualStyleBackColor = true;
            this.bNorthEast.Click += new System.EventHandler(this.bNorthEast_Click);
            // 
            // bSouthEast
            // 
            this.bSouthEast.Location = new System.Drawing.Point(77, 134);
            this.bSouthEast.Name = "bSouthEast";
            this.bSouthEast.Size = new System.Drawing.Size(23, 23);
            this.bSouthEast.TabIndex = 17;
            this.bSouthEast.Text = "&3";
            this.bSouthEast.UseVisualStyleBackColor = true;
            this.bSouthEast.Click += new System.EventHandler(this.bSouthEast_Click);
            // 
            // bSouthWest
            // 
            this.bSouthWest.Location = new System.Drawing.Point(18, 134);
            this.bSouthWest.Name = "bSouthWest";
            this.bSouthWest.Size = new System.Drawing.Size(23, 23);
            this.bSouthWest.TabIndex = 15;
            this.bSouthWest.Text = "&1";
            this.bSouthWest.UseVisualStyleBackColor = true;
            this.bSouthWest.Click += new System.EventHandler(this.bSouthWest_Click);
            // 
            // bEast
            // 
            this.bEast.Location = new System.Drawing.Point(77, 105);
            this.bEast.Name = "bEast";
            this.bEast.Size = new System.Drawing.Size(23, 23);
            this.bEast.TabIndex = 13;
            this.bEast.Text = "&6";
            this.bEast.UseVisualStyleBackColor = true;
            this.bEast.Click += new System.EventHandler(this.bEast_Click);
            // 
            // bSouth
            // 
            this.bSouth.Location = new System.Drawing.Point(48, 134);
            this.bSouth.Name = "bSouth";
            this.bSouth.Size = new System.Drawing.Size(23, 23);
            this.bSouth.TabIndex = 16;
            this.bSouth.Text = "&2";
            this.bSouth.UseVisualStyleBackColor = true;
            this.bSouth.Click += new System.EventHandler(this.bSouth_Click);
            // 
            // bStand
            // 
            this.bStand.Location = new System.Drawing.Point(48, 105);
            this.bStand.Name = "bStand";
            this.bStand.Size = new System.Drawing.Size(23, 23);
            this.bStand.TabIndex = 12;
            this.bStand.Text = "&5";
            this.bStand.UseVisualStyleBackColor = true;
            this.bStand.Click += new System.EventHandler(this.bStand_Click);
            // 
            // bWest
            // 
            this.bWest.Location = new System.Drawing.Point(18, 105);
            this.bWest.Name = "bWest";
            this.bWest.Size = new System.Drawing.Size(23, 23);
            this.bWest.TabIndex = 11;
            this.bWest.Text = "&4";
            this.bWest.UseVisualStyleBackColor = true;
            this.bWest.Click += new System.EventHandler(this.bWest_Click);
            // 
            // bNorth
            // 
            this.bNorth.Location = new System.Drawing.Point(48, 76);
            this.bNorth.Name = "bNorth";
            this.bNorth.Size = new System.Drawing.Size(23, 23);
            this.bNorth.TabIndex = 9;
            this.bNorth.Text = "&8";
            this.bNorth.UseVisualStyleBackColor = true;
            this.bNorth.Click += new System.EventHandler(this.bNorth_Click);
            // 
            // bStart
            // 
            this.bStart.Location = new System.Drawing.Point(166, 19);
            this.bStart.Name = "bStart";
            this.bStart.Size = new System.Drawing.Size(75, 23);
            this.bStart.TabIndex = 0;
            this.bStart.Text = "&Start";
            this.bStart.UseVisualStyleBackColor = true;
            this.bStart.Click += new System.EventHandler(this.bStart_Click);
            // 
            // tbLog
            // 
            this.tbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)));
            this.tbLog.Location = new System.Drawing.Point(6, 19);
            this.tbLog.Multiline = true;
            this.tbLog.Name = "tbLog";
            this.tbLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbLog.Size = new System.Drawing.Size(243, 129);
            this.tbLog.TabIndex = 2;
            // 
            // gbLog
            // 
            this.gbLog.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLog.Controls.Add(this.tbLog);
            this.gbLog.Location = new System.Drawing.Point(678, 348);
            this.gbLog.Name = "gbLog";
            this.gbLog.Size = new System.Drawing.Size(255, 154);
            this.gbLog.TabIndex = 3;
            this.gbLog.TabStop = false;
            this.gbLog.Text = "Log";
            // 
            // gbTime
            // 
            this.gbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbTime.Controls.Add(this.lElapsedTime);
            this.gbTime.Location = new System.Drawing.Point(678, 219);
            this.gbTime.Name = "gbTime";
            this.gbTime.Size = new System.Drawing.Size(95, 48);
            this.gbTime.TabIndex = 4;
            this.gbTime.TabStop = false;
            this.gbTime.Text = "Time";
            // 
            // lElapsedTime
            // 
            this.lElapsedTime.AutoSize = true;
            this.lElapsedTime.Location = new System.Drawing.Point(7, 18);
            this.lElapsedTime.Name = "lElapsedTime";
            this.lElapsedTime.Size = new System.Drawing.Size(0, 13);
            this.lElapsedTime.TabIndex = 0;
            // 
            // tElapsedTime
            // 
            this.tElapsedTime.Interval = 1000;
            this.tElapsedTime.Tick += new System.EventHandler(this.tElapsedTime_Tick);
            // 
            // gbStatus
            // 
            this.gbStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbStatus.Controls.Add(this.lMoves);
            this.gbStatus.Controls.Add(this.lTeleports);
            this.gbStatus.Controls.Add(this.lLevel);
            this.gbStatus.Controls.Add(this.lBombs);
            this.gbStatus.Controls.Add(this.lRobots);
            this.gbStatus.Location = new System.Drawing.Point(779, 219);
            this.gbStatus.Name = "gbStatus";
            this.gbStatus.Size = new System.Drawing.Size(154, 112);
            this.gbStatus.TabIndex = 5;
            this.gbStatus.TabStop = false;
            this.gbStatus.Text = "Status";
            // 
            // lMoves
            // 
            this.lMoves.AutoSize = true;
            this.lMoves.Location = new System.Drawing.Point(6, 86);
            this.lMoves.Name = "lMoves";
            this.lMoves.Size = new System.Drawing.Size(51, 13);
            this.lMoves.TabIndex = 4;
            this.lMoves.Text = "Moves: 0";
            // 
            // lTeleports
            // 
            this.lTeleports.AutoSize = true;
            this.lTeleports.Location = new System.Drawing.Point(6, 69);
            this.lTeleports.Name = "lTeleports";
            this.lTeleports.Size = new System.Drawing.Size(63, 13);
            this.lTeleports.TabIndex = 3;
            this.lTeleports.Text = "Teleports: 0";
            // 
            // lLevel
            // 
            this.lLevel.AutoSize = true;
            this.lLevel.Location = new System.Drawing.Point(6, 52);
            this.lLevel.Name = "lLevel";
            this.lLevel.Size = new System.Drawing.Size(45, 13);
            this.lLevel.TabIndex = 2;
            this.lLevel.Text = "Level: 0";
            // 
            // lBombs
            // 
            this.lBombs.AutoSize = true;
            this.lBombs.Location = new System.Drawing.Point(6, 35);
            this.lBombs.Name = "lBombs";
            this.lBombs.Size = new System.Drawing.Size(51, 13);
            this.lBombs.TabIndex = 1;
            this.lBombs.Text = "Bombs: 0";
            // 
            // lRobots
            // 
            this.lRobots.AutoSize = true;
            this.lRobots.Location = new System.Drawing.Point(6, 18);
            this.lRobots.Name = "lRobots";
            this.lRobots.Size = new System.Drawing.Size(52, 13);
            this.lRobots.TabIndex = 0;
            this.lRobots.Text = "Dahlex: 0";
            // 
            // tRandomPlayer
            // 
            this.tRandomPlayer.Interval = 1000;
            this.tRandomPlayer.Tick += new System.EventHandler(this.tRandomPlayer_Tick);
            // 
            // gbDemo
            // 
            this.gbDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbDemo.Controls.Add(this.bTest);
            this.gbDemo.Location = new System.Drawing.Point(679, 274);
            this.gbDemo.Name = "gbDemo";
            this.gbDemo.Size = new System.Drawing.Size(94, 57);
            this.gbDemo.TabIndex = 6;
            this.gbDemo.TabStop = false;
            this.gbDemo.Text = "Random demo";
            // 
            // bTest
            // 
            this.bTest.Location = new System.Drawing.Point(7, 20);
            this.bTest.Name = "bTest";
            this.bTest.Size = new System.Drawing.Size(47, 23);
            this.bTest.TabIndex = 0;
            this.bTest.Text = "Test";
            this.bTest.UseVisualStyleBackColor = true;
            this.bTest.Click += new System.EventHandler(this.bTest_Click);
            // 
            // fDahlexView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(945, 514);
            this.Controls.Add(this.gbDemo);
            this.Controls.Add(this.gbStatus);
            this.Controls.Add(this.gbTime);
            this.Controls.Add(this.gbLog);
            this.Controls.Add(this.gbControls);
            this.Controls.Add(this.gbBoardContainer);
            this.DoubleBuffered = true;
            this.Name = "fDahlexView";
            this.Text = "Dahlex.NET";
            this.Load += new System.EventHandler(this.fDahlex_Load);
            this.gbBoardContainer.ResumeLayout(false);
            this.gbControls.ResumeLayout(false);
            this.gbControls.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numWidth)).EndInit();
            this.gbLog.ResumeLayout(false);
            this.gbLog.PerformLayout();
            this.gbTime.ResumeLayout(false);
            this.gbTime.PerformLayout();
            this.gbStatus.ResumeLayout(false);
            this.gbStatus.PerformLayout();
            this.gbDemo.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbBoardContainer;
        private System.Windows.Forms.Panel pBoard;
        private System.Windows.Forms.GroupBox gbControls;
        private System.Windows.Forms.Button bStart;
        private System.Windows.Forms.TextBox tbLog;
        private System.Windows.Forms.GroupBox gbLog;
        private System.Windows.Forms.Button bSouthWest;
        private System.Windows.Forms.Button bEast;
        private System.Windows.Forms.Button bSouth;
        private System.Windows.Forms.Button bStand;
        private System.Windows.Forms.Button bWest;
        private System.Windows.Forms.Button bNorth;
        private System.Windows.Forms.Button nNorthWest;
        private System.Windows.Forms.Button bNorthEast;
        private System.Windows.Forms.Button bSouthEast;
        private System.Windows.Forms.GroupBox gbTime;
        private System.Windows.Forms.Label lElapsedTime;
        private System.Windows.Forms.Timer tElapsedTime;
        private System.Windows.Forms.Button bAbout;
        private System.Windows.Forms.Button bHelp;
        private System.Windows.Forms.GroupBox gbStatus;
        private System.Windows.Forms.Label lLevel;
        private System.Windows.Forms.Label lBombs;
        private System.Windows.Forms.Label lRobots;
        private System.Windows.Forms.Button bHighScores;
        private System.Windows.Forms.Button bSettings;
        private System.Windows.Forms.Button bNextLevel;
        private System.Windows.Forms.Label lMoves;
        private System.Windows.Forms.Label lTeleports;
        private System.Windows.Forms.Timer tRandomPlayer;
        private System.Windows.Forms.Button bTeleport;
        private System.Windows.Forms.Button bBomb;
        private System.Windows.Forms.GroupBox gbDemo;
        private System.Windows.Forms.Button bTest;
        private System.Windows.Forms.NumericUpDown numHeight;
        private System.Windows.Forms.NumericUpDown numWidth;
        private System.Windows.Forms.Label lHeight;
        private System.Windows.Forms.Label lWidth;
    }
}

