using FixtureManager.Domain.Models.Enums;
using System.Text.Json.Serialization;

namespace FixtureManager.Domain.Models;

public class UserDetail() // make a spectator table - spec details // notif table - fixture id & spec id -- add if there is enough time
{
    [JsonIgnore]
    public long Id { get; set; }
    public UserType Type { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public UserCredentials Credentials { get; set; } = new();
    public ContactInformation ContactInformation { get; set; } = new();
    public long SchoolId { get; set; }
}
