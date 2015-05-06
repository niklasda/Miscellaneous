using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.MockObjects;
using VisitorDemo;

namespace VisitorTests
{
    [TestClass()]
    public class PersonTestsMof
    {
        [TestMethod()]
        public void TestPersonPrintMock()
        {
            Mock<IFormUI> mock = new Mock<IFormUI>();
            IFormUI ui = mock.Instance;
            mock.Implement("PrintString", new object[] { "Niklas " } );  // set expectations before using mock

            Person p = new Person();
            p.FirstName = "Niklas";
            p.PrintName(ui);
        }
    }
}
