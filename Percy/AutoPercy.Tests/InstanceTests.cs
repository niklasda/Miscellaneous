using AutoPercy.Logic;
using Clz.Logic;
using MbUnit.Framework;

namespace AutoPercy.Tests
{
    [TestFixture]
    public class InstanceTests
    {
        [Test]
        public void ClzManagerTest()
        {
            Assert.IsNotNull(ClzManager.Instance);
        }

        [Test]
        public void PercyManagerTest()
        {
            Assert.IsNotNull(PercyManager.Instance);
        }
    }
}
