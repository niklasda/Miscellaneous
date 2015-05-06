using System;
using System.Collections.Generic;
using System.Xml;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Windows.Forms;
using System.Threading;
using Microsoft.Reporting.WinForms;

namespace Dotway.Demo
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnWait_Click(object sender, EventArgs e)
        {
            List<WaitHandle> waitHandlers = new List<WaitHandle>();

            IAsyncResult asyncResult = DbWaiter.BeginLoad(new AsyncCallback(receivedCallback), this);
            waitHandlers.Add(asyncResult.AsyncWaitHandle);
        }

        void receivedCallback(IAsyncResult ar)
        {
            XmlDocument doc = DbWaiter.EndLoad(ar);
            if (doc == null)
            {
                MessageBox.Show("nothing yet");
            }
            else
            {
                MessageBox.Show(doc.OuterXml);
            }
            Form1 f = (Form1)ar.AsyncState;
            Console.Write("hej");
  //          f.showStuff(); 
        } 

        private void showStuff()
        {
            reportViewer1.ProcessingMode = ProcessingMode.Local;
            reportViewer1.LocalReport.ReportPath = @"C:\Rosario\Projects\Demo Report\Demo Report\ReportStage2.rdl";

            reportViewer1.LocalReport.DataSources.Add(getDataSource());

            this.reportViewer1.RefreshReport();
        }


        ReportDataSource getDataSource()
        {
            SqlConnection cn = new SqlConnection("SERVER=.;DATABASE=DemoStage2;Trusted_Connection=yes;");
            cn.Open();

            SqlCommand cmDel = new SqlCommand("SELECT * FROM People;", cn);
            SqlDataReader rd = cmDel.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(rd);

            rd.Close();
            cn.Close();

            return new ReportDataSource("dsStage2", dt);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showStuff();
           int ? res = test(true, false,1,2,3);

        }

        private int? test(bool a, bool c, int? b, int? d, int? e)
        {
            return a ? b ?? e : a&&!c ? d ?? e : e ?? d;
        }
    }
}