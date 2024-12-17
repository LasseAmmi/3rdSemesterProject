using _3rdSemesterProject.WebSite.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using _3rdSemesterProject.WebSite.APIClient;

namespace _3rdSemesterProject.WebSite.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;
    private readonly IRestClient _restClient;


    public HomeController(ILogger<HomeController> logger, IRestClient restClient)
    {
        _logger = logger;
        _restClient = restClient;
    }

    public IActionResult Index()
    {
        return View(_restClient.GetThreeRoutes());
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
