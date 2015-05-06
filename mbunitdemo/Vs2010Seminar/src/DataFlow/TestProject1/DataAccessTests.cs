using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1;
using ClassLibrary1.EF;

namespace TestProject1
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class DataAccessTests
    {
        [TestMethod]
        public void DataAccessTest()
        {
            var da = new DataAccess();
            IEnumerable<Person> p = da.GetAll();
            Assert.AreEqual(p.Count(), 0);
        }

        [TestMethod]
        public void DataAccessInsertTest()
        {
            var da = new DataAccess();
            da.RemoveAll();
            da.Insert();
            IEnumerable<Person> p = da.GetAll();
            Assert.AreEqual(1, p.Count());
        }
    }
}
