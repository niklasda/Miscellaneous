using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.PLinq;

namespace TestProject1.PLinq
{
    [TestClass]
    public class PxTest
    {
        [TestMethod]
        public void TestPFor()
        {
            var mt = new PxStuff();
            mt.MultiFor();
            mt.MultiForEach();
        }
        




        [TestMethod]
        public void TestParallelTaskLibFactory()
        {
            var mt = new PxStuff();
            mt.ParallelTaskLibFactory();
        }




        [TestMethod]
        public void TestParallelTaskLibStartNew()
        {
            var mt = new PxStuff();
            mt.ParallelTaskLibStartNew();
        }
    }
}
