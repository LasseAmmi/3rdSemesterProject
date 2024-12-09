using _3rdSemesterProject.DataAccess.Models;
using _3rdSemesterProject.DataAccess.Models__Lasse_;
namespace _3rdSemesterProject.DataAccess;

public interface IOrderDAO
{
    Order GetOrderById(int id);

    int CreateOrder(Order newOrder);

    int UpdateOrderById(int id);

    int DeleteOrderById(int id);
}