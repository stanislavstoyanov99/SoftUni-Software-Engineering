using System;

namespace _01Logger.Exceptions
{
    public class InvalidLayoutTypeException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid layout type!";

        public InvalidLayoutTypeException()
            :base(EXCEPTION_MESSAGE)
        {

        }

        public InvalidLayoutTypeException(string message) 
            : base(message)
        {

        }
    }
}
