using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class NameShouldNotBeEmptyException : MyAccountAPIException
    {
        public NameShouldNotBeEmptyException()
        { }

        public NameShouldNotBeEmptyException(string message)
            : base(message)
        { }

        public NameShouldNotBeEmptyException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
