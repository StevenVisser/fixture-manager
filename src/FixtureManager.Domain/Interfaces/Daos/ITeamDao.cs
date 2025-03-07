using FixtureManager.Domain.Models;
using FixtureManager.Domain.Models.Requests;

namespace FixtureManager.Domain.Interfaces.Daos;

public interface ITeamDao
{
    Task<long> CreateTeamAsync(Team team);
    Task<Team> GetTeamByIdAsync(long id);
    Task<List<Team>> GetTeamByFilterAsync(SearchTeamRequest request);
    Task DeleteTeamByIdAsync(long id);
    Task DeleteTeamByNameAsync(string name);
    Task<Team> UpdateTeamAsync(UpdateTeamRequest request);
}
