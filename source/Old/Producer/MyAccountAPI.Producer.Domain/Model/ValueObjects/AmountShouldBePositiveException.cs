namespace MyAccountAPI.Domain.Model.ValueObjects
{
    using System;

    public class AmountShouldBePositiveException : DomainException
    {
        public AmountShouldBePositiveException(string message)
            : base(message)
        { }
    }
}
