using System;

namespace _10ExplicitInterfaces.Exceptions
{
    public class InexistentPersonTypeException : Exception
    {
        private const string EXCEPTION_MESSAGE = "Invalid person type!";

        public InexistentPersonTypeException()
        {

        }

        public InexistentPersonTypeException(string message) 
            : base(EXCEPTION_MESSAGE)
        {

        }
    }
}
