using _3rdSemesterProject.WebSite.Models.DTO;
using RestSharp;

namespace _3rdSemesterProject.WebSite.APIStub;

public class RestAPIClientStub : IRestClient
{
    private List<OrderDTO> _orders = new List<OrderDTO>();
    private CustomerDTO _customer = new CustomerDTO();
    private List<DepartureDTO> _departures = new List<DepartureDTO>()
    { new DepartureDTO() { AvailableSeats = 10, TicketPrice = 5, DepartureTime = DateTime.Now } };

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

    public DepartureDTO getFirstDeparture()
    {
        return _departures.First();
    }
}
