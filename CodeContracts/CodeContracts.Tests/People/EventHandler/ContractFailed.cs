using System.Diagnostics.Contracts;
using CodeContracts.People.Exceptions;
using Gallio.Framework;
using Utils.Logging;
using Utils.Logging.Interfaces;

namespace CodeContracts.Tests.People.EventHandler
{
    public static class ContractFailed
    {
        private static readonly ILogger logger = new BitLoggerUtility();

        public static void Contract_ContractFailed(object sender, ContractFailedEventArgs e)
        {
            e.Handled = true;
            string message = string.Format("{0}: {1}", e.DebugMessage, e.Condition);
            logger.Log(message);
            var exception = new ContractViolationException(message);

            TestLog.WriteException(exception);
            TestLog.WriteEllipsis();

            throw exception;
        }
    }
}