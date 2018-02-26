namespace MyAccountAPI.Producer.Application.UseCases.Withdraw
{
    using MyAccountAPI.Producer.Application.Responses;
    public class WithdrawResponse
    {
        public TransactionResponse Transaction { get; private set; }
        public double UpdatedBalance { get; private set; }

        public WithdrawResponse()
        {

        }

        public WithdrawResponse(TransactionResponse transaction, double updatedBalance)
        {
            this.Transaction = transaction;
            this.UpdatedBalance = updatedBalance;
        }
    }
}
