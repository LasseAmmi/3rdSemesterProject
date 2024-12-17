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
    public Departure Departure { get; set; }

    public DepartureController()
    {
        _boatCtrl = new BoatController();
        _routeCtrl = new RouteController();
        _depDAO = new DepartureDAO(_APIURL);
        Departure = new Departure();
    }

    

    public IEnumerable<Departure> GetAllDepartures(bool filter)
    {
        return _depDAO.GetDepartures(filter);
    }

    public void UpdateDeparture(Departure departure)
    {
        _depDAO.UpdateDeparture(departure);
    }

    public int CreateDeparture(Departure departure)
    {
        return _depDAO.CreateDeparture(departure);
    }

    public void DeleteDeparture(int departureId) 
    { 
        _depDAO.DeleteDeparture(departureId);
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
