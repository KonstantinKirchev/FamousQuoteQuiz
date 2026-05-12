namespace FamousQuoteQuiz.Domain.Entities;

public class User
{
    public required string Id { get; set; }
    public required string Email { get; set; }
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public required string Username { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public ICollection<UserGameAchievement> Achievements { get; set; } = new List<UserGameAchievement>();
}
