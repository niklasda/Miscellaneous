using System;
using System.Collections.Generic;
using System.Windows.Forms;
using nida.model;

namespace WinClient
{
    public partial class ClientForm : Form
    {
        public ClientForm()
        {
            InitializeComponent();
        }

        private void bList_Click(object sender, EventArgs e)
        {
            IUserHandler handler = new UserHandlerCache();
            List<MyParent> parents = handler.RetrieveParents();

            dgvUsers.DataSource = parents;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            IUserHandler handler = new UserHandlerCache();
            int id = int.Parse(txtCreateId.Text);
            string name = txtCreateName.Text;
            handler.Create(id, name);
        }

        private void bDelete_Click(object sender, EventArgs e)
        {
            IUserHandler handler = new UserHandlerCache();
            string id = txtDeleteId.Text;
            handler.Delete(id);
        }

        private void bListChildren_Click(object sender, EventArgs e)
        {
            IUserHandler handler = new UserHandlerCache();
           
            List<MyChild> children = handler.RetrieveChildren();

            dgvUsers.DataSource = children;
        }
    }
}