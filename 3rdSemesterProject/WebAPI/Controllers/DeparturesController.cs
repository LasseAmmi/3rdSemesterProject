using _3rdSemesterProject.DataAccess;
using _3rdSemesterProject.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

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
        return Ok(_departuresDAO.GetDeparturesByRouteId(id));
    }

// GET api/<DeparturesController>/5
[HttpGet("{id}")]
public string Get(int id)
{
    return "value";
}

// POST api/<DeparturesController>
[HttpPost]
public void Post([FromBody] string value)
{
}

// PUT api/<DeparturesController>/5
[HttpPut("{id}")]
public void Put(int id, [FromBody] string value)
{
}

// DELETE api/<DeparturesController>/5
[HttpDelete("{id}")]
public void Delete(int id)
{
}
}
