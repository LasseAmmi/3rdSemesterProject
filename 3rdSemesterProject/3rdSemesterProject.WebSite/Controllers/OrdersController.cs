using _3rdSemesterProject.WebSite.Models.DTO;
using _3rdSemesterProject.WebSite.Models.DTO.CombinedDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSharp;

namespace _3rdSemesterProject.WebSite.Controllers;

public class OrdersController : Controller
{
    private readonly APIStub.IRestClient _restClient;

    public OrdersController(APIStub.IRestClient restClient)
    {
        _restClient = restClient;
    }
    // GET: OrdersController
    public ActionResult Index()
    {
        return View();
    }

    // GET: OrdersController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: OrdersController/Create
    public ActionResult Create()
    {

        var model = new OrderDepartureDTOCombined();
        model.AvailableSeats = _restClient.getFirstDeparture().AvailableSeats;
        return View();
    }

    // POST: OrdersController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(OrderDTO newOrder)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                //TempData["Message"] = $"Error creating your order. Try again later...";
                return View();
            }

            int newOrderID = _restClient.CreateOrder(newOrder);
            //TempData["Message"] = $"Your order for the blog {author.BlogTitle} was created - welcome!";
            return Redirect("/home/index");
        }
        catch
        {
            return View();
        }
    }

    // GET: OrdersController/Edit/5
    public ActionResult Edit(int id)
    {
        return View();
    }

    // POST: OrdersController/Edit/5
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

    // GET: OrdersController/Delete/5
    public ActionResult Delete(int id)
    {
        return View();
    }

    // POST: OrdersController/Delete/5
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
