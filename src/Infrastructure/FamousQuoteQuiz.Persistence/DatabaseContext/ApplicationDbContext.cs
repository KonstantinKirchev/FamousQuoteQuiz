using FamousQuoteQuiz.Domain.Entities;
using FamousQuoteQuiz.Identity.DbContext;
using Microsoft.EntityFrameworkCore;

namespace FamousQuoteQuiz.Persistence.DatabaseContext;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Quote> Quotes { get; set; }
    public DbSet<UserGameAchievement> Achievements { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
    }
}
