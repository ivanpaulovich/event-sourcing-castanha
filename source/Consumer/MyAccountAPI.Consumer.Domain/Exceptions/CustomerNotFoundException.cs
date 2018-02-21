namespace MyAccountAPI.Domain.Exceptions
{
    using System;

    public class CustomerNotFoundException : DomainException
    {
        public CustomerNotFoundException(string message)
            : base(message)
        { }
    }
}
