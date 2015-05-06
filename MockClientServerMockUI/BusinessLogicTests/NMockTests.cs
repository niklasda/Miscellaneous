using System;
using System.Drawing;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockdemo.BusinessClasses;
using Mockdemo.BusinessLogic;

namespace BusinessLogicTests
{
    using NMock;
    using NMock.Constraints;

    /// <summary>
    /// this was just for screenshots, and demos
    /// </summary>
    [TestClass] public class NMockTests
    {
        [TestMethod]
        public void TestNMock()
        {
            Mock mockView = new DynamicMock(typeof(IViewUI));
            IViewUI view = (IViewUI)mockView.MockInstance;

            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(string)));   // sql server ...
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(string)));   // newLine
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(string)));   // Ctrl
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(double)));   // random
            mockView.ExpectNoCall("DrawInTextBox", typeof(string), typeof(Font), typeof(Color), typeof(int), typeof(int));

            VersionManager vm = new VersionManager(true);
            vm.PrintVersionNumber(view);

            mockView.Verify();
        }

        [TestMethod]
        public void TestNMock2()
        {
            Mock mockView = new DynamicMock(typeof(IViewUI));
            IViewUI view = (IViewUI)mockView.MockInstance;

            mockView.Expect("AppendToTextBox", new NotEqual("Blah")      );
            mockView.Expect("AppendToTextBox", new And( new IsTypeOf(typeof(string)), new IsEqualIgnoreWhiteSpace("")));
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(string)));
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(double)));
            mockView.ExpectNoCall("DrawInTextBox", typeof(string), typeof(Font), typeof(Color), typeof(int), typeof(int));

            mockView.Expect("AppendToTextBox", new IsAnything()      );
            mockView.Expect("AppendToTextBox", new And( new IsTypeOf(typeof(string)), new NotNull()));
            mockView.Expect("AppendToTextBox", new StartsWith("Ctrl"));
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(double)));

            mockView.Expect("AppendToTextBox", new NotIn("Blaj", 2));
            mockView.Expect("AppendToTextBox", new Or(new IsEqual(Environment.NewLine), new IsEqualIgnoreWhiteSpace("")));
            mockView.Expect("AppendToTextBox", new IsMatch(new Regex("C.*:")));
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(double)));

            mockView.Expect("AppendToTextBox", new Not( new IsIn("Blaj", 2)));
            mockView.Expect("AppendToTextBox", new Or(new IsEqual(Environment.NewLine), new IsEqualIgnoreWhiteSpace("")));
            mockView.Expect("AppendToTextBox", new IsMatch(new Regex("C.*:")));
            mockView.Expect("AppendToTextBox", new IsCloseTo(0.5, 0.5) );

            VersionManager vm = new VersionManager(true);
            vm.PrintVersionNumber(view);
            vm.PrintVersionNumber(view);
            vm.PrintVersionNumber(view);
            vm.PrintVersionNumber(view);

            mockView.Verify();
        }
    }
}