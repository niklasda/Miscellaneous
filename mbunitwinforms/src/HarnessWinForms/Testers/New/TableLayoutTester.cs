using System;
using System.Windows.Forms;

namespace MbUnitWinForms.Testers.New
{
    public class TableLayoutTester : ControlTester<TableLayoutPanel, TableLayoutTester>
    {
        public TableLayoutTester(string name, string formName)
            : base(name, formName)
        {
        }

        public TableLayoutTester(string name, Form form)
            : base(name, form)
        {
        }

        public TableLayoutTester(string name)
            : base(name)
        {
        }

        public TableLayoutTester(ControlTester<TableLayoutPanel, TableLayoutTester> tester, int index)
            : base(tester, index)
        {
        }

        public TableLayoutTester()
        {
        }

        /// <summary>
        /// returns the VScrollBar or HScrollBar as a ScrollBar
        /// </summary>
        public new TableLayoutPanel Properties
        {
            get
            {
                return base.Properties as TableLayoutPanel;
            }
        }

//        /// <summary>
//        /// Move the scrollbar
//        /// </summary>
//        /// <returns></returns>
//        public void Scroll(int x, int y)
//        {
//            Properties.GetControlFromPosition(x, y);
//        }

    }
}