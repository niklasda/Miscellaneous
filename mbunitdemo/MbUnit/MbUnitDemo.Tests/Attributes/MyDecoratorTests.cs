using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Attributes
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Attributes)]
    public class MyDecoratorTests
    {
        [Test]
        [MyTestDecorator("Added message to [Test]")]
        public void CustomDecoratorTest()
        {
            TestLog.WriteLine("Running CustomDecoratorTest");
            TestLog.WriteLine("Current Test: {0}", TestContext.CurrentContext.Test.FullName);
        }
    }
}