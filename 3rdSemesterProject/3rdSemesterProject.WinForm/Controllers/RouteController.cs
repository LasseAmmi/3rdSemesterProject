using _3rdSemesterProject.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.WinForm.Controllers
{
    internal class RouteController
    {
        public static List<Route> GetAllRoutes() //TODO: Implement API call that gets all Routes from DB
        {
            List<Route> routes = new List<Route>();

            routes.Add(new Route(90, "Route 1", "Sights"));
            routes.Add(new Route(30, "Route 2", "Sights"));
            routes.Add(new Route(45, "Route 3", "Sights"));

            return routes;
        }

    }
}
