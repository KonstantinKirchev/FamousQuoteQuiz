using FamousQuoteQuiz.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
    }
}
