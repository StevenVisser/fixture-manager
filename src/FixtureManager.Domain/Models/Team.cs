using System.Text.Json.Serialization;

namespace FixtureManager.Domain.Models;

public class Team
{
    [JsonIgnore]
    public long Id { get; set; }
    public long CoachId { get; set; }
    public long SportId { get; set; } // TODO: Add Sports
    public long SchoolId { get; set; }
    public string TeamName { get; set; } = string.Empty;
    public string AgeGroup { get; set; } = string.Empty;
}
