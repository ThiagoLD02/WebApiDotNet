using Dapper;
using WebApplicationExercise.Data;
using WebApplicationExercise.DTO.Orders;

namespace WebApplicationExercise.Repositories.Orders
{
    public class OrderRepository : IOrderRepository
    {

        private DBSession _dbSession;

        public OrderRepository(DBSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<Order> GetOrderByIDAsync(short id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Order>> GetOrders()
        {
            using var dbConnection = _dbSession.Connection;
            var query = "SELECT * FROM Orders";
            List<Order> orders = (await dbConnection.QueryAsync<Order>(query)).ToList();
            return orders;
        }

        public async Task<Order> SaveOrderAsync(OrderDTO orderDTO)
        {
            using var dbConnection = _dbSession.Connection;
            var query =
                @"  INSERT INTO Orders (Quantity, ProductName, CustomerID)
                    VALUES(@Quantity, @ProductName, @CustomerID);
                    SELECT * FROM Orders WHERE ID = SCOPE_IDENTITY();
                ";
            return await dbConnection.QuerySingleAsync<Order>(query, orderDTO);

        }

        public async Task<List<Order>> GetOrdersByCustomerIDAsync(short id)
        {
            using var dbConnection = _dbSession.Connection;
            List<Order> orders =  (await dbConnection.QueryAsync<Order>(
                "GetOrdersByCustomerID",
                new { CustomerID = id },
                commandType: System.Data.CommandType.StoredProcedure
            )).ToList();

            return orders;
        }

        public async Task<List<OrderCustomerNameDTO>> GetOrdersWithCustomerName()
        {
            using var dbConnection = _dbSession.Connection;
            var query =
                "SELECT o.ID, o.Quantity, o.ProductName, c.Name AS CustomerName  FROM Orders o " +
                "INNER JOIN Customers c ON  o.CustomerID = c.ID";
            List<OrderCustomerNameDTO> orders = (await dbConnection.QueryAsync<OrderCustomerNameDTO>(query)).ToList();
            return orders;
        }


    }
}
