using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;
using WatiN.Core;
using Xceed.Chart.Core;
using Xceed.Chart.DataManipulation;
using Xceed.Chart.GraphicsCore;

namespace XceedBoll
{
    public partial class Form1 : System.Windows.Forms.Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private bool _emaAdded;
        private bool _smaAdded;
        private bool _bollAdded;

        private Chart _mChart;
        private StockSeries _mStock;
        private LineSeries _mLine;

        private LineSeries _mLineUpper;
        private LineSeries _mLineLower;
        private LineSeries _mLineSma;
        private LineSeries _mLineEma;

        private FunctionCalculator _mCalcBollingerUpper;
        private FunctionCalculator _mCalcBollingerLower;
        private FunctionCalculator _mCalcSma;
        private FunctionCalculator _mCalcEma;

        private NotifyingList<RateData> _nl;
        private Browser _ie;

        private void Form1_Load(object sender, EventArgs e)
        {
            SetupChartControl();
            SetupLineSeries();
            SetupStockSeries();
           // GenerateOHLCData(_mStock, 5);

            UpdateExpressions();
            CalculateFunctions();

            WatiN.Core.Settings.AutoMoveMousePointerToTopLeft = false;
            WatiN.Core.Settings.HighLightElement = false;
            WatiN.Core.Settings.WaitUntilExistsTimeOut = 2;

            _nl = new NotifyingList<RateData>();
            _nl.ItemAdded += q_ItemAdded;

            // Timer timer = new Timer();
            timer.Interval = 1500;
            timer.Tick += timer_Tick;
            timer.Enabled = true;
            timer.Start();
        }

        private void q_ItemAdded(object sender, EventArgs e)
        {
            RateData r = _nl[_nl.Count - 1];
            labelRate.Text = string.Format("{0}. {1} @ {2}", _nl.Count - 1, r.Last, r.Date);


            _mLine.AddXY(r.Last, r.Last);
            m_ChartControl.Refresh();

        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer.Stop();
            timer.Dispose();
            if (_ie != null)
            {
                _ie.Close();
            }

        }

        private void UpdateExpressions()
        {
            string sb;

            if (_bollAdded)
            {
                sb = string.Format("BOLLINGER(close; {0}; {1})", trackBarBollPeriod.Value, trackBarDeviation.Value);
                _mCalcBollingerUpper.Expression = sb;

                sb = string.Format("BOLLINGER(close; {0}; {1})", trackBarBollPeriod.Value, -trackBarDeviation.Value);
                _mCalcBollingerLower.Expression = sb;
            }

            if (_smaAdded)
            {
                sb = string.Format("SMA(close; {0})", trackBarSmaPeriod.Value);
                _mCalcSma.Expression = sb;
            }

            if (_emaAdded)
            {
                sb = string.Format("EMA(close; {0})", trackBarEmaPeriod.Value);
                _mCalcEma.Expression = sb;
            }
        }

        private void CalculateFunctions()
        {
            try
            {
                if (_bollAdded)
                {
                    _mLineUpper.Values = _mCalcBollingerUpper.Calculate();
                    _mLineLower.Values = _mCalcBollingerLower.Calculate();
                }
                if (_smaAdded)
                {
                    _mLineSma.Values = _mCalcSma.Calculate();
                }
                if (_emaAdded)
                {
                    _mLineEma.Values = _mCalcEma.Calculate();
                }
            }
            catch (FunctionException ex)
            {
                Debug.WriteLine(ex.Message);
            }
            finally
            {
                m_ChartControl.Refresh();
            }
        }

