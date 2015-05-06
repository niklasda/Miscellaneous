
using System.Windows.Forms;

namespace Dahlex
{
    public partial class fHelp : Form
    {
        public fHelp()
        {
            InitializeComponent();
        }

        private static fHelp help = new fHelp();
        public static void ShowMe()
        {
            if (!help.Visible)
            {
                help.Show();
            }
            else
            {
                help.Activate();
            }
        }

        private void bClose_Click(object sender, System.EventArgs e)
        {
            help.Hide();
        }
    }
}