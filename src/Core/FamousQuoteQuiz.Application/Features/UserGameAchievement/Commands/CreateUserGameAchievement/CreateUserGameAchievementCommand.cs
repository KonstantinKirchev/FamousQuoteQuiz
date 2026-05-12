using MediatR;

namespace FamousQuoteQuiz.Application.Features.UserGameAchievement.Commands.CreateUserGameAchievement;

public class CreateUserGameAchievementCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
