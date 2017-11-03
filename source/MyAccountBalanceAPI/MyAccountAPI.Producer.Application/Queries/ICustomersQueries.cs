using System;
using System.Dynamic;
using System.Threading.Tasks;

namespace MyAccountAPI.Producer.Application.Queries
{
    public interface ICustomersQueries
    {
        Task<ExpandoObject> GetCustomerAsync(Guid id);
    }
}
