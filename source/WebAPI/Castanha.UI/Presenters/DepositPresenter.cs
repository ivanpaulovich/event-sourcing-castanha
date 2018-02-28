namespace Castanha.UI.Presenters
{
    using Castanha.Application;
    using Castanha.Application.UseCases.Deposit;
    using Castanha.UI.Model;
    using Microsoft.AspNetCore.Mvc;

    public class DepositPresenter : IOutputBoundary<DepositOutput>
    {
        public IActionResult ViewModel { get; private set; }

        public DepositOutput Response { get; private set; }

        public void Populate(DepositOutput response)
        {
            Response = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new ObjectResult(new DepositModel(
                response.Transaction.Amount,
                response.Transaction.Description,
                response.Transaction.TransactionDate,
                response.UpdatedBalance
            ));
        }
    }
}
