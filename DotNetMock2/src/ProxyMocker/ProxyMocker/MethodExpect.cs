using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace ProxyMocker
{

    public class MethodCall
    {
        public MethodCall(MethodInfo mi, params object[] args)
        {
            Mi = mi;
            Args = args;
        }
        public MethodInfo Mi;
        public object[] Args;
    }
}
