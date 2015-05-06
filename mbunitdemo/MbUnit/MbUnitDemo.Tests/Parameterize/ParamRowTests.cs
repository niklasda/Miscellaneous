using System;
using MbUnit.Framework;
using MbUnitDemo.Exception;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Parameterize
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Parameterized)]
    public class ParamRowTests
    {
        [Test]
        [Row("niklas", -1, ExpectedException = typeof(AgeException))]
        [Row("", 21, ExpectedException = typeof(ArgumentNullException))]  
        public void RowTestPersonInvalid(string name, int age)
        {
            var p = new Person(name, age);
            Assert.AreEqual(name, p.Name);
            Assert.AreEqual(age, p.Age);
        }
    }
}