using Microsoft.AspNetCore.Mvc;
using System.Security.Principal;
using WebAPI.DAL;
using WebAPI.DAL.DTO;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebAPI.Controllers;

[Route("api/[controller]")]
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
        return new string[] { "value1", "value2" };
    }

    // GET api/<OrdersController>/5
    [HttpGet("{id}")]
    public ActionResult<OrderDTO> GetOrderByID(int id)
    {
        try
        {
            OrderDTO order = _orderDAO.GetOrderByID(id);
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
    [HttpPost]
    public ActionResult<int> CreateOrder(OrderDTO newOrder)
    {
        try
        {
            if (OrderDTOValid(newOrder))
            {
                _orderDAO.CreateOrder(newOrder);
                return Created($"{baseURI}/{newOrder.OrderID}", newOrder);
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

    private bool OrderDTOValid(OrderDTO newOrder)
    {
        bool result = false;
        if (newOrder.SeatsReserved != null && newOrder.TotalPrice != null
            && newOrder.DepartureID != null && newOrder.CustomerID != null
            && newOrder.SeatsReserved > 0)
            //&& newOrder.SeatsReserved <= DeparturesController.FindDepartureById(newOrder.DepartureID).AvailableSeats
        {
            result = true;
        }
        return result;
    }
}
