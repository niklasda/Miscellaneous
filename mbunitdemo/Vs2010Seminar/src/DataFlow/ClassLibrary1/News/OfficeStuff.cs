using System.Reflection;
//using Word = Microsoft.Office.Interop.Word;

namespace ClassLibrary1.News
{
    public class OfficeStuff
    {
        public string MyMethod(string name, int age = 30)
        {
            return string.Format("Name:{0} Age:{1}", name, age);
        }

        public void WordMethod()
        {
            //var word = new Word.Application();
            //word.Visible = true;
            //Word.Document document = word.Documents.Add();
            //document.Range().Text = "sdfsdf";
            //document.Close(SaveChanges: false);
            //word.Quit();
        }

        public static void OldWordMethod()
        {
            //object missingValue = Missing.Value;
            //object saveChanges = false;

            //var word = new Word.Application();
            //word.Visible = true;
            //Word.Document document = word.Documents.Add(ref missingValue, ref missingValue, ref missingValue, ref missingValue);
            //document.Range(ref missingValue, ref missingValue).Text = "sdfsdf";
            //document.Close(ref saveChanges, ref missingValue, ref missingValue);
            //word.Quit(false, ref missingValue, ref missingValue);

        }
    }
}