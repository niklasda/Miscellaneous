using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ProxyMocker.Constraints
{
    public class Equals : IConstraint
    {
        private object expected;
        public Equals(object expectedValue)
        {
            expected = expectedValue;
        }
        
        public bool Verify()
        {
            return true;
        }

        public bool Test(object actualValue)
        {
//            if (actualValue.GetType().FullName.Equals(expected.GetType().FullName) && actualValue.Equals(expected))
            if (expected.Equals(actualValue))
            {
                return true;
            }
            else
            {
                /*
                Type t = expected.GetType();
                ConstructorInfo[] cis = t.GetConstructors();
                ConstructorInfo ci = t.GetConstructor(new Type[]{t});
                if (t.IsValueType && ci != null)
                {
                    object newActual = ci.Invoke(new Object[] { actualValue });
                    new System.Int32
                    if (expected.Equals(actualValue))
                    {
                        return true;
                    }
                    else
                        return false;
                }
                else
                 */
                    return false;
            }

        }
    }
}
