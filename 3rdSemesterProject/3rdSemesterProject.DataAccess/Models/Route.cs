using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.DataAccess.Models;

public class Route
{
    //Named PK_routeID instead of RouteID because Dapper needs the names in the database to match the object names in c#
    public int PK_routeID { get; set; } 
    public string Description { get; set; }
    public int Duration { get; set; }
    public string Title { get; set; }
}
