namespace MyAccountAPI.Domain.Exceptions
{
    using System;

    public class AccountNotFoundException : DomainException
    {
        public AccountNotFoundException(string message)
            : base(message)
        { }
    }
}
