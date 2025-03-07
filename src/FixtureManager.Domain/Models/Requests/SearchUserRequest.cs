namespace FixtureManager.Domain.Models.Requests;

public class SearchUserRequest
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 1000;
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public long? SchoolId { get; set; }
}
