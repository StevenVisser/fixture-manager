using MediatR;

namespace FixtureManager.Application.Commands.DeleteSchool;

public class DeleteUserByIdCommand : IRequest
{
    public long Id { get; set; }
}