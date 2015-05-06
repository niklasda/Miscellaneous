using System;
using System.Drawing;
using Mockdemo.BusinessClasses;

namespace Mockdemo.BusinessLogic
{
    public class UiRenderer
    {
        public void DrawString(IViewUI view, string p, Color color, int px, int py)
        {
            FontManager fm = new FontManager();
            Font f = fm.GetDefaultFont();

            view.DrawInTextBox("Demo", f, color, px, py);
        }

        public void AppendString(IViewUI view, string s, bool addNewLine)
        {
            view.AppendToTextBox(s);
            if (addNewLine)
            {
                view.AppendToTextBox(Environment.NewLine);
            }
        }

        public void AppendString(IViewUI view, double d, bool addNewLine)
        {
            view.AppendToTextBox(d);
            if (addNewLine)
            {
                view.AppendToTextBox(Environment.NewLine);
            }
        }
    }
}
