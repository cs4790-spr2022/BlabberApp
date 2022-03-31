using Domain.Common.Interfaces;
using Domain.Entities;

using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

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
    public IEnumerable<Blab> Get()
    {
        _logger.LogInformation("Retrieving all the blabs");
        return _repo.GetAll();
    }
}