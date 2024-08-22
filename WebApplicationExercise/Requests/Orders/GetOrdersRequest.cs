using MediatR;
using WebApplicationExercise.Data;

namespace WebApplicationExercise.Requests.Orders
{
    public class GetOrdersRequest : IRequest<List<Order>>
    {
    }
}
