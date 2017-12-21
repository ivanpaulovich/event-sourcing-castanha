using System.Threading.Tasks;

namespace MyAccountAPI.Domain.Model.Customers
{
    public interface ICustomerWriteOnlyRepository
    {
        Task Add(Customer customer);
        Task Update(Customer customer);
    }
}
