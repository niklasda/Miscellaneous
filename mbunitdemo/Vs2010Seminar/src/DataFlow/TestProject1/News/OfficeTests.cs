using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.News;

namespace TestProject1.News
{
    [TestClass]
    public class OfficeTests
    {
        [TestMethod]
        public void TestWordStuff()
        {
            var ns = new OfficeStuff();
            ns.WordMethod();
        }
    }
}
