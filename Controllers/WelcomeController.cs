using Microsoft.AspNetCore.Mvc;

namespace Day02.Controllers;

public class WelcomeController : Controller
{
    [Route("Welcome")]
    [Route("Welcome/Index")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("Welcome/{name}")]
    public IActionResult Welcome(string name)
    {
        ViewData["name"] = name;
        return View();
    }
}
