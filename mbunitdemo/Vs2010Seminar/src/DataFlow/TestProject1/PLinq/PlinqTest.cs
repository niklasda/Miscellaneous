using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.PLinq;

namespace TestProject1.PLinq
{
    [TestClass]
    public class PLinqTest
    {
        [TestMethod]
        public void TestPlinq()
        {
            var mt = new PLinqStuff();
            mt.Plinq();
        }
    }
}
