using FluentValidation;

namespace FSH.Starter.WebApi.Watches.Application.Create.v1;
public class CreateWatchCommandValidator : AbstractValidator<CreateWatchCommand>
{
    public CreateWatchCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(2).MaximumLength(75);
        RuleFor(p => p.RetailPrice).GreaterThan(0);
    }
}
