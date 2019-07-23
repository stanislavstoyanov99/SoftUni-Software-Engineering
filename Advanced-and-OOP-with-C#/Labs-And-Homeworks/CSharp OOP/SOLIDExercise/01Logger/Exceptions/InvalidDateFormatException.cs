using System;

namespace _01Logger.Exceptions
{
    public class InvalidDateFormatException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid date time format!";

        public InvalidDateFormatException()
            : base(EXCEPTION_MESSAGE)
        {

        }

        public InvalidDateFormatException(string message) 
            : base(message)
        {

        }
    }
}
