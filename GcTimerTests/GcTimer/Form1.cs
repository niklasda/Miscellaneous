using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace GcTimer
{
    public partial class frmGcTimers : Form
    {
        public frmGcTimers()
        {
            InitializeComponent();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                TimerHolder th = new TimerHolder();
                th.TakeTime(this);
            }
        }
    }
}
