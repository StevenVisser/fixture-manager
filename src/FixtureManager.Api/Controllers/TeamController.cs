using FixtureManager.Application.Commands.CreateTeam;
using FixtureManager.Application.Commands.DeleteSchool;
using FixtureManager.Application.Queries;
using FixtureManager.Application.Queries.GetTeam;
using FixtureManager.Application.Queries.SearchTeam;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FixtureManager.Controllers;

[ApiController]
[Route("team")]
public class TeamController(ILogger<TeamController> logger, IMediator mediator) : ControllerBase
{
    private readonly ILogger<TeamController> _logger = logger;
    private readonly IMediator _mediator = mediator;

    [HttpPost()]
    public async Task<long> CreateNewTeam([FromBody] CreateTeamCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("{id}")]
    public async Task<GetTeamVm> GetTeamById([FromRoute] long id)
    {
        return await _mediator.Send(new GetTeamByIdQuery { Id = id });
    }

    [HttpPost("search")]
    public async Task<SearchTeamVm> SearchForTeam([FromBody] SearchTeamQuery query)
    {
        return await _mediator.Send(query);
    }

    [HttpDelete()]
    public async Task DeleteTeam([FromQuery] string? name, [FromQuery] long? id)
    {
        await _mediator.Send(new DeleteSchoolCommand
        {
            Name = name,
            Id = id
        });
    }
}
