using MediatR;
using WebApplicationExercise.Data;
using WebApplicationExercise.DTO.Orders;

namespace WebApplicationExercise.Requests.Orders
{
    internal class SaveOrderRequest : IRequest<Order>
    {
        public OrderDTO OrderDTO { get; set; }
    }
}