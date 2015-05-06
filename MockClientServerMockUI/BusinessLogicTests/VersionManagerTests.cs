using System;
using System.Drawing;
using System.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Mockdemo.BusinessClasses;
using Mockdemo.BusinessLogic;
using Mockdemo.Server;
using Mockdemo.ClientUI;
using NMock;
using NMock.Constraints;

namespace Mockdemo.BusinessLogicTests
{

    /// <summary>
    /// This is a sample of Dependency Injection and mocking...
    /// Not unit test design
    /// </summary>
    [TestClass]
    public class VersionManagerTests
    {

        [TestMethod]
        public void TestVersionManagerUselessTest()
        {
            VersionManager vm = new VersionManager(true);
            Assert.IsNotNull("Failed to create object");
        }

        [TestMethod]
        public void TestVersionManagerNeedlessTest()
        {
            VersionManager vm = new VersionManager(true);
            Assert.IsNotNull(vm);
        }

        [TestMethod]
        public void TestVersionManagerRealViewAndRealDatabaseNoInject()
        {
            VersionManager vm = new VersionManager(true); // always uses db
            string ver = vm.GetDatabaseVersion();
            Assert.IsNotNull(ver);

            // this part should be among the UI tests
            ViewUI viewForm = new ViewUI();     // nothing to assert
            viewForm.PrintVersionNumber(ver);   // the UI might not be ready for this
            // We need a reference to the UI
        }

        [TestMethod]
        public void TestVersionManagerRealViewAndRealDatabaseViewRealInject()
        {
            VersionManager vm = new VersionManager(true); // always uses db
            string ver = vm.GetDatabaseVersion();
            Assert.IsNotNull(ver);

            ViewUI viewForm = new ViewUI();         // now the vm is responsible for printing itself
            vm.PrintVersionNumber(viewForm, ver);   // the UI might not be ready for this
                                                    // We need a reference to the UI
        }

        [TestMethod]
        public void TestVersionManagerMockViewAndRealDatabaseViewMockInject()
        {
            VersionManager vm = new VersionManager(true); // always uses db
            string ver = vm.GetDatabaseVersion();
            Assert.IsNotNull(ver);

            Mock mockView = new DynamicMock(typeof(IViewUI));   // now we only need a ref to the interface
            IViewUI view = (IViewUI)mockView.MockInstance;      // and we don't use the real UI anymore
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(string)));

            vm.PrintVersionNumber(view, ver);

            mockView.Verify();  // now we can assert
        }

        [TestMethod]
        public void TestVersionManagerMockViewAndMockDatabase()
        {
            Mock mockDb = new DynamicMock(typeof(IDatabase));   // we no longer need a db connection
            IDatabase db = (IDatabase)mockDb.MockInstance;
            mockDb.ExpectAndReturn("GetVersion", "TestString");

            // can't use this, since an actual result is needed for comparison below
         //   mockDb.ExpectAndReturn("GetVersion", new IsTypeOf(typeof(string))); 

            VersionManager vm = new VersionManager(db);
            string ver = vm.GetDatabaseVersion();
            Assert.IsNotNull(ver);
            mockDb.Verify();    // now we can assert

            Mock mockView = new DynamicMock(typeof(IViewUI));
            IViewUI view = (IViewUI)mockView.MockInstance;
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(string)));

            vm.PrintVersionNumber(view, ver);

            mockView.Verify();  // now we can assert both

            // but it's still bad since it tests 2 functions of vm
        }

        [TestMethod]
        public void TestVersionManagerMockViewAndMockDatabaseBetter()
        {
            Mock mockDb = new DynamicMock(typeof(IDatabase));
            IDatabase db = (IDatabase)mockDb.MockInstance;
            mockDb.ExpectAndReturn("GetVersion", new IsTypeOf(typeof(string)));

            Mock mockView = new DynamicMock(typeof(IViewUI));
            IViewUI view = (IViewUI)mockView.MockInstance;
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(string)));
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(string)));
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(string)));
            mockView.Expect("AppendToTextBox", new IsTypeOf(typeof(double)));

            VersionManager vm = new VersionManager(db);
            vm.PrintVersionNumber(view);

            mockDb.Verify();    // now we can assert
            mockView.Verify();  // now we can assert both
        }

    }
}
