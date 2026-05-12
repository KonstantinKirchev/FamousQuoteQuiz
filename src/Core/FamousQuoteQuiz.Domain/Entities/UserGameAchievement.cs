using FamousQuoteQuiz.Domain.Common;

namespace FamousQuoteQuiz.Domain.Entities;

public class UserGameAchievement : BaseEntity
{
    public int Id { get; set; }
    public string SelectedAnswer { get; set; } = string.Empty;
    public bool IsCorrect { get; set; }
    public string GameMode { get; set; } = string.Empty;
    public DateTime PlayedAt { get; set; } = DateTime.UtcNow;
    public required string UserId { get; set; }
    public User User { get; set; } = null!;
    public int QuoteId { get; set; }
    public Quote Quote { get; set; } = null!;
}
