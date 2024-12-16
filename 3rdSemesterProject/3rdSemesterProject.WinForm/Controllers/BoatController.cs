using _3rdSemesterProject.WinForm.Models;
using _3rdSemesterProject.WinForm.DataAccess;

namespace _3rdSemesterProject.WinForm.Controllers
{
    internal class BoatController
    {
        private static readonly string _APIURL = "https://localhost:7034/api/v1/";

        private IBoatDAO _boatDAO;

        public BoatController()
        {
            _boatDAO = new BoatDAO(_APIURL);
        }

        public IEnumerable<Boat> GetAllBoats()
        {
            return _boatDAO.GetBoats();
        }
    }
}
