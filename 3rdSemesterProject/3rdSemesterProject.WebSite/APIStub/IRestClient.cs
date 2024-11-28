﻿using _3rdSemesterProject.WebSite.Models.DTO;

namespace _3rdSemesterProject.WebSite.APIStub;

public interface IRestClient
{
    int CreateOrder(OrderDTO newOrder);
    DepartureDTO GetDepartureById(int id);
    public DepartureDTO getFirstDeparture();
    IEnumerable<RouteDTO> GetThreeRoutes();
    public RouteDTO GetRouteById(int id);
    IEnumerable<DepartureDTO> GetDeparturesByRouteId(int id);
}