using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProxyMocker
{

    public interface IMockManager
    {
        void MethodIntercepted(MethodCall m);
        IExpectation ExpectLastCall();

        Expectation FindExpectation(MethodInfo mi, params object[] args);

        void Verify();
    }
}
