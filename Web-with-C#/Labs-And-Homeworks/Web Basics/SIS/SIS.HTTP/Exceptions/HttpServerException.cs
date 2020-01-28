namespace SIS.HTTP.Exceptions
{
    using System;

    public class HttpServerException : Exception
    {
        public HttpServerException(string message)
            : base(message)
        {
        }
    }
}
