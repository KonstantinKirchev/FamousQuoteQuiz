
using MediatR;

namespace FamousQuoteQuiz.Application.Features.Quote.Commands.CreateQuote;

public class CreateQuoteCommand : IRequest<Unit>
{
    public string Text { get; set; }
    public string Author { get; set; }
}
