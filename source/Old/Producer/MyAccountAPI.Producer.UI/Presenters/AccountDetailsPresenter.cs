namespace MyAccountAPI.Producer.UI.Presenters
{
    using MyAccountAPI.Producer.Application;
    using MyAccountAPI.Producer.Application.Responses;
    using MyAccountAPI.Producer.UI.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class AccountDetailsPresenter : IOutputBoundary<AccountResponse>
    {
        public IActionResult ViewModel { get; private set; }
        public AccountResponse Response { get; private set; }

        public void Populate(AccountResponse response)
        {
            Response = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in response.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            ViewModel = new ObjectResult(new AccountDetailsModel(
                response.AccountId,
                response.CurrentBalance,
                transactions));
        }
    }
}
