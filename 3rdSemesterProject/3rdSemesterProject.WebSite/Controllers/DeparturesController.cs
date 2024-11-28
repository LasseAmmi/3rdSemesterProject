using _3rdSemesterProject.WebSite.APIStub;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace _3rdSemesterProject.WebSite.Controllers;

public class DeparturesController : Controller
{
    private readonly APIStub.IRestClient _restClient;

    public DeparturesController(APIStub.IRestClient restClient)
    {
        _restClient = restClient;
    }

    // GET: DeparturesController
    public ActionResult DeparturesOnRoute(int id)
    {
        var departures = _restClient.GetDeparturesByRouteId(id);
        return View(departures);
    }

    // GET: DeparturesController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: DeparturesController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: DeparturesController/Create
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

    // GET: DeparturesController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: DeparturesController/Edit/5
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

    // GET: DeparturesController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: DeparturesController/Delete/5
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
