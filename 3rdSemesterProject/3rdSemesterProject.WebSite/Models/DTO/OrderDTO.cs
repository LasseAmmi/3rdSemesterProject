using System.ComponentModel.DataAnnotations;

namespace _3rdSemesterProject.WebSite.Models.DTO;

public class OrderDTO
{
    [Required]
    public int CustomerID { get; set; }
    [Required]
    public int DepartureID { get; set; }
    [Required]
    [Display(Name = "Amount of seats")]
    public int SeatsReserved { get; set; }
    [Required]
    public decimal TotalPrice { get; set; }
    [Required]
    public int OrderID { get; set; }
}


