using Microsoft.AspNetCore.Mvc;

namespace FixtureManager.Controllers;

[ApiController]
[Route("[controller]")]
public class FixtureController(ILogger<FixtureController> logger) : ControllerBase
{ 
    private readonly ILogger<FixtureController> _logger = logger;

    [HttpGet("HelloWorld")]
    public string HelloWorld()
    {
        return "Hello World!";
    }
}
