namespace FamousQuoteQuiz.Application.Features.UserGameAchievement.Queries.GetUserGameAchievements;

public class UserGameAchievementDto
{
    public int Id { get; set; }
    public string SelectedAnswer { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public string GameMode { get; set; } = string.Empty;
    public DateTime PlayedAt { get; set; } = DateTime.UtcNow;
    public required string UserId { get; set; }
    public int QuoteId { get; set; }
}
