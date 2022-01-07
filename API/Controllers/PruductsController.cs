using Infrastructure.Data;
using Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private static readonly string[] Summaries = new[]
    {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;
    private readonly StoreContext _context;

    public ProductsController(ILogger<WeatherForecastController> logger, StoreContext context)
    {
        _logger = logger;
        _context = context;
    }

    [HttpGet(Name = "GetProducts")]
    public ActionResult<List<Product>> Get()
    {
        return Ok(_context.Products.ToArray());
        // return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        // {
        //     Date = DateTime.Now.AddDays(index),
        //     TemperatureC = Random.Shared.Next(-20, 55),
        //     Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        // })
        // .ToArray();
    }
}
