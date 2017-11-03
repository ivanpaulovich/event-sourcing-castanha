using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class InsuficientFundsException : MyAccountAPIException
    {
        public InsuficientFundsException()
        { }

        public InsuficientFundsException(string message)
            : base(message)
        { }

        public InsuficientFundsException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
