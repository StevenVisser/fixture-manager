using AutoMapper;
using FixtureManager.Domain.Interfaces.Daos;
using FixtureManager.Domain.Models;
using FixtureManager.Domain.Models.Requests;
using FixtureManager.Persistence.Tables;
using Microsoft.EntityFrameworkCore;

namespace FixtureManager.Persistence.Daos;

public class TeamDao : ITeamDao
{
    private readonly Mapper _mapper;
    private readonly IDbContextFactory<FixtureManagerDbContext> _contextFactory;

    public TeamDao(IDbContextFactory<FixtureManagerDbContext> contextFactory)
    {
        var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
        _mapper = new Mapper(mappingConfig);
        _contextFactory = contextFactory;
    }

    public async Task<long> CreateTeamAsync(Team team)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        var dbTeam = _mapper.Map<DbTeam>(team);
        dbContext.Teams.Add(dbTeam);
        await dbContext.SaveChangesAsync();
        return dbTeam.Id;
    }

    public async Task DeleteTeamByIdAsync(long id)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        var dbTeam = dbContext
            .Teams
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (dbTeam == null) return;

        dbContext.Teams.Remove(dbTeam);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteTeamByNameAsync(string name)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        var dbTeam = dbContext
            .Teams
            .AsNoTracking()
            .FirstOrDefault(x => x.TeamName.ToLower() == name.ToLower());

        if (dbTeam == null) return;

        dbContext.Teams.Remove(dbTeam);
        await dbContext.SaveChangesAsync();
    }

    public async Task<List<Team>> GetTeamByFilterAsync(SearchTeamRequest request)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        var query = dbContext.Teams.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.TeamName))
            query = query.Where(x =>
                x.TeamName.ToLower().Contains(request.TeamName.ToLower()));

        if (!string.IsNullOrWhiteSpace(request.AgeGroup))
            query = query.Where(x => x.AgeGroup == request.AgeGroup);

        if (request.CoachId != null)
            query = query.Where(x => x.CoachId == request.CoachId);

        if (request.SchoolId != null)
            query = query.Where(x => x.SchoolId == request.SchoolId);

        if (request.SportId != null)
            query = query.Where(x => x.SportId == request.SportId);

        var dbTeams = await query
            .Skip(request.Skip)
            .Take(request.Take)
            .ToListAsync();

        return _mapper.Map<List<Team>>(dbTeams);
    }

    public async Task<Team> GetTeamByIdAsync(long id)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        var dbTeam = await dbContext
            .Teams
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return _mapper.Map<Team>(dbTeam);
    }

    public Task<Team> UpdateTeamAsync(UpdateTeamRequest request)
    {
        throw new NotImplementedException();
    }
}
