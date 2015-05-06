using System;

namespace Dahlex.Logic.Logger
{
    public static class GameLogger
    {
        private static string _theLog = string.Empty;
        public static string TheLog
        {
            get { return _theLog; }
            private set { _theLog = value; }
        }

        // private string txtLog;
        public static void AddLineToLog(string log)
        {
            string txtLog = GameLogger.TheLog;
            //  if(!string.IsNullOrEmpty(txtLog.Text))
            log += Environment.NewLine;
            log += txtLog;
            GameLogger.TheLog = log;
        }
    }
}