using DahlNotes.Notes;

namespace DahlNotes.Logic
{
    /// <summary>
    /// Holds the global lists of note and forms
    /// </summary>
    public class Holder
    {
        private static readonly IdNotesDictionary _dicNotes = new IdNotesDictionary();
        private static readonly IdFormsDictionary _dicOpenNotes = new IdFormsDictionary();
        private static ProblemType _problem = ProblemType.None;

        public static IdNotesDictionary TheNotes
        {
            get { return _dicNotes; }
        }

        public static IdFormsDictionary TheForms
        {
            get { return _dicOpenNotes; }
        }

        public static ProblemType Problem
        {
            get { return _problem; }
            set { _problem = value; }
        }
    }
}