using System.Threading;
using Gallio.Framework;
using MbUnit.Framework;

[assembly: DegreeOfParallelism(5)]

namespace MbUnitDemo.Tests.Ordering
{
    public class ParallellTests
    {
        [Test]
        [Parallelizable]
        public void Parallel1Demo()
        {
            TestLog.WriteLine("Para: {0}", Thread.CurrentThread.Name);
            Assert.IsTrue(true);
        }

        [Test]
        [Repeat(2)]
        [Parallelizable]
        public void Parallel2Demo()
        {
            TestLog.WriteLine("Para: {0}", Thread.CurrentThread.Name);
            Assert.IsTrue(true);
        }

        [Test]
        [ThreadedRepeat(2)]
        [Parallelizable]
        public void Parallel3Demo()
        {
            TestLog.WriteLine("Para: {0}", Thread.CurrentThread.Name);
            Assert.IsTrue(true);
        }

        [Test]
        [Repeat(2)]
        [Parallelizable]
        public void Parallel4Demo()
        {
            TestLog.WriteLine("Para: {0}", Thread.CurrentThread.Name);
            Assert.IsTrue(true);
        }
    }
}