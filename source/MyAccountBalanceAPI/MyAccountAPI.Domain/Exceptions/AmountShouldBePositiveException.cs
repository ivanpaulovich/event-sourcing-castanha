using System;

namespace MyAccountAPI.Domain.Exceptions
{
    public class AmountShouldBePositiveException : MyAccountAPIException
    {
        public AmountShouldBePositiveException()
        { }

        public AmountShouldBePositiveException(string message)
            : base(message)
        { }

        public AmountShouldBePositiveException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
