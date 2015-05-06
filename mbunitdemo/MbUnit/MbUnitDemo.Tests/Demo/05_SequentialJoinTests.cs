using Gallio.Framework;
using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Demo
{
    [TestFixture]
    [AuthoredByDotway]
    [Category(Categories.Joins)]
    public class SequentialJoinTests
    {
        [Test]
        [SequentialJoin]
        public void TestSequentialJoinColumns(
            [Column(0, 1)] int a, 
            [Column("a", "b")] string b, 
            [Column(false, true)] bool c)
        {
            TestLog.WriteLine("{0} {1} {2}", a, b, c);

            // Test something with the specified combination.
            // Will be executed only 2 times instead of 8.

            /*
			 * 0 a false +
			 * 1 a false 
			 * 0 b false 
			 * 1 b false 
			 * 0 a true 
			 * 1 a true
			 * 0 b true 
			 * 1 b true  +
			 * */
        }
    }
}