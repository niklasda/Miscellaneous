using System;
using IBApi;
using Serilog;


namespace IBHelper
{
    public class IBClient : EWrapper
    {
        private EClientSocket clientSocket;
        private int nextOrderId;
        private ILogger _logger;

        public IBClient(ILogger logger)
        {
            _logger = logger;

            clientSocket = new EClientSocket(this);
        }

        public EClientSocket ClientSocket
        {
            get { return clientSocket; }
            set { clientSocket = value; }
        }

        public int NextOrderId
        {
            get { return nextOrderId; }
            set { nextOrderId = value; }
        }

        public virtual void error(Exception ex)
        {
            _logger.Error(ex, ex.Message);
            throw ex;
        }

        public virtual void error(string str)
        {
            _logger.Error("Error: " + str + "\n");
        }

        public virtual void error(int id, int errorCode, string errorMsg)
        {
            _logger.Error("Error. Id: " + id + ", Code: " + errorCode + ", Msg: " + errorMsg);
        }

        public virtual void connectionClosed()
        {
            _logger.Information("Connection closed.");
        }

        public virtual void currentTime(long time)
        {
            _logger.Information("Current Time: " + time);
        }

        public virtual void tickPrice(int tickerId, int field, double price, int canAutoExecute)
        {
            _logger.Information("Tick Price. Ticker Id:" + tickerId + ", Field: " + field + ", Price: " + price + ", CanAutoExecute: " + canAutoExecute);
        }

        public virtual void tickSize(int tickerId, int field, int size)
        {
            _logger.Information("Tick Size. Ticker Id:" + tickerId + ", Field: " + field + ", Size: " + size);
        }

        public virtual void tickString(int tickerId, int tickType, string value)
        {
            _logger.Information("Tick string. Ticker Id:" + tickerId + ", Type: " + tickType + ", Value: " + value);
        }

        public virtual void tickGeneric(int tickerId, int field, double value)
        {
            _logger.Information("Tick Generic. Ticker Id:" + tickerId + ", Field: " + field + ", Value: " + value );
        }

        public virtual void tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints, double impliedFuture, int holdDays, string futureExpiry, double dividendImpact, double dividendsToExpiry)
        {
            _logger.Information("TickEFP. " + tickerId + ", Type: " + tickType + ", BasisPoints: " + basisPoints + ", FormattedBasisPoints: " + formattedBasisPoints + ", ImpliedFuture: " + impliedFuture + ", HoldDays: " + holdDays + ", FutureExpiry: " + futureExpiry + ", DividendImpact: " + dividendImpact + ", DividendsToExpiry: " + dividendsToExpiry);
        }

        public virtual void tickSnapshotEnd(int tickerId)
        {
            _logger.Information("TickSnapshotEnd: " + tickerId);
        }

        public virtual void nextValidId(int orderId)
        {
            _logger.Information("Next Valid Id: " + orderId);
            NextOrderId = orderId;
        }

        public virtual void deltaNeutralValidation(int reqId, UnderComp underComp)
        {
            _logger.Information("DeltaNeutralValidation. " + reqId + ", ConId: " + underComp.ConId + ", Delta: " + underComp.Delta + ", Price: " + underComp.Price);
        }

        public virtual void managedAccounts(string accountsList)
        {
            _logger.Information("Account list: " + accountsList );
        }

        public virtual void tickOptionComputation(int tickerId, int field, double impliedVolatility, double delta, double optPrice, double pvDividend, double gamma, double vega, double theta, double undPrice)
        {
            _logger.Information("TickOptionComputation. TickerId: " + tickerId + ", field: " + field + ", ImpliedVolatility: " + impliedVolatility + ", Delta: " + delta
                + ", OptionPrice: " + optPrice + ", pvDividend: " + pvDividend + ", Gamma: " + gamma + ", Vega: " + vega + ", Theta: " + theta + ", UnderlyingPrice: " + undPrice);
        }

