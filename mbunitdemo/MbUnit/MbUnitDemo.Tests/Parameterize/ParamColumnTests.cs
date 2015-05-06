using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Exception;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Parameterize
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Parameterized)]
    public class ParamColumnTests
    {
        [Test]
        public void ColumnTestPersonInvalidAge(
            [Column("Niklas-1", "Niklas-2")] string name,
            [Column(-1, -2, ExpectedException = typeof(AgeException))] int age)
        {
            TestLog.WriteLine("Name: {0}, Age: {1}", name, age);

            var p = new Person(name, age);
            Assert.AreEqual(name, p.Name);
            Assert.AreEqual(age, p.Age);
        }

    }
}