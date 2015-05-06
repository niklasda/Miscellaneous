using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FactoryDemo;
using NMock;
//using NMock.Dynamic;

namespace FactoryDemo.Tests
{
    /// <summary>
    /// Tests of the PersonFactory class, the person class needs a database.
    /// If the database is available we have 100% coverage,
    /// If the database goes down, exceptions are thrown and coverage drops to 41%
    /// 
    /// And that is bad since these tests are for the Factory and not the database
    /// </summary>
    [TestClass]
    public class PersonFactoryTests
    {
        private int existingId = 1;
        private int nonExistingId = 20000;

        [TestMethod]
        public void TestPersonFactoryCreateNew()
        {
            IDatabase db = new Database();
            PersonFactory fac = new PersonFactory(db);

            Person p = fac.CreateNewPerson(nonExistingId);

            Assert.AreEqual(nonExistingId, p.Id, "Person got wrong ID");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestPersonFactoryCreateNewExisting()
        {
            IDatabase db = new Database();
            PersonFactory fac = new PersonFactory(db);

            Person p = fac.CreateNewPerson(existingId);

            Assert.AreEqual(existingId, p.Id, "Person got wrong ID");
        }

        [TestMethod]
        public void TestPersonFactoryGetExisting()
        {
            IDatabase db = new Database();
            PersonFactory fac = new PersonFactory(db);

            Person p = fac.GetExistingPerson(existingId);

            Assert.AreEqual(existingId, p.Id, "Person got wrong ID");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestPersonFactoryGetNonExisting()
        {
            IDatabase db = new Database();
            PersonFactory fac = new PersonFactory(db);

            Person p = fac.GetExistingPerson(nonExistingId); // throws since id=20000 does not exist in database

            Assert.AreEqual(nonExistingId, p.Id, "Person got wrong ID");
        }


        /*
         * Mocked versions below.
         * They are independant of the database.
         * 
         */

        [TestMethod]
        public void TestPersonFactoryCreateNewMocked()
        {
            DynamicMock mock = new DynamicMock(typeof(IDatabase));
            mock.ExpectAndReturn("PersonIdAlreadyExists", false, nonExistingId);

            IDatabase db = (IDatabase)mock.MockInstance;
            PersonFactory fac = new PersonFactory(db);

            Person p = fac.CreateNewPerson(nonExistingId);

            Assert.AreEqual(nonExistingId, p.Id, "Person got wrong ID");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestPersonFactoryCreateNewExistingMocked()
        {
            // the mock here makes our test independent of whether the id 
            // really exists in the database or not
            DynamicMock mock = new DynamicMock(typeof(IDatabase));
            mock.ExpectAndReturn("PersonIdAlreadyExists", true, existingId);

            IDatabase db = (IDatabase)mock.MockInstance;
            PersonFactory fac = new PersonFactory(db);

            Person p = fac.CreateNewPerson(existingId); // throws

            // no assert, the ExpectedException is the Assert
        }

        [TestMethod]
        public void TestPersonFactoryGetExistingMocked()
        {
            DynamicMock mock = new DynamicMock(typeof(IDatabase));
            IDatabase db = (IDatabase)mock.MockInstance;

            Person returnValue = new Person(existingId);
            mock.ExpectAndReturn("GetExistingPerson", returnValue, existingId);
            
            PersonFactory fac = new PersonFactory(db);
            Person p = fac.GetExistingPerson(existingId);

            Assert.AreEqual(existingId, p.Id, "Person got wrong ID");
        }

        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestPersonFactoryGetNonExistingMocked()
        {
            DynamicMock mock = new DynamicMock(typeof(IDatabase));
            mock.Expect("GetExistingPerson", nonExistingId);
           
            IDatabase db = (IDatabase)mock.MockInstance;
            PersonFactory fac = new PersonFactory(db);

            Person p = fac.GetExistingPerson(nonExistingId);

            mock.Verify();
            Assert.AreEqual(nonExistingId, p.Id, "Person got wrong ID");
        }
    }
}
