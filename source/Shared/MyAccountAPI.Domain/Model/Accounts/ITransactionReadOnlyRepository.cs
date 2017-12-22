namespace MyAccountAPI.Domain.Model.Accounts
{
    using System;
    using System.Threading.Tasks;

    public interface ITransactionReadOnlyRepository
    {
        Task<Transaction> GetTransaction(Guid transactionId);
    }
}
