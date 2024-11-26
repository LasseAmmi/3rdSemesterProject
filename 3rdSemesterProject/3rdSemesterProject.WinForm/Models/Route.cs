namespace _3rdSemesterProject.WinForm.Models;

public class Route
{

    public int TimeMinutes { get; set; }

    public string Description { get; set; }

    public string Name { get; set; }

    public Route(int timeInMinutes, string description, string name)
    {
        TimeMinutes = timeInMinutes;
        Description = description;
        Name = name;
    }

    public override string ToString()
    {
        return Name + " " + TimeMinutes.ToString();
    }

}