namespace WebAPI.DAL.DTO;

public class DepartureDTO
{
    public int AvailableSeats { get; set; }
    public decimal TicketPrice { get; set; }
    public DateTime DepartureTime { get; set; }
    public int DepartureID { get; set; }
}