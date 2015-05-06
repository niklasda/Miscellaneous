using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ObserverDemo.Tests
{
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void TestPersonCtor()
        {
            // the person class is easy to test since it is decoupled from its dependencies
            // using events

            string actualName = "Niklas";
            Person p = new Person(actualName);
            Assert.AreEqual(actualName, p.Name, "Setting name in ctor failed");
        }
    }
}
