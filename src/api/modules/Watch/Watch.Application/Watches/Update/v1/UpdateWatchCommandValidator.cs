using FluentValidation;

namespace FSH.Starter.WebApi.Watches.Application.Update.v1;
public class UpdateWatchCommandValidator : AbstractValidator<UpdateWatchCommand>
{
    public UpdateWatchCommandValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(2).MaximumLength(75);
        RuleFor(p => p.RetailPrice).GreaterThan(0);
    }
}
