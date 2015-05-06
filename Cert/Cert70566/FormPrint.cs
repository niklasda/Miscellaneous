using System;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Cert70566
{
    public partial class FormPrint : Form
    {
        public FormPrint()
        {
            InitializeComponent();
        }

        private void buttonSetup_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();

            printDocument.DefaultPageSettings = new PageSettings();
            printDocument.PrinterSettings = new PrinterSettings();
            printDocument.PrintPage += printDocument_PrintPage;

            PageSetupDialog pageSetupDialog = new PageSetupDialog();
            pageSetupDialog.AllowMargins = true;
            pageSetupDialog.AllowOrientation = true;
            pageSetupDialog.AllowPaper = true;
            pageSetupDialog.AllowPrinter = true;
            pageSetupDialog.EnableMetric = true;
            pageSetupDialog.ShowHelp = true;
            pageSetupDialog.ShowNetwork = true;
            pageSetupDialog.HelpRequest += printDialog_HelpRequest;

            pageSetupDialog.Document = printDocument;
            pageSetupDialog.ShowDialog();
        }

        private void buttonPreview_Click(object sender, EventArgs e)
        {
            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings = new PageSettings();
            printDocument.PrinterSettings = new PrinterSettings();
            printDocument.PrintPage += printDocument_PrintPage;

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;
            printPreviewDialog.ShowDialog();
        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            PrintDialog printDialog = new PrintDialog();
            printDialog.AllowCurrentPage = true;
            printDialog.AllowPrintToFile = true;
            printDialog.AllowSelection = true;
            printDialog.AllowSomePages = true;
            printDialog.ShowHelp = true;
            printDialog.ShowNetwork = true;
            printDialog.HelpRequest += printDialog_HelpRequest;

            PrintDocument printDocument = new PrintDocument();
            printDocument.DefaultPageSettings = new PageSettings();
            printDocument.PrinterSettings = new PrinterSettings();
            printDocument.PrintPage += printDocument_PrintPage;

            PrintPreviewDialog printPreviewDialog = new PrintPreviewDialog();
            printPreviewDialog.Document = printDocument;

            printDialog.ShowDialog();
        }

        private void printDialog_HelpRequest(object sender, EventArgs e)
        {
            MessageBox.Show("Fubar");
        }

        private void printDocument_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawString("Niklas tests", new Font("Courier New", 36), new SolidBrush(Color.Black), 40, 40);
            e.Graphics.DrawRectangles(new Pen(Color.Red), new[] { new RectangleF(20, 20, 100, 100) });
        }
    }
}