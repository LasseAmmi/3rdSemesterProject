using _3rdSemesterProject.WebSite.Models.DTO;
using RestSharp;

namespace _3rdSemesterProject.WebSite.APIStub;

public class RestAPIClientStub : IRestClient
{
    public List<OrderDTO> _orders = new List<OrderDTO>();
    public CustomerDTO _customer = new CustomerDTO();
    public List<DepartureDTO> _departures = new List<DepartureDTO>()
    { new DepartureDTO() { AvailableSeats = 10, TicketPrice = 5, DepartureTime = DateTime.Now },
      new DepartureDTO() { AvailableSeats = 20, TicketPrice = 10, DepartureTime = DateTime.Now } };
    public List<RouteDTO> _routes = new List<RouteDTO>()
    {
        new RouteDTO() { RouteID = 1, Description = "The description for route 1", Duration = 45, Title = "Route 1" },
        new RouteDTO() { RouteID = 2, Description = "The description for route 2", Duration = 60, Title = "Route 2" },
        new RouteDTO() { RouteID = 3, Description = "The description for route 3", Duration = 90, Title = "Route 3" }
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

    public IEnumerable<RouteDTO> GetThreeRoutes()
    {
        return _routes.Take(3);
    }
}
