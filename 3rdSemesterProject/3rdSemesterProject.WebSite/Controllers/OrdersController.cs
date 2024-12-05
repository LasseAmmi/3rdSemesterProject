using _3rdSemesterProject.WebSite.Models.DTO;
using _3rdSemesterProject.WebSite.Models.DTO.CombinedDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
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

    // GET: OrdersController/Create/Id
    [HttpGet("Orders/Create/{departureId}")]
    public ActionResult Create(int departureId)
    {
        try
        {
            var model = new OrderDepartureDTOCombined();
            var departure = _restClient.GetDepartureById(departureId);
            model.AvailableSeats = departure.AvailableSeats;
            model.DepartureID = departure.PK_departureID;
            return View(model);
        }
        catch (Exception ex)
        {
            throw new Exception($"Order could not be created. {ex.Message}", ex);
        }
    }

    // POST: OrdersController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(OrderDepartureDTOCombined model)
    {
        try
        {
            var departure = _restClient.GetDepartureById(model.DepartureID);
            model.AvailableSeats = departure.AvailableSeats;
            if (model.AvailableSeats < model.SeatsReserved)
            {
                ModelState.AddModelError("SeatsReserved", "Error you can not exceed the number available on the departure"); // TODO: Perhaps change this
            }
            else if (model.SeatsReserved <= 1)
            {
                ModelState.AddModelError("SeatsReserved", "Error you must input a positiv number of seats to reserve");
            }
            else
            {
                _restClient.CreateOrder(ConvertToOrderDTO(model));
                TempData["SuccessMessage"] = "Order successfully created."; // Store the success message for pop-up
                return Redirect("/home/index");
            }

            if (!ModelState.IsValid)
            {
                model.AvailableSeats = _restClient.GetDepartureById(model.DepartureID).AvailableSeats;
                return View(model);
            }
            return View(model);
        }
        catch
        {
            return View();
        }
    }

    private OrderDTO ConvertToOrderDTO(OrderDepartureDTOCombined newCombinedOrder)
    {
        OrderDTO newOrder = new OrderDTO();
        newOrder.OrderID = newCombinedOrder.OrderID;
        newOrder.CustomerID = newCombinedOrder.CustomerID;
        newOrder.DepartureID = newCombinedOrder.DepartureID;
        newOrder.SeatsReserved = newCombinedOrder.SeatsReserved;
        newOrder.TotalPrice = newCombinedOrder.TotalPrice;
        return newOrder;
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
