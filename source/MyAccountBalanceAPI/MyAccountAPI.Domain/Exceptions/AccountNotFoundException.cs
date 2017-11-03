using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class AccountNotFoundException : MyAccountAPIException
    {
        public AccountNotFoundException()
        { }

        public AccountNotFoundException(string message)
            : base(message)
        { }

        public AccountNotFoundException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
