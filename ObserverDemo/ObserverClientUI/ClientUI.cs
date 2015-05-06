using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ObserverDemo
{
    public partial class ClientUI : Form
    {
        public ClientUI()
        {
            InitializeComponent();
        }

        private void bCreatePerson_Click(object sender, EventArgs e)
        {
            Person p = new Person("Niklas");
            p.OnNameChanged += new PersonEventHandler(p_OnNameChanged);
        }

        private void p_OnNameChanged(string name)
        {
            tbName.Text = name;
        }
    }
}