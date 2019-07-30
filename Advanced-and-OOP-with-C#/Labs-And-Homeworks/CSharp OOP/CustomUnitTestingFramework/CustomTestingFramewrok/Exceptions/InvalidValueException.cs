namespace CustomTestingFramework.Exceptions
{
    using System;

    public class InvalidValueException : Exception
    {
        private const string EXCEPTION_MESSAGE = "The values are not the same.";

        public InvalidValueException()
            : base(EXCEPTION_MESSAGE)
        {

        }

        public InvalidValueException(string message)
            : base(message)
        {

        }
    }
}
