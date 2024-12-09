using _3rdSemesterProject.WebSite.APIStub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3rdSemesterProject.WebSite.Controllers;

public class RoutesController : Controller
{
    private readonly APIStub.IRestClient _restClient;


    public RoutesController(APIStub.IRestClient restClient)
    {
        _restClient = new RestAPIClientStub();
    }

    // GET: RoutesController
    public ActionResult Index()
    {
        try
        {
            return View(_restClient.GetThreeRoutes());
        }
        catch (Exception ex)
        {
            throw new Exception($"Routes could not be recieved. {ex.Message}", ex);
        }
    }

    // GET: RoutesController/Details/5
    public ActionResult Details(int routeId)
    {
        try
        {
            var route = _restClient.GetRouteById(routeId);
            if (route != null)
            {
                return View(route);
            }
            return NotFound();
        }
        catch (Exception ex)
        {
            throw new Exception($"Details view did not work properly. {ex.Message}", ex);
        }
    }

    // GET: RoutesController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: RoutesController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: RoutesController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: RoutesController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }

    // GET: RoutesController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: RoutesController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
