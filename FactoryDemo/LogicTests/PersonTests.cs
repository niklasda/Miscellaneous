using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FactoryDemo.Tests
{
    /// <summary>
    /// Small tests for the person class, but the person class contains very little logic
    /// since it's sopposed to be built by the Factory
    /// </summary>
    [TestClass]
    public class PersonTests
    {
        [TestMethod]
        public void TestPersonSetName()
        {
            int id = 1;
            Person p = new Person(id);

            Assert.AreEqual(id, p.Id, "Person got wrong ID");
        }

        [TestMethod]
        public void TestPersonSetProblemSetGetName()
        {
            int id = 1;
            Person p = new Person(id);
            p.SetName("N", "D");

            Assert.AreEqual("N D", p.GetName(), "Person got wrong ID");
        }
    }
}
