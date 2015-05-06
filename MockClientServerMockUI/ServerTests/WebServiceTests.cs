using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockdemo.Server;

namespace Mockdemo.ServerTests
{
    /// <summary>
    /// </summary>
    [TestClass]
    public class WebServiceTests
    {

        [TestMethod]
        public void TestGetExistingProduct()
        {
            WebService ws = new WebService();
            Assert.IsNotNull(ws, "Failed to create WebService");
            string ver = ws.GetVersion();
        }
    }
}
