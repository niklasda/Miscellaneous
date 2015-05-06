using System;
using System.Collections.Generic;

namespace DahlNotes.Notes
{
    public delegate void NotesChangedEventHandler(object sender, EventArgs e);

    public enum NotesChangedType
    {
        Add,
        Edit,
        Remove,
        Clear,
        ReCreate
    }

    public class NotesChangedEventArgs : EventArgs
    {
        public NotesChangedEventArgs(NotesChangedType changeType)
        {
            _changeType = changeType;
        }

        private NotesChangedType _changeType;
        public NotesChangedType ChangedType { get { return _changeType; } }

        public static NotesChangedEventArgs Add
        {
            get { return new NotesChangedEventArgs(NotesChangedType.Add); }
        }

        public static NotesChangedEventArgs Edit
        {
            get { return new NotesChangedEventArgs(NotesChangedType.Edit); }
        }
        
        public static NotesChangedEventArgs Remove
        {
            get { return new NotesChangedEventArgs(NotesChangedType.Remove); }
        }
        
        public static NotesChangedEventArgs Clear
        {
            get { return new NotesChangedEventArgs(NotesChangedType.Clear); }
        }
        
        public static NotesChangedEventArgs ReCreate
        {
            get { return new NotesChangedEventArgs(NotesChangedType.ReCreate); }
        }

    }

    /// <summary>
    /// Dictionary for Note objects.
    /// i.e. all the loaded Notes
    /// </summary>
    public class IdNotesDictionary
    {
        private readonly Dictionary<int, Note> _notes = new Dictionary<int, Note>();

        /// <summary>
        ///  Add Note to dictionary
        /// </summary>
        /// <param name="note">the Note</param>
        public void Add(Note note)
        {
            _notes.Add(note.Id, note);
            note.Owner = this;
            OnNotesChanged(NotesChangedEventArgs.Add);
        }

        /// <summary>
        /// Add a shared (i.e. read only) note (i.e. id is irrelevand and possibly duplicate)
        /// </summary>
        /// <param name="note"></param>
        private void AddShared(Note note)
        {
            note.Id = GetMaxKey() + 1;
            Add(note);
        }

        private int GetMaxKey()
        {
            int maxId = 0;

            foreach (var oItem in _notes)
            {
                var id = oItem.Key;
                if (id > maxId)
                {
                    maxId = id;
                }
            }

            return maxId;
        }

        private void Clear()
        {
            _notes.Clear();
        }

        public void Remove(Note note)
        {
            _notes.Remove(note.Id);
            note.Owner = null;
            OnNotesChanged(NotesChangedEventArgs.Remove);
        }

        private void OnNotesChanged(NotesChangedEventArgs e)
        {
            if (NotesChanged != null)
            {
                NotesChanged(this, e);
            }
        }

        public event NotesChangedEventHandler NotesChanged;

        public void ReCreate(IdNotesDictionary notes)
        {
            Clear();
            foreach (var note in notes._notes)
            {
                _notes.Add(note.Value.Id, note.Value);
            }
            OnNotesChanged(NotesChangedEventArgs.ReCreate);
        }

        public IReadOnlyDictionary<int, Note> TheNotes
        {
            get { return _notes; }
        }

        public void Edited()
        {
            OnNotesChanged(NotesChangedEventArgs.Edit);
        }

        /// <summary>
        /// Add a dictionary of shared (i.e. read only) notes to this dictionary
        /// </summary>
        /// <param name="sharedNotes"></param>
        /// <returns></returns>
        public IdNotesDictionary AddSharedNotes(IdNotesDictionary sharedNotes)
        {
            foreach (var kvpNote in sharedNotes.TheNotes)
            {
                this.AddShared(kvpNote.Value);
            }

            return this;
        }
    }
}
