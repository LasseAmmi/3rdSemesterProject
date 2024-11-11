using _3rdSemesterProject.WebSite.APIStub;
using _3rdSemesterProject.WebSite.Controllers;
using _3rdSemesterProject.WebSite.Models.DTO.CombinedDTO;

namespace _3rdSemesterProject.WebSiteTest;

public class Tests
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void MakingAnOrder_OutOfUpperBounds()
    {
        //Arrange
        RestAPIClientStub client = new RestAPIClientStub();
        OrdersController controller = new OrdersController(client);
        var model = new OrderDepartureDTOCombined();
        model.AvailableSeats = client.getFirstDeparture().AvailableSeats;
        model.SeatsReserved = client.getFirstDeparture().AvailableSeats + 1;
        //Act
        controller.Create(model, model.OrderID);
        //Assert
        Assert.IsEmpty(client._orders);
    }

    [Test]
    public void MakingAnOrder_OutOfLowerBounds()
    {
        //Arrange
        RestAPIClientStub client = new RestAPIClientStub();
        OrdersController controller = new OrdersController(client);
        var model = new OrderDepartureDTOCombined();
        model.AvailableSeats = client.getFirstDeparture().AvailableSeats;
        model.SeatsReserved = -1;
        //Act
        controller.Create(model, model.OrderID);
        //Assert
        Assert.IsEmpty(client._orders);
    }

    [Test]
    public void MakingAnOrder_HappyDays()
    {
        //Arrange
        RestAPIClientStub client = new RestAPIClientStub();
        OrdersController controller = new OrdersController(client);
        var model = new OrderDepartureDTOCombined();
        model.AvailableSeats = client.getFirstDeparture().AvailableSeats;
        model.SeatsReserved = client.getFirstDeparture().AvailableSeats - 1;
        //Act
        controller.Create(model, model.OrderID);
        //Assert
        Assert.IsTrue(client._orders.Count() > 0);
    }
}