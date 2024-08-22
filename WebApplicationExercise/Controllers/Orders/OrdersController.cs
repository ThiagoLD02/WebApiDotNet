using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationExercise.DTO.Orders;
using WebApplicationExercise.Requests.Orders;

namespace WebApplicationExercise.Controllers.Orders
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _mediator.Send(new GetOrdersRequest { }));
        }

        [HttpGet("CustomerID/{id}")]
        public async Task<IActionResult> GetOrdersByCustomerID(short id)
        {
            return Ok(await _mediator.Send(new GetOrdersByCustomerIDRequest { Id = id }));
        }

        [HttpGet("With-user-name")]
        public async Task<IActionResult> GetOrdersWithCustomerName()
        {
            return Ok(await _mediator.Send(new GetOrdersWithCustomerNameRequest { }));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderDTO orderDTO)
        {
            return Created("", await _mediator.Send(new SaveOrderRequest { OrderDTO = orderDTO }));
        }
    }
}
