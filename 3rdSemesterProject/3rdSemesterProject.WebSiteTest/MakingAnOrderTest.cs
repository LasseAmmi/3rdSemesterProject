using _3rdSemesterProject.WebSite.APIClient;
using _3rdSemesterProject.WebSite.Controllers;
using _3rdSemesterProject.WebSite.Models.DTO;
using _3rdSemesterProject.WebSite.Models.DTO.CombinedDTO;

namespace _3rdSemesterProject.WebSiteTest;

public class MakingAnOrderTest
{
    RestAPIClientStub client;
    OrdersController controller;
    OrderDepartureDTOCombined model;

    [SetUp]
    public void Setup()
    {
        client = new RestAPIClientStub();
        controller = new OrdersController(client);
        model = new OrderDepartureDTOCombined();
    }

    [Test]
    public void MakingAnOrder_SeatsOutOfUpperBounds()
    {
        //Arrange
        
        model.AvailableSeats = client.getFirstDeparture().AvailableSeats;
        model.SeatsReserved = model.AvailableSeats + 1;
        //Act
        controller.Create(model);
        //Assert
        Assert.IsEmpty(client._orders);
    }

    [Test]
    public void MakingAnOrder_SeatsOutOfLowerBounds()
    {
        //Arrange
        RestAPIClientStub client = new RestAPIClientStub();
        OrdersController controller = new OrdersController(client);
        var model = new OrderDepartureDTOCombined();
        model.SeatsReserved = -1;
        //Act
        controller.Create(model);
        //Assert
        Assert.IsEmpty(client._orders);
    }

    [Test]
    public void MakingAnOrder_HappyDays()
    {
        //Arrange
        DepartureDTO testDeparture = client.getFirstDeparture();
        model.Departure = testDeparture;
        model.DepartureID = testDeparture.DepartureID;
        model.AvailableSeats = testDeparture.AvailableSeats;
        model.SeatsReserved = 1;
        //Act
        controller.Create(model);
        //Assert
        Assert.IsTrue(client._orders.Count() > 0);
    }
    [TearDown]
    public void cleanupController()
    {
        controller.Dispose();
    }
}