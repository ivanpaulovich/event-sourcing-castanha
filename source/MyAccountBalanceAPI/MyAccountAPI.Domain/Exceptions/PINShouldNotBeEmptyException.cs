using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class PINShouldNotBeEmptyException : MyAccountAPIException
    {
        public PINShouldNotBeEmptyException()
        { }

        public PINShouldNotBeEmptyException(string message)
            : base(message)
        { }

        public PINShouldNotBeEmptyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
