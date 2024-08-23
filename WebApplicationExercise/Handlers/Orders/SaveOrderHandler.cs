using MediatR;
using WebApplicationExercise.Data;
using WebApplicationExercise.Repositories.Orders;
using WebApplicationExercise.Requests.Orders;
using WebApplicationExercise.Validators;

namespace WebApplicationExercise.Handlers
{
    public class SaveOrderHandler : IRequestHandler<SaveOrderRequest, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public SaveOrderHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        Task<Order> IRequestHandler<SaveOrderRequest, Order>.Handle(SaveOrderRequest request, CancellationToken cancellationToken)
        {

            return _orderRepository.SaveOrderAsync(request.OrderDTO);
        }
    }
}
