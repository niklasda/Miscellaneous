using System;
using System.Collections.Generic;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.CommandWpf;
using IBApi;
using OxyPlot;
using OxyPlot.Axes;
using OxyPlot.Series;
using Serilog;

namespace IBHelper.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            ConnectCommand = new RelayCommand(DoDemo0);
            AccountCommand = new RelayCommand(DoDemo1);
            ContractCommand = new RelayCommand(DoDemo2);
            TickCommand = new RelayCommand(DoDemo4);
            RealTimeCommand = new RelayCommand(DoDemo5);
            HistoricalCommand = new RelayCommand(DoDemo6);

            _logger = new LoggerConfiguration()
               .WriteTo.ColoredConsole()
               .CreateLogger();

            var plotModel = new PlotModel { Title = "Example 1", Subtitle = "Graph" };
            plotModel.Axes.Add(new LinearAxis { Position = AxisPosition.Left, Minimum = -1, Maximum = 10 });
            plotModel.Series.Add(new LineSeries { LineStyle = LineStyle.Solid });

            GraphData = plotModel;
           // Update2();

            Host = "127.0.0.1";
            Port = "4002";
        }

        public RelayCommand ConnectCommand { get; set; }
        public RelayCommand AccountCommand { get; set; }
        public RelayCommand ContractCommand { get; set; }
        public RelayCommand TickCommand { get; set; }
        public RelayCommand RealTimeCommand { get; set; }
        public RelayCommand HistoricalCommand { get; set; }


        private bool isConnected;
        private bool _initialized;
        private IBClient ibClient;
        private ILogger _logger;
        //private MarketDataManager marketDataManager;
        private int currentTicker = 1;


        private void Update2()
        {
            var s = (LineSeries)GraphData.Series[0];

          //  Action<string> callback = x =>
          //  {
            string x = "2";
                double y = double.Parse(x);
                s.Points.Add(new DataPoint(y, y));
                GraphData.InvalidatePlot(true);
          //  };

        //    var d = ServiceLocator.Current.GetInstance<IDemo1Service>();

      //      d.Demo1(callback);

        }

       


        public bool IsConnected
        {
            get { return isConnected; }
            set { isConnected = value; }
        }

        private PlotModel _graphData;

        public PlotModel GraphData
        {
            get { return _graphData; }
            set
            {
                if (_graphData != value)
                {
                    _graphData = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Host { get; set; }
        public string Port { get; set; }

        private void DoDemo0()
        {
            if (!IsConnected)
            {
                IsConnected = true;

                int port;
                string host = Host;

                if (host == null || host.Equals(""))
                    host = "127.0.0.1";
                try
                {
                    port = Int32.Parse("4002");
                    var clientId = Int32.Parse("1");
                    ibClient = new IBClient(_logger);

                    ibClient.ClientSocket.eConnect(host, port, clientId);
                }
                catch (Exception ex)
                {
                    _logger.Warning(ex, ex.Message);
                    /// HandleMessage(new ErrorMessage(-1, -1, "Please check your connection attributes."));
                }
            }
            else
            {
                IsConnected = false;
                ibClient.ClientSocket.eDisconnect();
            }
        }

        private void DoDemo1()
        {
            if (!accountSummaryRequestActive)
            {
                accountSummaryRequestActive = true;
                //accountSummaryGrid.Rows.Clear();
                ibClient.ClientSocket.reqAccountSummary(ACCOUNT_SUMMARY_ID, "All", ACCOUNT_SUMMARY_TAGS);
            }
            else
            {
                ibClient.ClientSocket.cancelAccountSummary(ACCOUNT_SUMMARY_ID);
            }
        }

        private void DoDemo2()
        {
            if (isConnected)
            {
                Contract contract = new Contract();
                contract.Symbol = "FISV";
                contract.SecType = "OPT";
                contract.Exchange = "SMART";
                contract.Currency = "USD";

                Contract gcontract = new Contract();
                gcontract.Symbol = "GOOG";
                gcontract.SecType = "STK";
                gcontract.Exchange = "SMART";
                gcontract.Currency = "USD";

                //Contract optionContract = ContractSamples.getOptionForQuery();

                ibClient.ClientSocket.reqContractDetails(1, gcontract);
            }
        }
        /*
         * STK
OPT
FUT
CASH
BOND
CFD
FOP
WAR
IOPT
FWD
BAG
IND
BILL
FUND
FIXED
SLB
NEWS
CMDTY
BSK
ICU
ICS*/
        private void DoDemo4()
        {
            if (isConnected)
            {
                Contract contract = new Contract();
                contract.SecType = "CASH";
                contract.Symbol = "EUR";
                contract.Exchange = "IDEALPRO";
                contract.Currency = "USD";
                contract.Expiry = "";
                contract.PrimaryExch = "";
                contract.IncludeExpired = false;

                //if (!mdContractRight.Text.Equals("") && !mdContractRight.Text.Equals("None"))
                //    contract.Right = (string)((IBType)mdContractRight.SelectedItem).Value;

                //contract.Strike = stringToDouble(this.strike_TMD_MDT.Text);
                //contract.Multiplier = this.multiplier_TMD_MDT.Text;
                //contract.LocalSymbol = this.localSymbol_TMD_MDT.Text;


                //Contract contract = GetMDContract();
                string genericTickList = "";
            //    if (genericTickList == null)
            //        genericTickList = "";
             //   marketDataManager.AddRequest(contract, genericTickList);


                ibClient.ClientSocket.reqMktData(TICK_ID_BASE + (currentTicker++), contract, genericTickList, false, new List<TagValue>());

                // ShowTab(marketData_MDT, topMarketDataTab_MDT);
            }
        }

        public const int RT_BARS_ID_BASE = 40000000;


        private void DoDemo5()
        {
            if (isConnected)
            {
                Contract contract = new Contract();
                contract.SecType = "CASH";
                contract.Symbol = "EUR";
                contract.Exchange = "IDEALPRO";
                contract.Currency = "USD";
                contract.Expiry = "";
                contract.PrimaryExch = "";
                contract.IncludeExpired = false;

                ibClient.ClientSocket.reqRealTimeBars(currentTicker + RT_BARS_ID_BASE, contract, 5, "MIDPOINT", true, null);

            }
        }
        public const int HISTORICAL_ID_BASE = 30000000;

        /*S
D
W
M
Y*/

        /*1 sec
5 secs
15 secs
30 secs
1 min
2 mins
3 mins
5 mins
15 mins
30 mins
1 hour
1 day*/
    private void DoDemo6()
    {
        if (isConnected)
        {
            Contract contract = new Contract();
            contract.SecType = "CASH";
            contract.Symbol = "EUR";
            contract.Exchange = "IDEALPRO";
            contract.Currency = "USD";
            contract.Expiry = "";
            contract.PrimaryExch = "";
            contract.IncludeExpired = false;


         //   Contract contract = GetMDContract();
            string endDateTime = "20160403 08:00:00 GMT";
            string durationString = "1 D";
            string barSizeSetting = "15 mins";
            string whatToShow = "MIDPOINT";
            int useRTH = false ? 1 : 0;
       //     historicalDataManager.AddRequest(contract, endTime, duration, barSize, whatToShow, outsideRTH, 1);
            //    historicalDataTab.Text = Utils.ContractToString(contract) + " (HD)";
            //    ShowTab(marketData_MDT, historicalDataTab);

            ibClient.ClientSocket.reqHistoricalData(currentTicker + HISTORICAL_ID_BASE, contract, endDateTime, durationString, barSizeSetting, whatToShow, useRTH, 1, new List<TagValue>());

        }
    }

    /*
     * TRADES
MIDPOINT
BID
ASK
BID_ASK
HISTORICAL_VOLATILITY
OPTION_IMPLIED_VOLATILITY
YIELD_BID
YIELD_ASK
YIELD_BID_ASK
YIELD_LAST*/

        public
        const int TICK_ID_BASE = 10000000;

        private bool accountSummaryRequestActive = false;
        private const int ACCOUNT_ID_BASE = 50000000;

        private const int ACCOUNT_SUMMARY_ID = ACCOUNT_ID_BASE + 1;

        private const string ACCOUNT_SUMMARY_TAGS = "AccountType,NetLiquidation,TotalCashValue,SettledCash,AccruedCash,BuyingPower,EquityWithLoanValue,PreviousEquityWithLoanValue,"
             + "GrossPositionValue,ReqTEquity,ReqTMargin,SMA,InitMarginReq,MaintMarginReq,AvailableFunds,ExcessLiquidity,Cushion,FullInitMarginReq,FullMaintMarginReq,FullAvailableFunds,"
             + "FullExcessLiquidity,LookAheadNextChange,LookAheadInitMarginReq ,LookAheadMaintMarginReq,LookAheadAvailableFunds,LookAheadExcessLiquidity,HighestSeverity,DayTradesRemaining,Leverage";

  

    }
}