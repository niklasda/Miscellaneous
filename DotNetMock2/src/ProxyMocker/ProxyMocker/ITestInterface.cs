using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyMocker.Tests
{

    public enum MyEnum { Te, Tf };

    public interface ITestInterface
    {
        bool Valid { get;}
        int GetInt(int i);
        short GetShort(short s);
        long GetLong(long s);
        char GetChar(char c);
        string GetString(string c);

        int? GetNullableInt(int? i);
        
        MyEnum EnumVar();
        void Voider();
        void Voider(int i);
        int GenericMethod1<U>();
     //   int GenericMethod2<V>();
     //   X GenericMethod4<X>(X inpa);
        
        Dictionary<int, string> GetDict();

    }

}
