using _3rdSemesterProject.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.WinForm.Controllers;

public class DepartureController
{

    public Departure Departure { get; set; }

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

    public static List<Boat> GetAllBoats()
    {
        return BoatController.GetAllBoats();
    }

    public static List<Route> GetAllRoutes()
    {
        return RouteController.GetAllRoutes();
    }


}
