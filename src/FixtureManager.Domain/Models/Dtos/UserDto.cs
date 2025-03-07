namespace FixtureManager.Domain.Models.Dtos;

public class UserDto
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public ContactInformation ContactInformation { get; set; } = new();
}
