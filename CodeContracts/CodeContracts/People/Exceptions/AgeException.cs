using System;

namespace CodeContracts.People.Exceptions
{
    [Serializable]
    public class AgeException : Exception
    {
        public AgeException() 
        {}

        public AgeException(string message)
            : base(message)
        { }

        public AgeException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}