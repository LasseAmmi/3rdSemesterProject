using System.ComponentModel.DataAnnotations;

namespace _3rdSemesterProject.WebSite.Models.DTO;

public class OrderDTO
{
    public CustomerDTO Customer { get; set; }
    public DepartureDTO Departure { get; set; }
    [Display(Name = "Amount of seats")]
    public int SeatsReserved { get; set; }
    public decimal TotalPrice { get; set; }
    public int OrderID { get; set; }

}


