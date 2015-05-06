using MbUnit.Framework;

namespace MbUnitDemo.Tests.Join
{
    public class CustomJoinAttributeTests
    {
        [Test]
        [OnewiseJoin]
        public void TestPairCol([Column(0, 1)] int a)
        {
            Assert.AreEqual(5, a);
        }
    }
}