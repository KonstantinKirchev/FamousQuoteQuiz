using FamousQuoteQuiz.Domain.Entities;

namespace FamousQuoteQuiz.Application.Contracts.Persistence;

public interface IUserGameAchievementRepository
{
    Task<IEnumerable<UserGameAchievement>> GetAllAsync();
}
