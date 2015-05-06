using System;
using System.Collections.Generic;
using System.Text;

namespace ProxyMocker.Constraints
{
    public interface IConstraint
    {
        bool Verify();

        bool Test(object actualValue);
    }
}
