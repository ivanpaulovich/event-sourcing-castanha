namespace Castanha.Application.Repositories
{
    using Castanha.Domain.Customers;
    using Castanha.Domain.Customers.Events;
    using System.Threading.Tasks;

    public interface ICustomerWriteOnlyRepository
    {
        Task Add(RegisteredDomainEvent domainEvent);
    }
}
