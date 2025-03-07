using AutoMapper;
using FixtureManager.Application.Services;
using FixtureManager.Domain;
using FixtureManager.Domain.Interfaces.Daos;
using FixtureManager.Domain.Models.Dtos;
using MediatR;

namespace FixtureManager.Application.Queries.GetTeam;

internal class GetTeamByIdHandler : IRequestHandler<GetTeamByIdQuery, GetTeamVm>
{
    private readonly Mapper _mapper;
    private readonly TeamService _teamService;
    private readonly ITeamDao _teamDao;

    public GetTeamByIdHandler(ITeamDao teamDao,
        TeamService teamService)
    {
        _teamDao = teamDao;
        _teamService = teamService;

        var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile(new DtoMappingProfile()));
        _mapper = new Mapper(mappingConfig);
    }

    public async Task<GetTeamVm> Handle(GetTeamByIdQuery request, CancellationToken cancellationToken)
    {
        var team = await _teamDao.GetTeamByIdAsync(request.Id);

        return await _teamService.BuildTeamInfoAsync(team);
    }
}
