using FamousQuoteQuiz.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace FamousQuoteQuiz.Identity.DbContext
{
    public class FamousQuoteQuizIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public FamousQuoteQuizIdentityDbContext(DbContextOptions<FamousQuoteQuizIdentityDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(FamousQuoteQuizIdentityDbContext).Assembly);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(warnings =>
                        warnings.Ignore(RelationalEventId.PendingModelChangesWarning));
        }
    }
}
