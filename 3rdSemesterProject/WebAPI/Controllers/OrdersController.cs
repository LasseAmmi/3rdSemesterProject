using _3rdSemesterProject.DataAccess;
using _3rdSemesterProject.DataAccess.Models;
using _3rdSemesterProject.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using WebAPI.DAL;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class OrdersController : ControllerBase
{
    #region Variables and constructor
    const string baseURI = "api/v1/[controller]";
    IOrderDAO _orderDAO;

    public OrdersController(IOrderDAO orderDAO)
    {
        _orderDAO = orderDAO;
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
            return BadRequest();
        }
    }

    // POST api/<OrdersController>
    [HttpPost("CreateOrder")]
    public ActionResult<int> CreateOrder([FromBody] Order newOrder)
    {
        try
        {
            //TODO : Change 2 lines under this after implementation of Customers log in and Payment methods
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
        catch
        {
            return StatusCode(500);
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
        {
            result = true;
        }
        return result;
    }
}
