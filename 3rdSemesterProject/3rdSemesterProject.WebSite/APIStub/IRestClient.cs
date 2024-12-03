using _3rdSemesterProject.WebSite.Models.DTO;
using _3rdSemesterProject.WebSite.STUBApi.DTO;

namespace _3rdSemesterProject.WebSite.APIStub;

public interface IRestClient
{
    int CreateOrder(OrderDTO newOrder, DepartureDTO departure);
    DepartureDTO GetDepartureById(int id);
    public DepartureDTO getFirstDeparture();
    IEnumerable<RouteDTO> GetThreeRoutes();
    public RouteDTO GetRouteById(int id);
    IEnumerable<DepartureDTO> GetDeparturesByRouteId(int id);
}