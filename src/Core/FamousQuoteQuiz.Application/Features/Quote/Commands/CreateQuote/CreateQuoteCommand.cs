
using MediatR;

namespace FamousQuoteQuiz.Application.Features.Quote.Commands.CreateQuote;

public class CreateQuoteCommand : IRequest<Unit>
{
    public int QuoteId { get; set; }
}
