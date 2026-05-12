using FamousQuoteQuiz.Application.Contracts.Persistence;
using FluentValidation;

namespace FamousQuoteQuiz.Application.Features.Quote.Commands.CreateQuote;

public class CreateQuoteCommandValidator : AbstractValidator<CreateQuoteCommand>
{
    private readonly IQuoteRepository _quoteRepository;

    public CreateQuoteCommandValidator(IQuoteRepository quoteRepository)
    {
        _quoteRepository = quoteRepository;

        RuleFor(p => p.QuoteId)
            .GreaterThan(0)
            .MustAsync(QuoteMustExist)
            .WithMessage("{PropertyName} does not exist.");
    }

    private async Task<bool> QuoteMustExist(int id, CancellationToken arg2)
    {
        var quote = await _quoteRepository.GetByIdAsync(id);
        return quote != null;
    }
}
