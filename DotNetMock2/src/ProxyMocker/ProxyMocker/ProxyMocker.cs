using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy;
using ProxyMocker;
using ProxyMocker.Tests;
using ProxyMocker.Constraints;

namespace ProxyMocker
{    
    public class MockerStatus : IDisposable
    {
        public MockerMode Status;
        public MockerStatus(MockerMode status)
        {
            Status = status;
            
        }
        
        public void Dispose()
        {
            Status = MockerMode.None;
        }
    }

    public class SimpleImplementation : ISimpleTest
    {
        public int GenericMethod1()
        {
            return 1;
        }
    }

    public class SimpleGenImplementation : ISimpleGenTest
    {
        public int GenericMethod1<T>()
        {
            return 1;
        }

    }
      
    
    public class Implementation : ITestInterface
    {
		public bool Valid {
			get { 
			    return true;
			}
		}
    	
		public int GetInt(int i)
		{return 1;
		}
    	
		public short GetShort(short s)
		{return 1;
		}
    	
		public long GetLong(long s)
		{return 1;
		}
    	
		public char GetChar(char c)
		{return 'c';
		}
    	
		public string GetString(string c)
		{return "";
		}
    	
		public Nullable<int> GetNullableInt(Nullable<int> i)
		{return null;
		}
    	
		public MyEnum EnumVar()
		{return MyEnum.Te;
		}
    	
		public void Voider()
		{
		}
    	
		public void Voider(int i)
		{
		}
    	
		public Dictionary<int, string> GetDict()
		{
			return new Dictionary<int, string>();
		}


        public int GenericMethod1<U>()
        {
            return 0;
        }
        //public void GenericMethod1()
        //{

        //}
    	
