namespace MyAccountAPI.Domain.Exceptions
{
    using System;

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
