using System.Collections.Generic;
using ClassLibrary1.News;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.News
{
    [TestClass]
    public class SortedSetTests
    {
        [TestMethod]
        public void SortedTest()
        {
            SortedSetMbTests sortedStuff = new SortedSetMbTests();
            sortedStuff.SortedTest();
        }
    }
}
