using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.WinForm;

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
        this.DepartureTime = depTime;
        this.Price = price;
        this.Description = description;
        this.AllInclusive = allInclusive;
        this.DepartureRoute = route;
        this.DepartureBoat = boat;
        this.DepartureID = id;
    }

    public Departure()
    {
        
    }

    public static List<Departure> GetAllDepartures() //TODO: Implement API call to get all departures
    {
        List<Departure> departures = new List<Departure>();

        departures.Add(new Departure(DateTime.Now, 20.35m, "Departure 1", true, new Route(90, "Route 1", "Sights"), new Boat(100, "Boat 1", 1), 1));
        departures.Add(new Departure(DateTime.Now.AddDays(1), 30m, "Departure 2", false, new Route(30, "Route 2", "Sights"), new Boat(200, "Boat 2", 2), 2));
        departures.Add(new Departure(DateTime.Now.AddDays(-1), 15.15m, "Departure 3", true, new Route(90, "Route 1", "Sights"), new Boat(300, "Boat 3", 3), 3));
        departures.Add(new Departure(DateTime.Now.AddDays(2), 12.50m, "Departure 4", false, new Route(30, "Route 2", "Sights"), new Boat(100, "Boat 1", 1), 4));
        departures.Add(new Departure(DateTime.Now.AddDays(-2), 40m, "Departure 5", true, new Route(45, "Route 3", "Sights"), new Boat(200, "Boat 2", 2), 5));

        return departures;
    }

    public override string ToString()
    {
        return "(" + DepartureID.ToString() + ") " + DepartureTime.ToShortDateString() + " " + DepartureTime.ToShortTimeString();
    }
}
