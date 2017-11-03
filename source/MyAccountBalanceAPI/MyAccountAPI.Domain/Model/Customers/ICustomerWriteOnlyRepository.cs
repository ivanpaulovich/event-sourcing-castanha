using System.Threading.Tasks;

namespace MyAccountAPI.Domain.Model.Customers
{
    public interface ICustomerWriteOnlyRepository
    {
        Task AddCustomer(Customer customer);
        Task UpdateCustomer(Customer customer);
    }
}
