using MediatR;

namespace FixtureManager.Application.Queries.GetTeam;

public class GetTeamByIdQuery : IRequest<GetTeamVm>
{
    public long Id { get; set; }
}