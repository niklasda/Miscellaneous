using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.News
{
    [TestClass]
    public class TupleTests
    {
        [TestMethod]
        public void TupleTest()
        {
            var eight = Tuple.Create(1, 2, 3, 4, 5, 6, 7, 8);
            var seven = Tuple.Create(1, 2, 3, 4, 5, 6, 7);
            var sixxx = Tuple.Create(1, 2, 3, 4, 5, 6);
            var fivee = Tuple.Create(1, 2, 3, 4, 5);
            var fourr = Tuple.Create(1, 2, 3, 4);
            var three = Tuple.Create(1, 2, 3);
            var twooo = Tuple.Create(1, 2);
            var oneee = Tuple.Create(1);

            Tuple<int, int> t = Tuple.Create(1, 2);

            Assert.AreEqual(t, twooo);
            Assert.AreEqual(7, eight.Item7);
            Assert.AreEqual(8, eight.Rest.Item1);
        }
    }
}


