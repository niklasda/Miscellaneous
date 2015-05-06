using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using DahlNotes.Configuration;
using DahlNotes.Logic;
using DahlNotes.Notes;
using Microsoft.Win32;

namespace DahlNotes.Forms
{
    /// <summary>
    /// Main form of the Application
    /// </summary>
    public partial class FormDahlNotesOptions : Form, IFormDahlNotesConfiguration
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormDahlNotesOptions"/> class. 
        /// </summary>
        public FormDahlNotesOptions()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Show the configuration form, and if specified minimize it or add new note
        /// </summary>
        /// <param name="stayHidden">Should the window stay hidden.</param>
        /// <param name="addNote">Should Add Note window open.</param>
        public void ShowWindow(bool stayHidden, bool addNote)
        {
            Show();
            if (stayHidden)
            {
                WindowState = FormWindowState.Minimized;
                ShowInTaskbar = false;
            }
            else
            {
                WindowState = FormWindowState.Normal;
                Activate();
                BringToFront();
                ShowInTaskbar = true;
            }

            if (addNote)
            {
                AddNote();
            }
        }

        /// <summary>
        /// Applies changes made to a Note in a NoteProperties form
        /// </summary>
        /// <param name="updatedNote">Updated Note object</param>
        /// <param name="isClosing">Is the update caused by closing</param>
        /// <returns>True if saved, false if no need to save</returns>
        public bool UpdateNote(Note updatedNote, bool isClosing)
        {
            redrawList();

            bool success = Settings.WriteNotes(Holder.TheNotes);

            if (isClosing)
            {
                if (Holder.TheForms.ContainsKey(updatedNote.Id))
                {
                    Holder.TheForms.Remove(updatedNote.Id);
                }
            }

            return success;
        }

        private void cmiOptions_Click(object sender, EventArgs e)
        {
            ShowWindow(false, false);
        }

        private void cmiExit_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void cmiNotesShowAll_Click(object sender, EventArgs e)
        {
            ShowAllNotes();
        }

        private void cmiNotesCloseAll_Click(object sender, EventArgs e)
        {
            CloseAllNotes();
        }

        private void lvNotes_DoubleClick(object sender, EventArgs e)
        {
            EditSelectedNote();
        }

