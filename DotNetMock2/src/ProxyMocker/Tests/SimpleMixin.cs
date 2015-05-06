using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyMocker
{
    public interface IMixinterface
    {
        string doMe(string name);
    }
    
    public class SimpleMixin : IMixinterface
    {
        public string doMe(string name)
        {
            return "Me:" + name;
        }
    }
}
