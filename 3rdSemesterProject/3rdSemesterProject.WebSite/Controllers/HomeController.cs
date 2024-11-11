using _3rdSemesterProject.WebSite.Models;
using _3rdSemesterProject.WebSite.STUBApi;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace _3rdSemesterProject.WebSite.Controllers;

public class HomeController : Controller
{

    private readonly ILogger<HomeController> _logger;
    private readonly STUBApi.IRestClient _restClient;


    public HomeController(ILogger<HomeController> logger, STUBApi.IRestClient restClient)
    {
        _logger = logger;
        _restClient = restClient;
    }

    public IActionResult Index()
    {
        return View(_restClient.GetThreeDepartures());
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
