using Microsoft.AspNetCore.Mvc;
using Toolbox.Models;

namespace Toolbox.Controllers;

[ApiController]
[Route("")]
public class MainController : Controller
{
    [HttpGet("[action]")]
    public IActionResult Hello()
    {
        return Ok("Hello World!");
    }
}
