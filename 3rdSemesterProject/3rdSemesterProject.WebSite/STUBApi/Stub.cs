using _3rdSemesterProject.WebSite.STUBApi.DTO;

namespace _3rdSemesterProject.WebSite.STUBApi;

public class Stub
{
    static private List<Departure> _departures = new List<Departure>()
    {
        new Departure() {
        PK_departureID = 1,
        FK_routeID = 1,
        FK_boatID = 1,
        Price = 99.99m,
        DepartureName = "Morning Ferry to Island A",
        Description = "A beautiful ferry ride to the scenic Island A.",
        AvailableSeats = 50,
        },
        new Departure() {
        PK_departureID = 2,
        FK_routeID = 1,
        FK_boatID = 1,
        Price = 99.99m,
        DepartureName = "Morning Ferry to Island A",
        Description = "A beautiful ferry ride to the scenic Island A.",
        AvailableSeats = 50,
        },
        new Departure() {
        PK_departureID = 2,
        FK_routeID = 2,
        FK_boatID = 1,
        Price = 99.99m,
        DepartureName = "Morning Ferry to Island A",
        Description = "A beautiful ferry ride to the scenic Island A.",
        AvailableSeats = 50,
        },
    };

    public IEnumerable<Departure> GetDepartures()
    {
        return _departures;
    }
}
