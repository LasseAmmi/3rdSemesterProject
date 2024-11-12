namespace _3rdSemesterProject.WinForm;

public class Boat
{
    public int MaxSeats { get; set; }

    public string Description { get; set; }

    public int BoatId { get; set; }

    public Boat(int capacity, string description, int id)
    { 
        this.MaxSeats = capacity;
        this.Description = description;
        this.BoatId = id;
    }

    public static List<Boat> GetAllBoats()
    {
        List<Boat> boats = new List<Boat>();

        boats.Add(new Boat(100, "Boat 1", 1));
        boats.Add(new Boat(200, "Boat 2", 2));
        boats.Add(new Boat(300, "Boat 3", 3));

        return boats;
    }

    public override string ToString()
    {
        return "Boat: " + BoatId;
    }
}