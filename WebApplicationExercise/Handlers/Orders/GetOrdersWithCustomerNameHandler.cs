using MediatR;
using WebApplicationExercise.Data;
using WebApplicationExercise.DTO.Orders;
using WebApplicationExercise.Repositories.Orders;
using WebApplicationExercise.Requests.Orders;

namespace WebApplicationExercise.Handlers.Orders
{
    public class GetOrdersWithCustomerNameHandler : IRequestHandler<GetOrdersWithCustomerNameRequest, List<OrderCustomerNameDTO>>
    {

        private readonly IOrderRepository _orderRepository;

        public GetOrdersWithCustomerNameHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<OrderCustomerNameDTO>> Handle(GetOrdersWithCustomerNameRequest request, CancellationToken cancellationToken)
        {
            return _orderRepository.GetOrdersWithCustomerName();
        }
    }
}
