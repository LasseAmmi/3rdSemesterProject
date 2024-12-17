using _3rdSemesterProject.WinForm.Models;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.WinForm.DataAccess
{
    public class RouteDAO : IRouteDAO
    {
        private RestClient _client;
        public RouteDAO(string BASEAPIURL)
        {
            _client = new RestClient(BASEAPIURL);
        }
        public IEnumerable<Route> GetRoutes()
        {
            RestRequest request = new RestRequest("routes/allRoutes");
            var response = _client.Get<IEnumerable<Route>>(request);
            if (response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("Couldn't retrieve all routes from database");
            }
        }
    }
}
