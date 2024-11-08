using _3rdSemesterProject.WebSite.Models;
using _3rdSemesterProject.WebSite.STUBApi;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _3rdSemesterProject.WebSite.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    readonly Stub client;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        client = new Stub();
    }

    public IActionResult Index()
    {
        return View(client.GetDepartures());
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
