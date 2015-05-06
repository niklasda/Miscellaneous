using System;
using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests
{
    [TestFixture]
    [AuthoredByNiklas]
    public class RetryTests
    {
        readonly Random _random = new Random();

        private bool DoRandomization()
        {
            int next = _random.Next(10);
            TestLog.WriteLine("rnd: {0}", next);
            if (next < 5)
            {
                return true;
            }
            return false;
        }

        private void DoBetweenTests()
        {
            TestLog.WriteLine("Between");
        }

        [Test]
        public void RetryDemo()
        {
            Retry.Repeat(10)
                .Until(DoRandomization);

            Assert.IsTrue(true);
        }

        [Test]
        public void RetryBetweenDemo()
        {
            Retry.Repeat(10)
                .DoBetween(DoBetweenTests)
                .Until(DoRandomization);

            Assert.IsTrue(true);
        }

        [Test]
        public void RetryTimeoutBetweenDemo()
        {
            Retry.WithTimeout(20000)
                .Repeat(10)
                .DoBetween(DoBetweenTests)
                .Until(DoRandomization);

            Assert.IsTrue(true);
        }
    }
}