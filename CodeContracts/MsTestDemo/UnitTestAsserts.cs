using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MsTestDemo
{
    [TestClass]
    public class UnitTestAsserts
    {
        [TestMethod]
        public void TestMethodAsserts()
        {
            Assert.AreEqual("Niklas", "Niklas");
            Assert.AreNotEqual("Niklas", "apa");
            Assert.AreNotSame("abc", "ijk");
            Assert.AreSame("asd", "asd");
          //  Assert.Fail();
          //  Assert.Inconclusive();
            Assert.IsFalse(false);
            Assert.IsInstanceOfType("nik", typeof(string));
            Assert.IsNotInstanceOfType(1, typeof(string));
            Assert.IsNotNull("not");
            Assert.IsNull(null);
            Assert.IsTrue(true);
            
        }
    }
}
