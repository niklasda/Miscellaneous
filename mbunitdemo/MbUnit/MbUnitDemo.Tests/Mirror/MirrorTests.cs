using MbUnit.Framework;

namespace MbUnitDemo.Tests.Mirror
{
    public class Fixture
    {
        [Test]
        public void Test()
        {
            var p = new Person("Niklas", 32);
            var pMirror = MbUnit.Framework.Mirror.ForObject(p);

            // Reading from a private field.
            int privateAge = (int)pMirror["_age"].Value;

            Assert.AreEqual(32, privateAge);

            // Writing to a private property.
            pMirror["_age"].Value = 42;
            privateAge = (int)pMirror["_age"].Value;

            Assert.AreEqual(42, privateAge);

            // Invoking a private method.
            int privateMaethodAge = (int)pMirror["getAge"].Invoke();
            Assert.AreEqual(42, privateMaethodAge);
        }
    }
}