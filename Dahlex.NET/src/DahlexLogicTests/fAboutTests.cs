using NUnit.Framework;
using NUnit.Extensions.Forms;
using Dahlex;

namespace DahlexTests
{
    [TestFixture]
    public class fAboutTests
    {
        [Test]
        public void TestForm() 
        {
            fAbout.ShowMe();

            FormTester formT = new FormTester("fAbout");
            ButtonTester buttonT = new ButtonTester("bClose");
            Assert.AreEqual("&Close", buttonT.Text);

            Assert.AreEqual(1, formT.Count);
            Assert.AreEqual(1, buttonT.Count);


            buttonT.Click();
            Assert.AreEqual("&Close", buttonT.Text);

        }
    }
}
