using _3rdSemesterProject.DataAccess;
using _3rdSemesterProject.DataAccess.Models;
using _3rdSemesterProject.DataAccess.Models__Lasse_;
using _3rdSemesterProject.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using WebAPI.DAL;
using WebAPI.DAL.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    #region Variables and constructor
    const string baseURI = "api/v1/[controller]";
    IOrderDAO _orderDAO;
    IDepartureDAO _departureDAO;

    public OrdersController(IOrderDAO orderDAO, IDepartureDAO departureDAO)
    {
        _orderDAO = orderDAO;
        //TODO: Ændre det her så det er måske en controller den holder der har den DAO
        _departureDAO = departureDAO;
    }

    #endregion

    // GET: api/<OrdersController>
    [HttpGet]
    public ActionResult<IEnumerable<string>> Get()
    {
        //TODO: Missing implemntaion
        return new string[] { "value1", "value2" };
    }

    // GET api/<OrdersController>/5
    [HttpGet("{id}")]
    public ActionResult<Order> GetOrderByID(int id)
    {
        try
        {
            Order order = _orderDAO.GetOrderById(id);
            if (order != null)
            {
                return Ok(order);
            }
            else
            {
                return NotFound();
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"API Could not access order."+ ex.Message, ex);
        }
    }

    // POST api/<OrdersController>
    [HttpPost("CreateOrder")]
    public ActionResult<int> CreateOrder(Order newOrder)
    {
        try
        {
            //TODO : Change 2 lines under this after implementation of Customers log in and price calculations
            newOrder.TotalPrice = 69;
            newOrder.CustomerID = 1;
            if (OrderDTOValid(newOrder))
            {
                return Ok(_orderDAO.CreateOrder(newOrder));
            }
            else
            {
                return BadRequest("The order data provided is invalid.");
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"API Could not create order." + ex.Message, ex);
        }
    }

    // PUT api/<OrdersController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<OrdersController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }

    private bool OrderDTOValid(Order newOrder)
    {
        bool result = false;
        if (newOrder.SeatsReserved > 0 && newOrder.TotalPrice > 0
            && newOrder.DepartureID > 0 && newOrder.CustomerID > 0)
            //TODO: Figure out if need be we can change the line under this
            //&& newOrder.SeatsReserved <= DeparturesController.FindDepartureById(newOrder.DepartureID).AvailableSeats
        {
            result = true;
        }
        return result;
    }
}
