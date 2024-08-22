using MediatR;
using WebApplicationExercise.Data;
using WebApplicationExercise.DTO.Orders;
using WebApplicationExercise.Repositories.Customers;
using WebApplicationExercise.Repositories.Orders;
using WebApplicationExercise.Requests.Orders;

namespace WebApplicationExercise.Handlers.Orders
{
    public class GetOrdersWithQuantityGraterThanHandler : IRequestHandler<GetOrdersWithQuantityGraterThanRequest, List<OrderCustomerNameDTO>>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrdersWithQuantityGraterThanHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Task<List<OrderCustomerNameDTO>> Handle(GetOrdersWithQuantityGraterThanRequest request, CancellationToken cancellationToken)
        {
            return _orderRepository.GetOrdersWithQuantityGraterThan(request.Quantity);
        }
    }
}
