using MediatR;

namespace FamousQuoteQuiz.Application.Features.UserGameAchievement.Queries.GetUserGameAchievements;

public class GetUserGameAchievementsQuery : IRequest<List<UserGameAchievementDto>>
{
    public bool IsLoggedInUser { get; set; }
}
