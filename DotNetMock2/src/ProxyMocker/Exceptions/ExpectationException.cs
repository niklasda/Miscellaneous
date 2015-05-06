using System;

namespace ProxyMocker
{
    public class ExpectationException : ApplicationException
    {
        public ExpectationException(string message) 
            : base(message)
        {

        }
    }
}
