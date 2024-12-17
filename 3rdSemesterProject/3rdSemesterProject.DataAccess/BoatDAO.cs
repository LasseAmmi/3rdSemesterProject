using _3rdSemesterProject.DataAccess.Models;
using Microsoft.Data.SqlClient;

namespace _3rdSemesterProject.DataAccess;

public class BoatDAO : BaseDAO, IBoatDAO
{
    #region SQL queries and constructor
    private readonly string _getBoats = $"SELECT * FROM Boat";
    public BoatDAO(string connectionstring) : base(connectionstring)
    {
        CreateConnection();
    }
    #endregion
    public IEnumerable<Boat>? GetBoats()
    {
        try
        {
            List<Boat> boats = new List<Boat>();
            var command = new SqlCommand(_getBoats, _sqlConnection);
            _sqlConnection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                boats.Add(CreateBoatPlaceholder(reader));
            }
            return boats;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
        finally 
        { 
            _sqlConnection.Close(); 
        }
    }

    private Boat CreateBoatPlaceholder(SqlDataReader reader)
    {
        Boat placeholderBoat = new Boat();
        placeholderBoat.BoatID = ((int)reader["PK_boatID"]);
        placeholderBoat.MaxSeats = ((int)reader["totalSeats"]);
        return placeholderBoat;
    }
}
