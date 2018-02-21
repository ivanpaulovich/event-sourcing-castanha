namespace MyAccountAPI.Domain.Exceptions
{
    using System;

    public class AccountCannotBeClosedException : DomainException
    {
        public AccountCannotBeClosedException(string message)
            : base(message)
        { }
    }
}
