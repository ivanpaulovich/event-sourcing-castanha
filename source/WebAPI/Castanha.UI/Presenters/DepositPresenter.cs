namespace Castanha.UI.Presenters
{
    using Castanha.Application;
    using Castanha.Application.UseCases.Deposit;
    using Castanha.UI.Model;
    using Microsoft.AspNetCore.Mvc;

    public class DepositPresenter : IOutputBoundary<DepositOutput>
    {
        public IActionResult ViewModel { get; private set; }

        public DepositOutput Output { get; private set; }

        public void Populate(DepositOutput output)
        {
            Output = output;

            if (output == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            ViewModel = new ObjectResult(new DepositModel(
                output.Transaction.Amount,
                output.Transaction.Description,
                output.Transaction.TransactionDate,
                output.UpdatedBalance
            ));
        }
    }
}
