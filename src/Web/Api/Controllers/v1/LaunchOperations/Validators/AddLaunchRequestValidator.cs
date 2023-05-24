using TesteComercio.Api.Controllers.v1.Launchs.Requests;
using FluentValidation;

namespace TesteComercio.Api.Controllers.v1.Products.Validators
{
    public class AddLaunchRequestValidator : AbstractValidator<AddLaunchRequest>
    {
        public AddLaunchRequestValidator()
        {
            RuleFor(x => x.Name)
                .NotNull().NotEmpty().WithMessage("{PropertyName} is not valid");

            RuleFor(x => x.Price)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage("{PropertyName} is not valid");
        }
    }
}
