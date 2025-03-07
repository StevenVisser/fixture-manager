using FixtureManager.Domain.Models;
using MediatR;

namespace FixtureManager.Application.Commands.CreateTeam;

public class CreateTeamCommand : Team, IRequest<long> { }