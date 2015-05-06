using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Join
{
    [TestFixture]
    [AuthoredByDotway]
    [Category(Categories.Joins)]
    public class PairJoinTests
    {
        [Test]
        [PairwiseJoin]
        public void TestPairCol(
            [Column(0, 1)] int a, 
            [Column("a", "b")] string b, 
            [Column(false, true)] bool c)
        {
            TestLog.WriteLine("{0} {1} {2}", a, b, c);

            // Test something with the specified combination.
            // Will be executed only 4 times instead of 8.

            /*
			 * 0 a false
			 * 1 a false +
			 * 0 b false +
			 * 1 b false 
			 * 0 a true  +
			 * 1 a true
			 * 0 b true
			 * 1 b true  +
			 * */
        }

        [Test]
        [Row(1, "a", false)]
        [Row(0, "b", false)]
        [Row(0, "a", true)]
        [Row(1, "b", true)]
        public void TestPairRow(int a, string b, bool c)
        {
            TestLog.WriteLine("{0} {1} {2}", a, b, c);
        }
    }
}