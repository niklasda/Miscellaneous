using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.MockObjects;
using FactoryDemo;

namespace FactoryDemo.Tests
{
    /// <summary>
    /// Testing the Visual Studio Mock Object Framework
    /// </summary>
    [TestClass]
    public class PersonFactoryMOFTests
    {
        private int existingId = 1;
        private int nonExistingId = 20000;


        [TestMethod]
        public void TestPersonFactoryGetExistingMofMocked()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            IDatabase db = mock.Instance;

            Person returnValue = new Person(existingId);
            object[] args = new object[] { existingId };
            mock.Implement("GetExistingPerson", args, returnValue);

            PersonFactory fac = new PersonFactory(db);
            Person p = fac.GetExistingPerson(existingId);

            Assert.AreEqual(existingId, p.Id, "Person got wrong ID");
        }

        [TestMethod]
        public void TestPersonFactoryGetExistingMofMockedMI()
        {
            Mock<IDatabase> mock = new Mock<IDatabase>();
            IDatabase db = mock.Instance;

            Person returnValue = new Person(existingId);
            object[] args = new object[] { existingId };

            MethodId mi = new MethodId(typeof(IDatabase), "GetExistingPerson");

            mock.Implement(mi, args, returnValue);

            PersonFactory fac = new PersonFactory(db);
            Person p = fac.GetExistingPerson(existingId);

            Assert.AreEqual(existingId, p.Id, "Person got wrong ID");
        }
    }
}
