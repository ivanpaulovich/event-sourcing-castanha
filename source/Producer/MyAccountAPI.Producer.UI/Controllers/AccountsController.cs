namespace MyAccountAPI.Producer.UI.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;
    using MyAccountAPI.Producer.Application.Commands.Accounts;
    using MyAccountAPI.Producer.Application.Queries;
    using MyAccountAPI.Domain.Exceptions;
    using MyAccountAPI.Domain.Model.Accounts;

    [Authorize]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IMediator mediator;
        private readonly IAccountsQueries accountsQueries;

        public AccountsController(IMediator mediator, IAccountsQueries accountsQueries)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));

            if (accountsQueries == null)
                throw new ArgumentNullException(nameof(accountsQueries));

            this.mediator = mediator;
            this.accountsQueries = accountsQueries;
        }

        /// <summary>
        /// Deposit from an account
        /// </summary>
        [HttpPatch("Deposit")]
        public async Task<Transaction> Deposit([FromBody]DepositCommand command)
        {
            Transaction transaction = await mediator.Send(command);
            return transaction;
        }

        /// <summary>
        /// Withdraw from an account
        /// </summary>
        [HttpPatch("Withdraw")]
        public async Task<Transaction> Withdraw([FromBody]WithdrawCommand command)
        {
            Transaction transaction = await mediator.Send(command);
            return transaction;
        }

        /// <summary>
        /// Close an account
        /// </summary>
        [HttpDelete]
        public async Task<IActionResult> Close([FromBody]CloseCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        /// <summary>
        /// Get an account balance
        /// </summary>
        [HttpGet("{id}", Name = "GetAccount")]
        public async Task<IActionResult> Get(Guid id)
        {
            var account = await accountsQueries.GetAsync(id);

            if (account == null)
                throw new CustomerNotFoundException($"The customer {id} does not exists or is not processed yet.");

            return Ok(account);
        }

        /// <summary>
        /// List all accounts
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var accounts = await accountsQueries.GetAsync();

            return Ok(accounts);
        }
    }
}
