using FixtureManager.Domain.Models.Requests;
using MediatR;

namespace FixtureManager.Application.Queries.SearchUser;

public class SearchUserQuery : SearchUserRequest, IRequest<SearchUserVm> { }