        //public int GenericMethod2<V>()
        //{
        //    return 1;
        //}
    	
    	
        //public X GenericMethod4<X>(X inpa)
        //{
        //    return inpa;
        //}
    }
    
    
    
    
    
    
    public class ProxyMocker<T> : IMockManager, IMockedCallHandler
        where T : class 
    {
    	public ProxyMocker()
    	{
    		typesToImplement.Add(typeof(T));
    		
    	}
    	
    	public U CreateProxyFor<U>()
    	{
            if(!typesToImplement.Contains(typeof(U)))
            {
                typesToImplement.Add(typeof(U));
            }
            else
            {
                throw new ExpectationException( string.Format("Type added multiple times: {0}", typeof(U).Name));
            }            
    	    
    	    ProxyGenerator generator = new ProxyGenerator();    // Castle

            // From DotNetMock. Needed to please Castle but not used
         //   ClassGenerator clsGen = new ClassGenerator();
//            T implementor = (T)clsGen.Generate(typeof(T), this);
            ITestInterface implementor = new Implementation();

            IInterceptor ceptor = new ProxyMockerInterceptor(this);
            
            Type[] types = typesToImplement.ToArray();

            object proxy1 = generator.CreateProxy(types, ceptor, implementor);
            

            return (U)proxy1;
    	}
    	
        public T CreateProxy()
        {

                
            ProxyGenerator generator = new ProxyGenerator();    // Castle

            // From DotNetMock. Needed to please Castle but not used
            ClassGenerator clsGen = new ClassGenerator();
            T implementor = (T)clsGen.Generate(typeof(T), this);
            //ITestInterface implementor = new Implementation();

            //ISimpleTest simplementor = new SimpleImplementation();

            IInterceptor ceptor = new ProxyMockerInterceptor(this);

            Type[] types = typesToImplement.ToArray();
            
            object proxy1 = generator.CreateProxy(types, ceptor, implementor);

        //    return null;
            return (T)proxy1;
        }

        
        //public void ImplmentAdditionalInterface<X>()
        //{
        //    if(!typesToImplement.Contains(typeof(X)))
        //    {
        //        typesToImplement.Add(typeof(X));
        //    }
        //    else
        //    {
        //        throw new ExpectationException( string.Format("Type added multiple times: {0}", typeof(X).Name));
        //    }
        	   
        	   
        	   
        //}
        
        private List<Type> typesToImplement = new List<Type>();
        public List<IExpectation> expectedMethods = new List<IExpectation>();
        public List<MethodCall> calledMethods = new List<MethodCall>();
        public MethodCall lastCall;
        //private bool strict = false;
        //private ExpectationType ordered = ExpectationType.OrderedCounted;
        private MockerMode mode = MockerMode.Using;
        private ExpectationType eType = ExpectationType.OrderedCounted;
        private UsingType uType = UsingType.Strict;

        private MockerStatus Status;


        private bool tryConvert(ref object value, Type type)
        {
            if (type.IsGenericType && type.Name.Equals("Nullable`1"))
            {
                type = Nullable.GetUnderlyingType(type);
            }
            try
            {
                value = Convert.ChangeType(value, type);
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        
        public void MethodIntercepted(MethodCall m)    // called from the interceptor
        {
            if(lastCall!=null && mode == MockerMode.Using)
            {
                if (uType == UsingType.Strict)
                {
                    if (!findMethodExpectation(lastCall.Mi))
                    {
                        throw new ExpectationException(string.Format("Call to unexpected method: {0}", lastCall.Mi.Name));
                    }
                }
                
                calledMethods.Add(lastCall);
            }
            lastCall = m;
         }


        public IExpectation ExpectLastCall()
        {
            if (lastCall != null)
            {
                Expectation expec = new Expectation(lastCall);
                expectedMethods.Add(expec);

                lastCall = null;

                return expec;
            }
            else
            {
                throw new ExpectationException("LastCall cannot be null");
            }
        }

        public void Verify()
        {
            if (lastCall != null)
            {
                calledMethods.Add(lastCall);
                lastCall = null;
            }
            
            if(expectedMethods.Count != calledMethods.Count)
            {
                throw new VerifyException(string.Format("{0} method call(s) was expected but {1} method(s) were called", expectedMethods.Count, calledMethods.Count, "Nisse"));
            }
            for (int i = 0; i < expectedMethods.Count; i++)
			{
                IExpectation expected = expectedMethods[i];
                MethodCall actual = calledMethods[i];
                if (!expected.GetMethodName().Equals(actual.Mi.Name))
                {
                    throw new VerifyException(String.Format("Expected method {0} but was {1}", expected.GetMethodName(), actual.Mi.Name));
                }
                if(expected.GetArgumentsCount() != actual.Args.Length)
                {
                    throw new VerifyException(String.Format("Expected {0} arguments for {1} but was {2}", expected.GetArgumentsCount(), expected.GetMethodName(), actual.Args.Length));
                }

                for (int j = 0; j < expected.GetArgumentsCount(); j++)
                {
                    IConstraint constraint = expected.GetConstraint(j);
                    if (!constraint.Test(actual.Args[j]))
                    {
                        throw new VerifyException(String.Format("XXXX ERROR!!!!!", expected.GetArgumentsCount(), expected.GetMethodName(), actual.Args.Length));
                    }
                }
			 
			}
            
        }

        //public void Call(object o)
        //{
        //    if (lastCall != null)
        //    {
        //        if(uType == UsingType.UsingMode)
        //        {
        //            if (!findMethodExpectation(lastCall.Mi))
        //            {
        //                throw new ExpectationException(string.Format("Call to unexpected method: {0}", lastCall.Mi.Name));
        //            }
        //        }
                    
        //        calledMethods.Add(lastCall.Mi);
        //        lastCall = null;
                
        //    }
        //}

        private bool findMethodExpectation(MethodInfo method)
        {
            foreach(Expectation exp in expectedMethods)
            {
                if (exp.mi == method)
                    return true;
            }
            return false;
        }

        public UsingType UsingMode
        {
            get { return uType; }
            set { uType = value; }
        }

        public ExpectationType ExpectationMode
        {
            get { return eType; }
            set { eType = value; }
        }

        public MockerStatus StartExpecting()
        {
            mode = MockerMode.Expecting;
            Status = new MockerStatus(mode);

            //m_status.mode = MockerMode.Expecting;
            //return m_status;

            return Status;
        }

//        public void FinishedExpecting()
  //      {
    //        mode = MockerMode.None;
      //  }

        public MockerStatus StartUsing()
        {
            mode = MockerMode.Using;
            Status = new MockerStatus(mode);

            return Status;
        }

//        public void FinishedUsing()
   //     {
     //       mode = MockerMode.None;                
       // }

        public Expectation FindExpectation(MethodInfo mi, params object[] args)
        {
            foreach (Expectation expec in expectedMethods)
            {
                if(expec.mi == mi)
                {
                    bool argcheck = true;
                    for (int i = 0; i < args.Length; i++)
                    {
                        object actualValue = args[i];
                        if(!expec.GetConstraint(i).Test(actualValue))
                        {
                            argcheck = false;
                        }
                    }
                    if (argcheck)
                    {
                        if (ExpectationMode == ExpectationType.OrderedCounted)
                        {
                            if (expec.CallCount == 0)
                            {
                                return expec;
                            }
                        }
                        else
                        {
                            Type[] genericTypes = mi.GetGenericArguments();
                            if (expec.defaultConstraints.Length == args.Length)
                            {
                                return expec;
                            }
                        }
                    }
                }
            }
            return null;
        }

        // not used but required to compile for the moment
        public object Call(MethodInfo mi, params object[] args)
        {
            return null;
        }
    }
}
