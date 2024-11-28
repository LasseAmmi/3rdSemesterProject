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

    public IEnumerable<DepartureDTO> GetDeparturesByRouteId(int id)
    {   
        RestRequest request = new RestRequest("departures/departuresByRouteId");
        request.AddParameter("id", id); 
        var response = _client.Get<IEnumerable<DepartureDTO>>(request);
        return response;
    }
    public IEnumerable<RouteDTO> GetThreeRoutes()
    {
        
        return _client.Get<IEnumerable<RouteDTO>>(new RestRequest("routes"));
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

    public RouteDTO GetRouteById(int id)
    {
        throw new NotImplementedException();
    }

}
