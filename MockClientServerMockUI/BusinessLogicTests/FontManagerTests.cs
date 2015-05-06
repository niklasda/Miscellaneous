using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Mockdemo.BusinessLogic;

namespace Mockdemo.BusinessLogicTests
{
    /// <summary>
    /// </summary>
    [TestClass]
    public class FontManagerTests
    {

        [TestMethod]
        public void TestFontManagerGetDefaultFont()
        {
            FontManager fm = new FontManager();

            float expected = 52;
            Font df = fm.GetDefaultFont();
            Assert.AreEqual("Arial", df.Name, "Wrong default font");
            Assert.AreEqual(expected, df.Size, "Wrong default fontsize");

        }
        
        [TestMethod]
        public void TestFontManagerGetFont()
        {
            FontManager fm = new FontManager();

            float expected4 = 12;
            Font f = fm.GetFont(12);
            Assert.AreEqual((expected4 / 4), f.Size, "Wrong font size");
        }
    }
}
