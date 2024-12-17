using _3rdSemesterProject.WinForm.Models;
using RestSharp;
using System.Text.Json;

namespace _3rdSemesterProject.WinForm.DataAccess;

public class DepartureDAO : IDepartureDAO
{
    private RestClient _client;

    public DepartureDAO(string BASEAPIURL)
    {
        _client = new RestClient(BASEAPIURL);
    }

    public int CreateDeparture(Departure departure)
    {
        RestRequest request = new RestRequest("departures");
        request.AddParameter("application/json", JsonSerializer.Serialize<Departure>(departure), ParameterType.RequestBody);
        var response = _client.Post<int>(request);
        return response;
    }

    public void DeleteDeparture(int id)
    {
        RestRequest request = new RestRequest("departures");
        request.AddParameter("id", id);
        _client.Delete(request);
    }

    public IEnumerable<Departure> GetDepartures()
    {
        RestRequest request = new RestRequest("departures");
        var response = _client.Get<IEnumerable<Departure>>(request);
        
        //For now not handling if response is null here, since program is expected to continue operation even if no departures are found in the system
        return response;
    }

    public void UpdateDeparture(Departure departure)
    {
        RestRequest request = new RestRequest("departures", Method.Put);
        //request.AddHeader("Accept", "application/json");
        request.AddParameter("application/json", JsonSerializer.Serialize<Departure>(departure), ParameterType.RequestBody);
        _client.Execute(request);
    }
}
