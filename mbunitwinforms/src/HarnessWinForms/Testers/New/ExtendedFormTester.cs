using System;
using System.Windows.Forms;

namespace MbUnitWinForms.Testers.New
{
    public class ExtendedFormTester : ControlTester<Form, ExtendedFormTester>, IDisposable
    {
        private bool _closed;

        public ExtendedFormTester()
        {
        }

        public ExtendedFormTester(string name) : base(name)
        {

        }

        public ExtendedFormTester(ExtendedFormTester tester, int index) : base(tester, index)
        {
            
        }

        public void Dispose()
        {
            if (!_closed)
            {
                Close();
            }
        }

        /// <summary>
        /// Closes this form.
        /// </summary>
        public void Close()
        {
            Properties.Close();
            _closed = true;
        }
    }
}