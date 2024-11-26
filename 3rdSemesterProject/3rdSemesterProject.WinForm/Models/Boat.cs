namespace _3rdSemesterProject.WinForm.Models;

public class Boat
{
    public int MaxSeats { get; set; }

    public string Description { get; set; }

    public int BoatId { get; set; }

    public Boat(int capacity, string description, int id)
    {
        MaxSeats = capacity;
        Description = description;
        BoatId = id;
    }

    public override string ToString()
    {
        return "Boat: " + BoatId;
    }
}