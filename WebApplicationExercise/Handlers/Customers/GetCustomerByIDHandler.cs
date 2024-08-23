using MediatR;
using WebApplicationExercise.Data;
using WebApplicationExercise.Repositories.Customers;
using WebApplicationExercise.Requests.Customers;

namespace WebApplicationExercise.Handlers.Customers
{
    public class GetCustomerByIDHandler : IRequestHandler<GetCustomerByIDRequest, Customer>
    {
        private readonly ICustomerRepository _customerRepository;
        public GetCustomerByIDHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Customer> Handle(GetCustomerByIDRequest request, CancellationToken cancellationToken)
        {
            return _customerRepository.GetCustomerByIDAsync(request.ID);
        }
    }
}
