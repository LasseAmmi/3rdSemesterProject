using _3rdSemesterProject.WinForm.Models;

namespace _3rdSemesterProject.WinForm.DataAccess;

public class DepartureDAO : IDepartureDAO
{
    static readonly HttpClient client = new HttpClient();
    private readonly string _getDepartures = $"";

    public DepartureDAO()
    {
        
    }

    public Task CreateDeparture(Departure departure)
    {
        
        throw new NotImplementedException();
    }

    public Task DeleteDeparture(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<Departure>> GetDepartures()
    {
        List<Departure> departures = new List<Departure>();
        HttpResponseMessage response = await client.GetAsync(_getDepartures);
        if (response.IsSuccessStatusCode)
        {
            
        }
        throw new NotImplementedException();
    }

    public Task UpdateDeparture(Departure departure)
    {
        throw new NotImplementedException();
    }
}
