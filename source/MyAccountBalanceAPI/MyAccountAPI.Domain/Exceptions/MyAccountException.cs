using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class MyAccountAPIException : Exception
    {
        public MyAccountAPIException()
        { }

        public MyAccountAPIException(string message)
            : base(message)
        { }

        public MyAccountAPIException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
