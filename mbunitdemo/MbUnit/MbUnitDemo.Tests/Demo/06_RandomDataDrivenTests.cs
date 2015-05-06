using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Demo
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.DataDriven)]
    public class RandomDataDrivenTests
    {
        [Test]
        public void TestRandomNamesData(
            [RandomStrings(Count = 5, 
                Stock = RandomStringStock.EnUSMaleNames)] 
            string name, 
            [RandomNumbers(Count = 2, 
                Minimum = 10, 
                Maximum = 70)]
            int age)
        {
            var p = new Person(name, age);
            Assert.IsNotNull(p);
        }






        [Test]
        public void TestRandomData(
            [RandomStrings(Count = 5, 
                Pattern = "[A-Z][0-9][a-z]", 
                Filter = FilterFunctionName)] 
            string name,
            [RandomNumbers(Count = 2, 
                Minimum = 10, 
                Maximum = 70)]
            int age)
        {
            var p = new Person(name, age);
            Assert.IsNotNull(p);
        }



        private const string FilterFunctionName = "FilterMyRandoms";
        private static bool FilterMyRandoms(string randomString)
        {
            if(randomString.StartsWith("A"))
            {
                TestLog.WriteLine("Filtered out: {0}", randomString);
                return false;
            }
            return true;
        }
    }
}