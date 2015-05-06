using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryDemo
{
    /// <summary>
    /// Exception thrown by the business layer
    /// </summary>
    public class BusinessException : ApplicationException
    {
        public BusinessException(string message)
            : base(message)
        {
        }
    }
}
