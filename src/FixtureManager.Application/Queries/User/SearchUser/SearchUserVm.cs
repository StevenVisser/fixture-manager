using FixtureManager.Domain.Models;

namespace FixtureManager.Application.Queries.SearchUser;

public class SearchUserVm
{
    public int Count { get; set; }
    public List<UserDetail> Students { get; set; } = [];
    public List<UserDetail> Coaches { get; set; } = [];
    public List<UserDetail> Spectators { get; set; } = [];
}
