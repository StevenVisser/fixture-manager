using FixtureManager.Domain.Models;
using MediatR;

namespace FixtureManager.Application.Queries.GetSchool;

public class GetSchoolQuery : IRequest<School>
{
    public string? Name { get; set; }
    public long? Id { get; set; }
}