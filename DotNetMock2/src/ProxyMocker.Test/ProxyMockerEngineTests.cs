using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using NUnit.Framework;
using ProxyMocker.Constraints;

namespace ProxyMocker.Tests
{
    [TestFixture]
    public class ProxyMockerEngineTests
    {

        private delegate long myLongDel(long pa);

        [Test]
        public void testMockMultipleInterfaces()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            Assert.IsNotNull(inter);
            // implements the interface specified so far

            ISerializable other = generator.CreateProxyFor<ISerializable>();
            Assert.IsNotNull(other);

            //generator.UsingMode = true;             // do we require an expectation or not
            //generator.ExpectationMode = true;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
                // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));
                Assert.IsTrue(typeof(ISerializable).IsAssignableFrom(other.GetType()));
            }
        }
        
        [Test]
        public void testMockByCalling()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            Assert.IsNotNull(inter);
            // implements the interface specified so far
            

            generator.UsingMode = ProxyMocker.UsingType.Strict;                             // do we require an expectation or not
            generator.ExpectationMode = ProxyMocker.ExpectationType.OrderedCounted;         // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));

                
                myLongDel asd = delegate(long pa){
                                    return pa;
                                };

                inter.GetLong(6);
                generator.ExpectLastCall()
                    .ByCalling(asd, 4)
                    .WithArgumentConstraints(new Equals(2L));  //TODO: Should L be needed?
                
            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                long res = inter.GetLong(2);
                Assert.AreEqual(4, res);
            }
        }



        [Test]
        public void testProxySyntaxGenerics()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            // implements the interface specified so far

            //generator.UsingMode = true;             // do we require an expectation or not
            //generator.ExpectationMode = true;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));

                bool v = inter.Valid;
                generator.ExpectLastCall().ToAlwaysReturn(true);

                inter.GenericMethod1<string>();
                generator.ExpectLastCall().ToNotReturnAnything();

                //int iOut = inter.GenericMethod2<string>();
                //generator.ExpectLastCall().ToReturn(1);

                //string sOut = inter.GenericMethod4<string>("d");
                //generator.ExpectLastCall().ToReturn("d");

                //int iOut2 = inter.GenericMethod4<int>(5);
                //generator.ExpectLastCall().ToReturn(5);

            }

            using (generator.StartUsing())  
                // no expect allowed while using
            {
                bool v = inter.Valid;
                Assert.AreEqual(true, v);

                // int iOut = inter.GenericMethod2<string>();
                //Assert.AreEqual(1, iOut);

                // string sOut = inter.GenericMethod4<string>("d");
                //Assert.AreEqual("d", sOut);

                // int iOut2 = inter.GenericMethod4<int>(5);
                //Assert.AreEqual(5, iOut2);
            }
        }


        [Test]
        public void testProxyGenSimple()
        {
            ProxyMocker<ISimpleGenTest> generator = new ProxyMocker<ISimpleGenTest>();

            ISimpleGenTest inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            {
                int res = inter.GenericMethod1<long>();
                generator.ExpectLastCall().ToReturn(1);
                Assert.AreEqual(1, res);
            }
            using (generator.StartUsing()) // config done. start expecting. several blocks allowed
            {
                int res2 = inter.GenericMethod1<int>();
                Assert.AreEqual(1, res2);
                generator.Verify();
            }
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void testProxyGenSimpleSyntaxError()
        {
            ProxyMocker<ISimpleGenTest> generator = new ProxyMocker<ISimpleGenTest>();

            ISimpleGenTest inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            {
                int res = inter.GenericMethod1<long>();
                generator.ExpectLastCall().ToReturn(1);
                Assert.AreEqual(1, res);
            }
            int res2 = inter.GenericMethod1<int>();  //Todo: must use using block, otherwise throw an exception
            Assert.AreEqual(1, res2);
            generator.Verify();
            /*
            
            ProxyMocker: ersätt mode med ett statusobjekt (med samma livslängd som proxymockern)

            Ändra bl.a i StartExpecting() mm
             
            m_status.mode = MockerMode.Expecting;
            return m_status;
 
             
              
            */

        }

        [Test]
        [ExpectedException(typeof(VerifyException), ExpectedMessage = "Expected method GetInt but was GetLong")]
        public void testMockStrictVerifyCallUnexpecteMethod()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            Assert.IsNotNull(inter);
            // implements the interface specified so far

            generator.UsingMode = UsingType.Strict;             // do we require an expectation or not
            generator.ExpectationMode = ExpectationType.OrderedCounted;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));

                inter.GetInt(1);
                generator.ExpectLastCall()
                    .ToReturn(1234)
                    .WithArgumentConstraints(new Equals(2));

                Assert.IsNull(generator.lastCall, "LastCall was not reset properly");
            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                long res = inter.GetLong(2);

                generator.Verify();
            }
        }


        [Test]
        [ExpectedException(typeof(ExpectationException), ExpectedMessage = "Method GetLong not defined")]
        public void testMockStrictCallUnexpecteMethod()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            Assert.IsNotNull(inter);
            // implements the interface specified so far

            generator.UsingMode = UsingType.Strict;             // do we require an expectation or not
            generator.ExpectationMode = ExpectationType.OrderedCounted;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));

                inter.GetInt(1);
                generator.ExpectLastCall()
                    .ToReturn(1234)
                    .WithArgumentConstraints(new Equals(2));

                Assert.IsNull(generator.lastCall, "LastCall was not reset properly");
            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                long res = inter.GetLong(2);
            }
        }



        [Test]
        public void testMockStrict()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            Assert.IsNotNull(inter);
            // implements the interface specified so far

            generator.UsingMode = UsingType.Strict;             // do we require an expectation or not
            generator.ExpectationMode = ExpectationType.OrderedCounted;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));

                inter.GetInt(1);
                generator.ExpectLastCall()
                    .ToReturn(1234)
                    .WithArgumentConstraints(new Equals(2));

                inter.GetInt(1);
                generator.ExpectLastCall()
                    .ToReturn(4321)
                    .WithArgumentConstraints(new Equals(2));

                Assert.IsNull(generator.lastCall, "LastCall was not reset properly");
            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                long res = inter.GetInt(2);
                Assert.AreEqual(1234, res);

                long intres = inter.GetInt(2);
                Assert.AreEqual(4321, intres);
                generator.Verify();
            }
        }



        [Test]
        [ExpectedException(typeof(VerifyException), ExpectedMessage = "1 method call(s) was expected but 2 method(s) were called")]
        public void testMockStrictExpectOneCallTwice()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            Assert.IsNotNull(inter);
            // implements the interface specified so far

            generator.UsingMode = UsingType.Strict;             // do we require an expectation or not
            generator.ExpectationMode = ExpectationType.OrderedCounted;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));

                inter.GetInt(1);
                generator.ExpectLastCall()
                    .ToReturn(1234)
                    .WithArgumentConstraints(new Equals(2));


                Assert.IsNull(generator.lastCall, "LastCall was not reset properly");
            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                long res = inter.GetInt(2);
                long intres = inter.GetInt(2);
                generator.Verify();
            }
        }

        [Test]
        [ExpectedException(typeof(VerifyException), ExpectedMessage = "2 method call(s) was expected but 1 method(s) were called")]
        public void testMockStrictExpectTwoCallOnce()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            Assert.IsNotNull(inter);
            // implements the interface specified so far

            generator.UsingMode = UsingType.Strict;             // do we require an expectation or not
            generator.ExpectationMode = ExpectationType.OrderedCounted;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));

                inter.GetInt(1);
                generator.ExpectLastCall()
                    .ToReturn(1234)
                    .WithArgumentConstraints(new Equals(2));

                inter.GetInt(1);
                generator.ExpectLastCall()
                    .ToReturn(4321)
                    .WithArgumentConstraints(new Equals(2));

                Assert.IsNull(generator.lastCall, "LastCall was not reset properly");
            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                long res = inter.GetInt(2);

                generator.Verify();
            }
        }
       
    }

}