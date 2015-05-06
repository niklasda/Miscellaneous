using System;
using System.Diagnostics;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TestProject1.News
{
    [TestClass]
    public class LazyTests
    {
        [TestMethod]
        public void LazyTest()
        {
            // this works only with parameterless constructor

            var myLazy = new Lazy<MyTestClass>();
            MyTestClass myt = myLazy.Value;

            Assert.AreEqual(true, myLazy.IsValueCreated);
            Assert.IsNotNull(myt);
        }
    }

    public class MyTestClass
    {
        public MyTestClass()
        {
            Debugger.Break();
        }
    }
}


