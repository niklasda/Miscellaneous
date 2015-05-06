using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using DahlNotes.Configuration;
using DahlNotes.Logic;
using DahlNotes.Notes;

namespace DahlNotes.Forms
{
    /// <summary>
    /// The form showing a Note.
    /// </summary>
    public partial class FormNote : Form
    {
        private readonly IFormDahlNotesConfiguration _mainForm;
        private NoteState _state;
        private bool _dragging;
        private Point _origin = Point.Empty;

        /// <summary>
        /// Initializes a new instance of the <see cref="FormNote"/> class. 
        /// </summary>
        /// <param name="mainForm">
        /// main application configuration form
        /// </param>
        /// <param name="noteToShow">
        /// the note to show
        /// </param>
        public FormNote(IFormDahlNotesConfiguration mainForm, Note noteToShow)
        {
            InitializeComponent();

            TheNote = noteToShow;
            ValidateNoteLocationSize();

            _mainForm = mainForm;

            // ∙ √
            // Text = string.Format("Note {0}", TheNote.Id);
            ShowState();

            SuspendLayout();
            Location = TheNote.Location;
            ResumeLayout(false);
        }

        /// <summary>
        /// Gets the note currently shown in this form
        /// </summary>
        public Note TheNote { get; private set; }

        /// <summary>
        /// show updated note in this form
        /// </summary>
        /// <param name="newNote">updated note to show</param>
        public void UpdateNote(Note newNote)
        {
            TheNote = newNote;
            ShowNote();
        }

        private void ValidateNoteLocationSize()
        {
            if (TheNote.Location.X < 0)
            {
                TheNote.Location = new Point(20, TheNote.Location.Y);
            }

            if (TheNote.Location.Y < 0)
            {
                TheNote.Location = new Point(TheNote.Location.X, 20);
            }

            bool itsIn = false;
            var noteBounds = new Rectangle(TheNote.Location, TheNote.Size);
            foreach (Screen screen in Screen.AllScreens)
            {
                if (screen.Bounds.IntersectsWith(noteBounds))
                {
                    itsIn = true;
                }
            }

            if (!itsIn)
            {
                TheNote.Location = new Point(20, 20);
            }

            if (TheNote.Size.Width < 200)
            {
                TheNote.Size = new Size(200, TheNote.Size.Height);
            }

            if (TheNote.Size.Height < 100)
            {
                TheNote.Size = new Size(TheNote.Size.Width, 100);
            }
        }

        private void FormNote_Load(object sender, EventArgs e)
        {
            ShowNote();
        }

        private void ShowNote()
        {
            tbNote.ReadOnly = TheNote.IsReadOnly;
            tbNote.Text = TheNote.NoteText;
            tbNote.BackColor = TheNote.BackColor;
            tbNote.ForeColor = TheNote.TextColor;
            tbNote.Font = TheNote.TextFont;
            tbNote.Select(tbNote.Text.Length, 0);

            Color backColor = Color.FromArgb(
                    Math.Max(0, TheNote.BackColor.R - 20),
                    Math.Max(0, TheNote.BackColor.G - 20),
                    Math.Max(0, TheNote.BackColor.B - 20));
            lblAdd.BackColor = backColor;
            lblClose.BackColor = backColor;
            lblNow.BackColor = backColor;

            double dOpacity = TheNote.Opacity / 100.0;
            Opacity = dOpacity;

            BackColor = TheNote.BackColor;
            ForeColor = TheNote.TextColor;

            cmiAlwaysOnTop.Checked = TheNote.AlwaysOnTop;
            TopMost = TheNote.AlwaysOnTop;
            Location = TheNote.Location;
            Size = TheNote.Size;
        }

        private void cmiClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void cmiOpenDahlNotes_Click(object sender, EventArgs e)
        {
            _mainForm.ShowWindow(false, false);
        }

        private void FormNote_Closing(object sender, CancelEventArgs e)
        {
            SaveNote(true);
        }

        private void SaveNote(bool isClosing)
        {
            TheNote.Location = Location;
            TheNote.Size = Size;
            TheNote.NoteText = tbNote.Text;
            //TheNote.Update(Location, Size, tbNote.Text);

            if (_mainForm.UpdateNote(TheNote, isClosing))
            {
                lblNow.Text = string.Format("Saved {0}", DateTime.Now);
            }
        }

        private void cmiAlwaysOnTop_Click(object sender, EventArgs e)
        {
            bool bAlwaysOnTop = !cmiAlwaysOnTop.Checked;
            cmiAlwaysOnTop.Checked = bAlwaysOnTop;

            TheNote.AlwaysOnTop = bAlwaysOnTop;
            ShowNote();
        }

