using MediatR;
using WebApplicationExercise.Data;
using WebApplicationExercise.Repositories.Customers;
using WebApplicationExercise.Repositories.Orders;
using WebApplicationExercise.Requests.Orders;

namespace WebApplicationExercise.Handlers.Orders
{
    public class GetOrdersByCustomerIDHandler : IRequestHandler<GetOrdersByCustomerIDRequest, List<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersByCustomerIDHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<Order>> Handle(GetOrdersByCustomerIDRequest request, CancellationToken cancellationToken)
        {
            return _orderRepository.GetOrdersByCustomerIDAsync(request.Id);
        }
    }
}
