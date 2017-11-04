using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class CustomerNotFoundException : DomainException
    {
        public CustomerNotFoundException(string message)
            : base(message)
        { }
    }
}
