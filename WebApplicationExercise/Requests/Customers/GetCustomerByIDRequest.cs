using MediatR;
using WebApplicationExercise.Data;

namespace WebApplicationExercise.Requests.Customers
{
    public class GetCustomerByIDRequest : IRequest<Customer>
    {
        public short ID { get; set; }
    }
}
