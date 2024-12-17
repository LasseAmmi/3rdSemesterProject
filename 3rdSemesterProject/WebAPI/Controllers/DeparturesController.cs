using _3rdSemesterProject.DataAccess;
using _3rdSemesterProject.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Reflection.Metadata.Ecma335;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _3rdSemesterProject.WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class DeparturesController : ControllerBase
{
    IDepartureDAO _departuresDAO;
    const string baseURI = "api/v1/[controller]";
    public DeparturesController(IDepartureDAO departuresDAO)
    {
        _departuresDAO = departuresDAO;
    }
    // GET: api/<DeparturesController>
    [HttpGet("departuresByRouteId")]
    public ActionResult<IEnumerable<Departure>> GetDeparturesByRouteId(int id)
    {
        IEnumerable<Departure> departuresByRouteId;
        try
        {
            departuresByRouteId = _departuresDAO.GetDeparturesByRouteId(id);
            if (departuresByRouteId != null)
            {
                return Ok(departuresByRouteId);
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

    // GET api/<DeparturesController>/5
    [HttpGet("departureById")]
    public ActionResult<Departure> GetDepartureById(int id)
    {
        Departure? departureById;
        try
        {
            departureById = _departuresDAO.GetDepartureById(id);
            if (departureById != null)
            {
                return Ok(departureById);
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


    //GET API/<DeparturesController>
    [HttpGet]
    public ActionResult<IEnumerable<Departure>> Get(bool filter)
    {
        IEnumerable<Departure> departuresByRouteId;
        try
        {
            departuresByRouteId = _departuresDAO.GetAllDepartures(filter);
            if (departuresByRouteId != null)
            {
                return Ok(departuresByRouteId);
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

    // POST api/<DeparturesController>
    [HttpPost]
    public ActionResult<int> Post([FromBody] Departure value)
    {
        try
        {
            if (IsValidDeparture(value))
            {
                return Ok(_departuresDAO.CreateDeparture(value));
            }
            else
            {
                return BadRequest("Entered Departure data is invalid");
            }
        }
        catch
        {
            return StatusCode(500);
        }
    }

    // PUT api/<DeparturesController>/5
    [HttpPut]
    public void Put([FromBody] Departure value)
    {
        _departuresDAO.UpdateDeparture(value);
    }

    // DELETE api/<DeparturesController>/5
    [HttpDelete]
    public void Delete(int id)
    {
        _departuresDAO.DeleteDepartureByID(id);
    }

    private bool IsValidDeparture(Departure dep)
    {
        bool isValid = false;

        isValid = dep.RouteID > 0 && dep.BoatID > 0 && !dep.DepartureName.IsNullOrEmpty() && !dep.Description.IsNullOrEmpty();

        return isValid;
    }
}
