using System.Threading;
using Gallio.Framework;
using MbUnit.Framework;

namespace MbUnitDemo.Tests.Ordering
{
    public class RepeatedTests
    {
        [Test]
        [ThreadedRepeat(3)]
        public void ThreadedRepeatedDemo()
        {
            TestLog.WriteLine("Thread: {0}", Thread.CurrentThread.Name);

            Assert.IsTrue(true);
        }

        [Repeat(3)]
        public void RepeatedCemo()
        {
            TestLog.WriteLine("Thread: {0}", Thread.CurrentThread.Name);

            Assert.IsTrue(true);
        }
    }
}