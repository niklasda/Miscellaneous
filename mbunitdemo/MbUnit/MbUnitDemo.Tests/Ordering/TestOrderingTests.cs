using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Ordering
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Ordering)]
    [Description("Illustrates the bad practice of test ordering")]
    public class TestOrderingTests
    {
        [Test(Order = 1)]
        public void Order1Demo()
        {
            TestLog.WriteLine("Order: {0}", TestContext.CurrentContext.Test.Order);

            Assert.IsTrue(true);
        }

        [Test(Order = 2)]
        public void Order2Demo()
        {
            TestLog.WriteLine("Order: {0}", TestContext.CurrentContext.Test.Order);

            Assert.IsTrue(true);
        }


    }
}