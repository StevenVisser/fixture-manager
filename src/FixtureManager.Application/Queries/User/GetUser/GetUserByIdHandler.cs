using FixtureManager.Domain.Interfaces.Daos;
using FixtureManager.Domain.Models;
using MediatR;

namespace FixtureManager.Application.Queries.GetUser;

internal class GetUserByIdHandler(IUserDao UserDao) : IRequestHandler<GetUserByIdQuery, UserDetail>
{
    private readonly IUserDao _UserDao = UserDao;

    public async Task<UserDetail> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        return await _UserDao.GetUserByIdAsync(request.Id); // TODO: when using action result, if not found return a notfound
    }
}
