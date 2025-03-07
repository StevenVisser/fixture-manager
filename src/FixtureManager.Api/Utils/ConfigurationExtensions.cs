namespace FixtureManager.Api.Utils;

public static class ConfigurationExtensions
{
    public static T BindOptions<T>(this IConfiguration config) where T : new()
    {
        var configInstance = new T();
        config.GetSection(typeof(T).Name).Bind(configInstance);
        return configInstance;
    }
}
