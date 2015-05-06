using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.MockObjects;

namespace DependencyInjectionDemo.Tests
{
    [TestClass()]
    public class LogicMofTests
    {
        [TestMethod()]
        public void TestGetVersion()
        {
            /*
             * since we don't want the test to require a database connection, we mock the database layer
             * The database layer should be tested separatly and not by the Business logic layer.
             * We are trying to test the logic inside GetDatabaseVersion here
             */
            Mock<IDatabase> mock = new Mock<IDatabase>();
            mock.Implement("GetVersion");  // expected call in Database class,
            // the return value may or may not be relevant to the test!

            // mock.ExpectAndReturn("GetVersion", "Microsoft SQL Server 2005 ..."); // If the function under test
            // performs some operations on the text, a return value can be set this way.

            IDatabase db = mock.Instance;

            Logic log = new Logic(db);
            string ver = log.GetDatabaseVersion();

          //  mock.Verify();
        }
    }
}