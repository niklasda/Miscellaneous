using System;
using Gallio.Framework;
using Gallio.Model;
using MbUnit.Framework;

namespace MbUnitDemo.Tests
{
    [TestFixture]
    public class LifeCycleDemo
    {
        [Test]
        public void TheTestCase()
        {
            TestLog.WriteLine("2.0 " + TestContext.CurrentContext.LifecyclePhase);
            DiagnosticLog.WriteLine("2.0 Testing");

            string value = TestStep.CurrentStep.Metadata.GetValue("niklasKey");
            Assert.AreEqual("NiklasV", value, StringComparison.CurrentCultureIgnoreCase);

            
            Assert.IsNull(null);
            TestLog.WriteLine("2.1 " + TestContext.CurrentContext.LifecyclePhase);

            TestLog.WriteLine("2.2 " + TestContext.CurrentContext.LifecyclePhase);
            Assert.IsNull(null);
            TestLog.WriteLine("2.3 " + TestContext.CurrentContext.LifecyclePhase);
        }

        [SetUp]
        public void Setup()
        {
            // where will this data be available? in TestStep
            // can values be communicated between tests?
            TestContext.CurrentContext.AddMetadata("niklasKey", "niklasV");
    
            TestLog.WriteLine("1.1 " + TestContext.CurrentContext.LifecyclePhase);
        }

        [TearDown]
        public void TearDown()
        {
            TestLog.WriteLine("3.0 " + TestContext.CurrentContext.LifecyclePhase);
        }

        [FixtureSetUp]
        public void FixtureSetup()
        {
            TestLog.WriteLine("1.0 " + TestContext.CurrentContext.LifecyclePhase);
            DiagnosticLog.WriteLine("1.0 FixSetUp");

            TestContext.CurrentContext.Finishing += CurrentContext_Finishing; 
        }

        void CurrentContext_Finishing(object sender, EventArgs e)
        {
            if (TestContext.CurrentContext.Outcome.Status == TestStatus.Failed)
            {
                TestLog.WriteLine("4.0 " + TestContext.CurrentContext.LifecyclePhase);
                
                Assert.IsNull(null);

                TestContext.CurrentContext.IncrementAssertCount();
                TestLog.WriteLine("Failed expectedly. NbrOfAsserts: " + TestContext.CurrentContext.AssertCount);
            }
        }

        [FixtureTearDown]
        public void FixtureTearDown()
        {
            TestLog.WriteLine("3.1 " + TestContext.CurrentContext.LifecyclePhase);
        
            if (TestContext.CurrentContext.Outcome.Status == TestStatus.Failed)
            {
               // TestLog.WriteLine("Failed expectedly. NbrOfAsserts: "+ TestContext.CurrentContext.AssertCount);
            }
        }

        [FixtureInitializer]
        public void FixtureTearœnit()
        {
            TestLog.WriteLine("0 " + TestContext.CurrentContext.LifecyclePhase);
        }
    }
}