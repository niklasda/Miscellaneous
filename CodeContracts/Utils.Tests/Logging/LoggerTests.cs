using Autofac.Builder;
using MbUnit.Framework;
using Utils.Logging;
using Utils.Logging.Interfaces;

namespace Utils.Tests.Logging
{	
	public class LoggerTests
	{
		[Test]
		public void BitLoggerCreate()
		{
			var builder = new ContainerBuilder();

			builder.Register<BitLoggerUtility>().As<ILogger>().FactoryScoped();

			using (var container = builder.Build())
			{
				var log = container.Resolve<ILogger>();
				log.Log("BitFactoryLogger created");
			}
		}
	}
}