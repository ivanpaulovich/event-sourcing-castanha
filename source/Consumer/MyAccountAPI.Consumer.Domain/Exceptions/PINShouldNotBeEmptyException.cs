namespace MyAccountAPI.Domain.Exceptions
{
    public class PINShouldNotBeEmptyException : DomainException
    {
        public PINShouldNotBeEmptyException(string message)
            : base(message)
        { }
    }
}
