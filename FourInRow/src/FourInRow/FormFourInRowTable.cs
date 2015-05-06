#region Copyright (c) 2003-2004, Niklas Dahlman, dahlman-group.com
/************************************************************************************
'
' Copyright © 2003-2004 Niklas Dahlman
'
' This software is provided 'as-is', without any express or implied warranty. In no 
' event will the authors be held liable for any damages arising from the use of this 
' software.
' 
' Permission is granted to anyone to use this software for any purpose, including 
' commercial applications, and to alter it and redistribute it freely, subject to the 
' following restrictions:
'
' 1. The origin of this software must not be misrepresented; you must not claim that 
' you wrote the original software. If you use this software in a product, an 
' acknowledgment (see the following) in the product documentation is required.
'
' Portions Copyright © 2004 Niklas Dahlman
'
' 2. Altered source versions must be plainly marked as such, and must not be 
' misrepresented as being the original software.
'
' 3. This notice may not be removed or altered from any source distribution.
'
'***********************************************************************************/
#endregion

using System;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace FourInRow
{
	/// <summary>
	/// Summary description for FormFourInRowTable.
	/// </summary>
	public class FormFourInRowTable: System.Windows.Forms.Form
	{
		#region gui

		private System.Windows.Forms.GroupBox gbPlayer1;
		private System.Windows.Forms.GroupBox gbPlayer2;
		private System.Windows.Forms.GroupBox gbCurrentPlayer;
		private System.Windows.Forms.Button btnNewGame;
		private System.Windows.Forms.Label lblCurrentPlayer;
		private System.Windows.Forms.Button btnHighScores;
		private System.Windows.Forms.Button btnAbout;
		private System.Windows.Forms.Button btnExit;
		private System.Windows.Forms.GroupBox gbTime;
		private System.Windows.Forms.TextBox tbPlayer2Name;
		private System.Windows.Forms.TextBox tbPlayer1Name;
		private System.Windows.Forms.Label lblStart;
		private System.Windows.Forms.Label lblEnd;
		private System.Windows.Forms.Label lblPlayer1Moves;
		private System.Windows.Forms.Label lblPlayer2Moves;
		private System.Windows.Forms.CheckBox cbComputer1;
		private System.Windows.Forms.CheckBox cbComputer2;
		private System.Windows.Forms.Timer tComputerPlayer;
		private System.Windows.Forms.Button btnNewGameBig;
		private System.Windows.Forms.Button btnNewGameSpecial;
		private System.Windows.Forms.PictureBox pbRed;
		private System.Windows.Forms.PictureBox pbYellow;
		private System.Windows.Forms.PictureBox pbEmpty;
		private System.Windows.Forms.Panel pBoard;
		private System.Windows.Forms.GroupBox grpValues;
		private System.Windows.Forms.Label lblInfoOffensive;
		private System.Windows.Forms.Label lblInfoDefensive;
		private System.Windows.Forms.ToolTip toolTipper;
		private System.Windows.Forms.PictureBox pbRedWithBg;
		private System.Windows.Forms.PictureBox pbYellowWithBg;
		private System.Windows.Forms.CheckBox cbComputer1Lvl2;
		private System.Windows.Forms.CheckBox cbComputer2Lvl2;

		private System.ComponentModel.IContainer components;
		#endregion

		/// <summary>
		/// standard empty constructor
		/// </summary>
		public FormFourInRowTable()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(FormFourInRowTable));
			this.gbPlayer1 = new System.Windows.Forms.GroupBox();
			this.tbPlayer1Name = new System.Windows.Forms.TextBox();
			this.lblPlayer1Moves = new System.Windows.Forms.Label();
			this.cbComputer1 = new System.Windows.Forms.CheckBox();
			this.pbRed = new System.Windows.Forms.PictureBox();
			this.gbPlayer2 = new System.Windows.Forms.GroupBox();
			this.tbPlayer2Name = new System.Windows.Forms.TextBox();
			this.lblPlayer2Moves = new System.Windows.Forms.Label();
			this.cbComputer2 = new System.Windows.Forms.CheckBox();
			this.pbYellow = new System.Windows.Forms.PictureBox();
			this.gbCurrentPlayer = new System.Windows.Forms.GroupBox();
			this.lblCurrentPlayer = new System.Windows.Forms.Label();
			this.btnNewGame = new System.Windows.Forms.Button();
			this.btnHighScores = new System.Windows.Forms.Button();
			this.btnAbout = new System.Windows.Forms.Button();
			this.btnExit = new System.Windows.Forms.Button();
			this.gbTime = new System.Windows.Forms.GroupBox();
			this.lblEnd = new System.Windows.Forms.Label();
			this.lblStart = new System.Windows.Forms.Label();
			this.pBoard = new System.Windows.Forms.Panel();
			this.pbEmpty = new System.Windows.Forms.PictureBox();
			this.tComputerPlayer = new System.Windows.Forms.Timer(this.components);
			this.btnNewGameBig = new System.Windows.Forms.Button();
			this.btnNewGameSpecial = new System.Windows.Forms.Button();
			this.grpValues = new System.Windows.Forms.GroupBox();
			this.lblInfoDefensive = new System.Windows.Forms.Label();
			this.lblInfoOffensive = new System.Windows.Forms.Label();
			this.toolTipper = new System.Windows.Forms.ToolTip(this.components);
			this.pbRedWithBg = new System.Windows.Forms.PictureBox();
			this.pbYellowWithBg = new System.Windows.Forms.PictureBox();
			this.cbComputer1Lvl2 = new System.Windows.Forms.CheckBox();
			this.cbComputer2Lvl2 = new System.Windows.Forms.CheckBox();
			this.gbPlayer1.SuspendLayout();
			this.gbPlayer2.SuspendLayout();
			this.gbCurrentPlayer.SuspendLayout();
			this.gbTime.SuspendLayout();
			this.grpValues.SuspendLayout();
			this.SuspendLayout();
			// 
			// gbPlayer1
			// 
			this.gbPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gbPlayer1.Controls.Add(this.cbComputer1Lvl2);
			this.gbPlayer1.Controls.Add(this.tbPlayer1Name);
			this.gbPlayer1.Controls.Add(this.lblPlayer1Moves);
			this.gbPlayer1.Controls.Add(this.cbComputer1);
			this.gbPlayer1.Controls.Add(this.pbRed);
			this.gbPlayer1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbPlayer1.Location = new System.Drawing.Point(480, 64);
			this.gbPlayer1.Name = "gbPlayer1";
			this.gbPlayer1.Size = new System.Drawing.Size(128, 184);
			this.gbPlayer1.TabIndex = 2;
			this.gbPlayer1.TabStop = false;
			this.gbPlayer1.Text = "Player 1";
			// 
			// tbPlayer1Name
			// 
			this.tbPlayer1Name.Location = new System.Drawing.Point(16, 24);
			this.tbPlayer1Name.MaxLength = 32;
			this.tbPlayer1Name.Name = "tbPlayer1Name";
			this.tbPlayer1Name.Size = new System.Drawing.Size(96, 20);
			this.tbPlayer1Name.TabIndex = 0;
			this.tbPlayer1Name.Text = "Player 1";
			this.tbPlayer1Name.TextChanged += new System.EventHandler(this.tbPlayer1Name_TextChanged);
			// 
			// lblPlayer1Moves
			// 
			this.lblPlayer1Moves.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblPlayer1Moves.Location = new System.Drawing.Point(24, 56);
			this.lblPlayer1Moves.Name = "lblPlayer1Moves";
			this.lblPlayer1Moves.Size = new System.Drawing.Size(88, 16);
			this.lblPlayer1Moves.TabIndex = 1;
			this.lblPlayer1Moves.Text = "0 moves";
			this.toolTipper.SetToolTip(this.lblPlayer1Moves, "Displays the number of moves made by player 1");
			// 
			// cbComputer1
			// 
			this.cbComputer1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbComputer1.Location = new System.Drawing.Point(16, 72);
			this.cbComputer1.Name = "cbComputer1";
			this.cbComputer1.Size = new System.Drawing.Size(96, 24);
			this.cbComputer1.TabIndex = 3;
			this.cbComputer1.Text = "&Computer";
			this.toolTipper.SetToolTip(this.cbComputer1, "Check to have the computer play as player 1");
			this.cbComputer1.CheckedChanged += new System.EventHandler(this.cbComputer_CheckedChanged);
			// 
			// pbRed
			// 
			this.pbRed.Image = ((System.Drawing.Image)(resources.GetObject("pbRed.Image")));
			this.pbRed.Location = new System.Drawing.Point(32, 128);
			this.pbRed.Name = "pbRed";
			this.pbRed.Size = new System.Drawing.Size(48, 48);
			this.pbRed.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbRed.TabIndex = 0;
			this.pbRed.TabStop = false;
			this.pbRed.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbRed_MouseDown);
			// 
			// gbPlayer2
			// 
			this.gbPlayer2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gbPlayer2.Controls.Add(this.cbComputer2Lvl2);
			this.gbPlayer2.Controls.Add(this.tbPlayer2Name);
			this.gbPlayer2.Controls.Add(this.lblPlayer2Moves);
			this.gbPlayer2.Controls.Add(this.cbComputer2);
			this.gbPlayer2.Controls.Add(this.pbYellow);
			this.gbPlayer2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbPlayer2.Location = new System.Drawing.Point(616, 64);
			this.gbPlayer2.Name = "gbPlayer2";
			this.gbPlayer2.Size = new System.Drawing.Size(128, 184);
			this.gbPlayer2.TabIndex = 3;
			this.gbPlayer2.TabStop = false;
			this.gbPlayer2.Text = "Player 2";
			// 
			// tbPlayer2Name
			// 
			this.tbPlayer2Name.Location = new System.Drawing.Point(16, 24);
			this.tbPlayer2Name.MaxLength = 32;
			this.tbPlayer2Name.Name = "tbPlayer2Name";
			this.tbPlayer2Name.Size = new System.Drawing.Size(96, 20);
			this.tbPlayer2Name.TabIndex = 0;
			this.tbPlayer2Name.Text = "Player 2";
			this.tbPlayer2Name.TextChanged += new System.EventHandler(this.tbPlayer2Name_TextChanged);
			// 
			// lblPlayer2Moves
			// 
			this.lblPlayer2Moves.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblPlayer2Moves.Location = new System.Drawing.Point(24, 56);
			this.lblPlayer2Moves.Name = "lblPlayer2Moves";
			this.lblPlayer2Moves.Size = new System.Drawing.Size(88, 16);
			this.lblPlayer2Moves.TabIndex = 1;
			this.lblPlayer2Moves.Text = "0 moves";
			this.toolTipper.SetToolTip(this.lblPlayer2Moves, "Displays the number of moves made by player 2");
			// 
			// cbComputer2
			// 
			this.cbComputer2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbComputer2.Location = new System.Drawing.Point(16, 72);
			this.cbComputer2.Name = "cbComputer2";
			this.cbComputer2.Size = new System.Drawing.Size(96, 24);
			this.cbComputer2.TabIndex = 3;
			this.cbComputer2.Text = "C&omputer";
			this.toolTipper.SetToolTip(this.cbComputer2, "Check to have the computer play as player 2");
			this.cbComputer2.CheckedChanged += new System.EventHandler(this.cbComputer_CheckedChanged);
			// 
			// pbYellow
			// 
			this.pbYellow.Image = ((System.Drawing.Image)(resources.GetObject("pbYellow.Image")));
			this.pbYellow.Location = new System.Drawing.Point(40, 128);
			this.pbYellow.Name = "pbYellow";
			this.pbYellow.Size = new System.Drawing.Size(48, 48);
			this.pbYellow.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbYellow.TabIndex = 1;
			this.pbYellow.TabStop = false;
			this.pbYellow.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbYellow_MouseDown);
			// 
			// gbCurrentPlayer
			// 
			this.gbCurrentPlayer.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
			this.gbCurrentPlayer.Controls.Add(this.lblCurrentPlayer);
			this.gbCurrentPlayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbCurrentPlayer.Location = new System.Drawing.Point(480, 16);
			this.gbCurrentPlayer.Name = "gbCurrentPlayer";
			this.gbCurrentPlayer.Size = new System.Drawing.Size(264, 40);
			this.gbCurrentPlayer.TabIndex = 1;
			this.gbCurrentPlayer.TabStop = false;
			// 
			// lblCurrentPlayer
			// 
			this.lblCurrentPlayer.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblCurrentPlayer.Location = new System.Drawing.Point(16, 16);
			this.lblCurrentPlayer.Name = "lblCurrentPlayer";
			this.lblCurrentPlayer.Size = new System.Drawing.Size(240, 16);
			this.lblCurrentPlayer.TabIndex = 0;
			this.lblCurrentPlayer.Text = "who to go";
			this.lblCurrentPlayer.TextAlign = System.Drawing.ContentAlignment.TopCenter;
			this.toolTipper.SetToolTip(this.lblCurrentPlayer, "Displays whos turn it is, or if game has ended");
			// 
			// btnNewGame
			// 
			this.btnNewGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNewGame.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnNewGame.Location = new System.Drawing.Point(480, 366);
			this.btnNewGame.Name = "btnNewGame";
			this.btnNewGame.Size = new System.Drawing.Size(104, 23);
			this.btnNewGame.TabIndex = 5;
			this.btnNewGame.Text = "&New Game [7:6:4]";
			this.toolTipper.SetToolTip(this.btnNewGame, "Start a new 4-in-a-row game using a board with width 7 and height 6");
			this.btnNewGame.Click += new System.EventHandler(this.btnNewGame_Click);
			// 
			// btnHighScores
			// 
			this.btnHighScores.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnHighScores.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnHighScores.Location = new System.Drawing.Point(592, 398);
			this.btnHighScores.Name = "btnHighScores";
			this.btnHighScores.Size = new System.Drawing.Size(104, 23);
			this.btnHighScores.TabIndex = 8;
			this.btnHighScores.Text = "High &Scores";
			this.btnHighScores.Click += new System.EventHandler(this.btnHighScores_Click);
			// 
			// btnAbout
			// 
			this.btnAbout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnAbout.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnAbout.Location = new System.Drawing.Point(704, 366);
			this.btnAbout.Name = "btnAbout";
			this.btnAbout.Size = new System.Drawing.Size(40, 23);
			this.btnAbout.TabIndex = 9;
			this.btnAbout.Text = "&About";
			this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
			// 
			// btnExit
			// 
			this.btnExit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnExit.Location = new System.Drawing.Point(704, 398);
			this.btnExit.Name = "btnExit";
			this.btnExit.Size = new System.Drawing.Size(40, 23);
			this.btnExit.TabIndex = 10;
			this.btnExit.Text = "E&xit";
			this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
			// 
			// gbTime
			// 
			this.gbTime.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.gbTime.Controls.Add(this.lblEnd);
			this.gbTime.Controls.Add(this.lblStart);
			this.gbTime.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbTime.Location = new System.Drawing.Point(480, 318);
			this.gbTime.Name = "gbTime";
			this.gbTime.Size = new System.Drawing.Size(264, 40);
			this.gbTime.TabIndex = 4;
			this.gbTime.TabStop = false;
			this.gbTime.Text = "Time";
			// 
			// lblEnd
			// 
			this.lblEnd.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblEnd.Location = new System.Drawing.Point(152, 16);
			this.lblEnd.Name = "lblEnd";
			this.lblEnd.Size = new System.Drawing.Size(100, 16);
			this.lblEnd.TabIndex = 1;
			this.toolTipper.SetToolTip(this.lblEnd, "The time this game ended");
			// 
			// lblStart
			// 
			this.lblStart.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblStart.Location = new System.Drawing.Point(16, 16);
			this.lblStart.Name = "lblStart";
			this.lblStart.Size = new System.Drawing.Size(100, 16);
			this.lblStart.TabIndex = 0;
			this.toolTipper.SetToolTip(this.lblStart, "The time this game started");
			// 
			// pBoard
			// 
			this.pBoard.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.pBoard.AutoScroll = true;
			this.pBoard.Location = new System.Drawing.Point(16, 24);
			this.pBoard.Name = "pBoard";
			this.pBoard.Size = new System.Drawing.Size(448, 398);
			this.pBoard.TabIndex = 0;
			// 
			// pbEmpty
			// 
			this.pbEmpty.Image = ((System.Drawing.Image)(resources.GetObject("pbEmpty.Image")));
			this.pbEmpty.Location = new System.Drawing.Point(8, 8);
			this.pbEmpty.Name = "pbEmpty";
			this.pbEmpty.Size = new System.Drawing.Size(48, 48);
			this.pbEmpty.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbEmpty.TabIndex = 2;
			this.pbEmpty.TabStop = false;
			this.pbEmpty.Visible = false;
			// 
			// tComputerPlayer
			// 
			this.tComputerPlayer.Interval = 1000;
			this.tComputerPlayer.Tick += new System.EventHandler(this.tComputerPlayer_Tick);
			// 
			// btnNewGameBig
			// 
			this.btnNewGameBig.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNewGameBig.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnNewGameBig.Location = new System.Drawing.Point(592, 366);
			this.btnNewGameBig.Name = "btnNewGameBig";
			this.btnNewGameBig.Size = new System.Drawing.Size(104, 23);
			this.btnNewGameBig.TabIndex = 6;
			this.btnNewGameBig.Text = "N&ew Game [8:7:4]";
			this.toolTipper.SetToolTip(this.btnNewGameBig, "Start a new 4-in-a-row game using a board with width 8 and height 7");
			this.btnNewGameBig.Click += new System.EventHandler(this.btnNewGameBig_Click);
			// 
			// btnNewGameSpecial
			// 
			this.btnNewGameSpecial.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNewGameSpecial.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnNewGameSpecial.Location = new System.Drawing.Point(480, 398);
			this.btnNewGameSpecial.Name = "btnNewGameSpecial";
			this.btnNewGameSpecial.Size = new System.Drawing.Size(104, 23);
			this.btnNewGameSpecial.TabIndex = 7;
			this.btnNewGameSpecial.Text = "Ne&w Game [8:7:5]";
			this.toolTipper.SetToolTip(this.btnNewGameSpecial, "Start a new 5-in-a-row game using a board with width 8 and height 7");
			this.btnNewGameSpecial.Click += new System.EventHandler(this.btnNewGameSpecial_Click);
			// 
			// grpValues
			// 
			this.grpValues.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.grpValues.Controls.Add(this.lblInfoDefensive);
			this.grpValues.Controls.Add(this.lblInfoOffensive);
			this.grpValues.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.grpValues.Location = new System.Drawing.Point(480, 256);
			this.grpValues.Name = "grpValues";
			this.grpValues.Size = new System.Drawing.Size(264, 56);
			this.grpValues.TabIndex = 11;
			this.grpValues.TabStop = false;
			this.grpValues.Text = "iPotVal/2+iVal^2";
			// 
			// lblInfoDefensive
			// 
			this.lblInfoDefensive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblInfoDefensive.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblInfoDefensive.Location = new System.Drawing.Point(8, 32);
			this.lblInfoDefensive.Name = "lblInfoDefensive";
			this.lblInfoDefensive.Size = new System.Drawing.Size(248, 16);
			this.lblInfoDefensive.TabIndex = 1;
			this.toolTipper.SetToolTip(this.lblInfoDefensive, "Defensive values [y,x][h,v,ur,dr][ph,pv,pur,pdr][value]");
			// 
			// lblInfoOffensive
			// 
			this.lblInfoOffensive.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lblInfoOffensive.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lblInfoOffensive.Location = new System.Drawing.Point(8, 16);
			this.lblInfoOffensive.Name = "lblInfoOffensive";
			this.lblInfoOffensive.Size = new System.Drawing.Size(248, 16);
			this.lblInfoOffensive.TabIndex = 0;
			this.toolTipper.SetToolTip(this.lblInfoOffensive, "Offensive values [y,x][h,v,ur,dr][ph,pv,pur,pdr][value]");
			// 
			// pbRedWithBg
			// 
			this.pbRedWithBg.Image = ((System.Drawing.Image)(resources.GetObject("pbRedWithBg.Image")));
			this.pbRedWithBg.Location = new System.Drawing.Point(72, 8);
			this.pbRedWithBg.Name = "pbRedWithBg";
			this.pbRedWithBg.Size = new System.Drawing.Size(48, 48);
			this.pbRedWithBg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbRedWithBg.TabIndex = 12;
			this.pbRedWithBg.TabStop = false;
			this.pbRedWithBg.Visible = false;
			// 
			// pbYellowWithBg
			// 
			this.pbYellowWithBg.Image = ((System.Drawing.Image)(resources.GetObject("pbYellowWithBg.Image")));
			this.pbYellowWithBg.Location = new System.Drawing.Point(136, 8);
			this.pbYellowWithBg.Name = "pbYellowWithBg";
			this.pbYellowWithBg.Size = new System.Drawing.Size(48, 48);
			this.pbYellowWithBg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pbYellowWithBg.TabIndex = 13;
			this.pbYellowWithBg.TabStop = false;
			this.pbYellowWithBg.Visible = false;
			// 
			// cbComputer1Lvl2
			// 
			this.cbComputer1Lvl2.Enabled = false;
			this.cbComputer1Lvl2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbComputer1Lvl2.Location = new System.Drawing.Point(16, 96);
			this.cbComputer1Lvl2.Name = "cbComputer1Lvl2";
			this.cbComputer1Lvl2.TabIndex = 4;
			this.cbComputer1Lvl2.Text = "Co&mputer lvl 2";
			// 
			// cbComputer2Lvl2
			// 
			this.cbComputer2Lvl2.Enabled = false;
			this.cbComputer2Lvl2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.cbComputer2Lvl2.Location = new System.Drawing.Point(16, 96);
			this.cbComputer2Lvl2.Name = "cbComputer2Lvl2";
			this.cbComputer2Lvl2.TabIndex = 5;
			this.cbComputer2Lvl2.Text = "Com&puter lvl 2";
			// 
			// FormFourInRowTable
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(754, 438);
			this.Controls.Add(this.grpValues);
			this.Controls.Add(this.btnNewGameSpecial);
			this.Controls.Add(this.btnNewGameBig);
			this.Controls.Add(this.gbTime);
			this.Controls.Add(this.btnExit);
			this.Controls.Add(this.btnAbout);
			this.Controls.Add(this.btnHighScores);
			this.Controls.Add(this.btnNewGame);
			this.Controls.Add(this.gbCurrentPlayer);
			this.Controls.Add(this.gbPlayer2);
			this.Controls.Add(this.gbPlayer1);
			this.Controls.Add(this.pBoard);
			this.Controls.Add(this.pbEmpty);
			this.Controls.Add(this.pbYellowWithBg);
			this.Controls.Add(this.pbRedWithBg);
			this.MinimumSize = new System.Drawing.Size(762, 386);
			this.Name = "FormFourInRowTable";
			this.Text = "title";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormFourInRowTable_Closing);
			this.Load += new System.EventHandler(this.frmSizeMan_Load);
			this.gbPlayer1.ResumeLayout(false);
			this.gbPlayer2.ResumeLayout(false);
			this.gbCurrentPlayer.ResumeLayout(false);
			this.gbTime.ResumeLayout(false);
			this.grpValues.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private Game m_oGame;
		private HighScoresDictionary m_dicHighScores = new HighScoresDictionary();
		private bool m_bDragging = false;

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			try
			{
				Application.EnableVisualStyles();
				Application.Run(new FormFourInRowTable());
			}
			catch(Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void frmSizeMan_Load(object sender, System.EventArgs e)
		{
			string sPlayer1Name="";
			string sPlayer2Name="";
			this.BackColor=Color.FromArgb(157,157,239);
			this.Text = Settings.sApplicationName;
			m_dicHighScores = Settings.loadHighScores(out sPlayer1Name, out sPlayer2Name);
			tbPlayer1Name.Text = sPlayer1Name;
			tbPlayer2Name.Text = sPlayer2Name;

			newGame();
		}

		/// <summary>
		/// returns the image for an empty position on the board
		/// </summary>
		/// <returns></returns>
		public Image getEmptyImage()
		{
			return pbEmpty.Image;
		}

		/// <summary>
		/// returns the image for player 1
		/// </summary>
		/// <returns></returns>
		public Image getPlayer1Image()
		{
			// red
			return pbRedWithBg.Image;
		//	return pbRed.Image;
		}

		/// <summary>
		/// returns the image for player 2
		/// </summary>
		/// <returns></returns>
		public Image getPlayer2Image()
		{
			// gul
			return pbYellowWithBg.Image;
		//	return pbYellow.Image;
		}

		private void btnNewGame_Click(object sender, System.EventArgs e)
		{
			Settings.c_iBoardHeight=6;
			Settings.c_iBoardWidth=7;
			Settings.c_iWinLength=4;
			newGame();
		}

		private void newGame()
		{
			m_oGame = new Game(this, tbPlayer1Name.Text.Trim(), tbPlayer2Name.Text.Trim());
			m_oGame.addControls(pBoard);
			printPlayer();
			enableAllDropButtons();
			resetPlayerMoves();
			printPlayer1Moves();
			printPlayer2Moves();
			lblStart.Text = DateTime.Now.ToLongTimeString();
			lblEnd.Text = "";
			m_oGame.bGameOver = false;
			tComputerPlayer.Enabled = true;
		}

		/// <summary>
		/// place a value in specified column
		/// if we are dragging
		/// </summary>
		/// <param name="iColumn">column to drop in</param>
		public void doDropIfDrag(int iColumn)
		{
			if(m_bDragging)
			{
				doDrop(iColumn);
				m_bDragging = false;
				this.Cursor = Cursors.Default;
			}
		}

		/// <summary>
		/// place a value in specified column
		/// </summary>
		/// <param name="iColumn">column to drop in</param>
		/// <returns>true if it was legal to drop in specified column</returns>
		public bool doDrop(int iColumn)
		{
			if(m_oGame.isDrawLegal(iColumn) && !m_oGame.bGameOver)
			{
				m_oGame.makeDraw(iColumn);
				if(m_oGame.playerHasWon(iColumn))
				{
					printWinner();
					diableAllDropButtons();
					m_oGame.bGameOver = true;
					lblEnd.Text = DateTime.Now.ToLongTimeString();
					addToHighScores();
				}
				else
				{
					if(m_oGame.boardIsFull())
					{
						printBoardFull();
						diableAllDropButtons();
						m_oGame.bGameOver = true;
					}
					else
					{
						m_oGame.changePlayer();
						printPlayer();
					}
				}
				printPlayer1Moves();
				printPlayer2Moves();

				this.Cursor = Cursors.Default;

				return true;
			}
			else
			{
				Beeper.doBeep();
				return false;
			}
		}

		private void addToHighScores()
		{
			string sWinner = m_oGame.getCurrentPlayer().getPlayerName();
			string sLoser = m_oGame.getNonCurrentPlayer().getPlayerName();
			string sName = sWinner +" (vs "+ sLoser +")";

			HighScore oScore = new HighScore(sName, m_oGame.getGameDuration(), "", m_oGame.getCurrentPlayer().getPlayerMoves());
			m_dicHighScores.Add(oScore);
			m_dicHighScores.Sort();
			int iPlace = m_dicHighScores.IndexOf(oScore)+1;

			if(iPlace<=10)
			{
				MessageBox.Show("Congratulations "+ sWinner +"!\nYou made number "+ iPlace +" on the high score list");
			}
		}

		private void resetPlayerMoves()
		{
			m_oGame.getPlayer1().resetPlayerMoves();
			m_oGame.getPlayer2().resetPlayerMoves();
		}

		private void printPlayer1Moves()
		{
			lblPlayer1Moves.Text = m_oGame.getPlayer1().getPlayerMoves() +" moves";
		}

		private void printPlayer2Moves()
		{
			lblPlayer2Moves.Text = m_oGame.getPlayer2().getPlayerMoves() +" moves";
		}

		private void printPlayer()
		{
			lblCurrentPlayer.Text = m_oGame.getCurrentPlayer().getPlayerName() +" to go";
		}

		private void printWinner()
		{
			lblCurrentPlayer.Text = m_oGame.getCurrentPlayer().getPlayerName() +" has won";
		}

		private void printBoardFull()
		{
			lblCurrentPlayer.Text = "The board is full, no winner";
		}

		private void diableAllDropButtons()
		{
			m_oGame.disableAllDropButtons();
		}

		private void enableAllDropButtons()
		{
			m_oGame.enableAllDropButtons();
		}

		private void btnExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnAbout_Click(object sender, System.EventArgs e)
		{
			FormAbout oForm = new FormAbout();
			oForm.ShowDialog(this);
		}

		private void tbPlayer1Name_TextChanged(object sender, System.EventArgs e)
		{
			if(m_oGame!=null)
			{
				string sPlayer1Name = tbPlayer1Name.Text.Trim();
				m_oGame.getPlayer1().setPlayerName(sPlayer1Name);
			}
		}

		private void tbPlayer2Name_TextChanged(object sender, System.EventArgs e)
		{
			if(m_oGame!=null)
			{
				string sPlayer2Name = tbPlayer2Name.Text.Trim();
				m_oGame.getPlayer2().setPlayerName(sPlayer2Name);		
			}
		}

		private void tComputerPlayer_Tick(object sender, System.EventArgs e)
		{
			if(m_oGame.bGameOver)
			{
				tComputerPlayer.Enabled = false;
			}
			else 
			{
				doComputerDrop();
			}
		}

		private void doComputerDrop()
		{
			if( (this.cbComputer1.Checked && m_oGame.getCurrentPlayer().getPlayerValue()==1)
			||	(this.cbComputer2.Checked && m_oGame.getCurrentPlayer().getPlayerValue()==2))
			{
				int iColumn = 0;
				do 
				{
					BoardPositionValue oOffensiveValue = m_oGame.getBestMove(m_oGame.getCurrentPlayer());
					BoardPositionValue oDefensiveValue = m_oGame.getBestMove(m_oGame.getNonCurrentPlayer());

					lblInfoOffensive.Text = ""+ oOffensiveValue.ToString();
					lblInfoDefensive.Text = ""+ oDefensiveValue.ToString();

					if(oOffensiveValue.iValue > oDefensiveValue.iValue)
						iColumn = oOffensiveValue.iColumn;
					else
						iColumn = oDefensiveValue.iColumn;
				}
				while(!doDrop(iColumn) && !m_oGame.bGameOver);
			}
		}

		private void cbComputer_CheckedChanged(object sender, System.EventArgs e)
		{
			if(cbComputer1.Checked || cbComputer2.Checked)
			{
				tComputerPlayer.Enabled = true;
			}
			else if(!cbComputer1.Checked && !cbComputer2.Checked)
			{
				tComputerPlayer.Enabled = false;
			}
		}

		private void btnNewGameBig_Click(object sender, System.EventArgs e)
		{
			Settings.c_iBoardHeight=7;
			Settings.c_iBoardWidth=8;
			Settings.c_iWinLength=4;
			newGame();
		}

		private void btnNewGameSpecial_Click(object sender, System.EventArgs e)
		{
			Settings.c_iBoardHeight=7;
			Settings.c_iBoardWidth=8;
			Settings.c_iWinLength=5;
			newGame();
		}

		private void FormFourInRowTable_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			tComputerPlayer.Enabled = false;

			Settings.saveHighScores(m_dicHighScores, tbPlayer1Name.Text.Trim(), tbPlayer2Name.Text.Trim());
		}

		private void btnHighScores_Click(object sender, System.EventArgs e)
		{
			FormHighScores oForm = new FormHighScores();
			oForm.showHighScores(m_dicHighScores);
		}

		private void pbRed_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// red = player 1
			if(m_oGame.getCurrentPlayer().getPlayerValue()==1)
			{
				Image imPlupp = pbRed.Image;
				makeCursor(imPlupp);
				m_bDragging = true;
			}
		}

		private void pbYellow_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			// yellow = player 2
			if(m_oGame.getCurrentPlayer().getPlayerValue()==2)
			{
				Image imPlupp = pbYellow.Image;
				makeCursor(imPlupp);
				m_bDragging = true;
			}
		}

		private void makeCursor(Image imPlupp)
		{
			Bitmap b = new Bitmap(imPlupp);
		
			// this is the trick!
			IntPtr ptr = b.GetHicon();
		
			this.Cursor = new Cursor( ptr );
		}
	}
}
