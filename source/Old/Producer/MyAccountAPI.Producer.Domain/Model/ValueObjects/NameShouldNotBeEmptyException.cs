namespace MyAccountAPI.Domain.Model.ValueObjects
{
    using System;

    public class NameShouldNotBeEmptyException : DomainException
    {
        public NameShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
