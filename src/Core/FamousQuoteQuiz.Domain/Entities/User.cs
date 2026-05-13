using Microsoft.AspNetCore.Identity;

namespace FamousQuoteQuiz.Domain.Entities;

public class User : IdentityUser
{
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public ICollection<UserGameAchievement> Achievements { get; set; } = new List<UserGameAchievement>();
}
