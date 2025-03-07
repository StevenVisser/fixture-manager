using AutoMapper;
using FixtureManager.Application.Queries;
using FixtureManager.Domain;
using FixtureManager.Domain.Interfaces.Daos;
using FixtureManager.Domain.Models;
using FixtureManager.Domain.Models.Dtos;

namespace FixtureManager.Application.Services;

public class TeamService
{
    private readonly Mapper _mapper;
    private readonly ISchoolDao _schoolDao;
    private readonly ITeamDao _teamDao;
    private readonly IUserDao _userDao;

    public TeamService(ITeamDao teamDao,
        ISchoolDao schoolDao,
        IUserDao userDao)
    {
        _schoolDao = schoolDao;
        _teamDao = teamDao;
        _userDao = userDao;

        var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile(new DtoMappingProfile()));
        _mapper = new Mapper(mappingConfig);
    }

    public async Task<GetTeamVm> BuildTeamInfoAsync(Team team)
    {
        var coach = await _userDao.GetUserByIdAsync(team.CoachId);
        var school = await _schoolDao.GetSchoolByIdAsync(team.SchoolId);

        return new GetTeamVm
        {
            TeamName = team.TeamName,
            AgeGroup = team.AgeGroup,
            SportId = team.SportId,
            Coach = _mapper.Map<UserDto>(coach),
            School = school
        };
    }
}
