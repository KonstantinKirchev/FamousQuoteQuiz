using FamousQuoteQuiz.Application.Contracts.Persistence;
using FluentValidation;

namespace FamousQuoteQuiz.Application.Features.Quote.Commands.UpdateQuote;

public class UpdateQuoteCommandValidator : AbstractValidator<UpdateQuoteCommand>
{
    private readonly IQuoteRepository _quoteRepository;

    public UpdateQuoteCommandValidator(IQuoteRepository quoteRepository)
    {
        _quoteRepository = quoteRepository;

        RuleFor(p => p.Id)
                .NotNull()
                .MustAsync(QuoteMustExist)
                .WithMessage("{PropertyName} must be present");
    }

    private async Task<bool> QuoteMustExist(int id, CancellationToken arg2)
    {
        var quote = await _quoteRepository.GetByIdAsync(id);
        return quote != null;
    }

}
