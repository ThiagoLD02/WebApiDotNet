using MediatR;
using WebApplicationExercise.Data;
using WebApplicationExercise.DTO.Customers;
using WebApplicationExercise.Repositories.Customers;
using WebApplicationExercise.Requests.Customers;

namespace WebApplicationExercise.Handlers.Customers
{
    public class SaveCustomerHandler : IRequestHandler<SaveCustomerRequest, Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public SaveCustomerHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Task<Customer> Handle(SaveCustomerRequest request, CancellationToken cancellationToken)
        {
            return _customerRepository.SaveCustomerAsync(request.CustomerDTO);
        }
    }
}
