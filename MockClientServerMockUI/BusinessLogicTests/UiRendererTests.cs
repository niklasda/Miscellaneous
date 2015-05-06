using System;
using System.Drawing;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockdemo.BusinessClasses;
using Mockdemo.BusinessLogic;
using Mockdemo.ClientUI;
using NMock;
using NMock.Constraints;


namespace Mockdemo.BusinessLogicTests
{
    /// <summary>
    /// A less good example that does not inject in constructor
    /// </summary>
    [TestClass]
    public class UiRendererTests
    {

        [TestMethod]
        public void TestUiRendererWithMock()
        {
            UiRenderer uir = new UiRenderer();
            Assert.IsNotNull(uir, "failed to create UI renderer"); // not needed

            Mock mock = new DynamicMock(typeof(IViewUI));
            IViewUI view = (IViewUI)mock.MockInstance;
            mock.Expect("DrawInTextBox", new IsTypeOf(typeof(string)), new IsAnything(), new IsAnything(), new IsAnything(), new IsAnything());
            
            uir.DrawString(view, "Demo", Color.Black, 1, 2);
            
            mock.Verify();
        }

        [TestMethod]
        public void TestUiRendererWithReal()
        {
            // supposed to fail
            UiRenderer uir = new UiRenderer();

            IViewUI view = new ViewUI();
            uir.DrawString(view, "Demo", Color.Black, 1, 2);

            // nothing to assert here
        }


        [TestMethod]
        public void TestUiRendererAppendTextWithNewLine()
        {
            UiRenderer uir = new UiRenderer();

            Mock mock = new DynamicMock(typeof(IViewUI));
            IViewUI view = (IViewUI)mock.MockInstance;
            mock.ExpectAndReturn("AppendToTextBox", new IsTypeOf(typeof(void)), "Demo");
            mock.ExpectAndReturn("AppendToTextBox", new IsTypeOf(typeof(void)), Environment.NewLine);
            
            uir.AppendString(view, "Demo", true);
            
            mock.Verify();
        }
        
        [TestMethod]
        public void TestUiRendererAppendTextWithoutNewLine()
        {
            UiRenderer uir = new UiRenderer();

            Mock mock = new DynamicMock(typeof(IViewUI));
            IViewUI view = (IViewUI)mock.MockInstance;
            mock.ExpectAndReturn("AppendToTextBox", new IsTypeOf(typeof(void)), "Demo");
            
            uir.AppendString(view, "Demo", false);
            
            mock.Verify();
        }
    }
}