        public virtual void accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            _logger.Information("Acct Summary. ReqId: " + reqId + ", Acct: " + account + ", Tag: " + tag + ", Value: " + value + ", Currency: " + currency);
        }

        public virtual void accountSummaryEnd(int reqId)
        {
            _logger.Information("AccountSummaryEnd. Req Id: " + reqId);
        }

        public virtual void updateAccountValue(string key, string value, string currency, string accountName)
        {
            _logger.Information("UpdateAccountValue. Key: " + key + ", Value: " + value + ", Currency: " + currency + ", AccountName: " + accountName);
        }

        public virtual void updatePortfolio(Contract contract, int position, double marketPrice, double marketValue, double averageCost, double unrealisedPNL, double realisedPNL, string accountName)
        {
            _logger.Information("UpdatePortfolio. " + contract.Symbol + ", " + contract.SecType + " @ " + contract.Exchange
                + ": Position: " + position + ", MarketPrice: " + marketPrice + ", MarketValue: " + marketValue + ", AverageCost: " + averageCost
                + ", UnrealisedPNL: " + unrealisedPNL + ", RealisedPNL: " + realisedPNL + ", AccountName: " + accountName );
        }

        public virtual void updateAccountTime(string timestamp)
        {
            _logger.Information("UpdateAccountTime. Time: " + timestamp);
        }

        public virtual void accountDownloadEnd(string account)
        {
            _logger.Information("Account download finished: " + account);
        }

        public virtual void orderStatus(int orderId, string status, int filled, int remaining, double avgFillPrice, int permId, int parentId, double lastFillPrice, int clientId, string whyHeld)
        {
            _logger.Information("OrderStatus. Id: " + orderId + ", Status: " + status + ", Filled" + filled + ", Remaining: " + remaining
                + ", AvgFillPrice: " + avgFillPrice + ", PermId: " + permId + ", ParentId: " + parentId + ", LastFillPrice: " + lastFillPrice + ", ClientId: " + clientId + ", WhyHeld: " + whyHeld);
        }

        public virtual void openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            _logger.Information("OpenOrder. ID: " + orderId + ", " + contract.Symbol + ", " + contract.SecType + " @ " + contract.Exchange + ": " + order.Action + ", " + order.OrderType + " " + order.TotalQuantity + ", " + orderState.Status );
            //clientSocket.reqMktData(2, contract, "", false);
            contract.ConId = 0;
            clientSocket.placeOrder(nextOrderId, contract, order);
        }

        public virtual void openOrderEnd()
        {
            _logger.Information("OpenOrderEnd");
        }

        public virtual void contractDetails(int reqId, ContractDetails contractDetails)
        {
            _logger.Information("ContractDetails. ReqId: " + reqId + " - " + contractDetails.Summary.Symbol + ", " + contractDetails.Summary.SecType + ", ConId: " + contractDetails.Summary.ConId + " @ " + contractDetails.Summary.Exchange);
        }

        public virtual void contractDetailsEnd(int reqId)
        {
            _logger.Information("ContractDetailsEnd. " + reqId);
        }

        public virtual void execDetails(int reqId, Contract contract, Execution execution)
        {
            _logger.Information("ExecDetails. " + reqId + " - " + contract.Symbol + ", " + contract.SecType + ", " + contract.Currency + " - " + execution.ExecId + ", " + execution.OrderId + ", " + execution.Shares);
        }

        public virtual void execDetailsEnd(int reqId)
        {
            _logger.Information("ExecDetailsEnd. " + reqId + "\n");
        }

        public virtual void commissionReport(CommissionReport commissionReport)
        {
            _logger.Information("CommissionReport. " + commissionReport.ExecId + " - " + commissionReport.Commission + " " + commissionReport.Currency + " RPNL " + commissionReport.RealizedPNL);
        }

        public virtual void fundamentalData(int reqId, string data)
        {
            _logger.Information("FundamentalData. " + reqId + "" + data);
        }

        public virtual void historicalData(int reqId, string date, double open, double high, double low, double close, int volume, int count, double WAP, bool hasGaps)
        {
            _logger.Information("HistoricalData. " + reqId + " - Date: " + date + ", Open: " + open + ", High: " + high + ", Low: " + low + ", Close: " + close + ", Volume: " + volume + ", Count: " + count + ", WAP: " + WAP + ", HasGaps: " + hasGaps);
        }

        public virtual void marketDataType(int reqId, int marketDataType)
        {
            _logger.Information("MarketDataType. " + reqId + ", Type: " + marketDataType + "\n");
        }

        public virtual void updateMktDepth(int tickerId, int position, int operation, int side, double price, int size)
        {
            _logger.Information("UpdateMarketDepth. " + tickerId + " - Position: " + position + ", Operation: " + operation + ", Side: " + side + ", Price: " + price + ", Size" + size);
        }

        public virtual void updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, int size)
        {
            _logger.Information("UpdateMarketDepthL2. " + tickerId + " - Position: " + position + ", Operation: " + operation + ", Side: " + side + ", Price: " + price + ", Size" + size);
        }


        public virtual void updateNewsBulletin(int msgId, int msgType, String message, String origExchange)
        {
            _logger.Information("News Bulletins. " + msgId + " - Type: " + msgType + ", Message: " + message + ", Exchange of Origin: " + origExchange);
        }

        public virtual void position(string account, Contract contract, int pos, double avgCost)
        {
            _logger.Information("Position. " + account + " - Symbol: " + contract.Symbol + ", SecType: " + contract.SecType + ", Currency: " + contract.Currency + ", Position: " + pos + ", Avg cost: " + avgCost);
        }

        public virtual void positionEnd()
        {
            _logger.Information("PositionEnd");
        }

        public virtual void realtimeBar(int reqId, long time, double open, double high, double low, double close, long volume, double WAP, int count)
        {
            _logger.Information("RealTimeBars. " + reqId + " - Time: " + time + ", Open: " + open + ", High: " + high + ", Low: " + low + ", Close: " + close + ", Volume: " + volume + ", Count: " + count + ", WAP: " + WAP);
        }

        public virtual void scannerParameters(string xml)
        {
            _logger.Information("ScannerParameters. " + xml);
        }

        public virtual void scannerData(int reqId, int rank, ContractDetails contractDetails, string distance, string benchmark, string projection, string legsStr)
        {
            _logger.Information("ScannerData. " + reqId + " - Rank: " + rank + ", Symbol: " + contractDetails.Summary.Symbol + ", SecType: " + contractDetails.Summary.SecType + ", Currency: " + contractDetails.Summary.Currency
                + ", Distance: " + distance + ", Benchmark: " + benchmark + ", Projection: " + projection + ", Legs String: " + legsStr);
        }

        public virtual void scannerDataEnd(int reqId)
        {
            _logger.Information("ScannerDataEnd. " + reqId);
        }

        public virtual void receiveFA(int faDataType, string faXmlData)
        {
            _logger.Information("Receing FA: " + faDataType + " - " + faXmlData);
        }

        public virtual void bondContractDetails(int requestId, ContractDetails contractDetails)
        {
            _logger.Information("Bond. Symbol " + contractDetails.Summary.Symbol + ", " + contractDetails.Summary);
        }

        public virtual void historicalDataEnd(int reqId, string startDate, string endDate)
        {
            _logger.Information("Historical data end - " + reqId + " from " + startDate + " to " + endDate);
        }

        public virtual void verifyMessageAPI(string apiData)
        {
            _logger.Information("verifyMessageAPI: " + apiData);
        }
        public virtual void verifyCompleted(bool isSuccessful, string errorText)
        {
            _logger.Information("verifyCompleted. IsSuccessful: " + isSuccessful + " - Error: " + errorText);
        }
        public virtual void displayGroupList(int reqId, string groups)
        {
            _logger.Information("DisplayGroupList. Request: " + reqId + ", Groups" + groups);
        }
        public virtual void displayGroupUpdated(int reqId, string contractInfo)
        {
            _logger.Information("displayGroupUpdated. Request: " + reqId + ", ContractInfo: " + contractInfo);
        }
    }
}
