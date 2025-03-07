using MediatR;

namespace FixtureManager.Application.Commands.DeleteTeam;

public class DeleteTeamCommand : IRequest
{
    public string? Name { get; set; }
    public long? Id { get; set; }
}