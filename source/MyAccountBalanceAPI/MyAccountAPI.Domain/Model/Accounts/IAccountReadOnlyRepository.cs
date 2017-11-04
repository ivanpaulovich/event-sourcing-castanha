using System;
using System.Threading.Tasks;

namespace MyAccountAPI.Domain.Model.Accounts
{
    public interface IAccountReadOnlyRepository
    {
        Task<Account> Get(Guid id);
    }
}
