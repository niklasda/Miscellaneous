using NUnit.Framework;

namespace ProxyMocker.Tests
{
    [TestFixture]
    public class GenericDelegateTest
    {
        [Test]
        public void TestGenDel()
        {
            int expectedValue = 12;
            SimpleGenImplementation simple = new SimpleGenImplementation(expectedValue);
            int res = simple.delegateMe();
            Assert.AreEqual(12, res);
        }
    }
    
    public class SimpleGenImplementation : ISimpleGenTest
    {
        public SimpleGenImplementation(int expectedValue)
        {
            returnValue = expectedValue;
        }
        
        public delegate int Simplegate();
        private int returnValue;

        public int GenericMethod1<T>()
        {
            return returnValue;
        }

        public int delegateMe()
        {
            Simplegate delvar = new Simplegate(GenericMethod1<int>);
            int i = delvar.Invoke();
            return i;
        }
    }
}