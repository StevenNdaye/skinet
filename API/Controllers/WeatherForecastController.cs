using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly StoreContext _context;

    public WeatherForecastController(ILogger<WeatherForecastController> logger, StoreContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<Product> Get()
    {
        return _context.Products.ToArray();
        // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        // {
        //     Date = DateTime.Now.AddDays(index),
        //     TemperatureC = Random.Shared.Next(-20, 55),
        //     Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        // })
        // .ToArray();
    }
}
