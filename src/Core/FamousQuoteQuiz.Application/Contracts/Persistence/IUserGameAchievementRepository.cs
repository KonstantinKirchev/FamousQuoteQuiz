using FamousQuoteQuiz.Domain.Entities;

namespace FamousQuoteQuiz.Application.Contracts.Persistence;

public interface IUserGameAchievementRepository : IGenericRepository<UserGameAchievement>
{
    Task<IReadOnlyList<UserGameAchievement>> GetAllAchievementsAsync();
    Task CreateAchievementAsync(UserGameAchievement userGameAchievement);
}
