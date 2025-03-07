using FixtureManager.Application.Commands.CreateSchool;
using FixtureManager.Application.Commands.DeleteSchool;
using FixtureManager.Application.Queries.GetSchool;
using FixtureManager.Domain.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FixtureManager.Controllers;

[ApiController]
[Route("admin")]
public class AdminController(ILogger<AdminController> logger, IMediator mediator) : ControllerBase
{
    private readonly ILogger<AdminController> _logger = logger;
    private readonly IMediator _mediator = mediator;

    // TODO: Add ActionResults to Controller Endpoints
    // TODO: Only use mediator for complex handlers. CRUD operations can come directly in the controller.

    [HttpPost("school")]
    public async Task<long> CreateNewSchool([FromBody] CreateSchoolCommand command)
    {
        return await _mediator.Send(command);
    }

    [HttpGet("school")]
    public async Task<School> GetSchool([FromQuery] string? name = null, [FromQuery] long? id = null)
    {
        return await _mediator.Send(new GetSchoolQuery
        {
            Name = name,
            Id = id
        });
    }

    [HttpDelete("school")]
    public async Task DeleteSchool([FromQuery] string? name = null, [FromQuery] long? id = null)
    {
        await _mediator.Send(new DeleteSchoolCommand
        {
            Name = name,
            Id = id
        });
    }
}
