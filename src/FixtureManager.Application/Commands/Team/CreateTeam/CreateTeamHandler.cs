using FixtureManager.Domain.Interfaces.Daos;
using MediatR;

namespace FixtureManager.Application.Commands.CreateTeam;

internal class CreateTeamHandler(ITeamDao teamDao) : IRequestHandler<CreateTeamCommand, long>
{
    private readonly ITeamDao _teamDao = teamDao;

    public async Task<long> Handle(CreateTeamCommand request, CancellationToken cancellationToken)
    {
        // TODO: Check that the coach exists - Inside of validator
        return await _teamDao.CreateTeamAsync(request);
    }
}
