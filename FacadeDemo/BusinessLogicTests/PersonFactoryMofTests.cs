using System;
using System.Xml;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Microsoft.VisualStudio.TestTools.MockObjects;
using FacadeDemo;

namespace FacadeDemo.Tests
{
    [TestClass]
    public class PersonFactoryMofTests
    {

        [TestMethod]
        public void TestPersonFactoryFacadeMock()
        {
            Mock<IXmlReaderFacade> mock = new Mock<IXmlReaderFacade>();
            IXmlReaderFacade xrf = mock.Instance;
            mock.Implement("GetPersonName", "Niklas" );

            PersonFactory pf = new PersonFactory();
            Person p = pf.CreatePersonFromXmlFacade(xrf);


            // State-based test
            Assert.AreEqual("Niklas", p.Name, "Wrong name");
        }
    }
}
