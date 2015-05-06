using System;
using System.Windows.Forms;

namespace GcTimer
{
    public class TimerHolder
    {
        private Timer _timer;
        public void TakeTime(frmGcTimers timerFrm)
        {
            
                _timer = new Timer();
                _timer.Enabled = true;
                _timer.Interval = 1000 ;
                _timer.Tag = "timer_" ;
                _timer.Tick += timer_Tick;
                _timer.Start();
            
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            // Timer t = (Timer)sender;
            // frmGcTimers tag = (frmGcTimers)t.Tag;
            // tag.lblUpdates.Text = i++.ToString();
            stop();
            //            i++;
            //lblUpdates.Text = t.Tag.ToString();
        }

        private void stop()
        {
            Console.WriteLine(_timer.Tag.ToString());
            _timer.Stop();

        }

       // private static int ick = 0;
    }
}