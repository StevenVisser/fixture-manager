namespace FixtureManager.Application.Queries.SearchTeam;

public class SearchTeamVm
{
    public int Count { get; set; }
    public List<GetTeamVm> Teams { get; set; } = [];
}
