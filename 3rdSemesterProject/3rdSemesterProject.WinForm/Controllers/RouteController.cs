using _3rdSemesterProject.WinForm.Models;
using _3rdSemesterProject.WinForm.DataAccess;

namespace _3rdSemesterProject.WinForm.Controllers
{
    internal class RouteController
    {
        private static readonly string _APIURL = "https://localhost:7034/api/v1/";

        private IRouteDAO _routeDAO;

        public RouteController()
        {
            _routeDAO = new RouteDAO(_APIURL);
        }

        public IEnumerable<Route> GetAllRoutes()
        {
            return _routeDAO.GetRoutes();
        }

    }
}
