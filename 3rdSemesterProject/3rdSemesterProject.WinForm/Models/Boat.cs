namespace _3rdSemesterProject.WinForm.Models;

public class Boat
{
    public int MaxSeats { get; set; }

    public int BoatID { get; set; }

    public Boat(int MaxSeats, int BoatID)
    {
        this.MaxSeats = MaxSeats;
        this.BoatID = BoatID;
    }

    public override string ToString()
    {
        return "Boat: " + BoatID;
    }
}