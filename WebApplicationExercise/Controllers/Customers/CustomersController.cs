using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationExercise.DTO.Customers;
using WebApplicationExercise.Requests.Customers;

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
            return Ok(await _mediator.Send(new SaveCustomerRequest { CustomerDTO = customerDTO }));
        }
    }
}
