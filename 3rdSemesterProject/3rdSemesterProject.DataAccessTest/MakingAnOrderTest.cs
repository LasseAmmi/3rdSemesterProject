using _3rdSemesterProject.DataAccess;
using _3rdSemesterProject.DataAccess.Models;
namespace _3rdSemesterProject.DataAccessTest;

public class Tests
{
    OrderDAO testOrderDAO;
    Order testOrder;
    Departure testDeparture;

    [OneTimeSetUp]
    public void Setup()
    {
        testOrder = new Order();
        testDeparture = new Departure();
        testOrderDAO = new OrderDAO("DefaultConnection"); 
    }

    [SetUp]
    public void ArrangeTests() 
    {
        testOrder.Departure = testDeparture;
        testDeparture.DepartureID = 1;
        testOrder.CustomerID = 1;
        testOrder.Departure = testDeparture;
        testOrder.TotalPrice = -100;
        testOrder.SeatsReserved = -100;
    }

    [Test]
    public void MakingAnOrder_HappyDays()
    {
        //Arrange
        
        //Act
        testOrder.OrderID = testOrderDAO.CreateOrder(testOrder);

        //Assert
        Assert.IsTrue(testOrder.OrderID > 0);
    }

    [Test]
    public void MakingAnOrder_InvalidCustomerID()
    {
        //Arrange
        testOrder.CustomerID = -1;

        //Act
        

        //Assert
        Assert.Throws<Exception>(() => testOrderDAO.CreateOrder(testOrder));
    }
    [Test]

    public void MakingAnOrder_InvalidDepartureID()
    {
        //Arrange
        testOrder.Departure.DepartureID = -1;

        //Act
       

        //Assert
        Assert.Throws<Exception>(() => testOrderDAO.CreateOrder(testOrder));
    }


    [OneTimeTearDown]
    public void ClassCleanup()
    {
        //TODO: Not implemnted yet
        testOrderDAO.DeleteOrderById(testOrder.OrderID);
    }
}