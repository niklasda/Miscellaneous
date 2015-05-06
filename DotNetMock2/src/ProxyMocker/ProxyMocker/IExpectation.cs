using System;
using ProxyMocker.Constraints;

namespace ProxyMocker
{

    public interface IExpectation
    {
        IExpectationAction ToReturn(object returnValue);
        IExpectationAction ToReturnNothing();
        IExpectationAction ToThrow(Exception exception);
        IExpectationAction ByCalling(Delegate callee, params object[] delegateArgs);
        IExpectationAction ToNotReturnAnything();
        IExpectationAction ToAlwaysReturn(object returnValue);
        string GetMethodName();
        int GetArgumentsCount();

        IConstraint GetConstraint(int j);
    }
    
    public interface IExpectationAction
    {
        
        IExpectationAction WithArgumentConstraints(params IConstraint[] argumentConstraints);
        IExpectationAction SetOutAndRefParametersTo(params object[] args);

        IConstraint GetConstraint(int j);
    }
}
