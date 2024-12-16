using _3rdSemesterProject.WinForm.Models;
using RestSharp;

namespace _3rdSemesterProject.WinForm.DataAccess
{
    public class BoatDAO : IBoatDAO
    {
        private RestClient _client;
        public BoatDAO(string BASEAPIURL)
        {
            _client = new RestClient(BASEAPIURL);
        }
        public IEnumerable<Boat> GetBoats()
        {
            RestRequest request = new RestRequest("boats");
            var response = _client.Get<IEnumerable<Boat>>(request);
            if(response != null)
            {
                return response;
            }
            else
            {
                throw new Exception("Couldn't retrieve all boats from database");
            }
        }
    }
}
