using Microsoft.AspNetCore.Mvc;

namespace Day02.Controllers;

public class GoodbyeController : Controller
{
    [Route("Goodbye")]
    [Route("Goodbye/Index")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("Goodbye/{name}")]
    public IActionResult Goodbye(string name)
    {
        ViewData["name"] = name;
        return View();
    }
}
