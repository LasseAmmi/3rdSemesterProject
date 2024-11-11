using _3rdSemesterProject.WebSite.STUBApi.DTO;
using RestSharp;

namespace _3rdSemesterProject.WebSite.STUBApi;

public class RestApiClient : IRestClient
{

    RestClient _client;

    public RestApiClient(string baseApiUrl)
    {
        _client = new RestClient(baseApiUrl);
    }
    public IEnumerable<Departure> GetThreeDepartures()
    {
        return _client.Get<IEnumerable<Departure>>(new RestRequest("departures")).Take(3);
    }
}
