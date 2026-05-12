using MediatR;

namespace FamousQuoteQuiz.Application.Features.Quote.Commands.DeleteQuote;

public class DeleteQuoteCommand : IRequest
{
    public int Id { get; set; }
}
