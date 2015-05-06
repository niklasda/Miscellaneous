using System;
using System.Activities;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ClassLibrary1.WF;

namespace TestProject1.WF
{
    [TestClass]
    public class Activity1Tests
    {
        [TestMethod]
        public void Activity1Test()
        {
            
            Activity1 wf = new Activity1();


            TimeSpan timeout = new TimeSpan(0, 0, 5);

            IDictionary<string, object> input = new Dictionary<string, object>();
            input.Add("count", 3);
            var output = WorkflowInvoker.Invoke(wf, input);

            var names = (ICollection<string>)output["theStuff"];
            Assert.AreEqual(1, names.Count);
        }
    }
}


