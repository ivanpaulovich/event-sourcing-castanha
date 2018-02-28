namespace Castanha.UI.Controllers
{
    using Castanha.Application;
    using Castanha.Application.UseCases.GetCustomerDetails;
    using Castanha.Application.UseCases.Register;
    using Castanha.UI.Presenters;
    using Castanha.UI.Requests;
    using Microsoft.AspNetCore.Mvc;
    using System;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    public class CustomersController : Controller
    {
        private readonly IInputBoundary<RegisterInput> registerInput;
        private readonly IInputBoundary<GetCustomerDetaisInput> getCustomerInput;

        private readonly RegisterPresenter registerPresenter;
        private readonly CustomerDetailsPresenter getCustomerDetailsPresenter;

        public CustomersController(
            IInputBoundary<RegisterInput> registerInput,
            IInputBoundary<GetCustomerDetaisInput> getCustomerInput,
            RegisterPresenter registerPresenter,
            CustomerDetailsPresenter getCustomerDetailsPresenter)
        {
            this.registerInput = registerInput;
            this.getCustomerInput = getCustomerInput;
            this.registerPresenter = registerPresenter;
            this.getCustomerDetailsPresenter = getCustomerDetailsPresenter;
        }

        /// <summary>
        /// Register a new Customer
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]RegisterRequest message)
        {
            var request = new RegisterInput(message.PIN, message.Name, message.InitialAmount);
            await registerInput.Process(request);
            return registerPresenter.ViewModel;
        }

        /// <summary>
        /// Get a Customer details 
        /// </summary>
        [HttpGet("{customerId}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer(Guid customerId)
        {
            var request = new GetCustomerDetaisInput(customerId);
            await this.getCustomerInput.Process(request);
            return this.getCustomerDetailsPresenter.ViewModel;
        }
    }
}
