using Microsoft.AspNetCore.Mvc;
using _3rdSemesterProject.DataAccess;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using _3rdSemesterProject.DataAccess.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _3rdSemesterProject.WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class RoutesController : ControllerBase
{
    #region Variables and constructor
    const string baseURI = "api/v1/[controller]";
    IRouteDAO _routeDAO;
    public RoutesController(IRouteDAO routeDAO)
    {
        _routeDAO = routeDAO;
    }
    #endregion
    // GET: api/<RoutesController>
    [HttpGet]
    public ActionResult<IEnumerable<DataAccess.Models.Route>> Get()
    {
        IEnumerable<DataAccess.Models.Route> threeRoutes;
        try
        {
            threeRoutes = _routeDAO.GetThreeRoutes();
            if (threeRoutes != null)
            {
                return Ok(threeRoutes);
            }
            else
            {
                return NotFound();
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }

    //GET api/<GetAllRoutes>
    [HttpGet("allRoutes")]
    public ActionResult<IEnumerable<DataAccess.Models.Route>> GetRoutes()
    {
        IEnumerable<DataAccess.Models.Route> routes;
        try
        {
            routes = _routeDAO.GetAllRoutes();
            if(routes != null)
            {
                return Ok(routes);
            }
            else
            {
                return NotFound();
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // GET api/<RoutesController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<RoutesController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<RoutesController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<RoutesController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}
