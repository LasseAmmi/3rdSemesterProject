using _3rdSemesterProject.WebSite.STUBApi.DTO;
namespace _3rdSemesterProject.WebSite.STUBApi;

public interface IRestClient
{
    IEnumerable<Departure> GetThreeDepartures();
}
