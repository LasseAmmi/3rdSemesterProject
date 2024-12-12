using _3rdSemesterProject.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.DataAccess.Models;

public class Order
{
    public int CustomerID { get; set; }
    public int DepartureID { get; set; }
    public int SeatsReserved { get; set; }
    public decimal TotalPrice { get; set; }
    public int OrderID { get; set; }
    public Departure Departure { get; set; }
}
