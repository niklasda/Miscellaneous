using System.Drawing;
using Dahlex;

using NUnit.Framework;
namespace DahlexTests
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestFixture]
    public class RandomizerTests
    {


        [Test]
        public void RandomDirectionTest()
        {
            MoveDirection dir = Randomizer.GetRandomDirection();
            Assert.AreNotEqual(MoveDirection.None, dir);
        }
        
        [Test]
        public void RandomPositionTest()
        {
            Point p = Randomizer.GetRandomPosition(1,1);
            Assert.AreEqual(p.X, 0);
            Assert.AreEqual(p.Y, 0);
        }
    }
}
