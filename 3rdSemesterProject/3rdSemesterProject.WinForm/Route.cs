namespace _3rdSemesterProject.WinForm;

public class Route
{

    public int TimeMinutes { get; set; }

    public string Description { get; set; }

    public string Name { get; set; }

    public Route(int timeInMinutes, string description, string name)
    {
        this.TimeMinutes = timeInMinutes;
        this.Description = description;
        Name = name;
    }

    public static List<Route> GetAllRoutes() //TODO: Implement API call that gets all Routes from DB
    {
        List<Route> routes = new List<Route>();

        routes.Add(new Route(90, "Route 1", "Sights"));
        routes.Add(new Route(30, "Route 2", "Sights"));
        routes.Add(new Route(45, "Route 3", "Sights"));

        return routes;
    }

    public override string ToString()
    {
        return Name + " " + TimeMinutes.ToString();
    }

}