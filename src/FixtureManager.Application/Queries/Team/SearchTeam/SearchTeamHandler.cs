using AutoMapper;
using FixtureManager.Application.Services;
using FixtureManager.Domain;
using FixtureManager.Domain.Interfaces.Daos;
using MediatR;

namespace FixtureManager.Application.Queries.SearchTeam;

internal class SearchTeamHandler : IRequestHandler<SearchTeamQuery, SearchTeamVm>
{
    private readonly Mapper _mapper;
    private readonly TeamService _teamService;
    private readonly ITeamDao _teamDao;

    public SearchTeamHandler(ITeamDao teamDao,
        TeamService teamService)
    {
        _teamDao = teamDao;
        _teamService = teamService;
    }

    public async Task<SearchTeamVm> Handle(SearchTeamQuery request, CancellationToken cancellationToken)
    {
        var teams = await _teamDao.GetTeamByFilterAsync(request);

        var teamTasks = teams.Select(_teamService.BuildTeamInfoAsync);
        var teamsVm = await Task.WhenAll(teamTasks);

        return new SearchTeamVm
        {
            Count = teams.Count,
            Teams = [.. teamsVm]
        };
    }
}
