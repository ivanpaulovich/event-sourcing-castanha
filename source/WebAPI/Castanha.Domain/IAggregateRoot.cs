namespace Castanha.Domain
{
    public interface IAggregateRoot : IAggregate
    {
        int Version { get; }
    }
}