using FixtureManager.Application.Commands.CreateUser;
using FixtureManager.Application.Commands.DeleteSchool;
using FixtureManager.Application.Queries.GetUser;
using FixtureManager.Application.Queries.SearchUser;
using FixtureManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FixtureManager.Controllers;

[ApiController]
[Route("user")]
public class UserController(ILogger<AdminController> logger, IMediator mediator) : ControllerBase
{
    private readonly ILogger<AdminController> _logger = logger;
    private readonly IMediator _mediator = mediator;

    [HttpPost()]
    public async Task<long> CreateNewUser([FromBody] CreateUserCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<UserDetail> GetUserById([FromRoute] long id)
    {
        return await _mediator.Send(new GetUserByIdQuery { Id = id });
    }

    [HttpPost("search")]
    public async Task<SearchUserVm> SearchForUser([FromBody] SearchUserQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpDelete("{id}")]
    public async Task DeleteUserById([FromRoute] long id)
    {
        await _mediator.Send(new DeleteUserByIdCommand
        {
            Id = id
        });
    }
}
