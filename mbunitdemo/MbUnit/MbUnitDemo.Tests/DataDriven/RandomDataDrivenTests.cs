using MbUnit.Framework;
using Gallio.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.DataDriven
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.DataDriven)]
    public class RandomDataDrivenTests
    {
        [Test]
        public void TestRandomNamesData(
            [RandomStrings(Count = 5, Stock = RandomStringStock.EnUSMaleNames)] string name, 
            [RandomNumbers(Count = 5, Minimum = 10, Maximum = 40)]int age)
        {
            var p = new Person(name, age);
            Assert.IsNotNull(p);
        }

        [Test]
        public void TestRandomData(
            [RandomStrings(Pattern ="[A-Z][0-9][a-z]", Count = 5)] string name,
            [RandomNumbers(Count = 5, Minimum = 10, Maximum = 40)]int age)
        {
            TestLog.WriteLine(name);
            var p = new Person(name, age);
            Assert.IsNotNull(p);
        }

    }
}