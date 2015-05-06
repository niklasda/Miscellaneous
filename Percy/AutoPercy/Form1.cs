using System;
using System.Windows.Forms;
using AutoPercy.Logic;
using Clz.Logic;

namespace AutoPercy
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void buttonOpen_Click(object sender, EventArgs e)
        {
            PercyManager pm = PercyManager.Instance;
            pm.OpenSite();
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            PercyManager pm = PercyManager.Instance;
            pm.Login();
        }

        private void buttonLogout_Click(object sender, EventArgs e)
        {
            PercyManager pm = PercyManager.Instance;
            pm.Logout();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            PercyManager pm = PercyManager.Instance;
            pm.GotoAddBook();
        }

        private void buttonBookStep1_Click(object sender, EventArgs e)
        {
            PercyManager pm = PercyManager.Instance;
            pm.AddBookStep1("author", "title", "1973", "publisher", "Inbunden", "isbn", "99", "originalTitle", "1", "subTitle", "locClassification", "124", "language", "owner");
        }

        private void buttonBookStep2_Click(object sender, EventArgs e)
        {
            PercyManager pm = PercyManager.Instance;
            pm.AddBookStep2();
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            ClzManager clz = ClzManager.Instance;
            clz.StartApp();
        }

        private void buttonSwe_Click(object sender, EventArgs e)
        {
            ClzManager clz = ClzManager.Instance;
            clz.OpenBookOne("Svenska (698)");
        }

        private void buttonGooglePurse_Click(object sender, EventArgs e)
        {
            ClzManager clz = ClzManager.Instance;
            clz.GoogleCurrent();
        }

        private void buttonFindCover_Click(object sender, EventArgs e)
        {
            ClzManager clz = ClzManager.Instance;
            clz.SearchForCoverOnCurrent();
        }

        private void buttonGotoNext_Click(object sender, EventArgs e)
        {
            ClzManager clz = ClzManager.Instance;
            clz.EditNextBook();
        }
    }
}
