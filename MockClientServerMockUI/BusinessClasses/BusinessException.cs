using System;

namespace Mockdemo.BusinessClasses
{
    /// <summary>
    /// Exception thrown by the business layer
    /// </summary>
    public class BusinessException : ApplicationException
    {
        public BusinessException(string message) : base(message)
        {
        }
    }
}
