namespace Dahlex
{
    partial class fHighScores
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
            this.bClose = new System.Windows.Forms.Button();
            this.gbLocal = new System.Windows.Forms.GroupBox();
            this.lvLocal = new System.Windows.Forms.ListView();
            this.chScore = new System.Windows.Forms.ColumnHeader();
            this.chName = new System.Windows.Forms.ColumnHeader();
            this.chLevel = new System.Windows.Forms.ColumnHeader();
            this.chMoves = new System.Windows.Forms.ColumnHeader();
            this.chBoardSize = new System.Windows.Forms.ColumnHeader();
            this.chGameTime = new System.Windows.Forms.ColumnHeader();
            this.gbLocal.SuspendLayout();
            this.SuspendLayout();
            // 
            // bClose
            // 
            this.bClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.bClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.bClose.Location = new System.Drawing.Point(453, 194);
            this.bClose.Name = "bClose";
            this.bClose.Size = new System.Drawing.Size(75, 23);
            this.bClose.TabIndex = 0;
            this.bClose.Text = "&Close";
            this.bClose.UseVisualStyleBackColor = true;
            // 
            // gbLocal
            // 
            this.gbLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.gbLocal.Controls.Add(this.lvLocal);
            this.gbLocal.Location = new System.Drawing.Point(12, 10);
            this.gbLocal.Name = "gbLocal";
            this.gbLocal.Size = new System.Drawing.Size(516, 178);
            this.gbLocal.TabIndex = 2;
            this.gbLocal.TabStop = false;
            this.gbLocal.Text = "High scores";
            // 
            // lvLocal
            // 
            this.lvLocal.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.lvLocal.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chScore,
            this.chName,
            this.chLevel,
            this.chMoves,
            this.chBoardSize,
            this.chGameTime});
            this.lvLocal.FullRowSelect = true;
            this.lvLocal.GridLines = true;
            this.lvLocal.Location = new System.Drawing.Point(7, 20);
            this.lvLocal.Name = "lvLocal";
            this.lvLocal.Size = new System.Drawing.Size(503, 152);
            this.lvLocal.Sorting = System.Windows.Forms.SortOrder.Descending;
            this.lvLocal.TabIndex = 0;
            this.lvLocal.UseCompatibleStateImageBehavior = false;
            this.lvLocal.View = System.Windows.Forms.View.Details;
            // 
            // chScore
            // 
            this.chScore.Text = "Score";
            this.chScore.Width = 48;
            // 
            // chName
            // 
            this.chName.Text = "Name";
            this.chName.Width = 136;
            // 
            // chLevel
            // 
            this.chLevel.Text = "Level";
            this.chLevel.Width = 50;
            // 
            // chMoves
            // 
            this.chMoves.Text = "Moves";
            // 
            // chBoardSize
            // 
            this.chBoardSize.Text = "Board Size";
            this.chBoardSize.Width = 77;
            // 
            // chGameTime
            // 
            this.chGameTime.Text = "Game Time";
            this.chGameTime.Width = 72;
            // 
            // fHighScores
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.bClose;
            this.ClientSize = new System.Drawing.Size(540, 229);
            this.Controls.Add(this.gbLocal);
            this.Controls.Add(this.bClose);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "fHighScores";
            this.Text = "HighScores";
            this.Load += new System.EventHandler(this.fHighScores_Load);
            this.gbLocal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button bClose;
        private System.Windows.Forms.GroupBox gbLocal;
        private System.Windows.Forms.ListView lvLocal;
        private System.Windows.Forms.ColumnHeader chScore;
        private System.Windows.Forms.ColumnHeader chName;
        private System.Windows.Forms.ColumnHeader chLevel;
        private System.Windows.Forms.ColumnHeader chMoves;
        private System.Windows.Forms.ColumnHeader chBoardSize;
        private System.Windows.Forms.ColumnHeader chGameTime;
    }
}