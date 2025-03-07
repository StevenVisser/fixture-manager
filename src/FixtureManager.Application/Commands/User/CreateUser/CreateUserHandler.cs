using FixtureManager.Domain.Interfaces.Daos;
using MediatR;

namespace FixtureManager.Application.Commands.CreateUser;

internal class CreateUserHandler(IUserDao userDao) : IRequestHandler<CreateUserCommand, long>
{
    private readonly IUserDao _userDao = userDao;

    public async Task<long> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        return await _userDao.CreateUserAsync(request);
    }
}
