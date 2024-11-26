using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.WinForm.Models;

public class Departure
{

    public DateTime DepartureTime { get; set; }

    public decimal Price { get; set; }

    public string Description { get; set; }

    public bool AllInclusive { get; set; }

    public Route DepartureRoute { get; set; }

    public Boat DepartureBoat { get; set; }

    public int AvailableSeats { get; set; }

    public int DepartureID { get; set; }

    public Departure(DateTime depTime, decimal price, string description, bool allInclusive, Route route, Boat boat, int id)
    {
        DepartureTime = depTime;
        Price = price;
        Description = description;
        AllInclusive = allInclusive;
        DepartureRoute = route;
        DepartureBoat = boat;
        DepartureID = id;
    }

    public Departure()
    {

    }

    public override string ToString()
    {
        return "(" + DepartureID.ToString() + ") " + DepartureTime.ToShortDateString() + " " + DepartureTime.ToShortTimeString();
    }
}
