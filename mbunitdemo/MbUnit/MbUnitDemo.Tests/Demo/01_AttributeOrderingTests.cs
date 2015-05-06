using System;
using System.Globalization;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Demo
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Ordering)]
    public class AttributeOrderingTests
    {
        [Test]
        [ThreadedRepeat(3, Order = 2)]
        [MultipleCulture("sv-SE", "en-US", Order = 1)]
        public void CultureRepeatedOrderDemo()
        {
            TestLog.WriteLine("Order: {0}", 
                TestContext.CurrentContext.Test.Order);
            TestLog.WriteLine("Culture: {0}", 
                CultureInfo.CurrentCulture.DisplayName);

            const double num = 2.2;
            TestLog.WriteLine("Value of num, presented in {0}={1}", 
                CultureInfo.CurrentCulture.DisplayName, 
                num);
        }






        [Test]
        [Description("Show the diff in Icarus")]
        [Importance(Importance.Severe)]
        [Impersonate(UserName = "Niklas2", Password = "Niklas2")]
        public void SlightDiffHighlighted()
        {
            Assert.AreEqual("Nìklas2", Environment.UserName);
        }
    }
}