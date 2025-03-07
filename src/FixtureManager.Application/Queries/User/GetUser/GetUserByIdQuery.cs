using FixtureManager.Domain.Models;
using MediatR;

namespace FixtureManager.Application.Queries.GetUser;

public class GetUserByIdQuery : IRequest<UserDetail>
{
    public long Id { get; set; }
}