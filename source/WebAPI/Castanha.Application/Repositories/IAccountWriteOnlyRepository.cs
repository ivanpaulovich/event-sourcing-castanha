namespace Castanha.Application.Repositories
{
    using Castanha.Domain.Accounts;
    using Castanha.Domain.Accounts.Events;
    using System.Threading.Tasks;

    public interface IAccountWriteOnlyRepository
    {
        Task Add(OpenedDomainEvent domainEvent);
        Task Update(DepositedDomainEvent domainEvent);
        Task Update(WithdrewDomainEvent domainEvent);
        Task Delete(ClosedDomainEvent domainEvent);
    }
}
