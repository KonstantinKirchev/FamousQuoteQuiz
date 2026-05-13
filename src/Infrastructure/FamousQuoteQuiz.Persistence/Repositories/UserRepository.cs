using FamousQuoteQuiz.Domain.Entities;
using FamousQuoteQuiz.Domain.Interfaces;
using FamousQuoteQuiz.Identity.DbContext;
using FamousQuoteQuiz.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FamousQuoteQuiz.Persistence.Repositories;

public class UserRepository : IUserRepository
{
    private readonly FamousQuoteQuizIdentityDbContext _context;

    public UserRepository(FamousQuoteQuizIdentityDbContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<User>> GetAllUsersAsync()
    {
        return (IReadOnlyList<User>)await _context.Users.ToListAsync();
    }

    public async Task<User?> GetByIdAsync(string id)
    {
        //return await _context.Users.FirstOrDefaultAsync(q => q.Id == id);
        throw new NotImplementedException();
    }

    public async Task CreateUserAsync(User user)
    {
        throw new NotImplementedException();
        //await _context.Users.AddAsync(user);
        //await _context.SaveChangesAsync();
    }

    public async Task UpdateUserAsync(User user)
    {
        throw new NotImplementedException();
        //_context.Users.Update(user);
        //await _context.SaveChangesAsync();
    }

    public async Task DisableUserAsync(User user)
    {
        user.IsActive = false;
        await _context.SaveChangesAsync();
    }

    public async Task DeleteUserAsync(User user)
    {
        user.IsDeleted = true;
        await _context.SaveChangesAsync();
    }

    public Task<IReadOnlyList<User>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<User> GetByIdAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task CreateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(User entity)
    {
        throw new NotImplementedException();
    }

    public Task SaveChangesAsync()
    {
        throw new NotImplementedException();
    }
}
