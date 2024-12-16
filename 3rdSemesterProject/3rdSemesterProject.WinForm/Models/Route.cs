namespace _3rdSemesterProject.WinForm.Models;

public class Route
{

    public int Duration { get; set; }

    public string Description { get; set; }

    public string Title { get; set; }

    public int RouteID {  get; set; }

    public Route(int RouteID, int Duration, string Description, string Title)
    {
        this.RouteID = RouteID;
        this.Duration = Duration;
        this.Description = Description;
        this.Title = Title;
    }

    public override string ToString()
    {
        return Title + " " + Duration.ToString();
    }

}