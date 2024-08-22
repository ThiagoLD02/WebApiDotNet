using MediatR;
using WebApplicationExercise.Data;

namespace WebApplicationExercise.Requests.Customers
{
    public class GetCustomersRequest : IRequest<List<Customer>>
    {
    }
}