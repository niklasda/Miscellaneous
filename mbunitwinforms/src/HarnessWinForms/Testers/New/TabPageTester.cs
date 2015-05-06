using System;
using System.Windows.Forms;

namespace MbUnitWinForms.Testers.New
{
    public class TabPageTester : ControlTester<TabPage, TabPageTester>
    {
        public TabPageTester(string name, string formName)
            : base(name, formName)
        {
        }

        public TabPageTester(string name, Form form)
            : base(name, form)
        {
        }

        public TabPageTester(string name)
            : base(name)
        {
        }

        public TabPageTester(ControlTester<TabPage, TabPageTester> tester, int index)
            : base(tester, index)
        {
        }

        public TabPageTester()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get the Current Tab Page
        /// </summary>
        public new TabPage Properties
        {
            get { return base.Properties; }
        }
    }
}