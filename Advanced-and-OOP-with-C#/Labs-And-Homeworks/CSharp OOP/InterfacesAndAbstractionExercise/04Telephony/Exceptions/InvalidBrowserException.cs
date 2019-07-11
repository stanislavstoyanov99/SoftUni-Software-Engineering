using System;

namespace _04Telephony.Exceptions
{
    public class InvalidBrowserException : Exception
    {
        private const string INVALID_BROWSER_MESSAGE = "Invalid URL!";

        public InvalidBrowserException()
            : base(INVALID_BROWSER_MESSAGE)
        {

        }

        public InvalidBrowserException(string message)
            : base(message)
        {

        }
    }
}
