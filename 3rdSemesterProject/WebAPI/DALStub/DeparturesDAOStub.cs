namespace _3rdSemesterProject.WebAPI.DALStub;

public class DeparturesDAOStub : IDeparturesDAO
{
    static private List<Departure> _departures = new List<Departure>()
    {
        new Departure() {Title = "Departure1", Price = 39.95, Duration = 60},
        new Departure() {Title = "Departure2", Price = 29.95, Duration = 90},
        new Departure() {Title = "Departure3", Price = 19.95, Duration = 45}
    };

    public IEnumerable<Departure> GetThreeDepartures()
    {
        return _departures.Take(3);
    }
}
