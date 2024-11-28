using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3rdSemesterProject.DataAccess.Models;
namespace _3rdSemesterProject.DataAccess;

public interface IDepartureDAO
{
    IEnumerable<Departure> GetDeparturesByRouteId(int id);
    Departure GetDepartureById(int id);
}
