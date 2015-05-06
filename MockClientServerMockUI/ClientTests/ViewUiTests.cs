using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockdemo.ClientUI;

namespace Mockdemo.ClientTests
{
    /// <summary>
    /// This is probably a test that should no be in.
    /// </summary>
    [TestClass]
    public class ViewUiTests
    {

        [TestMethod]
        public void TestViewUiCreation()
        {
            ViewUI ui = new ViewUI();
            Assert.IsNotNull(ui, "Failed to create UI");
        }
    }
}
