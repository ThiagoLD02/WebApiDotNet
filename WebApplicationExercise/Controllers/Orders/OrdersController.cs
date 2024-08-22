using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationExercise.DTO.Orders;
using WebApplicationExercise.Requests.Orders;

namespace WebApplicationExercise.Controllers.Orders
{
    [ApiController]
    [Route("[controller]")]
    public class OrdersController : ControllerBase
    {

        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetOrders()
        {
            return Ok(await _mediator.Send(new GetOrdersRequest { }));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> SaveOrder(OrderDTO orderDTO)
        {
            return Created("", await _mediator.Send(new SaveOrderRequest { OrderDTO = orderDTO }));
        }

        [HttpGet]
        [Route("/CustomerID/{id}")]
        public async Task<IActionResult> GetOrdersByCustomerID(short id)
        {
            return Ok(await _mediator.Send(new GetOrdersByCustomerIDRequest { Id = id }));
        }
    }
}
