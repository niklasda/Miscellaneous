using System;

namespace MbUnitDemo.Exception
{
    [Serializable]
    public class AgeException : System.Exception
    {
        public AgeException() 
        {}

        public AgeException(string message)
            : base(message)
        { }

        public AgeException(string message, System.Exception innerException)
            : base(message, innerException)
        { }
    }
}