using _3rdSemesterProject.WinForm.DataAccess;
using _3rdSemesterProject.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.WinForm.Controllers;

public class DepartureController
{

    private static readonly string _APIURL = "https://localhost:7034/api/v1/";

    private BoatController _boatCtrl;
    private RouteController _routeCtrl;
    private IDepartureDAO _depDAO;

    public DepartureController()
    {
        _boatCtrl = new BoatController();
        _routeCtrl = new RouteController();
        _depDAO = new DepartureDAO();
    }

    public Departure Departure { get; set; }

    public IEnumerable<Departure> GetAllDepartures() //TODO: Implement API call to get all departures
    {
        List<Departure> departures = new List<Departure>();

        departures.Add(new Departure(DateTime.Now, 20.35m, "Departure 1", 1, 1, 1));
        departures.Add(new Departure(DateTime.Now.AddDays(1), 30m, "Departure 2", 2, 2, 2));
        departures.Add(new Departure(DateTime.Now.AddDays(-1), 15.15m, "Departure 3", 1, 3, 3));
        departures.Add(new Departure(DateTime.Now.AddDays(2), 12.50m, "Departure 4", 2, 1, 4));
        departures.Add(new Departure(DateTime.Now.AddDays(-2), 40m, "Departure 5", 3, 2, 5));

        return departures;
    }

    public IEnumerable<Boat> GetAllBoats()
    {
        return _boatCtrl.GetAllBoats();
    }

    public IEnumerable<Route> GetAllRoutes()
    {
        return _routeCtrl.GetAllRoutes();
    }


}
