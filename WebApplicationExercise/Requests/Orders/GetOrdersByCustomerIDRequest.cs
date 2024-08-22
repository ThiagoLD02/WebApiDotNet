using MediatR;
using WebApplicationExercise.Data;

namespace WebApplicationExercise.Requests.Orders
{
    public class GetOrdersByCustomerIDRequest : IRequest<List<Order>>
    {
        public short Id { get; set; }
    }
}
