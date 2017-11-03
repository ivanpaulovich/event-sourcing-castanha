using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAccountAPI.Domain.Model.Customers;
using MyAccountAPI.Producer.Application.Commands.Customers;
using MyAccountAPI.Producer.Application.Queries;
using System;
using System.Threading.Tasks;

namespace MyAccountAPI.Producer.UI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IMediator mediator;
        private readonly ICustomersQueries customerQueries;

        public CustomersController(IMediator mediator, ICustomersQueries customerQueries)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));

            if (customerQueries == null)
                throw new ArgumentNullException(nameof(customerQueries));

            this.mediator = mediator;
            this.customerQueries = customerQueries;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterCustomerCommand command)
        {
            Customer customer = await mediator.Send(command);

            var result = new
            {
                CustomerId = customer.Id,
                SSN = customer.GetPIN().Text,
                Name = customer.GetName().Text,
                Accounts = customer.GetAccounts()
            };

            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, result);
        }

        [HttpGet(Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var school = await customerQueries.GetCustomerAsync(id);

            return Ok(school);
        }
    }
}
