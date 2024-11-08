using System.ComponentModel.DataAnnotations;

namespace _3rdSemesterProject.WebSite.Models.DTO.CombinedDTO
{
    public class OrderDepartureDTOCombined
    {
        public CustomerDTO Customer { get; set; }
        public DepartureDTO Departure { get; set; }
        [Display(Name = "Amount of seats")]
        public int SeatsReserved { get; set; }
        public decimal TotalPrice { get; set; }
        public int OrderID { get; set; }

        
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public DateTime DepartureTime { get; set; }
    }
}
