using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.WinForm.Models;

public class Departure
{
    public int DepartureID { get; set; }

    public int RouteID { get; set; }

    public int BoatID { get; set; }

    public decimal Price { get; set; }

    public string DepartureName { get; set; }

    public string Description { get; set; }

    public int AvailableSeats { get; set; }

    public DateTime Time { get; set; }

    public byte[] RowVersion { get; set; }
    

    public Departure(int DepartureID, int RouteID, int BoatID, decimal Price, string DepartureName, 
        string Description, int AvailableSeats, DateTime Time, byte[] RowVersion)
    {
        this.DepartureID = DepartureID;
        this.RouteID = RouteID;
        this.BoatID = BoatID;
        this.Price = Price;
        this.DepartureName = DepartureName;
        this.Description = Description;
        this.AvailableSeats = AvailableSeats;
        this.Time = Time;
        this.RowVersion = RowVersion;
    }

    public Departure()
    {

    }

    public override string ToString()
    {
        return "(" + DepartureID.ToString() + ") " + Time.ToShortDateString() + " " + Time.ToShortTimeString();
    }
}
