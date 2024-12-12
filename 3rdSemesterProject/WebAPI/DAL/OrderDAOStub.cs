using _3rdSemesterProject.DataAccess;
using _3rdSemesterProject.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.DAL;


public class OrderDAOStub : IOrderDAO
{
    public List<Order> _orders = new List<Order>() {
    new Order() {OrderID = 1, CustomerID = 1, DepartureID = 1, SeatsReserved = 5, TotalPrice = 20}
    };
    public OrderDAOStub(string baseURI)
    {
                
    }

    public int CreateOrder(Order newOrder)
    {
        _orders.Add(newOrder);
        return newOrder.OrderID;
    }

    public int UpdateOrderById(int id)
    {
        throw new NotImplementedException();
    }
    public int DeleteOrderById(int id)
    {
        throw new NotImplementedException();
    }

    public Order GetOrderById(int id)
    {
        return _orders[id];
    }
}
