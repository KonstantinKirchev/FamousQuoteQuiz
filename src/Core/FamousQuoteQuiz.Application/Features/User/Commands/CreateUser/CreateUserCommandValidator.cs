using FamousQuoteQuiz.Application.Contracts.Persistence;
using FamousQuoteQuiz.Domain.Interfaces;
using FluentValidation;

namespace FamousQuoteQuiz.Application.Features.User.Commands.CreateUser;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(x => x.Firstname).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Lastname).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Username).NotEmpty().MaximumLength(50);
        RuleFor(x => x.Email).NotEmpty().EmailAddress();
    }
}
