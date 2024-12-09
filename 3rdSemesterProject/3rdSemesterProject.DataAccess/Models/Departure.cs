using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.DataAccess.Models;

public class Departure
{
    public int DepartureID { get; set; }
    public int RouteID { get; set; }
    public int BoatID { get; set; }
    public decimal Price { get; set; }
    public string DepartureName { get; set; }
    public string Description { get; set; }
    public int AvailableSeats { get; set; }
    public DateTime Time {  get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
}
