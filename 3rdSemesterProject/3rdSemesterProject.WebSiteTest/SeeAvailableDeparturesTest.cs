using _3rdSemesterProject.WebSite.APIStub;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.WebSiteTest;

public class SeeAvailableDeparturesTest
{
    RestAPIClientStub client;
    [SetUp]
    public void Setup()
    {
        client = new RestAPIClientStub();

    }


    [Test]
    public void GetAvailibleDeparturesByRouteId_HappyDays()
    {
        //Arrange
        client.GetDeparturesByRouteId(1);
        //Act
        //Assert
    }

}
