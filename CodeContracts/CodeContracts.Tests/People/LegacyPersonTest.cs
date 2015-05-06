using CodeContracts.People;
using MbUnit.Framework;

namespace CodeContracts.Tests.People
{
    public class LegacyPersonTest
    {
        [Test]
        public void TestLegacyPerson()
        {
            var p = new LegacyPerson(null, 32);
            Assert.IsNotNull(p);
        }
    }
}