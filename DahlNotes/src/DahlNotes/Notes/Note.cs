using System.Drawing;

namespace DahlNotes.Notes
{
    /// <summary>
    /// The Note.
    /// </summary>
    public class Note
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class. 
        /// Used when creating new Note
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="noteText">the text</param>
        /// <param name="backColor">window background color</param>
        /// <param name="textColor">text color</param>
        /// <param name="textFont">text font</param>
        /// <param name="opacity">window opacity</param>
        /// <param name="alwaysOnTop">Window always on top</param>
        public Note(int id, string noteText, Color backColor, Color textColor, Font textFont, int opacity, bool alwaysOnTop)
        {
            Id = id;
            NoteText = noteText;
            BackColor = backColor;
            TextColor = textColor;
            TextFont = textFont;
            Opacity = opacity;
            AlwaysOnTop = alwaysOnTop;

            Location = new Point(30, 30);   // x, y
            Size = new Size(200, 120);      // w, h
            StartOpened = true;
            IsReadOnly = false;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Note"/> class. 
        /// Used when loading notes
        /// </summary>
        /// <param name="id">note id</param>
        /// <param name="noteText">the text</param>
        /// <param name="backColor">window background color</param>
        /// <param name="textColor">text color</param>
        /// <param name="textFont">text font</param>
        /// <param name="opacity">window opacity</param>
        /// <param name="alwaysOnTop">Window always on top</param>
        /// <param name="x">window x position</param>
        /// <param name="y">window y position</param>
        /// <param name="w">window width</param>
        /// <param name="h">window height</param>
        /// <param name="startOpened">Note opens when application starts</param>
        public Note(int id, string noteText, Color backColor, Color textColor, Font textFont, int opacity, bool alwaysOnTop, int x, int y, int w, int h, bool startOpened)
        {
            Id = id;
            NoteText = noteText;
            BackColor = backColor;
            TextColor = textColor;
            TextFont = textFont;
            Opacity = opacity;
            AlwaysOnTop = alwaysOnTop;

            Location = new Point(x, y); // x, y
            Size = new Size(w, h);      // w, h
            StartOpened = startOpened;
            IsReadOnly = false;
        }

        /// <summary>
        /// Gets or sets the id of the note
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the note text
        /// </summary>
        public string NoteText { get; set; }

        /// <summary>
        /// Gets or sets the background color for the window
        /// </summary>
        public Color BackColor { get; set; }

        /// <summary>
        /// Gets or sets the text color for the window
        /// </summary>
        public Color TextColor { get; set; }

        /// <summary>
        /// Gets or sets the text font for the window
        /// </summary>
        public Font TextFont { get; set; }

        /// <summary>
        /// Gets or sets the opacity for the window
        /// </summary>
        public int Opacity { get; set; }

        /// <summary>
        /// Gets or sets the location for the window
        /// </summary>
        public Point Location { get; set; }

        /// <summary>
        /// Gets or sets the size for the window
        /// </summary>
        public Size Size { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether note-window should open when program starts
        /// </summary>
        public bool StartOpened { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether note-window should be on top
        /// </summary>
        public bool AlwaysOnTop { get; set; }

        /// <summary>
        /// Gets or sets the dictionary this note belongs to
        /// </summary>
        public IdNotesDictionary Owner { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether this note is read only (i.e. shared)
        /// </summary>
        public bool IsReadOnly { get; set; }
    }
}
