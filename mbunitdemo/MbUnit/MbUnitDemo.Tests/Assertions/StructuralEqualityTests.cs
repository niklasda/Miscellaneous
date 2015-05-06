using MbUnit.Framework;
using MbUnitDemo.Tests.Extensions;

namespace MbUnitDemo.Tests.Assertions
{
    [TestFixture]
    [AuthoredByNiklas]
    [Importance(Importance.Serious)]
    [Category(Categories.Assertions)]
    public class StructuralEqualityTest
    {
        [Test]
        [MultipleAsserts]
        [Category(Categories.Assertions)]
        public void StructuralEqualityComparerTest()
        {
            var p1 = new Person("p2", 22);
            var p2 = new Person("p2", 22);

            //  Assert.AreEqual(p1, p2); // fails
            //  Assert.AreSame(p1, p2);  // fails

            var sec = new StructuralEqualityComparer<Person>
            {
                 x => x.Age ,
                 x => x.Name ,
                 x => x.ToString()
            };
            Assert.AreEqual(p1, p2, sec);
        }
    }
}