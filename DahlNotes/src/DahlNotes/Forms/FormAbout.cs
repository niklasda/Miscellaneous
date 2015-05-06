using System;
using System.Diagnostics;
using System.Windows.Forms;
using DahlNotes.Configuration;

namespace DahlNotes.Forms
{
    /// <summary>
    /// Code for the About-box
    /// </summary>
    public partial class FormAbout : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="FormAbout"/> class. 
        /// </summary>
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            lblAbout.Text = Settings.ApplicationName + Environment.NewLine + Environment.NewLine + "Copyright (C) 2004-2013" + Environment.NewLine + Environment.NewLine + "by Dahlman Labs";
        }

        private void lnkDg_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                Process.Start("http://dahlman.biz/");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to launch site!" + Environment.NewLine + ex.Message, Settings.ApplicationName);
            }
        }
    }
}
