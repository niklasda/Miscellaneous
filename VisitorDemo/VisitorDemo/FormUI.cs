using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace VisitorDemo
{
    public partial class FormUI : Form, IFormUI
    {
        public FormUI()
        {
            InitializeComponent();
        }

        // approach 1
        // the Person controls the printing
        
        public void AppendString(string test)
        {
            tbOutput.AppendText(test);
        }
        public void PrintString(string test)
        {
            tbOutput.Text = test;
        }

        // approach 2
        // the UI controls the printing

        public void PrintPerson(Person pers)
        {
            tbOutput.AppendText(pers.FirstName);
            tbOutput.AppendText(" ");
            tbOutput.AppendText(pers.LastName);
        }

    }
}