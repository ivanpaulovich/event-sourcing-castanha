namespace Castanha.Application
{
    using Castanha.Domain;

    public interface IDispatcher
    {
        void Send(IDomainEvent domainEvent);
    }
}
