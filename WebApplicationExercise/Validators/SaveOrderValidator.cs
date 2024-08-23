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

            RuleFor(x => x.CustomerID).SetValidator(new CustomerIDValidator(_mediator));


        }

    }
}
