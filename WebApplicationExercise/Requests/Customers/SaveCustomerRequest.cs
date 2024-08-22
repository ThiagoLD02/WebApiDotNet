using MediatR;
using WebApplicationExercise.Data;
using WebApplicationExercise.DTO.Customers;

namespace WebApplicationExercise.Requests.Customers
{
    public class SaveCustomerRequest : IRequest<Customer>
    {
        public CustomerDTO CustomerDTO { get; set; }
    }
}
