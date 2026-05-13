

using FamousQuoteQuiz.Application.Contracts.Persistence;
using FamousQuoteQuiz.Application.Exceptions;
using MediatR;

namespace FamousQuoteQuiz.Application.Features.Quote.Commands.DeleteQuote;

public class DeleteQuoteCommandHandler : IRequestHandler<DeleteQuoteCommand, Unit>
{
    private readonly IQuoteRepository _quoteRepository;

    public DeleteQuoteCommandHandler(IQuoteRepository quoteRepository)
    {
        _quoteRepository = quoteRepository;
    }

    public async Task<Unit> Handle(DeleteQuoteCommand request, CancellationToken cancellationToken)
    {
        var quote = await _quoteRepository.GetByIdAsync(request.Id);

        if (quote == null)
            throw new NotFoundException(nameof(quote), request.Id);

        await _quoteRepository.DeleteAsync(quote);
        return Unit.Value;
    }
}
