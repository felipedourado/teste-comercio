using TesteComercio.Api.Controllers.v1.Launchs.Requests;
using FluentValidation;

namespace TesteComercio.Api.Controllers.v1.Products.Validators
{
    public class GetLaunchRequestValidator : AbstractValidator<GetLaunchRequest>
    {
        public GetLaunchRequestValidator()
        {
            RuleFor(x => x.Page)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage("{PropertyName} is not valid");

            RuleFor(x => x.PageSize)
                .NotNull().NotEmpty().GreaterThan(0).WithMessage("{PropertyName} is not valid");
        }
    }
}
