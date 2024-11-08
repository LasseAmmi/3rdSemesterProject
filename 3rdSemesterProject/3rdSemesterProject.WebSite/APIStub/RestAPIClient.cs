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

    public DepartureDTO getFirstDeparture()
    {
        throw new NotImplementedException();
    }
}
