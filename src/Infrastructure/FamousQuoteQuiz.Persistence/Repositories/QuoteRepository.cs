using FamousQuoteQuiz.Application.Contracts.Persistence;
using FamousQuoteQuiz.Domain.Entities;
using FamousQuoteQuiz.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FamousQuoteQuiz.Persistence.Repositories;

public class QuoteRepository : GenericRepository<Quote>, IQuoteRepository
{
    public QuoteRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task<IReadOnlyList<Quote>> GetAllQuotesAsync()
    {
        var quotes = await _context.Quotes.ToListAsync();
        return quotes;
    }

    public async Task<Quote> GetQuoteAsync(int id)
    {
        var quote = await _context.Quotes.FirstOrDefaultAsync(q => q.Id == id);
        return quote;
    }

    public async Task CreateQuoteAsync(Quote quote)
    {
        await _context.AddAsync(quote);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateQuoteAsync(Quote quote)
    {
        _context.Quotes.Update(quote);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteQuoteAsync(Quote quote)
    {
        _context.Quotes.Remove(quote);
        await _context.SaveChangesAsync();
    }

    public async Task<bool> IsQuoteUniqueAsync(string text)
    {
        return await _context.Quotes.AnyAsync(q => q.Text == text) == false;
    }
}
