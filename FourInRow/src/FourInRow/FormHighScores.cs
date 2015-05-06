using System;
using System.Collections;
using System.Diagnostics;
using System.Windows.Forms;

namespace FourInRow
{
	/// <summary>
	/// Summary description for formAbout.
	/// </summary>
	public class FormHighScores : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView lvHighScores;
		private System.Windows.Forms.GroupBox gbHighScores;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.ColumnHeader chName;
		private System.Windows.Forms.ColumnHeader chTime;
		private System.Windows.Forms.Button btnDelete;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		/// <summary>
		/// standard empty constructor
		/// </summary>
		public FormHighScores()
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
				if(components != null)
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
			this.lvHighScores = new System.Windows.Forms.ListView();
			this.chTime = new System.Windows.Forms.ColumnHeader();
			this.chName = new System.Windows.Forms.ColumnHeader();
			this.gbHighScores = new System.Windows.Forms.GroupBox();
			this.btnDelete = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.gbHighScores.SuspendLayout();
			this.SuspendLayout();
			// 
			// lvHighScores
			// 
			this.lvHighScores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.lvHighScores.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						   this.chTime,
																						   this.chName});
			this.lvHighScores.FullRowSelect = true;
			this.lvHighScores.GridLines = true;
			this.lvHighScores.HideSelection = false;
			this.lvHighScores.Location = new System.Drawing.Point(16, 24);
			this.lvHighScores.Name = "lvHighScores";
			this.lvHighScores.Size = new System.Drawing.Size(272, 128);
			this.lvHighScores.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.lvHighScores.TabIndex = 0;
			this.lvHighScores.View = System.Windows.Forms.View.Details;
			// 
			// chTime
			// 
			this.chTime.Text = "Time";
			// 
			// chName
			// 
			this.chName.Text = "Name";
			this.chName.Width = 184;
			// 
			// gbHighScores
			// 
			this.gbHighScores.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right)));
			this.gbHighScores.Controls.Add(this.lvHighScores);
			this.gbHighScores.Controls.Add(this.btnDelete);
			this.gbHighScores.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.gbHighScores.Location = new System.Drawing.Point(8, 8);
			this.gbHighScores.Name = "gbHighScores";
			this.gbHighScores.Size = new System.Drawing.Size(304, 192);
			this.gbHighScores.TabIndex = 1;
			this.gbHighScores.TabStop = false;
			this.gbHighScores.Text = "High score list";
			// 
			// btnDelete
			// 
			this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
			this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnDelete.Location = new System.Drawing.Point(16, 160);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.TabIndex = 3;
			this.btnDelete.Text = "&Delete";
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClose.Location = new System.Drawing.Point(232, 208);
			this.btnClose.Name = "btnClose";
			this.btnClose.TabIndex = 2;
			this.btnClose.Text = "&Close";
			// 
			// FormHighScores
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(320, 238);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.gbHighScores);
			this.MinimizeBox = false;
			this.Name = "FormHighScores";
			this.Text = "High scores";
			this.gbHighScores.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private HighScoresDictionary m_dicHighScores;

		/// <summary>
		/// show list of high scores
		/// </summary>
		/// <param name="dicHighScores"></param>
		public void showHighScores(HighScoresDictionary dicHighScores)
		{
			m_dicHighScores = dicHighScores;

			refreshHighScores();

			ShowDialog();
		}

		private void refreshHighScores()
		{
			lvHighScores.Items.Clear();
			foreach(HighScore oScore in m_dicHighScores)
			{
				ListViewItem oItem = new ListViewItem(oScore.sGameTime);
				oItem.Tag = oScore;
				oItem.SubItems.Add(oScore.sName);
			//	oItem.SubItems.Add(oScore.sBoard);
				lvHighScores.Items.Add(oItem);
			}
		}

		private void btnDelete_Click(object sender, System.EventArgs e)
		{
			foreach(ListViewItem oItem in lvHighScores.SelectedItems)
			{
				HighScore oScore = (HighScore)oItem.Tag;
				m_dicHighScores.Remove(oScore);
			}

			refreshHighScores();
		}
	}
}
