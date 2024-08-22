using WebApplicationExercise.Data;
using WebApplicationExercise.DTO.Customers;

namespace WebApplicationExercise.Repositories.Customers
{
    public interface ICustomerRepository
    {
        Task<Customer> GetCustomerByIDAsync(short id);
        Task<List<Customer>> GetCustomersAsync();
        Task<Customer> SaveCustomerAsync(CustomerDTO customerDTO);
    }
}
