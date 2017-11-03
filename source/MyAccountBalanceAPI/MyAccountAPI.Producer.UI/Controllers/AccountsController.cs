using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MyAccountAPI.Producer.Application.Commands.Accounts;

namespace MyAccountAPI.Producer.UI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class AccountsController : Controller
    {
        private readonly IMediator mediator;

        public AccountsController(IMediator mediator)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));

            this.mediator = mediator;
        }

        [HttpPatch("Deposit")]
        public async Task<IActionResult> Deposit([FromBody]DepositCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("Withdraw")]
        public async Task<IActionResult> Withdraw([FromBody]WithdrawCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }

        [HttpPatch("Close")]
        public async Task<IActionResult> Close([FromBody]CloseCommand command)
        {
            await mediator.Send(command);
            return (IActionResult)Ok();
        }
    }
}
