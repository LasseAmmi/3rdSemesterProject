using WebAPI.DAL.DTO;

namespace WebAPI.DAL;


public class OrderDAOStub : IOrderDAO
{
    public List<OrderDTO> _orders = new List<OrderDTO>() {
    new OrderDTO() {OrderID = 1, CustomerID = 1, DepartureID = 1, SeatsReserved = 5, TotalPrice = 20}
    };
    public OrderDAOStub(string baseURI)
    {
                
    }
    public int CreateOrder(OrderDTO newOrder)
    {
        _orders.Add(newOrder);
        return newOrder.OrderID;
    }

    public OrderDTO GetOrderByID(int orderID)
    {

        return _orders.FirstOrDefault(order => order.OrderID == orderID);
    }
}
