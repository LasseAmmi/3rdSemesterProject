using Microsoft.AspNetCore.Mvc;
using _3rdSemesterProject.DataAccess;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using _3rdSemesterProject.DataAccess.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace _3rdSemesterProject.WebAPI.Controllers;

[Route("api/v1/[controller]")]
[ApiController]
public class BoatsController : ControllerBase
{
    #region Variables and constructor
    const string baseURI = "api/v1/[controller]";
    IBoatDAO _boatDAO;
    public BoatsController(IBoatDAO boatDAO)
    {
        _boatDAO = boatDAO;
    }
    #endregion

    // GET: api/<BoatsController>
    [HttpGet]
    public ActionResult<IEnumerable<Boat>> Get()
    {
        IEnumerable<DataAccess.Models.Boat> boats;
        try
        {
            boats = _boatDAO.GetBoats();
            if (boats != null)
            {
                return Ok(boats);
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

    // GET api/<BoatsController>/5
    [HttpGet("{id}")]
    public string Get(int id)
    {
        return "value";
    }

    // POST api/<BoatsController>
    [HttpPost]
    public void Post([FromBody] string value)
    {
    }

    // PUT api/<BoatsController>/5
    [HttpPut("{id}")]
    public void Put(int id, [FromBody] string value)
    {
    }

    // DELETE api/<BoatsController>/5
    [HttpDelete("{id}")]
    public void Delete(int id)
    {
    }
}

