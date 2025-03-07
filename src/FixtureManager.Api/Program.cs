using FixtureManager.Application;
using FixtureManager.Persistence;
using FixtureManager.Persistence.Configuration;
using FixtureManager.Api.Utils;
using System.Text.Json.Serialization;
using FixtureManager.Application.Services;

namespace FixtureManager;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration
            .AddJsonFile("appsettings.json",
                optional: true,
                reloadOnChange: true)
            .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json",
                optional: true,
                reloadOnChange: true)
            .AddEnvironmentVariables();

        ConfigureServices(builder.Services, builder.Configuration);
        ConfigureApp(builder.Build())
            .Run();
    }

    private static void ConfigureServices(IServiceCollection services, IConfiguration config)
    {
        services.AddMvcCore()
            .AddApiExplorer()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
            });

        services.AddControllers();
        services.AddSwaggerGen();

        services.InjectMediatR();
        services.InjectAutoMapper();

        var dbConfig = config.BindOptions<DatabaseConfiguration>();
        services.AddPersistenceLayer(dbConfig.ConnectionString);

        services.AddSingleton<TeamService>();
    }

    private static WebApplication ConfigureApp(WebApplication app)
    {
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        return app;
    }

    
}
