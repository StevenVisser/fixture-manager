using System.Text.Json.Serialization;

namespace FixtureManager.Domain.Models;

public class School
{
    [JsonIgnore]
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Province { get; set; } = string.Empty;
}
