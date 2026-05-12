using FluentValidation;

namespace FamousQuoteQuiz.Application.Features.User.Commands.DisableUser;

public class DisableUserCommandValidator : AbstractValidator<DisableUserCommand>
{
    public DisableUserCommandValidator()
    {
        RuleFor(x => x.Id).GreaterThan(0);
    }
}
