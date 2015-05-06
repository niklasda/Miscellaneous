using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text;
using VisitorDemo;

namespace VisitorTests
{
    [TestClass()]
    public class FormUITests
    {
        [TestMethod()]
        public void TestUiPrint()
        {
            Person pers = new Person();
            pers.FirstName = "Niklas";



            //approach 2 (ask)
            FormUI ui = new FormUI();
            ui.PrintPerson(pers);

            // have to change tbOutput to be non-private make this work
            // plus the UI might be hard to instantiate and initialize
            Assert.AreEqual("Niklas ", ui.tbOutput.Text, "Wrong text in textbox");
        }
    }
}
