﻿using _3rdSemesterProject.WebSite.Models.DTO;
using _3rdSemesterProject.WebSite.STUBApi.DTO;
using RestSharp;

namespace _3rdSemesterProject.WebSite.APIStub;

public class RestAPIClient : IRestClient
{
    RestClient _client;
    public RestAPIClient(string baseAPIURL)
    {
        _client = new RestClient(baseAPIURL);
    }

    public IEnumerable<DepartureDTO> GetDeparturesByRouteId(int id)
    {
        RestRequest request = new RestRequest("departures/departuresByRouteId");
        request.AddParameter("id", id);
        var response = _client.Get<IEnumerable<DepartureDTO>>(request);
        return response;
    }

    public DepartureDTO GetDepartureById(int id)
    {
        RestRequest request = new RestRequest("departures/departureById");
        request.AddParameter("id", id);
        var response = _client.Get<DepartureDTO>(request);
        if (response != null)
        {
            return response;
        }
        else
        {
            throw new Exception("Could not retrieve departure.");
        }
    }
    public IEnumerable<RouteDTO> GetThreeRoutes()
    {

        return _client.Get<IEnumerable<RouteDTO>>(new RestRequest("routes"));
    }
    public int CreateOrder(OrderDTO newOrder, DepartureDTO departure)
    {
        try
        {
            RestRequest request = new RestRequest("orders/CreateOrder");
            request.AddJsonBody(newOrder);
            var response = _client.Post<int>(request);
            if (response != 0)
            {
                return response;
            }
            else
            {
                throw new Exception("Could not create order.");
            }
        }
        catch (Exception ex)
        {
            throw ex;
        }
    }


    public DepartureDTO getFirstDeparture()
    {
        throw new NotImplementedException();
    }

    public RouteDTO GetRouteById(int id)
    {
        throw new NotImplementedException();
    }

}
