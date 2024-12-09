using _3rdSemesterProject.WebSite.Models.DTO;
using _3rdSemesterProject.WebSite.Models.DTO.CombinedDTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using RestSharp;
using _3rdSemesterProject.WebSite.APIClient;

namespace _3rdSemesterProject.WebSite.Controllers;

public class OrdersController : Controller
{
    private readonly APIClient.IRestClient _restClient;

    public OrdersController(APIClient.IRestClient restClient)
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
    // Here the View for creating an Order is created with a combined object of Departure and Order
    // So that you can easily display information from both
    [HttpGet("Orders/Create/{departureId}")]
    public IActionResult Create(int departureId)
    {
        try
        {
            var model = new OrderDepartureDTOCombined();
            var departure = _restClient.GetDepartureById(departureId);
            model.AvailableSeats = departure.AvailableSeats;
            model.DepartureID = departure.DepartureID;
            return View(model);
        }
        catch (Exception ex)
        {
            throw new Exception($"Order could not be created. {ex.Message}", ex);
        }
    }

    // POST: OrdersController/Create
    // POST method for a Order
    // Checks if the user written data is acceptable and if so makes a call for the API to save the order.

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(OrderDepartureDTOCombined model)
    {
        try
        {
            // Lets the View if failed still keep the necesary information from the departure
            DepartureDTO departure = _restClient.GetDepartureById(model.DepartureID);
            model.AvailableSeats = departure.AvailableSeats;
            // Check if the seats reserved is acceptable
            if (model.AvailableSeats < model.SeatsReserved)
            {
                ModelState.AddModelError("SeatsReserved", "Error you can not exceed the number available on the departure"); // TODO: Perhaps change this
            }
            else if (model.SeatsReserved < 1)
            {
                ModelState.AddModelError("SeatsReserved", "Error you must input a positiv number of seats to reserve");
            }
            // Happy days scenario 
            else
            {
                model.Departure = departure;
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
            TempData["ErrorMessage"] = "Order was not created. Try again later";
            return Redirect("/home/index");
        }
    }
    // Help method which makes it removes bloat from a another Method which might need this funconality
    // Takes a CombinedObject and returns a new Order from that information
    private OrderDTO ConvertToOrderDTO(OrderDepartureDTOCombined newCombinedOrder)
    {
        OrderDTO newOrder = new OrderDTO();
        newOrder.OrderID = newCombinedOrder.OrderID;
        newOrder.CustomerID = newCombinedOrder.CustomerID;
        newOrder.SeatsReserved = newCombinedOrder.SeatsReserved;
        newOrder.TotalPrice = newCombinedOrder.TotalPrice;
        newOrder.Departure = newCombinedOrder.Departure;
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
