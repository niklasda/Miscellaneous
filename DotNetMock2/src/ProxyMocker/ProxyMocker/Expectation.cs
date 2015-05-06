using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ProxyMocker.Constraints;

namespace ProxyMocker
{
    public class Expectation : IExpectation
    {
        public Expectation(MethodCall expectedMethod)
        {
            mi = expectedMethod.Mi;
            defaultConstraints = new Equals[expectedMethod.Args.Length];
            for (int i = 0; i < expectedMethod.Args.Length; i++)
            {
                defaultConstraints[i] = new Equals(expectedMethod.Args[i]);
            }
        }

        private int callCount = 0;
        public MethodInfo mi;
        public object ReturnValue;
        public Exception ExpectedException;
        public Delegate Callee;
        public IConstraint[] defaultConstraints;
        public object[] delegateArgs;
        public IExpectationAction action;

        public int CallCount
        {
            get { return callCount; }
        }

        public IExpectationAction ToReturn(object returnValue)
        {
            ReturnValue = returnValue;
            action = new ExpectationAction(this);
            return action;
        }
        public IExpectationAction ToReturnNothing()
        {
            action = new ExpectationAction(this);
            return action;
        }
        public IExpectationAction ToAlwaysReturn(object returnValue)
        {
            ReturnValue = returnValue;
            action = new ExpectationAction(this);
            return action;
        }
        public IExpectationAction ToNotReturnAnything()
        {
         //   ReturnValue = returnValue;
            action = new ExpectationAction(this);
            return action;
        }

        public IExpectationAction ToThrow(Exception exception)
        {
            ExpectedException = exception;
            action = new ExpectationAction(this);
            return action;
        }

        public IExpectationAction ByCalling(Delegate callee, params object[] dArgs)
        {
            delegateArgs = dArgs;
            Callee = callee;
            action = new ExpectationAction(this);
            return action;
        }

        public object PerformExpectedAction()
        {
            callCount++;
            if (ExpectedException != null)
            {
                throw ExpectedException;
            }
            if (Callee != null)
            {
                return Callee.DynamicInvoke(delegateArgs);
            }
            else
            {
                return ReturnValue;
            }
        }


        public string GetMethodName()
        {
            return mi.Name;
        }

        public int GetArgumentsCount()
        {
            return this.defaultConstraints.Length;
        }


        public IConstraint GetConstraint(int j)
        {
            if (action != null)
            {
                return action.GetConstraint(j);
            }
            else
            {
                return defaultConstraints[j];
            }
        }

    }
}
