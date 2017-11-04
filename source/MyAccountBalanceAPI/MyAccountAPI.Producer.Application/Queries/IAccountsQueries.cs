using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading.Tasks;

namespace MyAccountAPI.Producer.Application.Queries
{
    public interface IAccountsQueries
    {
        Task<ExpandoObject> GetAsync(Guid id);
        Task<IEnumerable<ExpandoObject>> GetAsync();
    }
}
