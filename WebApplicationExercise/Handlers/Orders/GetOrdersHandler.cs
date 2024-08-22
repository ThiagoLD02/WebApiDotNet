using MediatR;
using WebApplicationExercise.Data;
using WebApplicationExercise.Repositories.Orders;
using WebApplicationExercise.Requests.Orders;

namespace WebApplicationExercise.Handlers.Orders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersRequest, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<Order>> Handle(GetOrdersRequest request, CancellationToken cancellationToken)
        {
            return _orderRepository.GetOrders();
        }
    }
}
