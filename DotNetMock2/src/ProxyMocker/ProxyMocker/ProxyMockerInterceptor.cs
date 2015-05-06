using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using Castle.DynamicProxy;

namespace ProxyMocker
{
    public class ProxyMockerInterceptor : StandardInterceptor
    {
        IMockManager mm;
        public ProxyMockerInterceptor(IMockManager mockManager)
        {
            mm = mockManager;
        }

        public override object Intercept(IInvocation invocation, params object[] args)
        {
               // Create a StackTrace that captures
            // filename, line number, and column
            // information for the current thread.
            StackTrace st = new StackTrace(true);
            for (int i = 0; i < st.FrameCount; i++)
            {
                // Note that high up the call stack, there is only
                // one stack frame.
                StackFrame sf = st.GetFrame(i);
                MethodBase mi = sf.GetMethod();
                if (mi.IsGenericMethod)
                {
                    Type[] ts = mi.GetGenericArguments();
                }
            }

            object retValue = null;// = invocation.Proceed(args);
            //retValue = invocation.Proceed(args);
            PostProceed(invocation, ref retValue, args);
            return retValue;
        }

        private Expectation FindExpectation(MethodInfo mi, params object[] args)
        {
            return mm.FindExpectation(mi, args);
        }


        
        protected override void PostProceed(IInvocation invocation, ref object returnValue, params object[] arguments)
        {
            //if (mm.)
            mm.MethodIntercepted( new MethodCall( invocation.Method, arguments));
            Expectation expec = FindExpectation(invocation.Method, arguments);
            if (expec != null)
            {
                returnValue = expec.PerformExpectedAction();
            }
            else
            {
                //Refactor this, only run code below in expect setup mode, not in call mode
                Type returnType = invocation.Method.ReturnType;
                if(returnType.IsValueType)
                {
                   
                   
                    if (returnType.IsEnum)
                    {
                        returnValue = 0;
                    }
                    else if (returnType == typeof(short) || returnType == typeof(int) || returnType == typeof(long)
                         || returnType == typeof(ushort) || returnType == typeof(uint) || returnType == typeof(ulong) || returnType == typeof(decimal)
                        )
                    {
                        returnValue = 1;
                        returnValue = Convert.ChangeType(returnValue, returnType);
                    }
                    else if (returnType == typeof(char))
                    {
                        returnValue = 'a';
                    }
                    else if (returnType == typeof(bool))
                    {
                        returnValue = true;
                    }
                }
            }
        }
    }
}
