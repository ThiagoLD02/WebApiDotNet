using MediatR;
using WebApplicationExercise.Data;
using WebApplicationExercise.Repositories.Customers;
using WebApplicationExercise.Requests.Customers;

namespace WebApplicationExercise.Handlers.Customers
{
    public class GetCustomersHandler : IRequestHandler<GetCustomersRequest, List<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomersHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<List<Customer>> Handle(GetCustomersRequest request, CancellationToken cancellationToken)
        {
            return _customerRepository.GetCustomersAsync();
        }
    }
}
