using FamousQuoteQuiz.Application.Contracts.Persistence;
using FamousQuoteQuiz.Domain.Interfaces;
using FamousQuoteQuiz.Persistence.DatabaseContext;
using FamousQuoteQuiz.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FamousQuoteQuiz.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options => {
            options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
        });

        services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
        services.AddScoped<IQuoteRepository, QuoteRepository>();
        services.AddScoped<IUserGameAchievementRepository, UserGameAchievementRepository>();
        services.AddScoped<IUserRepository, UserRepository>();

        return services;
    }
}
