namespace FixtureManager.Domain.Models;

public class UserCredentials
{
    public string UserName { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
}
