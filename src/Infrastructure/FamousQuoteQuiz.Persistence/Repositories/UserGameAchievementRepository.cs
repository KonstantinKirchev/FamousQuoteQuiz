using FamousQuoteQuiz.Application.Contracts.Persistence;
using FamousQuoteQuiz.Domain.Entities;
using FamousQuoteQuiz.Persistence.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace FamousQuoteQuiz.Persistence.Repositories;

public class UserGameAchievementRepository : GenericRepository<UserGameAchievement>, IUserGameAchievementRepository
{
    public UserGameAchievementRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async Task CreateAchievementAsync(UserGameAchievement userGameAchievement)
    {
        await _context.AddAsync(userGameAchievement);
        await _context.SaveChangesAsync();
    }

    public async Task<IReadOnlyList<UserGameAchievement>> GetAllAchievementsAsync()
    {
        var achievements = await _context.UserGameAchievements.ToListAsync();
        return achievements;
    }
}
