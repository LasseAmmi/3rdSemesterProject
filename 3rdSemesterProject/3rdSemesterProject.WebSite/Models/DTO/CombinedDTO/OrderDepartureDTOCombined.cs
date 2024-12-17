using System.ComponentModel.DataAnnotations;

namespace _3rdSemesterProject.WebSite.Models.DTO.CombinedDTO
{
    public class OrderDepartureDTOCombined
    {

        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public DateTime DepartureTime { get; set; }

        public int CustomerID { get; set; }
        public int DepartureID { get; set; }
        [Display(Name = "Amount of seats")]
        [Range(1, int.MaxValue, ErrorMessage = "Please use a valid number between 1 and the max available")]
        public int SeatsReserved { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }
        [Timestamp]
        public byte[] RowVersion { get; set; }
        public DepartureDTO Departure { get; set; }
    }
}
