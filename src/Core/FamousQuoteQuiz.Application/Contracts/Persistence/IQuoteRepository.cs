using FamousQuoteQuiz.Domain.Entities;

namespace FamousQuoteQuiz.Application.Contracts.Persistence;

public interface IQuoteRepository : IGenericRepository<Quote>
{
    Task<IReadOnlyList<Quote>> GetAllQuotesAsync();
    Task<Quote> GetQuoteAsync(int id);
    Task CreateQuoteAsync(Quote quote);
    Task UpdateQuoteAsync(Quote quote);
    Task DeleteQuoteAsync(Quote quote);
    Task<bool> IsQuoteUniqueAsync(string text);
}
