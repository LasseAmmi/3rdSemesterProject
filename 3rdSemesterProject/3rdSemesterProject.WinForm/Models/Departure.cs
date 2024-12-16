using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.WinForm.Models;

public class Departure
{

    public DateTime Time { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public int RouteID { get; set; }

    public int BoatID { get; set; }

    public int AvailableSeats { get; set; }

    public int DepartureID { get; set; }

    public Departure(DateTime depTime, decimal price, string description, int route, int boat, int id)
    {
        Time = depTime;
        Price = price;
        Description = description;
        RouteID = route;
        BoatID = boat;
        DepartureID = id;
    }

    public Departure()
    {

    }

    public override string ToString()
    {
        return "(" + DepartureID.ToString() + ") " + Time.ToShortDateString() + " " + Time.ToShortTimeString();
    }
}
