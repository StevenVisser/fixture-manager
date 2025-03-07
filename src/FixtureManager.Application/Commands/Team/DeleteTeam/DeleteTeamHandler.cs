using FixtureManager.Domain.Interfaces.Daos;
using MediatR;

namespace FixtureManager.Application.Commands.DeleteTeam;

internal class DeleteTeamHandler(ITeamDao teamDao) : IRequestHandler<DeleteTeamCommand> // TODO: Add Validators for commands
{
    private readonly ITeamDao _teamDao = teamDao;

    public async Task Handle(DeleteTeamCommand request, CancellationToken cancellationToken)
    {
        if (!string.IsNullOrEmpty(request.Name))
            await _teamDao.DeleteTeamByNameAsync(request.Name);
        else
            await _teamDao.DeleteTeamByIdAsync((long)request.Id!);
    }
}
