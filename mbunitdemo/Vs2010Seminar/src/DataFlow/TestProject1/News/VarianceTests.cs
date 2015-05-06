using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.News;

namespace TestProject1.News
{
    [TestClass]
    public class VarianceTests
    {
        [TestMethod]
        public void TestCoStuff()
        {
            var ns = new VarianceStuff();
            ns.CovariantContainerMethod();
        }

        [TestMethod]
        public void TestCo2Stuff()
        {
            var ns = new VarianceStuff();
            ns.NonCovariantContainerMethod();
        }
    }
}
