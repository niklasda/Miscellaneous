using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;
using ProxyMocker.Tests;

namespace Proxymockervs.Tests
{
    [TestFixture]
    public class GenericDelegateTest
    {
        [Test]
        public void TestGenDel()
        {
            SimpleGenImplementation simple = new SimpleGenImplementation();
            int res = simple.delegateMe();
            Assert.AreEqual(12, res);
        }
    }
    public class SimpleGenImplementation : ISimpleGenTest
    {
        public delegate int Simplegate();

        public int GenericMethod1<T>()
        {
            return 1;
        }

        public int delegateMe()
        {
            Simplegate delvar = new Simplegate(GenericMethod1<int>);
            int i = delvar.Invoke();
            return i;
        }
    }
}