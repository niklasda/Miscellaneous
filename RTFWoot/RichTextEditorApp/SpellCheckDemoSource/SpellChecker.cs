using System.Reflection;
using Microsoft.Office.Interop.Word;

namespace SpellCheckDemo
{
    public class SpellChecker
    {
        public string CheckSpelling(string textToCheck)
        {
            string result;

            int iErrorCount = 0;
            Application app = new Application();
            if (textToCheck.Length > 0)
            {
                app.Visible = false;
                // Setting these variables is comparable to passing null to the function. 
                // This is necessary because the C# null cannot be passed by reference.
                object template = Missing.Value;
                object newTemplate = Missing.Value;
                object documentType = Missing.Value;
                object visible = false;
                object optional = Missing.Value;

                _Document doc = app.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
                doc.Words.First.InsertBefore(textToCheck);
                ProofreadingErrors we = doc.SpellingErrors;
                iErrorCount = we.Count;

                doc.CheckSpelling(ref optional, ref optional, ref optional, ref optional,
                    ref optional, ref optional, ref optional,
                    ref optional, ref optional, ref optional, ref optional, ref optional);

                if (iErrorCount == 0)
                    result = "Spelling OK. No errors corrected ";
                else if (iErrorCount == 1)
                    result = "Spelling OK. 1 error corrected ";
                else
                    result = "Spelling OK. " + iErrorCount + " errors corrected ";
                object first = 0;
                object last = doc.Characters.Count - 1;

//                tBox.Text = doc.Range(ref first, ref last).Text;
            }
            else
                result = "Textbox is empty";

            object saveChanges = false;
            object originalFormat = Missing.Value;
            object routeDocument = Missing.Value;
            app.Quit(ref saveChanges, ref originalFormat, ref routeDocument);

            return result;
        }
    }
}