        private void GenerateOHLCData(StockSeries s, int nCount)
        {
            double prevclose = 1.0;
            var rnd = new Random();

            s.OpenValues.Clear();
            s.HighValues.Clear();
            s.LowValues.Clear();
            s.CloseValues.Clear();

            for (int nIndex = 0; nIndex < nCount; nIndex++)
            {
                double open = prevclose;

                double high;
                double low;
                double close;
                if (prevclose < 0.5 || rnd.NextDouble() > 0.5)  // upward price change
                {
                    close = open + ( (rnd.NextDouble() * 1.0));  // close
                    high = close + (rnd.NextDouble() * 1.0);      // high
                    low = open - (rnd.NextDouble() * 1.0);      //low

                    // if (low < 1) { low = 1; }
                }
                else  // downward price change
                {
                    close = open - ( (rnd.NextDouble() * 1.0));  // close
                    high = open + (rnd.NextDouble() * 1.0);      // high
                    low = close - (rnd.NextDouble() * 1.0);      // low

                    //  if (low < 1)
                    //   {
                    //       low = 1;
                    //  }
                }

                prevclose = close;

                s.AddStock(open, high, low, close);
            }
        }

        private void SetupStockSeries()
        {
            _mStock = (StockSeries)_mChart.Series.Add(SeriesType.Stock);
            _mStock.DataLabels.Mode = DataLabelsMode.Subset;
            _mStock.CandleStyle = CandleStyle.Stick;
            _mStock.CandleWidth = 0.4f;
            _mStock.UpLineProps.Color = Color.Green;
            _mStock.DownLineProps.Color = Color.Red;
            _mStock.Legend.Mode = SeriesLegendMode.None;

            _mStock.OpenValues.Name = "open";
            _mStock.HighValues.Name = "high";
            _mStock.LowValues.Name = "low";
            _mStock.CloseValues.Name = "close";
            _mStock.Name = "EURUSD";
        }

        private void SetupLineSeries()
        {
            _mLine = (LineSeries)_mChart.Series.Add(SeriesType.Line);
            _mLine.DataLabels.Mode = DataLabelsMode.Subset;
   //         _mLine.CandleStyle = CandleStyle.Stick;
     //       _mLine.CandleWidth = 0.4f;
       //     _mLine.UpLineProps.Color = Color.Green;
         //   _mLine.DownLineProps.Color = Color.Red;
            _mLine.Legend.Mode = SeriesLegendMode.None;

  //          _mLine.OpenValues.Name = "open";
    //        _mLine.HighValues.Name = "high";
      //      _mLine.LowValues.Name = "low";
        //    _mLine.CloseValues.Name = "close";
            _mLine.Name = "EURUSD";
        }

        private void SetupChartControl()
        {
            chartToolbarControl1.ChartControl = m_ChartControl;

            m_ChartControl.Settings.RenderSurface = TargetRenderSurface.Bitmap;
            m_ChartControl.Settings.EnableAntialiasing = false;
            m_ChartControl.Background.FillEffect.SetGradient(GradientStyle.Horizontal, GradientVariant.Variant1, Color.FromArgb(222, 222, 239), Color.White);

            _mChart = m_ChartControl.Charts[0];
            _mChart.View.SetPredefinedProjection(PredefinedProjection.Orthogonal);
            _mChart.LightModel.EnableLighting = false;
            _mChart.Axis(StandardAxis.Depth).Visible = false;
            _mChart.Wall(ChartWallType.Floor).Visible = false;
            _mChart.Wall(ChartWallType.Left).Visible = false;
            _mChart.MarginMode = MarginMode.Stretch;
            _mChart.Margins = new RectangleF(10, 10, 70, 80);

            // setup X axis
            Axis ax = _mChart.Axis(StandardAxis.PrimaryX);
            ax.DimensionScale.NumberOfDataPointsBetweenTicks = 20;
            ax.DimensionScale.NumberOfDataPointsBetweenLabels = 20;
            ax.MajorGridLine.Pattern = LinePattern.Dot;
            ax.SetMajorShowAtWall(ChartWallType.Back, true);
            ax.SetMajorShowAtWall(ChartWallType.Floor, false);

            // setup primary Y axis
            Axis ay = _mChart.Axis(StandardAxis.PrimaryY);
            ay.Border.Width = 2;
            ay.MajorGridLine.Pattern = LinePattern.Dot;
            ay.SetMajorShowAtWall(ChartWallType.Left, false);
            ay.InnerTickLine.Width = 0;
        }

