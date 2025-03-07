using FixtureManager.Domain.Models;
using FixtureManager.Domain.Models.Requests;

namespace FixtureManager.Domain.Interfaces.Daos;

public interface IUserDao
{
    Task<long> CreateUserAsync(UserDetail userDetail);
    Task<UserDetail> GetUserByIdAsync(long id);
    Task<List<UserDetail>> GetUsersByFilter(SearchUserRequest request);
    Task DeleteUserByIdAsync(long id);
    Task<UserDetail> UpdateUserAsync(UpdateUserRequest request);
}
