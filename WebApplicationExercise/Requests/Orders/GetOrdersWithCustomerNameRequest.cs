using MediatR;
using WebApplicationExercise.DTO.Orders;

namespace WebApplicationExercise.Requests.Orders
{
    public class GetOrdersWithCustomerNameRequest : IRequest<List<OrderCustomerNameDTO>>
    {
    }
}
