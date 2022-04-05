using Domain.Common.Interfaces;
using Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

public class BlabDto
{
    public string? Username { get; set; }
    public string? Content { get; set; }
}

[ApiController]
[Route("[controller]")]
public class BlabsController : ControllerBase
{
    private readonly ILogger<BlabsController> _logger;
    private readonly IBlabRepository _repo;

    public BlabsController(ILogger<BlabsController> logger, IBlabRepository repo)
    {
        _logger = logger;
        _repo = repo;
    }

    [HttpGet(Name = "Blabs")]
    public IEnumerable<Blab> GetAll()
    {
        _logger.LogInformation("Retrieving all the blabs");
        return _repo.GetAll();
    }

    [HttpGet]
    [Route("{id:guid}")]
    public IActionResult GetById([FromRoute] Guid id)
    {
        _logger.LogInformation("Retrieving blab " + id.ToString());
        var b = _repo.GetById(id);
        if (b.Username is "")
            return NotFound();
        return Ok(b);
    }

    [HttpPost]
    public IActionResult Post([FromBody] BlabDto? bDto)
    {
        try
        {
            if (bDto is null)
            {
                _logger.LogError("Blab object is null");
                return BadRequest("Blab object is null");
            }

            Blab b = new(bDto.Content, bDto.Username);

            _repo.Add(b);

            return CreatedAtRoute("Blabs", new {id = b.Id}, b);
        }
        catch (Exception ex)
        {
            _logger.LogError($"{ex.Message}");
            return StatusCode(500, "Internal server error");
        }
    }
}