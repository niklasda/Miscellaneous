using System;
using System.Windows.Forms;
using DahlNotes.Notes;

namespace DahlNotes.Forms
{
    /// <summary>
    /// Form for editing notes
    /// </summary>
    public partial class FormNoteProperties : Form
    {
        private Note _noteToEdit;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormNoteProperties"/> class. 
        /// </summary>
        public FormNoteProperties()
        {
            InitializeComponent();
        }

        /// <summary>
        /// returns the configured note
        /// </summary>
        /// <returns>a note</returns>
        public Note GetNote()
        {
            //    _noteToEdit.Update(,,,, ,,);
            _noteToEdit.NoteText = tbNote.Text.Trim();
            _noteToEdit.BackColor = tbNote.BackColor;
            _noteToEdit.TextColor = tbNote.ForeColor;
            _noteToEdit.TextFont = tbNote.Font;
            _noteToEdit.Opacity = tbOpacity.Value;
            _noteToEdit.AlwaysOnTop = cbAlwaysOnTop.Checked;
            _noteToEdit.StartOpened = cbStartOpened.Checked;

            return _noteToEdit;
        }

        /// <summary>
        /// sets the note to configure
        /// </summary>
        /// <param name="oldNote">the note</param>
        public void SetNote(Note oldNote)
        {
            _noteToEdit = oldNote;

            Text = string.Format("Note {0} Properties", oldNote.Id);

            tbNote.Text = oldNote.NoteText;
            tbNote.Select(tbNote.Text.Length, 0);
            tbOpacity.Value = oldNote.Opacity;

            tbNote.BackColor = oldNote.BackColor;
            tbNote.ForeColor = oldNote.TextColor;
            tbNote.Font = oldNote.TextFont;

            cbAlwaysOnTop.Checked = oldNote.AlwaysOnTop;
            cbStartOpened.Checked = oldNote.StartOpened;
        }

        /// <summary>
        /// starts dialog for adding new notes
        /// </summary>
        /// <returns>ok or cancel</returns>
        public DialogResult AddNew()
        {
            return ShowDialog();
        }

        /// <summary>
        /// starts dialog for editing existing note
        /// </summary>
        /// <returns>ok or cancel</returns>
        public DialogResult EditExisting()
        {
            return ShowDialog();
        }

        private void tbTransparency_ValueChanged(object sender, EventArgs e)
        {
            double dOpacity = tbOpacity.Value / 100.0;
            Opacity = dOpacity;
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            cdNoteColor.Color = tbNote.BackColor;
            if (cdNoteColor.ShowDialog(this) == DialogResult.OK)
            {
                tbNote.BackColor = cdNoteColor.Color;
            }

            tbNote.Focus();
        }

        private void btnTextColor_Click(object sender, EventArgs e)
        {
            cdNoteColor.Color = tbNote.ForeColor;
            if (cdNoteColor.ShowDialog(this) == DialogResult.OK)
            {
                tbNote.ForeColor = cdNoteColor.Color;
            }

            tbNote.Focus();
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            fdNoteFont.Font = tbNote.Font;
            if (fdNoteFont.ShowDialog(this) == DialogResult.OK)
            {
                tbNote.Font = fdNoteFont.Font;
            }

            tbNote.Focus();
        }
    }
}
