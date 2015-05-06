using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Cert70566
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();

            maskedTextBox1.Multiline = true;
        }

        private void maskedTextBox1_Validated(object sender, EventArgs e)
        {
            errorProvider1.SetError(maskedTextBox1, "");
        }

        private void maskedTextBox1_Validating(object sender, CancelEventArgs e)
        {
            try
            {
                object obj = maskedTextBox1.ValidateText();
                if (obj == null)
                {
                    errorProvider1.SetError(maskedTextBox1, "fail");
                    e.Cancel = true;
                }
            }
            catch (Exception ex)
            {
                errorProvider1.SetError(maskedTextBox1, ex.Message);
                e.Cancel = true;
            }
        }

        private void fileSystemWatcher1_Created(object sender, FileSystemEventArgs e)
        {
            textBox1.Text = e.FullPath;
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormPrint frm = new FormPrint();
            frm.ShowDialog();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog(this);
        }

        private void helpToolStripButton_Click(object sender, EventArgs e)
        {
            AboutBox box = new AboutBox();
            box.ShowDialog(this);
        }

        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            FormPrint frm = new FormPrint();
            frm.ShowDialog();
        }

        private void printToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormPrint frm = new FormPrint();
            frm.ShowDialog();
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings = new PageSettings();
            printDocument.PrinterSettings = new PrinterSettings();
            printDocument.PrintPage += printDocument_PrintPage;

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Niklas tests", new Font("Courier New", 36), new SolidBrush(Color.Black), 40, 40);
            e.Graphics.DrawRectangles(new Pen(Color.Red), new[] { new RectangleF(20, 20, 700, 100) });
        }
    }
}