using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using VisitorDemo;
using NMock;
using NMock.Dynamic;
using NMock.Constraints;

namespace VisitorTests
{
    [TestClass()]
    public class PersonTests
    {
        [TestMethod()]
        public void TestPersonPrint()
        {
            IFormUI ui = new FormUI();

            // approach 2 (tell)
            Person p = new Person();
            p.FirstName = "Niklas";
            p.PrintName(ui);

            // have to change interface to make this Assertable
        }

        [TestMethod()]
        public void TestPersonPrintMock()
        {
            DynamicMock mock = new DynamicMock(typeof(IFormUI));
            IFormUI ui = (IFormUI)mock.MockInstance;
            mock.Expect("PrintString", "Niklas ");  // set expectations before using mock

            Person p = new Person();
            p.FirstName = "Niklas";
            p.PrintName(ui);

            mock.Verify();
        }
    }
}
