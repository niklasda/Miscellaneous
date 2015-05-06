using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockdemo.BusinessClasses;

namespace Mockdemo.BusinessClassesTests
{
    /// <summary>
    /// </summary>
    [TestClass]
    public class ProductTests
    {
        [TestMethod]
        public void TestCreateProduct()
        {
            int id = 1;
            Product p = new Product(id);
            Assert.AreEqual(id, p.Id, "Id of created product was wrong");
        }
    }
}
