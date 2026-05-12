using FamousQuoteQuiz.Domain.Entities;
using Microsoft.AspNetCore.Identity;

namespace FamousQuoteQuiz.Identity.Models;

public class ApplicationUser : IdentityUser
{
    public required string Firstname { get; set; }
    public required string Lastname { get; set; }
    public bool IsActive { get; set; } = true;
    public bool IsDeleted { get; set; } = false;
    public ICollection<UserGameAchievement> Achievements { get; set; } = new List<UserGameAchievement>();
}
