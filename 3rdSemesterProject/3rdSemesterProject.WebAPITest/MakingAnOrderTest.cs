using _3rdSemesterProject.DataAccess.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.DAL;

namespace _3rdSemesterProject.WebAPITest;

internal class MakingAnOrderTest
{
    OrderDAOStub DAO;
    OrdersController ordersController;
    Departure testDeparture;
    Order testOrder;

    [SetUp]
    public void Setup()
    {
        DAO = new OrderDAOStub("");
        ordersController = new OrdersController(DAO);
        testDeparture = new Departure()
        {
            DepartureID = 1
        };
        testOrder = new Order()
        {
            Departure = testDeparture,
            OrderID = 2,
            CustomerID = 1,
            SeatsReserved = 5,
            TotalPrice = 20
        };
    }

    [Test]
    public void CreateOrder_HappyDays()
    {
        //Arrange
        //Handled in Setup

        //Act
        ordersController.CreateOrder(testOrder);
        //Assert
        Assert.True(DAO._orders.Count() > 1);
    }

    [Test]
    public void CreateOrder_NegativePrice()
    {
        //Arrange
        testOrder.TotalPrice = -100;
        //Act
        
        //Assert
        Assert.IsNotInstanceOf<OkObjectResult>(ordersController.CreateOrder(testOrder));
    }

    [Test]
    public void CreateOrder_InvalidCustomerID()
    {
        //Arrange
        testOrder.CustomerID = -100;
        //Act

        //Assert
        Assert.IsNotInstanceOf<OkObjectResult>(ordersController.CreateOrder(testOrder));
    }

    [Test]
    public void CreateOrder_InvalidDeparureID()
    {
        //Arrange
        testDeparture.DepartureID = -100;
        //Act

        //Assert
        Assert.IsNotInstanceOf<OkObjectResult>(ordersController.CreateOrder(testOrder));
    }
    [Test]
    public void CreateOrder_InvalidSeatsReserved()
    {
        //Arrange
        testOrder.SeatsReserved = -100;
        //Act

        //Assert
        Assert.IsNotInstanceOf<OkObjectResult>(ordersController.CreateOrder(testOrder));
    }

    [Test]
    public void GetOrderById_Test_HappyDays()
    {
        //Arrange

        //Act
        var result = ordersController.GetOrderByID(0);
        //Assert
        Assert.IsInstanceOf<OkObjectResult>(result.Result);
    }

    [Test]
    public void GetOrderById_OutOfBounds_Test()
    {
        //Arrange
        int nonExistentOrderId = DAO._orders.Count() + 100; // ID that doesn’t exist

        //Act

        //Assert
        Assert.Throws<Exception>(() => ordersController.GetOrderByID(nonExistentOrderId));

    }
}
