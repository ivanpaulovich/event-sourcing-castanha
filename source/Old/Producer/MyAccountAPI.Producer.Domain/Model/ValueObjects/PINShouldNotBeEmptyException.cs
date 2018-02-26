namespace MyAccountAPI.Domain.Model.ValueObjects
{
    public class PINShouldNotBeEmptyException : DomainException
    {
        public PINShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
