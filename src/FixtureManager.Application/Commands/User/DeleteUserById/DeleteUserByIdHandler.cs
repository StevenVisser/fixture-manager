using FixtureManager.Domain.Interfaces.Daos;
using MediatR;

namespace FixtureManager.Application.Commands.DeleteSchool;

internal class DeleteUserByIdHandler(IUserDao userDao) : IRequestHandler<DeleteUserByIdCommand> // TODO: Add Validators for commands
{
    private readonly IUserDao _userDao = userDao;

    public async Task Handle(DeleteUserByIdCommand request, CancellationToken cancellationToken)
    {
        await _userDao.DeleteUserByIdAsync(request.Id);
    }
}
