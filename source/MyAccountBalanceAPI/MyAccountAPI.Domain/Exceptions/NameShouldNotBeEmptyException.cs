using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class NameShouldNotBeEmptyException : DomainException
    {
        public NameShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
