using System;
using System.Collections.Generic;
using System.Text;
using ProxyMocker.Tests;

namespace testrunner
{
    class Program
    {
        static void Main(string[] args)
        {
            ProxyMockerTests pmt = new ProxyMockerTests();
            pmt.testProxySyntax3();
        }
    }
}
