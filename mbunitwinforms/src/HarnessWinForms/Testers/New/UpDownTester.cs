using System;
using System.Windows.Forms;

namespace MbUnitWinForms.Testers.New
{
    /// <summary>
    /// Class to handle Up/Down controls
    /// </summary>
    public class UpDownTester : ControlTester<UpDownBase, UpDownTester>
    {
        public UpDownTester(string name, string formName)
            : base(name, formName)
        {
        }

        public UpDownTester(string name, Form form)
            : base(name, form)
        {
        }

        public UpDownTester(string name)
            : base(name)
        {
        }

        public UpDownTester(ControlTester<UpDownBase, UpDownTester> tester, int index)
            : base(tester, index)
        {
        }

        public UpDownTester()
        {
        }

        /// <summary>
        /// returns the AmountUpDown as a UpDownBase
        /// </summary>
        public new UpDownBase Properties
        {
            get
            {
                return base.Properties;
            }
        }

        /// <summary>
        /// Get the amount as text
        /// </summary>
        /// <returns></returns>
        public string GetAmount()
        {
            Control ctrl = Properties.Controls[1];
            if(ctrl is UpDownBase)
            {
                ctrl = ctrl.Controls[1];
            }
            var tb = (TextBox) ctrl;

            return tb.Text;
        }

        /// <summary>
        /// set the amount
        /// </summary>
        /// <returns></returns>
        public void SetAmount(string amount)
        {
            Control ctrl = Properties.Controls[1];
            if (ctrl is UpDownBase)
            {
                ctrl = ctrl.Controls[1];
            } 
            var tb = (TextBox)ctrl;
            tb.Text = amount;
        }
    }
}