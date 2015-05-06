using System;
using System.Collections.Generic;
using System.Windows.Forms;
using WatiN.Core;
using ZedGraph;
using Form = System.Windows.Forms.Form;

namespace ZedBoll
{
    public partial class Form1 : Form
    {
        private Browser _ie;
        private Timer _timer;
        private IList<RateData> _nl = new List<RateData>();
        private StockPointList _jp = new StockPointList();
        private long _start;

        public Form1()
        {
            InitializeComponent();
        }

        private void buttonPlot_Click(object sender, EventArgs e)
        {
            zed1.GraphPane.Title.Text = "EURUSD";
            zed1.GraphPane.XAxis.Title.Text = "Time";
            zed1.GraphPane.YAxis.Title.Text = "Rate";

            setCurve();
        }

        private void setCurve()
        {
            
            foreach (var rd in _nl)
            {

                _jp.Add(DateTime.Now.Ticks - _start, rd.High, rd.Low, rd.Open, rd.Last, 0.2);

            }
            JapaneseCandleStickItem bar2 = zed1.GraphPane.AddJapaneseCandleStick("Jps", _jp);

          //  jp.Add(5.5, 11, 7, 8, 9, 30);
          //  jp.Add(6, 12, 8, 9, 10, 40);
          //  jp.Add(6.5, 13, 9, 10, 11, 50);
           // JapaneseCandleStickItem bar2 = zed1.GraphPane.AddJapaneseCandleStick("Jps", _jp);
            zed1.AxisChange();
            zed1.Invalidate();
        }


        public Browser TheBrowser
        {
            get
            {
                if (_ie == null)
                {
                    _ie = new IE(new Uri("http://www.fxstreet.com/rates-charts/forex-rates/"));
                }
                return _ie;
            }
        }

        private RateData GetSomeData()
        {
            try
            {
                Div rates = TheBrowser.Div(Find.ById("GraphContainer"));
                TableCell eurusd = rates.TableCell(Find.ByText("EUR/USD"));
                TableRow eur = (TableRow)eurusd.Parent;
                string last = eur.OwnTableCell("last_3212164").Text;
                var open = eur.OwnTableCell("open_3212164").Text;
                var high = eur.OwnTableCell("high_3212164").Text;
                var low = eur.OwnTableCell("low_3212164").Text;
                var change = eur.OwnTableCell("change_3212164").Text;
                var percent = eur.OwnTableCell("changePercent_3212164").Text;
                var date = eur.OwnTableCell("dateTime_3212164").Text;

                var us = System.Globalization.CultureInfo.GetCultureInfo(1033).NumberFormat;
                var r = new RateData(double.Parse(last, us), double.Parse(open, us), double.Parse(high, us), double.Parse(low, us), change, percent, DateTime.Parse(date));
                return r;
            }
            catch
            {
                return null;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings.AutoMoveMousePointerToTopLeft = false;

            _start = DateTime.Now.Ticks;

            _timer = new Timer();
            _timer.Interval = 2000;
            _timer.Tick += new EventHandler(timer_Tick);
            _timer.Start();
        }

        void timer_Tick(object sender, EventArgs e)
        {
            RateData r = GetSomeData();
            if (r != null)
            {
                _nl.Add(r);
                setCurve();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _timer.Stop();
        }
    }
}
