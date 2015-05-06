using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyMocker.Constraints
{
    public class Anything : IConstraint
    {
        public bool Verify()
        {
            return true;
        }



        public bool Test(object actualValue)
        {
            throw new Exception("The method or operation is not implemented.");
        }
    }
}
