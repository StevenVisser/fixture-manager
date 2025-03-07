using System.Text.Json.Serialization;

namespace FixtureManager.Domain.Models;

public class Fixture
{
    [JsonIgnore]
    public long Id { get; set; }
    public DateTime DateTime { get; set; }
    public string Location { get; set; } = string.Empty;
}
