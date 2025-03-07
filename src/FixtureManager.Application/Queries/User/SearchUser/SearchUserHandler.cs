using FixtureManager.Domain.Interfaces.Daos;
using FixtureManager.Domain.Models.Enums;
using MediatR;

namespace FixtureManager.Application.Queries.SearchUser;

internal class SearchUserHandler(IUserDao UserDao) : IRequestHandler<SearchUserQuery, SearchUserVm>
{
    private readonly IUserDao _UserDao = UserDao;

    public async Task<SearchUserVm> Handle(SearchUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _UserDao.GetUsersByFilter(request);

        return new SearchUserVm
        {
            Count = users.Count,
            Students = users.Where(x => x.Type == UserType.Student).ToList(),
            Coaches = users.Where(x => x.Type == UserType.Student).ToList(),
            Spectators = users.Where(x => x.Type == UserType.Spectator).ToList()
        };
    }
}
