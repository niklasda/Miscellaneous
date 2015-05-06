using DahlNotes.Notes;

namespace DahlNotes.Forms
{
    /// <summary>
    /// Interface implemented by configuration form to be used by other forms
    /// </summary>
    public interface IFormDahlNotesConfiguration
    {
        /// <summary>
        /// Show the configuration form, and if specified minimize it or add new note
        /// </summary>
        /// <param name="stayHidden">Should the window stay hidden.</param>
        /// <param name="addNote">Should Add Note window open.</param>
        void ShowWindow(bool stayHidden, bool addNote);

        /// <summary>
        /// Applies changes made to a Note in a NoteProperties form
        /// </summary>
        /// <param name="updatedNote">Updated Note object</param>
        /// <param name="isClosing">Is the update caused by closing</param>
        /// <returns>True if saved, false if no need to save</returns>
        bool UpdateNote(Note updatedNote, bool isClosing);
    }
}
/*
todo
----
remove this interface
have all redrawing in event
edit event
*/