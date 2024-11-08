using _3rdSemesterProject.WebSite.Models.DTO;

namespace _3rdSemesterProject.WebSite.APIStub;

public interface IRestClient
{
    int CreateOrder(OrderDTO newOrder);
    public DepartureDTO getFirstDeparture();
}