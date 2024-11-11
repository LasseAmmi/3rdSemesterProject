using WebAPI.DAL.DTO;

namespace WebAPI.DAL;

public interface IOrderDAO
{
    int CreateOrder(OrderDTO newOrder);

    OrderDTO GetOrderByID(int orderID);


}

