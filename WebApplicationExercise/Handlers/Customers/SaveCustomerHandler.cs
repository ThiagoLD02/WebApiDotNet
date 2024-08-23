using FluentValidation.Results;
using MediatR;
using WebApplicationExercise.Data;
using WebApplicationExercise.Repositories.Customers;
using WebApplicationExercise.Requests.Customers;
using WebApplicationExercise.Validators;

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
            SaveCustomerValidator validator = new SaveCustomerValidator();
            ValidationResult results = validator.Validate(request.CustomerDTO);
            if(results.IsValid)
                return _customerRepository.SaveCustomerAsync(request.CustomerDTO);
            throw new BadHttpRequestException(results.ToString());

        }
    }
}