        private void cmiTextColor_Click(object sender, EventArgs e)
        {
            cdColor.Color = TheNote.TextColor;
            if (cdColor.ShowDialog(this) == DialogResult.OK)
            {
                TheNote.TextColor = cdColor.Color;
                ShowNote();
            }
        }

        private void cmiBackColor_Click(object sender, EventArgs e)
        {
            cdColor.Color = TheNote.BackColor;
            if (cdColor.ShowDialog(this) == DialogResult.OK)
            {
                TheNote.BackColor = cdColor.Color;
                ShowNote();
            }
        }

        private void cmiTextFont_Click(object sender, EventArgs e)
        {
            fdFont.Font = TheNote.TextFont;
            if (fdFont.ShowDialog(this) == DialogResult.OK)
            {
                TheNote.TextFont = fdFont.Font;
                ShowNote();
            }
        }

        private void cmNoteMenu_Popup(object sender, EventArgs e)
        {
            cmiAlwaysOnTop.Checked = TopMost;
        }

        private void lblNow_Click(object sender, EventArgs e)
        {
            ShowState();
        }

        private void ShowState()
        {
            ttStatus.SetToolTip(lblNow, string.Format("Note {0}", TheNote.Id));

            if (_state == NoteState.CurrentTime)
            {
               // lblNow.Text = string.Format("{0}", DateTime.Now);
                timerStatus.Start();
                _state = NoteState.Nothing;
            }
            else if (_state == NoteState.Nothing)
            {
                if (TheNote.IsReadOnly)
                {
                    lblNow.Text = "Read only";
                }
                else
                {
                    lblNow.Text = string.Empty;   
                }

                timerStatus.Stop();
                _state = NoteState.CurrentTime;
            }
        }

        private void timerStatus_Tick(object sender, EventArgs e)
        {
            if (InvokeRequired)
            {
                this.Invoke((MethodInvoker)delegate { lblNow.Text = string.Format("{0}", DateTime.Now); });
            }
            else
            {
                lblNow.Text = string.Format("{0}", DateTime.Now);
            }
        }

        private void lblClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void lblClose_MouseHover(object sender, EventArgs e)
        {
            lblClose.Font = new Font(lblClose.Font, FontStyle.Bold);
        }

        private void lblClose_MouseLeave(object sender, EventArgs e)
        {
            lblClose.Font = new Font(lblClose.Font, FontStyle.Regular);
        }

        private void lblAdd_Click(object sender, EventArgs e)
        {
            _mainForm.ShowWindow(false, true);
        }

        private void lblAdd_MouseHover(object sender, EventArgs e)
        {
            lblAdd.Font = new Font(lblClose.Font, FontStyle.Bold);
        }

        private void lblAdd_MouseLeave(object sender, EventArgs e)
        {
            lblAdd.Font = new Font(lblClose.Font, FontStyle.Regular);
        }

        private void lblNow_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _dragging = true;

                int borderWidth = (Size.Width - ClientSize.Width) / 2;
                int borderHeight = (Size.Height - ClientSize.Height) / 2;

                _origin = new Point(e.Location.X + lblNow.Location.X + borderWidth, e.Location.Y + lblNow.Location.Y + borderHeight);
            }
        }

        private void lblNow_MouseUp(object sender, MouseEventArgs e)
        {
            _dragging = false;
            _origin = Point.Empty;
        }

        private void lblNow_MouseMove(object sender, MouseEventArgs e)
        {
            if (_dragging)
            {
                Location = new Point(Cursor.Position.X - _origin.X, Cursor.Position.Y - _origin.Y);
            }
        }

        private void cmiAddNewNote_Click(object sender, EventArgs e)
        {
            _mainForm.ShowWindow(false, true);
        }

        private void cmiBall_Click(object sender, EventArgs e)
        {
            int idx = tbNote.SelectionStart;
            tbNote.Text = tbNote.Text.Insert(idx, "∙");
            tbNote.SelectionStart = idx + 1;
        }

        private void cmiCheck_Click(object sender, EventArgs e)
        {
            int idx = tbNote.SelectionStart;
            tbNote.Text = tbNote.Text.Insert(idx, "√");
            tbNote.SelectionStart = idx + 1;
        }

        private void cmiSelectAll_Click(object sender, EventArgs e)
        {
            tbNote.SelectAll();
        }

        private void FormNote_Deactivate(object sender, EventArgs e)
        {
            SaveNote(false);
        }
    }
}
