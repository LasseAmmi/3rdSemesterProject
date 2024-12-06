using System.ComponentModel.DataAnnotations;

namespace _3rdSemesterProject.WebSite.Models.DTO;

public class DepartureDTO
{
    public int PK_departureID { get; set; }
    public int FK_routeID { get; set; }
    public int FK_boatID { get; set; }
    public decimal Price { get; set; }
    public string DepartureName { get; set; }
    public string Description { get; set; }
    public int AvailableSeats { get; set; }
    public DateTime Time { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
}