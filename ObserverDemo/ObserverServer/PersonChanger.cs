using System;
using System.Windows.Forms;

namespace ObserverDemo
{
    /// <summary>
    /// This class simulates that some other system isupdating our person
    /// </summary>
    public class PersonChanger
    {
        public PersonChanger(Person p)
        {
            person = p;

            timer = new Timer();
            timer.Interval = 2000;
            timer.Tag = 0;
            timer.Enabled = true;
            timer.Tick += new EventHandler(timer_Tick);
        }

        private Person person;
        private Timer timer;

        private void timer_Tick(object sender, EventArgs e)
        {
            int val = (int)timer.Tag;
            timer.Tag = ++val;
            person.Name = string.Format("Niklas.{0}", val.ToString());
        }
    }
}
