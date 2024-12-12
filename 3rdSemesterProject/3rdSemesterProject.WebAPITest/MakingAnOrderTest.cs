using _3rdSemesterProject.DataAccess.Models;
using _3rdSemesterProject.DataAccess.Models__Lasse_;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.DAL;
using WebAPI.DAL.DTO;

namespace _3rdSemesterProject.WebAPITest;

internal class MakingAnOrderTest
{
    [SetUp]
    public void Setup()
    {

    }

    [Test]
    public void CreateOrder_HappyDays()
    {
        //Arrange
        OrderDAOStub dao = new OrderDAOStub("");
        OrdersController controller = new OrdersController(dao);
        Order order = new Order()
        {
            OrderID = 2,
            CustomerID = 1,
            DepartureID = 1,
            SeatsReserved = 5,
            TotalPrice = 20
        };
        Departure departure = new Departure();
        //Act
        controller.CreateOrder(order, departure);
        //Assert
        Assert.True(dao._orders.Count() > 1);
    }

    [Test]
    public void GetOrderById_Test()
    {
        //Arrange
        OrderDAOStub dao = new OrderDAOStub("");
        OrdersController controller = new OrdersController(dao);
        //Act
        var result = controller.GetOrderByID(0);
        //Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
    }

    [Test]
    public void GetOrderById_OutOfBounds_Test()
    {
        //Arrange
        OrderDAOStub dao = new OrderDAOStub("");
        OrdersController controller = new OrdersController(dao);
        int nonExistentOrderId = dao._orders.Count() + 100; // ID that doesn’t exist

        //Act

        //Assert
        Assert.Throws<Exception>(() => controller.GetOrderByID(nonExistentOrderId));

    }
}