        void timer_Tick(object sender, EventArgs e)
        {
            RateData r = GetSomeData();
            if (r != null)
            {
                _nl.Add(r);
            }
            else
            {
                labelRate.Text = "Error";
            }
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
                Div rates = TheBrowser.Div(Find.ById("objecte"));
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

        private void AddEma(bool doShow)
        {
            if (doShow)
            {
                if (_mCalcEma == null)
                {
                    _mCalcEma = new FunctionCalculator();

                    // Add line series for Exponential Moving Average
                    _mLineEma = (LineSeries)_mChart.Series.Add(SeriesType.Line);
                    _mLineEma.DataLabels.Mode = DataLabelsMode.None;
                    _mLineEma.LineBorder.Color = Color.DarkViolet;
                    _mLineEma.Name = "Exponential Moving Average";

                    _mCalcEma.Arguments.Add(_mStock.CloseValues);
                }
            }

            _mLineEma.Visible = doShow;
            _emaAdded = doShow;

            UpdateExpressions();
            CalculateFunctions();
        }

        private void AddSma(bool doShow)
        {
            if (doShow)
            {
                if (_mCalcSma == null)
                {
                    _mCalcSma = new FunctionCalculator();

                    // Add line series for Exponential Moving Average
                    _mLineSma = (LineSeries)_mChart.Series.Add(SeriesType.Line);
                    _mLineSma.DataLabels.Mode = DataLabelsMode.None;
                    _mLineSma.LineBorder.Color = Color.DarkViolet;
                    _mLineSma.Name = "Simple Moving Average";

                    _mCalcSma.Arguments.Add(_mStock.CloseValues);
                }
            }

            _mLineSma.Visible = doShow;
            _smaAdded = doShow;

            UpdateExpressions();
            CalculateFunctions();
        }

        private void AddBollinger(bool doShow)
        {
            if (doShow)
            {
                if (_mCalcBollingerLower == null && _mCalcBollingerUpper == null)
                {
                    _mCalcBollingerUpper = new FunctionCalculator();
                    _mCalcBollingerLower = new FunctionCalculator();

                    // Add line series for Upper Bollinger Band
                    _mLineUpper = (LineSeries)_mChart.Series.Add(SeriesType.Line);
                    _mLineUpper.DataLabels.Mode = DataLabelsMode.None;
                    _mLineUpper.LineBorder.Color = Color.Green;
                    _mLineUpper.Name = "Bollinger Band - Upper";

                    // Add line series for Upper Lower Band
                    _mLineLower = (LineSeries)_mChart.Series.Add(SeriesType.Line);
                    _mLineLower.DataLabels.Mode = DataLabelsMode.None;
                    _mLineLower.LineBorder.Color = Color.Green;
                    _mLineLower.Name = "Bollinger Band - Lower";

                    // Add arguments
                    _mCalcBollingerUpper.Arguments.Add(_mStock.CloseValues);
                    _mCalcBollingerLower.Arguments.Add(_mStock.CloseValues);
                }
            }

            _mLineLower.Visible = doShow;
            _mLineUpper.Visible = doShow;
            _bollAdded = doShow;

            UpdateExpressions();
            CalculateFunctions();
        }

        private void trackBarEma_Scroll(object sender, EventArgs e)
        {
            UpdateExpressions();
            CalculateFunctions();
        }

        private void checkBoxEma_CheckedChanged(object sender, EventArgs e)
        {
            AddEma(checkBoxEma.Checked);
        }

        private void checkBoxSma_CheckedChanged(object sender, EventArgs e)
        {
            AddSma(checkBoxSma.Checked);
        }

        private void checkBoxBoll_CheckedChanged(object sender, EventArgs e)
        {
            AddBollinger(checkBoxBoll.Checked);
        }

        private void checkBoxCandleStyle_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCandleStyle.Checked)
            {
                _mStock.CandleStyle = CandleStyle.Bar;
                _mStock.CandleWidth = 0.2f;
                checkBoxCandleStyle.Text = "-> Stick";
            }
            else
            {
                _mStock.CandleStyle = CandleStyle.Stick;
                _mStock.CandleWidth = 0.4f;
                checkBoxCandleStyle.Text = "-> Bar";
            }

            UpdateExpressions();
            CalculateFunctions();
        }

    }
}
