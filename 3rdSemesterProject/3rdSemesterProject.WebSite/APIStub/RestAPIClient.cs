using _3rdSemesterProject.WebSite.Models.DTO;
using RestSharp;

namespace _3rdSemesterProject.WebSite.APIStub;

public class RestAPIClient : IRestClient
{
    RestClient _client;

    public RestAPIClient(string baseAPIURL)
    {
            _client = new RestClient(baseAPIURL);
    }

    public int CreateOrder(OrderDTO newOrder)
    {
        //_client.CreateNewOrder(newOrder);
        throw new NotImplementedException();
    }

    public DepartureDTO GetDepartureById(int id)
    {
        throw new NotImplementedException();
    }

    public DepartureDTO getFirstDeparture()
    {
        throw new NotImplementedException();
    }

    public IEnumerable<RouteDTO> GetThreeRoutes()
    {
        
        return _client.Get<IEnumerable<RouteDTO>>(new RestRequest("routes"));
    }
}
