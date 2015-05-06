using System;
using System.Windows.Forms;

namespace MbUnitWinForms.Testers.New
{
    public class ScrollBarTester : ControlTester<ScrollBar, ScrollBarTester>
    {
        public ScrollBarTester(string name, string formName)
            : base(name, formName)
        {
        }

        public ScrollBarTester(string name, Form form)
            : base(name, form)
        {
        }

        public ScrollBarTester(string name)
            : base(name)
        {
        }

        public ScrollBarTester(ControlTester<ScrollBar, ScrollBarTester> tester, int index)
            : base(tester, index)
        {
        }

        public ScrollBarTester()
        {
        }

        /// <summary>
        /// returns the VScrollBar or HScrollBar as a ScrollBar
        /// </summary>
        public new ScrollBar Properties
        {
            get
            {
                return base.Properties as ScrollBar;
            }
        }

        /// <summary>
        /// Move the scrollbar
        /// </summary>
        /// <returns></returns>
        public void Scroll(int val)
        {
            Properties.Value = val;
        }

    }
}