using AutoMapper;
using FixtureManager.Domain.Interfaces.Daos;
using FixtureManager.Domain.Models;
using FixtureManager.Domain.Models.Requests;
using FixtureManager.Persistence.Tables;
using Microsoft.EntityFrameworkCore;

namespace FixtureManager.Persistence.Daos;

public class SchoolDao : ISchoolDao
{
    private readonly Mapper _mapper;
    private readonly IDbContextFactory<FixtureManagerDbContext> _contextFactory;

    public SchoolDao(IDbContextFactory<FixtureManagerDbContext> contextFactory)
    {
        var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
        _mapper = new Mapper(mappingConfig);
        _contextFactory = contextFactory;
    }

    public async Task<long> CreateSchool(School school)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        var dbSchool = _mapper.Map<DbSchool>(school);
        dbContext.Schools.Add(dbSchool);
        await dbContext.SaveChangesAsync();
        return dbSchool.Id;
    }

    public async Task DeleteSchoolByIdAsync(long id)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        var dbSchool = dbContext
            .Schools
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (dbSchool == null) return;

        dbContext.Schools.Remove(dbSchool);
        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteSchoolByNameAsync(string name)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        var dbSchool = dbContext
            .Schools
            .AsNoTracking()
            .FirstOrDefault(x => x.Name.ToLower() == name.ToLower());

        if (dbSchool == null) return;

        dbContext.Schools.Remove(dbSchool);
        await dbContext.SaveChangesAsync();
    }

    public async Task<School> GetSchoolByIdAsync(long id)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        var dbSchool = await dbContext
            .Schools
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return _mapper.Map<School>(dbSchool);
    }

    public async Task<School> GetSchoolByNameAsync(string name)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        var dbSchool = await dbContext
            .Schools
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Name.ToLower() == name.ToLower());

        return _mapper.Map<School>(dbSchool);
    }

    public Task<School> UpdateSchoolAsync(UpdateSchoolRequest request)
    {
        throw new NotImplementedException();
    }
}
