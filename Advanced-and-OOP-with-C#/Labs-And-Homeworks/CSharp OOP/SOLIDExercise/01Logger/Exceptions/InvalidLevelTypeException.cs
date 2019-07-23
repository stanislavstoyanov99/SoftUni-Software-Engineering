using System;

namespace _01Logger.Exceptions
{
    public class InvalidLevelTypeException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid level type!";

        public InvalidLevelTypeException()
            :base(EXCEPTION_MESSAGE)
        {

        }

        public InvalidLevelTypeException(string message) 
            : base(message)
        {

        }
    }
}
