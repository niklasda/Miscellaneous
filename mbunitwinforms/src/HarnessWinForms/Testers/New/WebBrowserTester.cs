using System;
using System.Windows.Forms;

namespace MbUnitWinForms.Testers.New
{
    /// <summary>
    /// Utility class helping out for handling WebBrowser
    /// </summary>
    public class WebBrowserTester : ControlTester<WebBrowser, WebBrowserTester>
    {
        public WebBrowserTester(string name, string formName)
            : base(name, formName)
        {
        }

        public WebBrowserTester(string name, Form form)
            : base(name, form)
        {
        }

        public WebBrowserTester(string name)
            : base(name)
        {
        }

        public WebBrowserTester(ControlTester<WebBrowser, WebBrowserTester> tester, int index)
            : base(tester, index)
        {
        }

        public WebBrowserTester()
        {
            // should throw something, mayve from base.base

            //throw new NotImplementedException();
        }

        /// <summary>
        /// Returns the WebBrowser object
        /// </summary>
        public new WebBrowser Properties
        {
            get { return base.Properties; }
        }
    }
}