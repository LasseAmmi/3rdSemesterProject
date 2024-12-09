using System.ComponentModel.DataAnnotations;

namespace _3rdSemesterProject.WebSite.Models.DTO;

public class DepartureDTO
{
    public int DepartureID { get; set; }
    public int RouteID { get; set; }
    public int BoatID { get; set; }
    public decimal Price { get; set; }
    public string DepartureName { get; set; }
    public string Description { get; set; }
    public int AvailableSeats { get; set; }
    public DateTime Time { get; set; }
    [Timestamp]
    public byte[] RowVersion { get; set; }
}