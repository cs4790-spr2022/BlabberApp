using BlabberApp.Domain.Common.Interfaces;
using BlabberApp.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BlabsController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBlabRepository _repo;

        public BlabsController(ILogger<WeatherForecastController> logger, IBlabRepository repo)
        {
            _logger = logger;
            _repo = repo;
        }

        [HttpGet(Name = "Blabs")]
        public IEnumerable<Blab> Get()
        {
            throw new NotImplementedException();
            // _repo.GetAll();
            // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            // {
            //     Date = DateTime.Now.AddDays(index),
            //     TemperatureC = Random.Shared.Next(-20, 55),
            //     Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            // })
            // .ToArray();
        }
    }
}