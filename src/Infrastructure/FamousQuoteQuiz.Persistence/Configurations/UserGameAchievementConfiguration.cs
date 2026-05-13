using FamousQuoteQuiz.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamousQuoteQuiz.Persistence.Configurations;

public class UserGameAchievementConfiguration : IEntityTypeConfiguration<UserGameAchievement>
{
    public void Configure(EntityTypeBuilder<UserGameAchievement> builder)
    {
        builder.HasOne(a => a.User)
            .WithMany(u => u.Achievements)
            .HasForeignKey(a => a.UserId);
        builder.HasOne(a => a.Quote)
            .WithMany()
            .HasForeignKey(a => a.QuoteId);
    }
}
