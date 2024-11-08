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

    // GET: OrdersController/Create
    public ActionResult Create()
    {

        var model = new OrderDepartureDTOCombined();
        model.AvailableSeats = _restClient.getFirstDeparture().AvailableSeats;
        return View(model);
    }

    // GET: OrdersController/Create/Id
    public ActionResult Create(int id)
    {
        var model = new OrderDepartureDTOCombined();
        model.AvailableSeats = _restClient.GetDepartureById(id).AvailableSeats;
        return View(model);
    }

    // POST: OrdersController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(OrderDepartureDTOCombined newCombinedOrder)
    {
        try
        {
            newCombinedOrder.AvailableSeats = _restClient.getFirstDeparture().AvailableSeats;
            if (newCombinedOrder.AvailableSeats < newCombinedOrder.SeatsReserved)
            {
                ModelState.AddModelError("SeatsReserved", "Error you can not exceed the number available on the departure");
            }
            else
            {
                int newOrderID = _restClient.CreateOrder(ConvertToOrderDTO(newCombinedOrder));
                return Redirect("/home/index");
            }

            if (!ModelState.IsValid)
            {
                newCombinedOrder.AvailableSeats = _restClient.getFirstDeparture().AvailableSeats;
                return View(newCombinedOrder);
            }
            return View(newCombinedOrder);
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
