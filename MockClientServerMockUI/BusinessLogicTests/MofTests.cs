using System;
using System.Drawing;
using System.Text.RegularExpressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.MockObjects;
using Mockdemo.BusinessClasses;
using Mockdemo.BusinessLogic;

namespace BusinessLogicTests
{
    /// <summary>
    /// this was just for screenshots, and demos
    /// </summary>
    [TestClass] public class MofTests
    {
        [TestMethod]
        public void TestMof()
        {
            SequenceMock<IViewUI> mockView = new SequenceMock<IViewUI>();
            IViewUI view = mockView.Instance;

            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsInstanceOfType<string>(typeof(string)) });   // sql server ...
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsInstanceOfType<string>(typeof(string)) });   // newLine
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsInstanceOfType<string>(typeof(string)) });   // Ctrl...
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsInstanceOfType<double>(typeof(double)) });   // random
          //  mockView.ExpectNoCall("DrawInTextBox", typeof(string), typeof(Font), typeof(Color), typeof(int), typeof(int));

            VersionManager vm = new VersionManager(true);
            vm.PrintVersionNumber(view);

            mockView.Verify();
        }

        [TestMethod]
        public void TestMof2()
        {
            SequenceMock<IViewUI> mockView = new SequenceMock<IViewUI>();
            IViewUI view = mockView.Instance;

            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsNotSame<string>("Blah") });
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsInstanceOfTypeAnd<string>(MockConstraint.IsNotNull<string>()) });
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsInstanceOfType<string>(typeof(string)) });
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsInstanceOfType<double>(typeof(double)) });
         
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsAnything<string>()});
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.And<string>(MockConstraint.IsInstanceOfType<string>(typeof(string)), MockConstraint.IsNotNull<string>()) });
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsNotEqual<string>("Ctrl")});
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsInstanceOfType<double>(typeof(double))});

            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsNotIn<string>("Blaj", "2")});
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsEqual<string>(Environment.NewLine) });
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsNotEqual("Ctrl") });
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsInstanceOfType<double>(typeof(double)) });

            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsInstanceOfAnyType<string>(new Type[] { typeof(string) }) });
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.Or<string>(MockConstraint.IsInstanceOfType<string>(typeof(string)), MockConstraint.IsNotNull<string>()) });
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsNotEqual("Ctrl")});
            mockView.AddExpectation("AppendToTextBox", new object[] { MockConstraint.IsInstanceOfType<double>(typeof(double))});


            // Missing:  IsEqualIgnoreWhiteSpace, IsMatch, IsCloseTo, StartsWith

            VersionManager vm = new VersionManager(true);
            vm.PrintVersionNumber(view);
            vm.PrintVersionNumber(view);
            vm.PrintVersionNumber(view);
            vm.PrintVersionNumber(view);

            mockView.Verify();
        }
    }
}