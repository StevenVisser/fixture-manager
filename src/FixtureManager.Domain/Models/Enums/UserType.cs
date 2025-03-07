using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace FixtureManager.Domain.Models.Enums;

[JsonConverter(typeof(StringEnumConverter))]
public enum UserType
{
    Coach,
    Student,
    Spectator
}
