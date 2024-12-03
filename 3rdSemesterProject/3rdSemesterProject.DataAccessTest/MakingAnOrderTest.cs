using _3rdSemesterProject.DataAccess.Models__Lasse_;
using _3rdSemesterProject.DataAccess;
namespace _3rdSemesterProject.DataAccessTest;

public class Tests
{
    OrderDAO testOrderDAO;
    Order testOrder;

    [OneTimeSetUp]
    public void Setup()
    {
        testOrder = new Order();
        testOrderDAO = new OrderDAO("Server=group3db.clwaww2kakx8.eu-north-1.rds.amazonaws.com,1433;Database=CaptainJacksBoatTours;User Id=buurgaard;Password=group3secretpassword;Encrypt=True;TrustServerCertificate=True;"); 
    }

    [SetUp]
    public void ArrangeTests() 
    {
        testOrder.CustomerID = 1;
        testOrder.DepartureID = 1;
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
        testOrder.DepartureID = -1;

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