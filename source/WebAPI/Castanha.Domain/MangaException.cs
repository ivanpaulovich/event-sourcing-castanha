namespace Castanha.Domain
{
    using System;

    public class CastanhaException : Exception
    {
        internal CastanhaException()
        { }

        internal CastanhaException(string message)
            : base(message)
        { }

        internal CastanhaException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
