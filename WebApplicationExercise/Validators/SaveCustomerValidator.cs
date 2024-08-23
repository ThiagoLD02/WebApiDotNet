using FluentValidation;
using WebApplicationExercise.DTO.Customers;

namespace WebApplicationExercise.Validators
{
    public class SaveCustomerValidator : AbstractValidator<CustomerDTO>
    {
        public SaveCustomerValidator() 
        { 
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is empty!");
            RuleFor(x => x.City).NotEmpty().WithMessage("City is empty!");
        }

    }
}
