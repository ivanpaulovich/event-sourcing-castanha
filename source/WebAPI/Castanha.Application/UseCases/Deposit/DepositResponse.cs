namespace Castanha.Application.UseCases.Deposit
{
    using Castanha.Application.Responses;
    public class DepositResponse
    {
        public TransactionResponse Transaction { get; private set; }
        public double UpdatedBalance { get; private set; }
        public DepositResponse()
        {

        }

        public DepositResponse(TransactionResponse transaction, double updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdatedBalance = updatedBalance;
        }
    }
}
