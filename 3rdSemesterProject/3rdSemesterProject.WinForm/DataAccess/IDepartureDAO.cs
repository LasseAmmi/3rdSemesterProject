using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _3rdSemesterProject.WinForm.Models;

namespace _3rdSemesterProject.WinForm.DataAccess;
public interface IDepartureDAO
{
    IEnumerable<Departure> GetDepartures();

    void UpdateDeparture(Departure departure);

    void DeleteDeparture(int id);

    int CreateDeparture(Departure departure);
}
