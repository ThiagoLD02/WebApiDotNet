using Azure.Core;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationExercise.DTO.Customers;
using WebApplicationExercise.Requests.Customers;
using WebApplicationExercise.Validators;

namespace WebApplicationExercise.Controllers.Customers
{

    [ApiController]
    [Route("[Controller]")]
    public class CustomersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetCustomers()
        {
            return Ok(await _mediator.Send( new GetCustomersRequest { }));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> SaveCustomer(CustomerDTO customerDTO)
        {
            SaveCustomerValidator validator = new SaveCustomerValidator();
            ValidationResult results = validator.Validate(customerDTO);
            if (results.IsValid)
                return Ok(await _mediator.Send(new SaveCustomerRequest { CustomerDTO = customerDTO }));
            throw new BadHttpRequestException(results.ToString());
        }
    }
}
