namespace MyAccountAPI.Domain.Exceptions
{
    using System;

    public class NameShouldNotBeEmptyException : DomainException
    {
        public NameShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
