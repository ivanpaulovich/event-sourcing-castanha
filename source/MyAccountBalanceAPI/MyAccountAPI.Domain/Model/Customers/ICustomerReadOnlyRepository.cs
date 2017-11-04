using System;
using System.Threading.Tasks;

namespace MyAccountAPI.Domain.Model.Customers
{
    public interface ICustomerReadOnlyRepository
    {
        Task<Customer> Get(Guid id);
    }
}
