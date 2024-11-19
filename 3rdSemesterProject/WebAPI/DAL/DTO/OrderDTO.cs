using System.ComponentModel.DataAnnotations;

namespace WebAPI.DAL.DTO;

public class OrderDTO
{   
    public int CustomerID { get; set; }
    public int DepartureID { get; set; }
    public int SeatsReserved { get; set; }
    public decimal TotalPrice { get; set; }
    public int OrderID { get; set; }
}
