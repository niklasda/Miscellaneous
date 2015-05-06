using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DahlNotes.Notes;

namespace DahlNotes.Tests.Notes
{
    [TestClass]
    public class NoteTests
    {
        [TestMethod]
        public void CreateNoteTest()
        {
            var oFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point);
            var oNote = new Note(1, "note", Color.Black, Color.White, oFont, 90, false);

            Assert.AreEqual(1, oNote.Id);
            Assert.AreEqual("note", oNote.NoteText);
            Assert.AreEqual(Color.Black, oNote.BackColor);
            Assert.AreEqual(Color.White, oNote.TextColor);
            Assert.AreEqual(true, oNote.StartOpened);
            Assert.AreEqual(90, oNote.Opacity);
            Assert.AreEqual(false, oNote.AlwaysOnTop);
        }

        [TestMethod]
        public void IdNotesDictionaryOneItemTest()
        {
            var oFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point);
            var oNote1 = new Note(1, "note1", Color.Black, Color.White, oFont, 90, false);

            var nd = new IdNotesDictionary();
            nd.Add(oNote1);

            Assert.AreEqual(true, nd.TheNotes.ContainsKey(1));
            Assert.AreEqual(1, nd.TheNotes.Count);
        }

        [TestMethod]
        public void IdNotesDictionaryManyItemsTest()
        {
            var oFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point);
            var oNote1 = new Note(1, "note1", Color.Black, Color.White, oFont, 90, false);
            var oNote2 = new Note(2, "note2", Color.Black, Color.White, oFont, 90, false);
            var oNote3 = new Note(3, "note3", Color.Black, Color.White, oFont, 90, false);

            var nd = new IdNotesDictionary();
            nd.Add(oNote1);
            nd.Add(oNote2);
            nd.Add(oNote3);

            Assert.AreEqual(true, nd.TheNotes.ContainsKey(1));
            Assert.AreEqual(true, nd.TheNotes.ContainsKey(2));
            Assert.AreEqual(true, nd.TheNotes.ContainsKey(3));
            Assert.AreEqual(3, nd.TheNotes.Count);
        }

        [TestMethod]
        public void IdFormsDictionaryOneItemTest()
        {
            var oFont = new Font("Microsoft Sans Serif", 9F, FontStyle.Italic, GraphicsUnit.Point);
            var oNote1 = new Note(1, "note1", Color.Black, Color.White, oFont, 90, false);

            var nd = new IdFormsDictionary();
            nd.Add(oNote1.Id, null);

            Assert.AreEqual(true, nd.ContainsKey(1));
            Assert.AreEqual(1, nd.Count);
        }
    }
}
