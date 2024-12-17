using _3rdSemesterProject.DataAccess;
using _3rdSemesterProject.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System.Data.SqlTypes;
namespace _3rdSemesterProject.DataAccessTest;

public class DepartureTests
{
    DepartureDAO testDepDAO;
    Departure testDep;

    [OneTimeSetUp]
    public void Setup()
    {
        testDep = new Departure();
        testDepDAO = new DepartureDAO("Data Source=hildur.ucn.dk;Initial Catalog=DMA-CSD-S231_10503080;User ID=DMA-CSD-S231_10503080;Password=Password1!;TrustServerCertificate=True;"); 
    }

    [SetUp]
    public void ArrangeTests() 
    {
        testDep.Time = (DateTime)SqlDateTime.MinValue;
        testDep.DepartureName = "TestDeparture";
        testDep.Price = -100;
        testDep.AvailableSeats = -100;
        testDep.BoatID = 1;
        testDep.RouteID = 1;
        testDep.Description = "Test Departure description";
    }

    [Test]
    public void MakingADeparture_HappyDays()
    {
        //Arrange
        
        //Act

        //Assert
        Assert.IsTrue(testDepDAO.CreateDeparture(testDep) > 0);
    }

    [Test]
    public void MakingADeparture_InvalidBoatID()
    {
        //Arrange
        testDep.BoatID = -1;

        //Act
        

        //Assert
        Assert.Throws<SqlException>(() => testDepDAO.CreateDeparture(testDep));
    }
    
    [Test]
    public void MakingADeparture_InvalidRouteID()
    {
        //Arrange
        testDep.RouteID = -1;

        //Act
       

        //Assert
        Assert.Throws<SqlException>(() => testDepDAO.CreateDeparture(testDep));
    }


    [OneTimeTearDown]
    public void ClassCleanup()
    {
        testDepDAO.DeleteDepartureByID(testDep.DepartureID);
    }
}