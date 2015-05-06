using System;
using System.Threading;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Attributes
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Attributes)]
    public class MoreAttributesTests
    {
        [Test]
        [ApartmentState(ApartmentState.STA)]
        [Explicit("Explicit = must run alone")]
        public void ExplicitTest()
        {
            Assert.IsTrue(true);
        }

        [Test]
        [Importance(Importance.Serious)]
        public void ImportanceTest()
        {
            Assert.IsTrue(true);
        }

        [Test]
        [ExpectedException(typeof(ArgumentNullException))]
        [TestsOn(typeof(Person))]
        public void ExpecteExceptionTest()
        {
            var p = new Person(null, 23);
            Assert.IsNull(p);
        }

        [Test]
        [ExpectedArgumentNullException]
        public void ExpectedArgumentNullException()
        {
            var p = new Person(null, 23);
            Assert.IsNull(p);
        }

        [Test]
        [MultipleAsserts]
        public void MultiFailTest()
        {
            Assert.IsTrue(false);
            Assert.IsTrue(false);
            Assert.IsTrue(false);
            Assert.IsTrue(true);
        }
    }
}