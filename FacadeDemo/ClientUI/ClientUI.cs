using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Xml;
using System.Windows.Forms;

namespace FacadeDemo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void bCreatePerson_Click(object sender, EventArgs e)
        {
            PersonFactory pf = new PersonFactory();
            Person p = pf.CreatePersonFromXml( new XmlTextReader(@"C:\Niklas.xml") );
        }
    }
}