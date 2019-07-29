using System;

namespace _07CustomException.Exceptions
{
    public class InvalidPersonNameException : Exception
    {
        private const string EXCEPTION_MESSAGE = "The name should not contain any special character or numeric value.";

        public InvalidPersonNameException()
            : base(EXCEPTION_MESSAGE)
        {

        }

        public InvalidPersonNameException(string message) 
            : base(message)
        {

        }
    }
}
