using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.News;

namespace TestProject1.News
{
    [TestClass]
    public class ContractsStuffTests
    {
        [TestMethod]
        public void TestContractStuff()
        {
            var ns = new ContractsStuff();
            ns.MyMethod("Niklas", 12);
        }
    }
}
