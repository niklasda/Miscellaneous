using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using NUnit.Framework;
using ProxyMocker.Constraints;
//using ProxyMocker.NUnit.Framework;

namespace ProxyMocker.Tests
{
    [TestFixture]
    public class ProxyMockerTests
    {
        [Test]
        public void testProxy()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();
            ITestInterface inter = generator.CreateProxy();
            //            IMixinterface minter = generator.CreateMixProxy();

            Assert.IsNotNull(inter);

            //            string nikl = minter.doMe("dah");
            //            Assert.AreEqual("Me:dah", nikl);

            generator.Strict = true;      // do we require an expectation or not
            generator.Ordered = true;    // do we require methods to be called in the same order as they are expected
            generator.StartExpecting(); // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter

            Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));


            inter.GetChar('a');

            generator.ExpectAndReturn(inter.GetChar('a'), '3');
            generator.ExpectAndReturn(inter.GetLong((77)), 34);
            generator.ExpectAndReturn(inter.GetNullableInt((77)), 34);
            generator.ExpectAndReturn(inter.GetShort((77)), "34");
            generator.ExpectAndReturn(inter.GetInt(77), 34);
            generator.ExpectAndReturn(inter.GetString(("77")), 34);
            generator.ExpectAndThrow(inter.GetInt(78), new Exception("failure!"));

            generator.ExpectAndReturn(inter.GetDict(), null);


            generator.ExpectAndReturn(inter.EnumVar(), MyEnum.Tf);
            //  generator.ExpectAndReturn(inter.Valid, true);    // get_Valid

            generator.ExpectAndAlwaysSameReturn(inter.Valid, true); // like SetValue
            //   generator.ExpectAndReturn(inter.Valid, true);    // get_Valid
            //  inter.Voider();

            Assert.IsNull(generator.lastCall);
            Assert.AreEqual(10, generator.expectedMethods.Count);

            generator.FinishedExpecting();  // finished with expect block

            generator.StartUsing(ExpectationType.OrderedCounted, UsingType.Loose);

            generator.Call(inter.GetInt(1));
            inter.GetInt(1);
            bool booo = inter.Valid;
            inter.EnumVar();
            inter.Voider();

            Assert.IsNotNull(generator.lastCall);
            Assert.AreEqual(10, generator.expectedMethods.Count);
            Assert.AreEqual(5, generator.calledMethods.Count);


            int val = 20;
            Assert.AreEqual(34, inter.GetInt(val));
            Assert.AreEqual(34, inter.GetInt(val - 1));
            Assert.AreEqual(34, inter.GetInt(20));
            Assert.AreEqual(true, inter.Valid);

            Assert.AreEqual(34, inter.GetLong(20));
            Assert.AreEqual(34, inter.GetNullableInt(20));
            Assert.AreEqual(34, inter.GetShort(20));
            Assert.AreEqual("34", inter.GetString("20"));
            Assert.AreEqual(null, inter.GetDict());
            char charVal = inter.GetChar('2');
            Assert.AreEqual('4', charVal);   // cannot assert char s either.

            Assert.AreEqual(8, generator.calledMethods.Count);

            generator.FinishedUsing();  // required before new startusing or new startexpecting.
            generator.StartUsing(ExpectationType.UnOrderedCounted, UsingType.Loose); // new using block with other settings

            generator.FinishedUsing();  // not required before validate.
            generator.Verify();

            Assert.AreEqual(4, generator.expectedMethods.Count);
            Assert.AreEqual(9, generator.calledMethods.Count);

        }

        private delegate void mydel(int i);

        [Test]
        public void testProxySyntax2()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();
            generator.ImplmentAdditionalInterface<ISerializable>();
            //    int i = generator.ImplmentAdditionalInterface<int>(7);
            //    generator.ImplmentAdditionalInterface<int>(8);
            //    Assert.AreEqual(7, i);
            //    generator.ImplmentAdditionalType<int>(8);
            //    generator.ImplmentAdditionalType2<int>();
            //    generator.ImplmentAdditionalTypeVoid<ISerializable>();
            generator.ImplmentAdditionalInterface<IEnumerable<string>>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            // implements the interface specified so far

            ISerializable other = generator.CreateProxyFor<ISerializable>();
            Assert.IsNotNull(other);
            Assert.IsNotNull(inter);

            generator.Strict = true;             // do we require an expectation or not
            generator.Ordered = true;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));


                inter.GetInt(77);
                generator.ExpectLastCallToReturn(34);

                inter.GetInt(78);
                generator.ExpectLastCallToThrow(new Exception("failure!"));

                inter.EnumVar();
                generator.ExpectLastCall()
                    .ToReturn(MyEnum.Tf)
                    .SetOutAndRefParametersTo()
                    .WithArgumentConstraints(new Anything(), new Equals(2));

                generator.ExpectLastCall().ToThrow(new Exception()).WithArgumentConstraints(new Anything(), new Equals(2));
                //    generator.ExpectLastCall().ByCalling( delegate { return 2;}).WithArgumentConstraints( new Anything(), new Equals(2));

                bool va = inter.Valid;
                //                generator.ExpectLastCallToReturn(true);    // get_Valid
                generator.ExpectLastCallToAlwaysReturn(true);    // like SetValue

                inter.Voider();
                generator.ExpectLastCall();

                Assert.IsNull(generator.lastCall);
                Assert.AreEqual(5, generator.expectedMethods.Count);

                generator.FinishedExpecting();  // finished with expect block
            }

            using (generator.StartUsing(ExpectationType.OrderedCounted, UsingType.Loose))  // no expect allowed while using
            {
                generator.Call(inter.GetInt(1));    // alternative call syntax? useless.
                inter.GetInt(1);
                bool b = inter.Valid;
                inter.EnumVar();
                inter.Voider();

                Assert.IsNotNull(generator.lastCall);
                Assert.AreEqual(5, generator.expectedMethods.Count);
                Assert.AreEqual(4, generator.calledMethods.Count);

                Assert.AreEqual(34, inter.GetInt(34));
                Assert.AreEqual(34, inter.GetInt(55));
                Assert.AreEqual(34, inter.GetInt(20));
                Assert.AreEqual(true, inter.Valid);

                Assert.AreEqual(8, generator.calledMethods.Count);

                generator.FinishedUsing();  // required before new startusing or new startexpecting. may now be redundant
            }

            using (generator.StartUsing(ExpectationType.UnOrderedCounted, UsingType.Loose)) // new using block with other settings
            {
                generator.FinishedUsing();  // not required before validate.
                generator.Verify();

                Assert.AreEqual(5, generator.expectedMethods.Count);
                Assert.AreEqual(9, generator.calledMethods.Count);
            }
        }



        [Test]
        public void testProxySyntax3()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            // implements the interface specified so far

            generator.Strict = true;             // do we require an expectation or not
            generator.Ordered = true;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));

                bool v = inter.Valid;
                generator.ExpectLastCall().ToAlwaysReturn(true);

                //inter.GenericMethod1<string>();
                //generator.ExpectLastCall().ToNotReturnAnything();

                //int iOut = inter.GenericMethod2<string>();
                //generator.ExpectLastCall().ToReturn(1);

                //string sOut = inter.GenericMethod4<string>("d");
                //generator.ExpectLastCall().ToReturn("d");

                //int iOut2 = inter.GenericMethod4<int>(5);
                //generator.ExpectLastCall().ToReturn(5);

            }

            using (generator.StartUsing(ExpectationType.OrderedCounted, UsingType.Loose))  // no expect allowed while using
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
        public void testProxySimple()
        {
            ProxyMocker<ISimpleTest> generator = new ProxyMocker<ISimpleTest>();

            ISimpleTest inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            {
                int res = inter.GenericMethod1();
                Assert.AreEqual(3, res);
            }
        }

        [Test]
        public void testProxyGenSimple()
        {
            ProxyMocker<ISimpleGenTest> generator = new ProxyMocker<ISimpleGenTest>();

            ISimpleGenTest inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            {
                int res =inter.GenericMethod1<long>();
                generator.ExpectLastCall().ToReturn(1);
                Assert.AreEqual(1, res);
            }
            int res2 = inter.GenericMethod1<int>();
            Assert.AreEqual(1, res2);
            generator.Verify();
        }


        [Test]
        public void testmsdn()
        {
            Msdn msdn = new Msdn();
        }
    }

}