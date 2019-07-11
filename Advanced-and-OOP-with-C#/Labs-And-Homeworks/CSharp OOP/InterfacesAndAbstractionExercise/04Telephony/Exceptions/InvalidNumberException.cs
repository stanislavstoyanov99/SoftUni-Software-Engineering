using System;

namespace _04Telephony.Exceptions
{
    public class InvalidNumberException : Exception
    {
        private const string INVALID_NUMBER_MESSAGE = "Invalid number!";

        public InvalidNumberException()
            : base(INVALID_NUMBER_MESSAGE)
        {

        }

        public InvalidNumberException(string message)
            : base(message)
        {

        }
    }
}
