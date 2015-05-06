using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockdemo.BusinessClasses;
using Mockdemo.BusinessLogic;
using Mockdemo.Server;
using NMock;
using NMock.Constraints;

namespace Mockdemo.BusinessLogicTests
{
    /// <summary>
    /// </summary>
    [TestClass]
    public class ProductFactoryTests
    {

        [TestMethod]
        public void TestProductFactoryCreateNewReal()
        {
            // supposed to fail
            IDatabase db = new Database(false); // real database

            ProductFactory pf = new ProductFactory(db);

            Product p = pf.CreateNewProduct(1000);
            Assert.IsNotNull(p, "Failed to create product");
        }
        
        [TestMethod]
        public void TestProductFactoryCreateNewMock()
        {
            Mock mock = new DynamicMock(typeof(IDatabase));
            IDatabase db = (IDatabase)mock.MockInstance;
            mock.ExpectAndReturn("ProductIdAlreadyExists", false, 1000);
            
            ProductFactory pf = new ProductFactory(db);

            Product p = pf.CreateNewProduct(1000);          // with a mock we can be sure
            Assert.IsNotNull(p, "Failed to create product");
            
            mock.Verify();
        }
        
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestProductFactoryCreateNewExisting()
        {
            ProductFactory pf = new ProductFactory(true);

            Product p = pf.CreateNewProduct(1);
            Assert.IsNotNull(p, "Failed to create product");
        }
        
        [TestMethod]
        public void TestProductFactoryGetExisting()
        {
            ProductFactory pf = new ProductFactory(true); // real database

            // can't be really sure if it already exists or not
            Product p = pf.GetExistingProduct(1);
            Assert.IsNotNull(p, "Failed to get product");
        }
        
        [TestMethod]
        [ExpectedException(typeof(BusinessException))]
        public void TestProductFactoryGetExistingMissing()
        {
            ProductFactory pf = new ProductFactory(true); // real database

            // can't be really sure if it is missing or not
            Product p = pf.GetExistingProduct(1001);
            Assert.IsNotNull(p, "Failed to get product");
        }
    }
}
