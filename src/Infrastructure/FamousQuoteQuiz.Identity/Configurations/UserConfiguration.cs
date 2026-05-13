using FamousQuoteQuiz.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FamousQuoteQuiz.Identity.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<ApplicationUser>
{
    public void Configure(EntityTypeBuilder<ApplicationUser> builder)
    {
        var hasher = new PasswordHasher<ApplicationUser>();
        builder.HasData(
             new ApplicationUser
             {
                 Id = "8e445865-a24d-4543-a6c6-9443d048cdb9",
                 Email = "admin@localhost.com",
                 NormalizedEmail = "ADMIN@LOCALHOST.COM",
                 UserName = "admin@localhost.com",
                 IsActive = true,
                 NormalizedUserName = "ADMIN@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             },
             new ApplicationUser
             {
                 Id = "9e224968-33e4-4652-b7b7-8574d048cdb9",
                 Email = "user@localhost.com",
                 NormalizedEmail = "USER@LOCALHOST.COM",
                 UserName = "user@localhost.com",
                 IsActive = true,
                 NormalizedUserName = "USER@LOCALHOST.COM",
                 PasswordHash = hasher.HashPassword(null, "P@ssword1"),
                 EmailConfirmed = true
             }
        );
    }
}
