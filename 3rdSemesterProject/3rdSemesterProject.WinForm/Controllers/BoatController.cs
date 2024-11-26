using _3rdSemesterProject.WinForm.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.WinForm.Controllers
{
    internal class BoatController
    {

        public static List<Boat> GetAllBoats()
        {
            List<Boat> boats = new List<Boat>();

            boats.Add(new Boat(100, "Boat 1", 1));
            boats.Add(new Boat(200, "Boat 2", 2));
            boats.Add(new Boat(300, "Boat 3", 3));

            return boats;
        }
    }
}
