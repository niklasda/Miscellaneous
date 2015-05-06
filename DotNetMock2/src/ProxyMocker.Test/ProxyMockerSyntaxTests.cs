using System;
using System.Runtime.Serialization;
using System.Collections.Generic;
using NUnit.Framework;
using ProxyMocker.Constraints;

namespace ProxyMocker.Tests
{
    [TestFixture]
    public class ProxyMockerSyntaxTests
    {


        [Test]
        //[ExpectedException(typeof(ExpectationException),"Number")]
        public void testProxyMockerVoid()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            // implements the interface specified so far

            ISerializable other = generator.CreateProxyFor<ISerializable>();
            Assert.IsNotNull(other);
            Assert.IsNotNull(inter);

            //generator.UsingMode = true;             // do we require an expectation or not
            //generator.ExpectationMode = true;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
                // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));


                inter.Voider();
                generator.ExpectLastCall();
            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                inter.Voider();
                generator.Verify();
            }
        }
        
        [Test]
        [ExpectedException(typeof(VerifyException))]
        public void testProxyMockerArgumentConstraintsFail()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            // implements the interface specified so far

            ISerializable other = generator.CreateProxyFor<ISerializable>();
            Assert.IsNotNull(other);
            Assert.IsNotNull(inter);

            //generator.UsingMode = true;             // do we require an expectation or not
            //generator.ExpectationMode = true;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));


                inter.GetInt(33);
                generator.ExpectLastCall()
                    .ToReturn(MyEnum.Tf)
                    .SetOutAndRefParametersTo()
                    .WithArgumentConstraints(new Equals(2));

            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                inter.GetInt(33);
                generator.Verify();
            }

        }



        [Test]
        [ExpectedException(typeof(VerifyException))]
        public void testProxyMockerBasicArgumentConstraintsFail()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            // implements the interface specified so far

            ISerializable other = generator.CreateProxyFor<ISerializable>();
            Assert.IsNotNull(other);
            Assert.IsNotNull(inter);

            //generator.UsingMode = true;             // do we require an expectation or not
            //generator.ExpectationMode = true;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));


                inter.GetInt(32);
                generator.ExpectLastCall();

            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                inter.GetInt(33);
                generator.Verify();
            }

        }




        [Test]
        public void testProxyMockerArgumentConstraints()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            // implements the interface specified so far

            ISerializable other = generator.CreateProxyFor<ISerializable>();
            Assert.IsNotNull(other);
            Assert.IsNotNull(inter);

            //generator.UsingMode = true;             // do we require an expectation or not
            //generator.ExpectationMode = true;           // do we require methods to be called in the same order as they are expected
            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));


                inter.GetInt(33);
                generator.ExpectLastCall()
                    .ToReturn(MyEnum.Tf)
                    .SetOutAndRefParametersTo()
                    .WithArgumentConstraints(new Equals(2));

            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                inter.GetInt(2);
                generator.Verify();
            }

        }



        [Test]
        [ExpectedException(typeof(ExpectationException))]
        public void testProxyMockerToManyArgumentConstraints()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances
            // implements the interface specified so far

            ISerializable other = generator.CreateProxyFor<ISerializable>();
            Assert.IsNotNull(other);
            Assert.IsNotNull(inter);

            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));


                inter.GetInt(3);
                generator.ExpectLastCall()
                    .ToReturn(MyEnum.Tf)
                    .SetOutAndRefParametersTo()
                    .WithArgumentConstraints(new Anything(), new Equals(2));

            }


        }



        [Test]
        [ExpectedException(typeof(Exception))]
        public void testProxyMockerToThrow()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances

            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
                // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));


                inter.EnumVar();
                generator.ExpectLastCall()
                    .ToThrow(new Exception());
            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                inter.EnumVar();
                generator.Verify();
            }
        }

        [Test]
        [ExpectedException(typeof(Exception))]
        public void testProxyMockerOrderedDuplicate()
        {
            ProxyMocker<ITestInterface> generator = new ProxyMocker<ITestInterface>();

            ITestInterface inter = generator.CreateProxy(); // get instance, can be called repeatedly to get several instances

            generator.UsingMode = UsingType.Strict;
            generator.ExpectationMode = ExpectationType.OrderedCounted;

            using (generator.StartExpecting()) // config done. start expecting. several blocks allowed
            // store expectation in a way that support both strict, ordered, counted etc to avoid parameter
            {
                Assert.IsTrue(typeof(ITestInterface).IsAssignableFrom(inter.GetType()));

                inter.EnumVar();
                generator.ExpectLastCall()
                    .ToReturn(MyEnum.Tf);


                inter.EnumVar();
                generator.ExpectLastCall()
                    .ToThrow(new Exception());
            }

            using (generator.StartUsing())  // no expect allowed while using
            {
                inter.EnumVar();
                inter.EnumVar();
                generator.Verify();
            }
        }
        
        
    }
}