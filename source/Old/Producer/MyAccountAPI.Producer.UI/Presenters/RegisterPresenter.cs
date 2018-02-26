namespace MyAccountAPI.Producer.UI.Presenters
{
    using MyAccountAPI.Producer.Application;
    using MyAccountAPI.Producer.Application.UseCases.Register;
    using MyAccountAPI.Producer.UI.Model;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;

    public class RegisterPresenter : IOutputBoundary<RegisterResponse>
    {
        public IActionResult ViewModel { get; private set; }
        public RegisterResponse Response { get; private set; }

        public void Populate(RegisterResponse response)
        {
            Response = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }
            
            List<TransactionModel> transactions = new List<TransactionModel>();

            foreach (var item in response.Account.Transactions)
            {
                var transaction = new TransactionModel(
                    item.Amount,
                    item.Description,
                    item.TransactionDate);

                transactions.Add(transaction);
            }

            AccountDetailsModel account = new AccountDetailsModel(
                response.Account.AccountId,
                response.Account.CurrentBalance,
                transactions);

            List<AccountDetailsModel> accounts = new List<AccountDetailsModel>();
            accounts.Add(account);

            RegisterModel model = new RegisterModel(
                response.Customer.CustomerId,
                response.Customer.Personnummer,
                response.Customer.Name,
                accounts
            );

            ViewModel = new CreatedAtRouteResult("GetCustomer", new { customerId = model.CustomerId }, model);
        }
    }
}
