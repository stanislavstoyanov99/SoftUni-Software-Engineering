using System;

namespace _01Logger.Exceptions
{
    public class InvalidAppenderTypeException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid appender type!";

        public InvalidAppenderTypeException()
            : base(EXCEPTION_MESSAGE)
        {

        }

        public InvalidAppenderTypeException(string message) 
            : base(message)
        {

        }
    }
}
