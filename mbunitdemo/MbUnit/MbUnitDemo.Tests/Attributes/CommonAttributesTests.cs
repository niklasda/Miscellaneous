using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Attributes
{
    [AssemblyFixture]
    public class CommonAssemblyAttributes
    {
        [SetUp]
        public void Setup()
        {}

        [TearDown]
        public void TearDown()
        {}
    }

    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Attributes)]
    public class CommonAttributes
    {
        [FixtureInitializer]
        public void FixtureInit()
        {
            TestLog.WriteLine("0 FixInitialize");
        }

        [FixtureSetUp]
        public void FixtureSetup()
        {
            TestLog.WriteLine("1.0 FixSetUp");
        }
        
        [SetUp]
        public void Setup()
        {
            TestLog.WriteLine("1.1 SetUp");
        }

        [Test]
        public void TestCase()
        {
            TestLog.WriteLine("2.0 TearCase");
        }
        
        [TearDown]
        public void TearDown()
        {
            TestLog.WriteLine("3.0 TearDown");
        }
       
        [FixtureTearDown]
        public void FixtureTearDown()
        {
            TestLog.WriteLine("3.1 FixTearDown");
        }
    }
}