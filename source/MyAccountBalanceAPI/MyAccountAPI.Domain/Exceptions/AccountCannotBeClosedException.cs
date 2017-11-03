using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class AccountCannotBeClosedException : MyAccountAPIException
    {
        public AccountCannotBeClosedException()
        { }

        public AccountCannotBeClosedException(string message)
            : base(message)
        { }

        public AccountCannotBeClosedException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
