using System;
using System.Windows.Forms;


namespace MbUnitWinForms.Testers.New
{
    public class DateTimePickerTester : ControlTester<DateTimePicker, DateTimePickerTester>
    {
        public DateTimePickerTester(string name, string formName)
            : base(name, formName)
        {
        }

        public DateTimePickerTester(string name, Form form)
            : base(name, form)
        {
        }

        public DateTimePickerTester(string name)
            : base(name)
        {
        }

        public DateTimePickerTester(ControlTester<DateTimePicker, DateTimePickerTester> tester, int index)
            : base(tester, index)
        {
        }

        public DateTimePickerTester()
        {
        }

        /// <summary>
        /// returns the DateTimePicker
        /// </summary>
        public new DateTimePicker Properties
        {
            get { return base.Properties as DateTimePicker; }
        }

        /// <summary>
        /// Get the amount as text
        /// </summary>
        /// <returns></returns>
        public string GetDate()
        {
            return Properties.Text;
        }

        /// <summary>
        /// set the amount
        /// </summary>
        /// <returns></returns>
        public void SetDate(string date)
        {
            //  Control ctrl = Properties.Controls[1];

            Properties.Value = DateTime.Parse(date);
            //Properties.Text = amount;

            //   var tb = (TextBox) ctrl;
            //   tb.Text = amount;
        }
    }
}