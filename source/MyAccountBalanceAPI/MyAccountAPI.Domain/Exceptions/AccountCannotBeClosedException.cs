using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class AccountCannotBeClosedException : DomainException
    {
        public AccountCannotBeClosedException(string message)
            : base(message)
        { }
    }
}
