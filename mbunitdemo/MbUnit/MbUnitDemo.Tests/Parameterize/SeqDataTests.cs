using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Parameterize
{
    [TestFixture]
    [AuthoredByNiklas]
    [Category(Categories.Parameterized)]
    public class SeqDataTests
    {
        [Test]
        public void TestSeqData(
            [SequentialNumbers(Start=1.0, End=5.1, Step=0.25)] decimal fraction)
        {            
            Assert.Between(fraction, 1, 5.1m);
        }
    }
}