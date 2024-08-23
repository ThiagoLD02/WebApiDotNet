using FluentValidation;
using MediatR;
using WebApplicationExercise.Requests.Customers;

namespace WebApplicationExercise.Validators
{
    public class CustomerIDValidator : AbstractValidator<short>
    {
        private readonly IMediator _mediator;
        public CustomerIDValidator(IMediator mediator)
        {
            _mediator = mediator;
            RuleFor(id => id)
                .Must(id => id > 0).WithMessage("Id is 0")
                .MustAsync(async (id, cancellation) => await UserExists(id))
                .WithMessage("This user was not found");
        }

        private async Task<bool> UserExists(short id)
        {
            var customer = await _mediator.Send(new GetCustomerByIDRequest { ID = id });
            return customer != null;
        }
    }
}
