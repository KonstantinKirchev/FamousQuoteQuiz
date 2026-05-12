using FamousQuoteQuiz.Application.Contracts.Persistence;
using FluentValidation;

namespace FamousQuoteQuiz.Application.Features.Quote.Commands.CreateQuote;

public class CreateQuoteCommandValidator : AbstractValidator<CreateQuoteCommand>
{
    private readonly IQuoteRepository _quoteRepository;

    public CreateQuoteCommandValidator(IQuoteRepository quoteRepository)
    {
        RuleFor(p => p.Text)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(70).WithMessage("{PropertyName} must be fewer than 70 characters");

        RuleFor(p => p.Author)
            .NotEmpty().WithMessage("{PropertyName} is required")
            .NotNull()
            .MaximumLength(50).WithMessage("{PropertyName} must be fewer than 50 characters");

        RuleFor(q => q)
            .MustAsync(QuoteUnique)
            .WithMessage("Quote already exists");

        _quoteRepository = quoteRepository;
    }

    private Task<bool> QuoteUnique(CreateQuoteCommand command, CancellationToken token)
    {
        return _quoteRepository.IsQuoteUnique(command.Text);
    }
}
