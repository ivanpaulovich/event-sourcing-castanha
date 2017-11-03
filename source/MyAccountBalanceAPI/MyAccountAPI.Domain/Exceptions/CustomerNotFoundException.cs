using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class CustomerNotFoundException : MyAccountAPIException
    {
        public CustomerNotFoundException()
        { }

        public CustomerNotFoundException(string message)
            : base(message)
        { }

        public CustomerNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
