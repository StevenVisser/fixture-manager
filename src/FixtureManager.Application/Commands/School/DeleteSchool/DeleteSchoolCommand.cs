using MediatR;

namespace FixtureManager.Application.Commands.DeleteSchool;

public class DeleteSchoolCommand : IRequest
{
    public string? Name { get; set; }
    public long? Id { get; set; }
}