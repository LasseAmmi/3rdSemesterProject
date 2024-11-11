using _3rdSemesterProject.WebSite.APIStub;
using _3rdSemesterProject.WebSite.Controllers;
using _3rdSemesterProject.WebSite.Models.DTO.CombinedDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.TestNUNIT;

class MakingAOrderWebsiteTest
{
    [SetUp]
    public void SetupMethod()
    {

    }

    [Test]
    public void CreateOrder()
    {
        //Arrange
        RestAPIClientStub client = new RestAPIClientStub();
        OrdersController controller = new OrdersController(client);
        var model = new OrderDepartureDTOCombined();
        model.AvailableSeats = client.getFirstDeparture().AvailableSeats;
        //Act
        controller.Create(model);
        //Assert
        Assert.IsTrue(client._orders.Count() > 0);
    }
}
