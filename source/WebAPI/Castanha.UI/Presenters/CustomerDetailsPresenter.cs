namespace Castanha.UI.Presenters
{
    using Castanha.Application;
    using Castanha.Application.Outputs;
    using Castanha.UI.Model;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Collections.Generic;

    public class CustomerDetailsPresenter : IOutputBoundary<CustomerOutput>
    {
        public IActionResult ViewModel { get; private set; }
        public CustomerOutput Response { get; private set; }

        public void Populate(CustomerOutput response)
        {
            Response = response;

            if (response == null)
            {
                ViewModel = new NoContentResult();
                return;
            }

            List<Guid> accounts = new List<Guid>();

            foreach (var account in response.Accounts)
            {
                accounts.Add(account);
            }

            CustomerDetailsModel model = new CustomerDetailsModel(
                response.CustomerId,
                response.Personnummer,
                response.Name,
                accounts
            );

            ViewModel = new ObjectResult(model);
        }
    }
}
