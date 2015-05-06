using System;
using MbUnit.Framework;
using MbUnitDemo.Exception;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Demo
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Parameterized)]
    public class ParamRowTests
    {
        [Test]
        [Row("Niklas", 23)]
        [Row("Nils", 24)]
        public void RowTestPersonSuccess(string name, int age)
        {
            var p = new Person(name, age);
            Assert.AreEqual(name, p.Name);
            Assert.AreEqual(age, p.Age);
        }





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