        private void FormDahlNotesOptions_Resize(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Minimized)
            {
                HideWindow();
            }
        }

        private void FormDahlNotesOptions_Load(object sender, EventArgs e)
        {
            Text = Settings.ApplicationName + " Configuration";
            niTrayIcon.Text = Settings.ApplicationName;

            Holder.TheNotes.NotesChanged += TheNotes_NotesChanged;

            Process[] x = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (x.Length > 1)
            {
                Holder.Problem = ProblemType.AlreadyRunning;
            }
            else if (Settings.IsSettingsFileAvailableAndWritable())
            {
                IdNotesDictionary notes = Settings.ReadAllNotes();
                Holder.TheNotes.ReCreate(notes);
                //redrawList();

                OpenInitialNotes();
                if (Holder.TheForms.Count == 0)
                {
                    WindowState = FormWindowState.Normal;
                }
            }
            else
            {
                Holder.Problem = ProblemType.SettingsReadOnly;
            }

            timerHide.Enabled = true;

            SystemEvents.SessionEnding += SystemEvents_SessionEnding;
        }

        private void TheNotes_NotesChanged(object sender, EventArgs e)
        {
            redrawList();
        }

        private void SystemEvents_SessionEnding(object sender, SessionEndingEventArgs e)
        {
            Holder.Problem = ProblemType.SystemShuttingDown;
        }

        private void FormDahlNotesOptions_Closing(object sender, CancelEventArgs e)
        {
            Settings.WriteNotes(Holder.TheNotes);
            HideWindow();

            e.Cancel = Holder.Problem != ProblemType.SystemShuttingDown;
        }

        private void timerHide_Tick(object sender, EventArgs e)
        {
            if (Visible && Holder.TheForms.Count > 0)
            {
                HideWindow();
            }
            else
            {
                timerHide.Enabled = false;
            }

            if (Holder.Problem == ProblemType.SettingsReadOnly)
            {
                Application.Exit();
            }
            else if (Holder.Problem == ProblemType.AlreadyRunning)
            {
                MessageBox.Show("DahlNotes is already running, so this instance will shut down!", Settings.ApplicationName);
                Application.Exit();
            }
        }

        private void HideWindow()
        {
            Hide();
        }

        private void ShowAbout()
        {
            var oFormAbout = new FormAbout();
            oFormAbout.ShowDialog(this);
        }

        private void ExitApp()
        {
            ShowWindow(true, false);
            Settings.WriteNotes(Holder.TheNotes);
            Application.Exit();
        }

        private int GetMaxId()
        {
            int maxId = 0;

            foreach (ListViewItem oItem in lvNotes.Items)
            {
                var oNote = (Note)oItem.Tag;
                if (oNote.Id > maxId)
                {
                    maxId = oNote.Id;
                }
            }

            return maxId;
        }

        private string GetFirstLine(string sNote)
        {
            int newLinePosition = sNote.IndexOf(Environment.NewLine, StringComparison.CurrentCultureIgnoreCase);
            string firstLine = sNote;

            if (newLinePosition > 0)
            {
                firstLine = sNote.Substring(0, newLinePosition);
            }

            return firstLine;
        }

        private void AddNoteToList(Note oNote)
        {
            Holder.TheNotes.Add(oNote);

            // redrawList();
        }

        private void EditSelectedNote()
        {
            if (lvNotes.SelectedItems.Count > 0)
            {
                ListViewItem oItem = lvNotes.SelectedItems[0];
                var oNote = (Note)oItem.Tag;
                if (!oNote.IsReadOnly)
                {
                    var oFormAddNote = new FormNoteProperties();
                    oFormAddNote.SetNote(oNote);

                    try
                    {
                        if (oFormAddNote.EditExisting() == DialogResult.OK)
                        {
                            oNote = oFormAddNote.GetNote();

                            redrawList();

                            if (oNote.StartOpened)
                            {
                                OpenNote(oNote);
                            }

                            Settings.WriteNotes(Holder.TheNotes);
                        }
                    }
                    catch (Exception e)
                    {
                        MessageBox.Show(e.ToString(), Settings.ApplicationName);
                    }
                }
                else
                {
                    MessageBox.Show("Cannot edit or delete shared notes!", Settings.ApplicationName);                    
                }
            }
        }

        private void niTrayIcon_DoubleClick(object sender, EventArgs e)
        {
            ShowWindow(false, false);
        }

        private void OpenInitialNotes()
        {
            foreach (var oEntry in Holder.TheNotes.TheNotes)
            {
                Note oNote = oEntry.Value;
                if (oNote.StartOpened)
                {
                    OpenNote(oNote);
                }
            }
        }

        private void OpenNote(Note oNote)
        {
            UpdateNote(oNote, false);
            if (!Holder.TheForms.ContainsKey(oNote.Id))
            {
                var oFormNote = new FormNote(this, oNote);
                oFormNote.Show();

                Holder.TheForms.Add(oNote.Id, oFormNote);
            }
            else
            {
                FormNote oFormNote = Holder.TheForms[oNote.Id];
                oFormNote.UpdateNote(oNote);
            }
        }

        private void AddNote()
        {
            var oFormAddNote = new FormNoteProperties();
            int iNewNoteId = GetMaxId() + 1;
            var newNote = new Note(iNewNoteId, string.Empty, Color.White, Color.Black, btnAdd.Font, 100, false);

            oFormAddNote.SetNote(newNote);

            if (oFormAddNote.AddNew() == DialogResult.OK)
            {
                Note oNote = oFormAddNote.GetNote();
                AddNoteToList(oNote);

                if (oNote.StartOpened)
                {
                    OpenNote(oNote);
                }

                Settings.WriteNotes(Holder.TheNotes);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            EditSelectedNote();
        }

        private void btnShowAll_Click(object sender, EventArgs e)
        {
            ShowAllNotes();
        }

        private void btnCloseAll_Click(object sender, EventArgs e)
        {
            CloseAllNotes();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedNote();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            ShowSelectedNote();
        }

        private void DeleteSelectedNote()
        {
            if (lvNotes.SelectedItems.Count > 0)
            {
                ListViewItem oItem = lvNotes.SelectedItems[0];
                int idx = lvNotes.Items.IndexOf(oItem);

                var oNote = (Note) oItem.Tag;
                if (!oNote.IsReadOnly)
                {
                    Holder.TheNotes.Remove(oNote);

                    //redrawList();

                    foreach (var openNote in Holder.TheForms)
                    {
                        if (openNote.Value.TheNote.Id == oNote.Id)
                        {
                            openNote.Value.Close();
                            break;
                        }
                    }

                    lvNotes.SelectedIndices.Clear();
                    if (lvNotes.Items.Count > 0)
                    {
                        lvNotes.SelectedIndices.Add(Math.Min(idx, lvNotes.Items.Count - 1));
                    }

                    Settings.WriteNotes(Holder.TheNotes);
                }
                else
                {
                    MessageBox.Show("Cannot edit or delete shared notes!", Settings.ApplicationName);
                }
            }
        }

        private void redrawList()
        {
            IdNotesDictionary dicNotes = Holder.TheNotes;
            lvNotes.Items.Clear();

            foreach (var oEntry in dicNotes.TheNotes)
            {
                Note oNote = oEntry.Value;

                var oItem = new ListViewItem(oNote.Id.ToString("000"));
                oItem.UseItemStyleForSubItems = false;
                oItem.SubItems.Add(string.Format("{0} %", oNote.Opacity));

                ListViewItem.ListViewSubItem oSubItem = oItem.SubItems.Add(oNote.TextFont.Name + " (" + oNote.TextFont.SizeInPoints + ")");
                oSubItem.BackColor = oNote.BackColor;
                oSubItem.ForeColor = oNote.TextColor;

                oItem.SubItems.Add(GetFirstLine(oNote.NoteText));
                oItem.SubItems.Add("(" + oNote.Location.X + "," + oNote.Location.Y + "," + oNote.Size.Width + "," + oNote.Size.Height + ")");
                oItem.SubItems.Add(oNote.StartOpened.ToString());
                oItem.SubItems.Add(oNote.AlwaysOnTop.ToString());
                oItem.SubItems.Add(oNote.IsReadOnly.ToString());
                oItem.Tag = oNote;

                if (oNote.IsReadOnly)
                {
                    oItem.Font = new Font(oItem.Font, FontStyle.Italic);
                }

                lvNotes.Items.Add(oItem);
            }
        }

        private void ShowSelectedNote()
        {
            if (lvNotes.SelectedItems.Count > 0)
            {
                ListViewItem oItem = lvNotes.SelectedItems[0];
                var oNote = (Note)oItem.Tag;

                OpenNote(oNote);
            }
        }

        private void ShowAllNotes()
        {
            foreach (ListViewItem oItem in lvNotes.Items)
            {
                var oNote = (Note)oItem.Tag;
                OpenNote(oNote);
            }
        }

        private void CloseAllNotes()
        {
            int k = 0;
            var arForms = new FormNote[Holder.TheForms.Count];

            foreach (var oEntry in Holder.TheForms)
            {
                FormNote oForm = oEntry.Value;
                arForms[k++] = oForm;
            }

            foreach (FormNote oForm in arForms)
            {
                if (oForm != null)
                {
                    oForm.Close();
                }
            }

            Holder.TheForms.Clear();  // should already be empty from the Close statements
        }

        private void miHide_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void miSaveExit_Click(object sender, EventArgs e)
        {
            ExitApp();
        }

        private void miReload_Click(object sender, EventArgs e)
        {
            var notes = Settings.ReadAllNotes();
            Holder.TheNotes.ReCreate(notes);
            OpenInitialNotes();
            // redrawList();
        }

        private void miAbout_Click(object sender, EventArgs e)
        {
            ShowAbout();
        }

        private void miNoteAdd_Click(object sender, EventArgs e)
        {
            AddNote();
        }

        private void miNoteEdit_Click(object sender, EventArgs e)
        {
            EditSelectedNote();
        }

        private void miNoteDelete_Click(object sender, EventArgs e)
        {
            DeleteSelectedNote();
        }

        private void miNoteShow_Click(object sender, EventArgs e)
        {
            ShowSelectedNote();
        }

        private void miNoteShowAll_Click(object sender, EventArgs e)
        {
            ShowAllNotes();
        }

        private void miNoteCloseAll_Click(object sender, EventArgs e)
        {
            CloseAllNotes();
        }

        private void cmiNoteBringToFront_Click(object sender, EventArgs e)
        {
            foreach (var oEntry in Holder.TheForms)
            {
                FormNote oForm = oEntry.Value;
                oForm.Activate();
            }
        }

        private void cmiAddNote_Click(object sender, EventArgs e)
        {
            ShowWindow(false, true);
        }

        private void miOpen_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog();
            dlg.InitialDirectory = Environment.CurrentDirectory;
            dlg.CheckFileExists = true;
            dlg.Multiselect = false;
            dlg.DefaultExt = "xml";
            dlg.Filter = "XML files (*.xml)|*.xml|All files (*.*)|*.*";

            if (dlg.ShowDialog() == DialogResult.OK)
            {
                var notes = Settings.ReadAllNotes(dlg.FileName);
                Holder.TheNotes.ReCreate(notes);
                OpenInitialNotes();
            }
        }
    }
}
