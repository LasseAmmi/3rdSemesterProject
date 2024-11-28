using _3rdSemesterProject.DataAccess.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.DataAccess;

public interface IRouteDAO
{
    Route GetRouteById (int id);
    IEnumerable<Route> GetThreeRoutes();
}
