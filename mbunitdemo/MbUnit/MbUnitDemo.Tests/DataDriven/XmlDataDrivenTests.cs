using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.DataDriven
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.DataDriven)]
    [DependsOn(typeof(CsvDataDrivenTests))]
    public class XmlDataDrivenTests
    {
        [Test]
        [XmlData("//Person", FilePath = @"Files\Persons.xml")]
        public void TestOnXmlData(
            [Bind("Name")]string name, 
            [Bind("Age")]int age)
        {
            Assert.AreEqual("Niklas", name);
            Assert.AreApproximatelyEqual(31, age, 1);
        }
    }
}