using System.Collections.Generic;
using MbUnit.Framework;

namespace ClassLibrary1.News
{
    public class SortedSetMbTests
    {
        [Test]
        public void SortedTest()
        {
            SortedSet< int> set = new SortedSet<int>(new[] { 3, 6, 8, 9, 2, 1, 0, 7878, 4 });
            Assert.Sorted(set, SortOrder.Increasing);
        }
    }
}
