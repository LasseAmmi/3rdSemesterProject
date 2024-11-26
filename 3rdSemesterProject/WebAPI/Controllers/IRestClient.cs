using WebAPI.DAL.DTO;

namespace _3rdSemesterProject.WebAPI.Controllers;

public interface IRestClient
{
    int CreateOrder(OrderDTO newOrder);
    DepartureDTO GetDepartureById(int id);
    public DepartureDTO getFirstDeparture();
}

