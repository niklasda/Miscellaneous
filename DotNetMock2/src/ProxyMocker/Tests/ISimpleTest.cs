using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyMocker.Tests
{


    public interface ISimpleTest
    {
        int GenericMethod1();
    }

    public interface ISimpleGenTest
    {
        int GenericMethod1<T>();
    }

}
