using System.Threading.Tasks;

namespace MyAccountAPI.Domain.Model.Accounts
{
    public interface IAccountWriteOnlyRepository
    {
        Task Add(Account account);
        Task Update(Account account);
        Task Delete(Account account);
    }
}
