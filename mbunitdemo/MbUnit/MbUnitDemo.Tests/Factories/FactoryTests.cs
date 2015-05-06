using System.Collections.Generic;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Factories
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Factories)]
    public class FactoryTests
    {
        public IEnumerable<string> NameGen()
        {
            yield return "Niklas1";
            yield return "Niklas2";
            yield return "Niklas3";
        }

        public IEnumerable<Person> PersGen()
        {
            yield return new Person("Niklas1", 1);
            yield return new Person("Niklas2", 2);
            yield return new Person("Niklas3", 3);
        }

        [Test]
        [Factory("NameGen")]
        public void TestDataGen(string name)
        {
            Assert.StartsWith(name, "Nikl");
        }

        [Test]
        [Description("Test all combinations of both params")]
        public void TestDataGen2(
            [Factory("NameGen")] string name, 
            [Column(1, 2, 3)] int age)
        {
            Assert.StartsWith(name, "Nikl");
        }
    }
}