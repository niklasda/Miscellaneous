using BitFactory.Logging;
using Utils.Logging.Interfaces;

namespace Utils.Logging
{
	public class BitLoggerUtility : ILogger
	{
		public BitLoggerUtility()
		{
			logger = new FileLogger(@"Logs\BitLogfile.log");

			logger.LogDebug("Logging started");
		}

		private readonly Logger logger;

		public void Log(string message)
		{
			logger.LogDebug(message);
		}

		public override string ToString()
		{
			string id = string.Format("{0}", GetType());
			return id;
		}
	}
}