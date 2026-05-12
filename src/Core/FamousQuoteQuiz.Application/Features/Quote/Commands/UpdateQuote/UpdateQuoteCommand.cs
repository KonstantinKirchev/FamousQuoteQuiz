using MediatR;

namespace FamousQuoteQuiz.Application.Features.Quote.Commands.UpdateQuote;

public class UpdateQuoteCommand : IRequest<Unit>
{
    public int Id { get; set; }
    public string Text { get; set; }
    public string Author { get; set; }
}
