using AutoMapper;
using FixtureManager.Domain.Interfaces.Daos;
using FixtureManager.Domain.Models;
using FixtureManager.Domain.Models.Requests;
using FixtureManager.Persistence.Tables;
using Microsoft.EntityFrameworkCore;

namespace FixtureManager.Persistence.Daos;

public class UserDao : IUserDao
{
    private readonly Mapper _mapper;
    private readonly IDbContextFactory<FixtureManagerDbContext> _contextFactory;

    public UserDao(IDbContextFactory<FixtureManagerDbContext> contextFactory)
    {
        var mappingConfig = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
        _mapper = new Mapper(mappingConfig);
        _contextFactory = contextFactory;
    }

    public async Task<long> CreateUserAsync(UserDetail userDetail)
    {
        using var dbContext = _contextFactory.CreateDbContext();
        var dbUserDetail = _mapper.Map<DbUserDetails>(userDetail);
        dbContext.UserDetails.Add(dbUserDetail);
        await dbContext.SaveChangesAsync();
        return dbUserDetail.Id;
    }

    public async Task<UserDetail> GetUserByIdAsync(long id)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        var dbUser = await dbContext
            .UserDetails
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == id);

        return _mapper.Map<UserDetail>(dbUser);
    }

    public async Task<List<UserDetail>> GetUsersByFilter(SearchUserRequest request)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        var query = dbContext.UserDetails.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(request.FirstName))
            query = query.Where(x =>
                x.FirstName.ToLower().Contains(request.FirstName.ToLower()));

        if(!string.IsNullOrWhiteSpace(request.LastName))
            query = query.Where(x =>
                x.LastName.ToLower().Contains(request.LastName.ToLower()));

        if (request.SchoolId != null)
            query = query.Where(x => x.SchoolId == request.SchoolId);

        var dbUsers = await query
            .Skip(request.Skip)
            .Take(request.Take)
            .ToListAsync();

        return _mapper.Map<List<UserDetail>>(dbUsers);
    }

    public async Task DeleteUserByIdAsync(long id)
    {
        using var dbContext = _contextFactory.CreateDbContext();

        var dbUser = dbContext
            .UserDetails
            .AsNoTracking()
            .FirstOrDefault(x => x.Id == id);

        if (dbUser == null) return;

        dbContext.UserDetails.Remove(dbUser);
        await dbContext.SaveChangesAsync();
    }

    public Task<UserDetail> UpdateUserAsync(UpdateUserRequest request)
    {
        throw new NotImplementedException();
    }
}
