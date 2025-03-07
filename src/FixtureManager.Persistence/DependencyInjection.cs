using FixtureManager.Domain.Interfaces;
using FixtureManager.Domain.Interfaces.Daos;
using FixtureManager.Persistence.Daos;
using FixtureManager.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FixtureManager.Persistence;

public static class DependencyInjection
{
    public static IServiceCollection AddPersistenceLayer(this IServiceCollection services, string connectionString)
    {
        services.AddDbContextFactory<FixtureManagerDbContext>(options =>
            options.UseNpgsql(connectionString, opt => opt.EnableRetryOnFailure(3)));

        services.AddSingleton<IFixtureRepository, FixtureRepository>();
        services.AddSingleton<ISchoolDao, SchoolDao>();
        services.AddSingleton<ITeamDao, TeamDao>();
        services.AddSingleton<IUserDao, UserDao>();

        return services;
    }
}
