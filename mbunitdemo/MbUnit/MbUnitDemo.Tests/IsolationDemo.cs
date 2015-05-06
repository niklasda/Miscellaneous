using System;
using System.Threading;
using Gallio.Framework;
using MbUnit.Framework;

namespace MbUnitDemo.Tests
{
    // all tests run on same thread and in same appdomain
    // can run in Icarus AppDomain, see options

    [TestFixture]
    public class IsolationDemo1
    {
        [Test]
        public void DemoIsolation11()
        {
            TestLog.WriteLine("AppDomain: {0}", AppDomain.CurrentDomain.Id);
            TestLog.WriteLine("Thread: {0}", Thread.CurrentThread.Name);
        }

        [Test]
        public void DemoIsolation12()
        {
            TestLog.WriteLine("AppDomain: {0}", AppDomain.CurrentDomain.Id);
            TestLog.WriteLine("Thread: {0}", Thread.CurrentThread.Name);
        }
    }


    [TestFixture]
    public class IsolationDemo2
    {
        [Test]
        public void DemoIsolation21()
        {
            TestLog.WriteLine("AppDomain: {0}", AppDomain.CurrentDomain.Id);
            TestLog.WriteLine("Thread: {0}", Thread.CurrentThread.Name);
            TestLog.WriteLine("Identity: {0}", Thread.CurrentPrincipal.Identity.Name);
        }

        [Test]
        public void DemoIsolation22()
        {
            TestLog.WriteLine("AppDomain: {0}", AppDomain.CurrentDomain.Id);
            TestLog.WriteLine("Thread: {0}", Thread.CurrentThread.Name);
            TestLog.WriteLine("Identity: {0}", Thread.CurrentPrincipal.Identity.Name);
        }
    }
}