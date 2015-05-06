using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ComLister
{
    public partial class VariableExpanderForm : Form
    {
        public VariableExpanderForm()
        {
            InitializeComponent();
        }

        private void VariableExpanderForm_Load(object sender, EventArgs e)
        {
            /*cbbVariables.Items.Clear();
            cbbVariables.Items.Add("%ALLUSERSPROFILE%");
            cbbVariables.Items.Add("%PROGRAMDATA%");
            cbbVariables.Items.Add("%APPDATA%");
            cbbVariables.Items.Add("%COMPUTERNAME%");
            cbbVariables.Items.Add("%COMMONPROGRAMFILES%");
            cbbVariables.Items.Add("%COMMONPROGRAMFILES(x86)%");
            cbbVariables.Items.Add("%COMSPEC%");
            cbbVariables.Items.Add("%HOMEDRIVE%");
            cbbVariables.Items.Add("%HOMEPATH%");
            cbbVariables.Items.Add("%PATH%");
            cbbVariables.Items.Add("%PATHEXT%");
            cbbVariables.Items.Add("%PROGRAMFILES%");
            cbbVariables.Items.Add("%PROGRAMFILES(X86)%");
            cbbVariables.Items.Add("%PROMPT%");
            cbbVariables.Items.Add("%SYSTEMDRIVE%");
            cbbVariables.Items.Add("%SystemRoot%");
            cbbVariables.Items.Add("%TEMP%");
            cbbVariables.Items.Add("%USERNAME%");
            cbbVariables.Items.Add("%USERPROFILE%");
            cbbVariables.Items.Add("%WINDIR%");
            cbbVariables.Items.Add("%PUBLIC%");
            cbbVariables.Items.Add("%PSModulePath%");*/

            cbbVariables.Items.Clear();
            IDictionary envVars = Environment.GetEnvironmentVariables();
            foreach (DictionaryEntry envVar in envVars)
            {
                cbbVariables.Items.Add("%" + envVar.Key + "%");
            }
        }

        private void btnExpand_Click(object sender, EventArgs e)
        {
            string source = cbbVariables.Text;
            string dest = Environment.ExpandEnvironmentVariables(source);
            txtResult.Text = dest;
        }

        private void cbbVariables_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Return)
            {
                btnExpand.Select();
                btnExpand_Click(sender, EventArgs.Empty);
            }
        }
    }
}
