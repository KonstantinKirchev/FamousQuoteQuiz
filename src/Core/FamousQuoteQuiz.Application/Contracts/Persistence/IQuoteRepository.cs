using FamousQuoteQuiz.Domain.Entities;

namespace FamousQuoteQuiz.Application.Contracts.Persistence;

public interface IQuoteRepository : IGenericRepository<Quote>
{
    Task AddQuote(Quote quote);
    Task<Quote> GetQuoteDetails(string id);
    Task<List<Quote>> GetQuotesWithDetails();
    Task<List<Quote>> GetQuotesWithDetails(string userId);
    Task<bool> IsQuoteUnique(string text);
}
