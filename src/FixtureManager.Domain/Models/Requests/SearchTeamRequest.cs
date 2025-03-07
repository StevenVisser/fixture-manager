namespace FixtureManager.Domain.Models.Requests;

public class SearchTeamRequest
{
    public int Skip { get; set; } = 0;
    public int Take { get; set; } = 1000;
    public long? CoachId { get; set; }
    public long? SportId { get; set; }
    public long? SchoolId { get; set; }
    public string? TeamName { get; set; }
    public string? AgeGroup { get; set; }
}
