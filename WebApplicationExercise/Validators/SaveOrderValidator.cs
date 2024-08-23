using FluentValidation;
using MediatR;
using WebApplicationExercise.DTO.Orders;
using WebApplicationExercise.Requests.Customers;

namespace WebApplicationExercise.Validators
{
    public class SaveOrderValidator : AbstractValidator<OrderDTO>
    {
        private readonly IMediator _mediator;
        public SaveOrderValidator(IMediator mediator)
        {
            _mediator = mediator;

            RuleFor(x => x.Quantity)
                .NotEmpty().WithMessage("Quantity is empty.")
                .GreaterThan(0).WithMessage("Quantity should be grater than 0.");
            
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("ProductName is empty.");

            RuleFor(x => x.CustomerID)
                .NotEmpty().WithMessage("CustomerID is empty.")
                .MustAsync( async (CustomerID, cancellation) => await UserExists(CustomerID))
                .WithMessage("No customer found with this CustomerID");


        }

        private async Task<bool> UserExists(short id)
        {
            var customer = await _mediator.Send(new GetCustomerByIDRequest { ID = id });
            return customer != null;
        }
    }
}
