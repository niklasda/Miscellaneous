using System;

namespace ProxyMocker
{
    public class VerifyException : ApplicationException
    {
        public VerifyException(string message) 
            : base(message)
        {

        }
    }
}
