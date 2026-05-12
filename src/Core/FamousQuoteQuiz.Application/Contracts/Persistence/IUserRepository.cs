using FamousQuoteQuiz.Application.Contracts.Persistence;
using FamousQuoteQuiz.Domain.Entities;

namespace FamousQuoteQuiz.Domain.Interfaces;

public interface IUserRepository : IGenericRepository<User>
{
    Task<IReadOnlyList<User>> GetAllUsersAsync();
    Task<User?> GetByIdAsync(string id);
    Task CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DisableUserAsync(User user);
    Task DeleteUserAsync(User user);
}
