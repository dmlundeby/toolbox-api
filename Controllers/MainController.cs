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

    [HttpGet("wait")]
    public async Task<string> Wait([FromQuery] double seconds)
    {
        await Task.Delay((int)(seconds * 1000));
        return $"Waited for {seconds:0.##} seconds";
    }

    [HttpGet("block")]
    public string Block([FromQuery] double seconds)
    {
        Thread.Sleep((int)(seconds * 1000));
        return $"Blocked for {seconds:0.##} seconds";
    }

    [HttpGet("pi")]
    public double Pi([FromQuery] int iterations)
    {
        var x = 1.0;
        for (var i = 1; i < iterations + 1; i++)
        {
            var d = 2 * i + 1;
            if (i % 2 == 1)
                x -= 1.0 / d;
            else
                x += 1.0 / d;
        }
        return x * 4;
    }
}
