using System.Globalization;
using System.Threading;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Ordering
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Ordering)]
    public class AttributeOrderingTests
    {
        [Test]
        [ThreadedRepeat(3, Order = 1)]
        [MultipleCulture("sv-SE", "en-US", Order = 2)]
        public void RepeatedCultureOrderDemo()
        {    
            TestLog.WriteLine("Order: {0}", TestContext.CurrentContext.Test.Order);
            TestLog.WriteLine("Culture: {0}", CultureInfo.CurrentCulture.DisplayName);
            TestLog.WriteLine("Culture: {0}", Thread.CurrentThread.CurrentCulture.DisplayName);
            // NOT working
            double num = 2.2;
            TestLog.WriteLine("Value of num, presented in {0}={1}", CultureInfo.CurrentCulture.DisplayName, num);
        }

        [Test]
        [ThreadedRepeat(3, Order = 2)]
        [MultipleCulture("sv-SE", "en-US", Order = 1)]
        public void CultureRepeatedOrderDemo()
        {
            TestLog.WriteLine("Order: {0}", TestContext.CurrentContext.Test.Order);
            TestLog.WriteLine("Culture: {0}", CultureInfo.CurrentCulture.DisplayName);
            TestLog.WriteLine("Culture: {0}", Thread.CurrentThread.CurrentCulture.DisplayName);

            double num = 2.2;
            TestLog.WriteLine("Value of num, presented in {0}={1}", CultureInfo.CurrentCulture.DisplayName, num);
        }
    }
}