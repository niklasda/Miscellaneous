using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockdemo.BusinessClasses;
using Mockdemo.Server;

namespace Mockdemo.ServerTests
{
    /// <summary>
    /// </summary>
    [TestClass]
    public class DatabaseTests
    {
        [TestMethod]
        public void TestGetExistingProduct()
        {
            int id = 1;
            Database db = new Database(true);
            Product p = db.GetExistingProduct(id);
            Assert.IsNotNull(p, "Failed to get existing product: {0}", id);
        }
        
        [TestMethod]
        public void TestProductAlreadyExists()
        {
            int id = 1;
            Database db = new Database(true);
            bool exists = db.ProductIdAlreadyExists(id);
            Assert.IsTrue(exists, "product failed to exist: {0}", id);
        }
        
        [TestMethod]
        public void TestGetVersion()
        {
            Database db = new Database(true);
            string ver = db.GetVersion();
            Assert.IsNotNull(ver, "Failed to get version");
        }
    }
}
