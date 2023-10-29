using Microsoft.AspNetCore.Mvc;
using Toolbox.Models;

namespace Toolbox.Controllers;

[ApiController]
[Route("")]
public class MainController : Controller
{
    [HttpGet("hello")]
    public ActionResult<string> Hello()
    {
        return Ok("Hello World!");
    }

    [HttpGet("echo")]
    public ActionResult<string> Echo([FromQuery] string message)
    {
        return message;
    }

    [HttpGet("weather")]
    public IEnumerable<WeatherForecast> Weather()
    {
        var summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast(
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ));
    }
}
