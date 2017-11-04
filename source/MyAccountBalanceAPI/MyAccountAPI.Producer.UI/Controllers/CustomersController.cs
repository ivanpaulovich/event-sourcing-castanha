using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAccountAPI.Domain.Model.Customers;
using MyAccountAPI.Producer.Application.Commands.Customers;
using MyAccountAPI.Producer.Application.Queries;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace MyAccountAPI.Producer.UI.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IMediator mediator;
        private readonly ICustomersQueries customersQueries;

        public CustomersController(IMediator mediator, ICustomersQueries customersQueries)
        {
            if (mediator == null)
                throw new ArgumentNullException(nameof(mediator));

            if (customersQueries == null)
                throw new ArgumentNullException(nameof(customersQueries));

            this.mediator = mediator;
            this.customersQueries = customersQueries;
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
                AccountId = customer.GetAccounts().First().Id,
                CurrentBalance = customer.GetAccounts().First().GetCurrentBalance()
            };

            return CreatedAtRoute("GetCustomer", new { id = customer.Id }, result);
        }

        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid id)
        {
            var customer = await customersQueries.GetAsync(id);

            return Ok(customer);
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await customersQueries.GetAsync();

            return Ok(customers);
        }
    }
}
