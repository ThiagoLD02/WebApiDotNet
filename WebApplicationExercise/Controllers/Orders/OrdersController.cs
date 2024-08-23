using Azure.Core;
using FluentValidation.Results;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplicationExercise.DTO.Customers;
using WebApplicationExercise.DTO.Orders;
using WebApplicationExercise.Requests.Orders;
using WebApplicationExercise.Validators;

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

        [HttpGet("Quantity-grater-than/{quantity}")]
        public async Task<IActionResult> GetOrdersWithQuantityGraterThan(int quantity)
        {
            return Ok(await _mediator.Send(new GetOrdersWithQuantityGraterThanRequest {Quantity = quantity }));
        }

        [HttpPost]
        public async Task<IActionResult> SaveOrder(OrderDTO orderDTO)
        {
            SaveOrderValidator validator = new SaveOrderValidator(_mediator);
            ValidationResult results = await validator.ValidateAsync(orderDTO);
            
            if (results.IsValid)
                return Created("", await _mediator.Send(new SaveOrderRequest { OrderDTO = orderDTO }));
            throw new BadHttpRequestException(results.ToString());
        }
    }
}
