using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class AccountNotFoundException : DomainException
    {
        public AccountNotFoundException(string message)
            : base(message)
        { }
    }
}
