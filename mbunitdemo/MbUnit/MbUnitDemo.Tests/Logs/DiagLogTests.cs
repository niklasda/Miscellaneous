using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Logs
{
    [TestFixture]
    [Category(Categories.Logs)]
    public class DiagLogTests
    {
        [Test]
        public void DiagLogInit()
        {
            DiagnosticLog.WriteLine("Message to DiagnosticsLog");
            DiagnosticLog.WriteLine("Current Test: {0}", TestContext.CurrentContext.Test.FullName);
        }
    }
}