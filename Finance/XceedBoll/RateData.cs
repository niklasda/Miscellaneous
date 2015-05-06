using System;

namespace XceedBoll
{
    public class RateData
    {
        private readonly double _last;
        private readonly double _open;
        private readonly double _high;
        private readonly double _low;
        private readonly string _change;
        private readonly string _percent;
        private readonly DateTime _date;

        public RateData(double last, double open, double high, double low, string change, string percent, DateTime date)
        {
            _last = last;
            _open = open;
            _high = high;
            _low = low;
            _change = change;
            _percent = percent;
            _date = date;
        }

        public DateTime Date
        {
            get { return _date; }
        }

        public string Percent
        {
            get { return _percent; }
        }

        public string Change
        {
            get { return _change; }
        }

        public double Low
        {
            get { return _low; }
        }

        public double High
        {
            get { return _high; }
        }

        public double Open
        {
            get { return _open; }
        }

        public double Last
        {
            get { return _last; }
        }
    }
}