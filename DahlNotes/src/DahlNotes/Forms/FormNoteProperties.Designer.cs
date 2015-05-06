using System.Windows.Forms;

namespace DahlNotes.Forms
{
    partial class FormNoteProperties
    {
        private GroupBox gbNote;
        private System.Windows.Forms.TextBox tbNote;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.ColorDialog cdNoteColor;
        private System.Windows.Forms.Button btnColor;
        private System.Windows.Forms.TrackBar tbOpacity;
        private System.Windows.Forms.Button btnTextColor;
        private System.Windows.Forms.Label lblOpacity;
        private System.Windows.Forms.CheckBox cbAlwaysOnTop;
        private System.Windows.Forms.CheckBox cbStartOpened;
        private System.Windows.Forms.Button btnFont;
        private System.Windows.Forms.FontDialog fdNoteFont;
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
            this.gbNote = new System.Windows.Forms.GroupBox();
            this.btnFont = new System.Windows.Forms.Button();
            this.cbStartOpened = new System.Windows.Forms.CheckBox();
            this.cbAlwaysOnTop = new System.Windows.Forms.CheckBox();
            this.lblOpacity = new System.Windows.Forms.Label();
            this.btnTextColor = new System.Windows.Forms.Button();
            this.tbOpacity = new System.Windows.Forms.TrackBar();
            this.btnColor = new System.Windows.Forms.Button();
            this.tbNote = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.cdNoteColor = new System.Windows.Forms.ColorDialog();
            this.fdNoteFont = new System.Windows.Forms.FontDialog();
            this.gbNote.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).BeginInit();
            this.SuspendLayout();
            // 
            // gbNote
            // 
            this.gbNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gbNote.Controls.Add(this.btnFont);
            this.gbNote.Controls.Add(this.cbStartOpened);
            this.gbNote.Controls.Add(this.cbAlwaysOnTop);
            this.gbNote.Controls.Add(this.lblOpacity);
            this.gbNote.Controls.Add(this.btnTextColor);
            this.gbNote.Controls.Add(this.tbOpacity);
            this.gbNote.Controls.Add(this.btnColor);
            this.gbNote.Controls.Add(this.tbNote);
            this.gbNote.Location = new System.Drawing.Point(8, 8);
            this.gbNote.Name = "gbNote";
            this.gbNote.Size = new System.Drawing.Size(352, 220);
            this.gbNote.TabIndex = 0;
            this.gbNote.TabStop = false;
            this.gbNote.Text = "Note";
            // 
            // btnFont
            // 
            this.btnFont.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFont.Location = new System.Drawing.Point(261, 114);
            this.btnFont.Name = "btnFont";
            this.btnFont.Size = new System.Drawing.Size(85, 30);
            this.btnFont.TabIndex = 4;
            this.btnFont.Text = "Text &Font...";
            this.btnFont.Click += new System.EventHandler(this.btnFont_Click);
            // 
            // cbStartOpened
            // 
            this.cbStartOpened.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbStartOpened.AutoSize = true;
            this.cbStartOpened.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbStartOpened.Location = new System.Drawing.Point(24, 187);
            this.cbStartOpened.Name = "cbStartOpened";
            this.cbStartOpened.Size = new System.Drawing.Size(92, 17);
            this.cbStartOpened.TabIndex = 2;
            this.cbStartOpened.Text = "&Start Opened:";
            this.cbStartOpened.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAlwaysOnTop
            // 
            this.cbAlwaysOnTop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cbAlwaysOnTop.AutoSize = true;
            this.cbAlwaysOnTop.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.cbAlwaysOnTop.Location = new System.Drawing.Point(127, 187);
            this.cbAlwaysOnTop.Name = "cbAlwaysOnTop";
            this.cbAlwaysOnTop.Size = new System.Drawing.Size(101, 17);
            this.cbAlwaysOnTop.TabIndex = 3;
            this.cbAlwaysOnTop.Text = "&Always On Top:";
            this.cbAlwaysOnTop.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblOpacity
            // 
            this.lblOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblOpacity.Location = new System.Drawing.Point(13, 116);
            this.lblOpacity.Name = "lblOpacity";
            this.lblOpacity.Size = new System.Drawing.Size(56, 13);
            this.lblOpacity.TabIndex = 7;
            this.lblOpacity.Text = "Opacity:";
            // 
            // btnTextColor
            // 
            this.btnTextColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTextColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTextColor.Location = new System.Drawing.Point(261, 148);
            this.btnTextColor.Name = "btnTextColor";
            this.btnTextColor.Size = new System.Drawing.Size(85, 30);
            this.btnTextColor.TabIndex = 5;
            this.btnTextColor.Text = "&Text Color...";
            this.btnTextColor.Click += new System.EventHandler(this.btnTextColor_Click);
            // 
            // tbOpacity
            // 
            this.tbOpacity.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbOpacity.Location = new System.Drawing.Point(6, 132);
            this.tbOpacity.Maximum = 100;
            this.tbOpacity.Minimum = 50;
            this.tbOpacity.Name = "tbOpacity";
            this.tbOpacity.Size = new System.Drawing.Size(238, 45);
            this.tbOpacity.TabIndex = 1;
            this.tbOpacity.Value = 100;
            this.tbOpacity.ValueChanged += new System.EventHandler(this.tbTransparency_ValueChanged);
            // 
            // btnColor
            // 
            this.btnColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnColor.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnColor.Location = new System.Drawing.Point(261, 183);
            this.btnColor.Name = "btnColor";
            this.btnColor.Size = new System.Drawing.Size(85, 30);
            this.btnColor.TabIndex = 6;
            this.btnColor.Text = "&Back Color...";
            this.btnColor.Click += new System.EventHandler(this.btnColor_Click);
            // 
            // tbNote
            // 
            this.tbNote.AcceptsReturn = true;
            this.tbNote.AcceptsTab = true;
            this.tbNote.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbNote.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNote.Location = new System.Drawing.Point(6, 19);
            this.tbNote.Multiline = true;
            this.tbNote.Name = "tbNote";
            this.tbNote.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbNote.Size = new System.Drawing.Size(340, 89);
            this.tbNote.TabIndex = 0;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(272, 234);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(85, 30);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "Cancel";
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOk.Location = new System.Drawing.Point(178, 234);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(85, 30);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&Ok";
            // 
            // cdNoteColor
            // 
            this.cdNoteColor.AnyColor = true;
            this.cdNoteColor.FullOpen = true;
            this.cdNoteColor.SolidColorOnly = true;
            // 
            // fdNoteFont
            // 
            this.fdNoteFont.AllowScriptChange = false;
            this.fdNoteFont.AllowVerticalFonts = false;
            this.fdNoteFont.Color = System.Drawing.SystemColors.ControlText;
            this.fdNoteFont.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.fdNoteFont.FontMustExist = true;
            this.fdNoteFont.ScriptsOnly = true;
            this.fdNoteFont.ShowEffects = false;
            // 
            // FormNoteProperties
            // 
            this.AcceptButton = this.btnOk;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(372, 273);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.gbNote);
            this.MinimumSize = new System.Drawing.Size(370, 280);
            this.Name = "FormNoteProperties";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.Text = "Note props";
            this.gbNote.ResumeLayout(false);
            this.gbNote.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tbOpacity)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
    }
}