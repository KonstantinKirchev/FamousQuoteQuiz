using MediatR;

namespace FamousQuoteQuiz.Application.Features.Quote.Queries.GetQuotes
{
    public class GetQuotesQuery : IRequest<List<QuoteDto>>
    {
        public bool IsLoggedInUser { get; set; }
    }
}
