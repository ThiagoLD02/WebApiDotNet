using WebApplicationExercise.Data;
using WebApplicationExercise.DTO.Orders;

namespace WebApplicationExercise.Repositories.Orders
{
    public interface IOrderRepository
    {
        Task<Order> GetOrderByIDAsync(short id);
        
        Task<List<Order>> GetOrders();
        
        Task<Order> SaveOrderAsync(OrderDTO orderDTO);

        Task<List<Order>> GetOrdersByCustomerIDAsync(short id);
    }
}
