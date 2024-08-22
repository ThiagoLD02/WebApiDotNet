using MediatR;
using WebApplicationExercise.DTO.Orders;

namespace WebApplicationExercise.Requests.Orders
{
    public class GetOrdersWithQuantityGraterThanRequest : IRequest<List<OrderCustomerNameDTO>>
    {
        public int Quantity { get; set; }
    }
}
