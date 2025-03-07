using FixtureManager.Domain.Models;
using FixtureManager.Domain.Models.Dtos;

namespace FixtureManager.Application.Queries;

public class GetTeamVm
{
    public string TeamName { get; set; } = string.Empty;
    public long SportId { get; set; }
    public string AgeGroup { get; set; } = string.Empty;
    public School School { get; set; } = new();
    public UserDto Coach { get; set; } = new();
}
