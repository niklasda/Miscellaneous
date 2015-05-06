using System.Drawing;

namespace Mockdemo.BusinessClasses
{
    public interface IViewUI
    {

        void DrawInTextBox(string s, Font f, Color color, int px, int py);
        void AppendToTextBox(string s);
        void AppendToTextBox(double d); // to test nmock ranged constraints
    }
}
