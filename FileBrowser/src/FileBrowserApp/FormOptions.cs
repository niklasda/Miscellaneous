using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Nida.Dfb
{
    public partial class FormOptions : Form
    {
        public FormOptions()
        {
            InitializeComponent();
        }

        public FormOptions(string comparerApp, string renamerApp, string notepadApp) : this()
        {
            txtComparer.Text = comparerApp;
            txtRenamer.Text = renamerApp;
            txtNotepad.Text = notepadApp;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.RestoreDirectory = true;
            dlg.InitialDirectory = txtComparer.Text;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                txtComparer.Text = dlg.FileName.Trim();
            }
        }

        private void btnRenamer_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.RestoreDirectory = true;
            dlg.InitialDirectory = txtRenamer.Text;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                txtRenamer.Text = dlg.FileName.Trim();
            }
        }

        private void btnNotepad_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Multiselect = false;
            dlg.RestoreDirectory = true;
            dlg.InitialDirectory = txtNotepad.Text;
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                txtNotepad.Text = dlg.FileName.Trim();
            }
        }

        public string GetComparer()
        {
            return txtComparer.Text.Trim();
        }

        public string GetRenamer()
        {
            return txtRenamer.Text.Trim();
        }

        public string GetNotepad()
        {
            return txtNotepad.Text.Trim();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }
    }
}