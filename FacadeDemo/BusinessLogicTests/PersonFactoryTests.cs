using System;
using System.Xml;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FacadeDemo;
using NMock;
using NMock.Dynamic;

namespace FacadeDemo.Tests
{
    [TestClass]
    public class PersonFactoryTests
    {
        [TestMethod]
        public void TestPersonFactory()
        {
            // we have Dependency injection, but we can't mock it
            XmlTextReader xtr = new XmlTextReader(@"C:\Niklas.xml");
            PersonFactory pf = new PersonFactory();
            Person p = pf.CreatePersonFromXml(xtr);

            // State-based test
            Assert.AreEqual("Niklas", p.Name, "Wrong name");
        }

        [TestMethod]
        public void TestPersonFactoryFacade()
        {
            // we have Dependency injection, but we can't mock it
            IXmlReaderFacade xrf = new XmlReaderFacade(@"C:\Niklas.xml");
            PersonFactory pf = new PersonFactory();
            Person p = pf.CreatePersonFromXmlFacade(xrf);

            // State-based test
            Assert.AreEqual("Niklas", p.Name, "Wrong name");
        }

        [TestMethod]
        public void TestPersonFactoryFacadeMock()
        {
            DynamicMock mock = new DynamicMock(typeof(IXmlReaderFacade));
            IXmlReaderFacade xrf = (IXmlReaderFacade)mock.MockInstance;
            mock.ExpectAndReturn("GetPersonName", "Niklas");

            PersonFactory pf = new PersonFactory();
            Person p = pf.CreatePersonFromXmlFacade(xrf);

            // interction based test
            mock.Verify();

            // State-based test
            Assert.AreEqual("Niklas", p.Name, "Wrong name");
        }
    }
}
