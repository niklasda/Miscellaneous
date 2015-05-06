using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.News;

namespace TestProject1.News
{
    [TestClass]
    public class ArgsTests
    {
        [TestMethod]
        public void TestDefaultStuff()
        {
            var ns = new ArgsStuff();
            string tag = ns.MyMethod("Niklas");

            Assert.AreEqual("Name:Niklas Age:30", tag);
        }







        [TestMethod]
        public void TestNamedStuff()
        {
            var ns = new ArgsStuff();
            string tag = ns.MyMethod(age: 35, name: "Niklas");

            Assert.AreEqual("Name:Niklas Age:35", tag);
        }





        [TestMethod]
        public void TestDynamicStuff()
        {
            dynamic ns = new VarianceStuff();
            string tag = ns.MyNewjjkkMethod(age: 35, name: "Niklas");

            Assert.AreEqual("Name:Niklas Age:35", tag);
        }





        [TestMethod]
        public void TestMefStuff()
        {
            ArgsStuff mef = new ArgsStuff();
            int parts = mef.MefStuff();

            Assert.AreEqual(parts, 1);
        }
    }
}
