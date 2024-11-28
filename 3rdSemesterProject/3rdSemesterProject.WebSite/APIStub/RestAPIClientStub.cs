using _3rdSemesterProject.WebSite.Models.DTO;
using RestSharp;
using System.Linq;

namespace _3rdSemesterProject.WebSite.APIStub;

public class RestAPIClientStub : IRestClient
{
    public List<OrderDTO> _orders = new List<OrderDTO>();
    public CustomerDTO _customer = new CustomerDTO();
    public List<DepartureDTO> _departures = new List<DepartureDTO>()
    { new DepartureDTO() { AvailableSeats = 10, Price = 5, Time = DateTime.Now },
      new DepartureDTO() { AvailableSeats = 20, Price = 10, Time = DateTime.Now } };
    public List<RouteDTO> _routes = new List<RouteDTO>()
    {
        new RouteDTO() { PK_routeID = 1, Description = "The description for route 1", Duration = 45, Title = "Route 1" },
        new RouteDTO() { PK_routeID = 2, Description = "The description for route 2", Duration = 60, Title = "Route 2" },
        new RouteDTO() { PK_routeID = 3, Description = "The description for route 3", Duration = 90, Title = "Route 3" }
    };

    public RestAPIClientStub()
    {
    }

    public int CreateOrder(OrderDTO newOrder)
    {
        if (_orders.Count() == 0)
        {
            newOrder.OrderID = 1;
        }
        else
        {
            var highestId = _orders.Max(author => author.OrderID);
            newOrder.OrderID = highestId + 1;
        }
        _orders.Add(newOrder);
        return newOrder.OrderID;
    }

    public DepartureDTO GetDepartureById(int id)
    {
        return _departures[id];
    }

    public DepartureDTO getFirstDeparture()
    {
        return _departures.First();
    }
    public RouteDTO GetRouteById(int id)
    {
        return _routes[id - 1];
    }
    public IEnumerable<RouteDTO> GetThreeRoutes()
    {
        return _routes.Take(3);
    }

    IEnumerable<DepartureDTO> IRestClient.GetDeparturesByRouteId(int id)
    {
        return null;
    }
}
