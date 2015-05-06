using System;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests
{
    [TestFixture]
    [AuthoredByNiklas]
    public class ImpersonateTests
    {
        [Test]
        [Impersonate(UserName = "Niklas2", Password = "Niklas2")]
        public void ImpersonatedTest()
        {
            TestLog.WriteLine(Environment.UserName);
            Assert.AreEqual("Niklas2", Environment.UserName);
        }
    }
}
