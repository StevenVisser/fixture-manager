using FixtureManager.Domain.Models.Requests;
using MediatR;

namespace FixtureManager.Application.Queries.SearchTeam;

public class SearchTeamQuery : SearchTeamRequest, IRequest<SearchTeamVm> { }