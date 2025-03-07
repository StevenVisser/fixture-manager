using FixtureManager.Application.Commands.CreateUser;
using Microsoft.Extensions.DependencyInjection;

namespace FixtureManager.Application;

public static class DependencyInjection
{
    public static IServiceCollection InjectMediatR(this IServiceCollection services)
    {
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(CreateUserHandler).Assembly));
        return services;
    }

    public static IServiceCollection InjectAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper((typeof(CreateUserHandler).Assembly));
        return services;
    }
}
