using FamousQuoteQuiz.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace FamousQuoteQuiz.Persistence.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Quote> Quotes { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<UserGameAchievement> Achievements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserGameAchievement>()
            .HasOne(a => a.User)
            .WithMany(u => u.Achievements)
            .HasForeignKey(a => a.UserId);

        modelBuilder.Entity<UserGameAchievement>()
            .HasOne(a => a.Quote)
            .WithMany()
            .HasForeignKey(a => a.QuoteId);

        base.OnModelCreating(modelBuilder);
    }
}
