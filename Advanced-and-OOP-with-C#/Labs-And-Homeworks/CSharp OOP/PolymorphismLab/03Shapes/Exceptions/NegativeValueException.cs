using System;

namespace Shapes.Exceptions
{
    public class NegativeValueException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Value should be bigger than zero.";

        public NegativeValueException()
            : base(EXCEPTION_MESSAGE)
        {

        }

        public NegativeValueException(string message) 
            : base(message)
        {

        }
    }
}
