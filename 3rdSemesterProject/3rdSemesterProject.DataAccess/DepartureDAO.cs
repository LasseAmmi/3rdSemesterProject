using _3rdSemesterProject.DataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.DataAccess;

public class DepartureDAO : BaseDAO, IDepartureDAO
{
    #region Constructor and SQL queries
    private readonly string _getDepartureById = $"SELECT PK_departureID, FK_routeID, FK_boatID, price, departureName, description, availableSeats, time, RowVersion FROM [Departure] WHERE PK_departureID = @id";
    private readonly string _getDepartureByRouteId = $"SELECT PK_departureID, FK_routeID, FK_boatID, price, departureName, description, availableSeats, time, RowVersion FROM [Departure] WHERE FK_routeID = @id";


    public DepartureDAO(string connectionstring) : base(connectionstring)
    {
        CreateConnection();
    }
    #endregion
    public Departure? GetDepartureById(int id)
    {
        Departure placeHolderDeparture = null;
        try
        {
            _sqlConnection.Open();
            var command = new SqlCommand(_getDepartureById, _sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.Read())
            {
                return CreateDeparturePlaceHolder(sqlDataReader);
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to return a Departure on the given ID" + ex.Message, ex);
        }
        finally
        {
            _sqlConnection.Close();
        }
        return placeHolderDeparture;
    }
    // Helper method to reduce bloat of other methods
    // takes a reader to then create a Departure from the DataReader
    public static Departure CreateDeparturePlaceHolder(SqlDataReader reader)
    {
        Departure placeholderDeparture = new Departure();
        placeholderDeparture.DepartureID = ((int)reader["PK_departureID"]);
        placeholderDeparture.RouteID = ((int)reader["FK_routeID"]);
        placeholderDeparture.BoatID = ((int)reader["FK_boatID"]);
        placeholderDeparture.Price = ((decimal)reader["price"]);
        placeholderDeparture.DepartureName = ((string)reader["departureName"]);
        placeholderDeparture.Description = ((string)reader["description"]);
        placeholderDeparture.AvailableSeats = ((int)reader["availableSeats"]);
        placeholderDeparture.Time = ((DateTime)reader["time"]);
        placeholderDeparture.RowVersion = (byte[])reader["RowVersion"];
        return placeholderDeparture;
    }
    
    public IEnumerable<Departure> GetDeparturesByRouteId(int id)
    {
        using var connection = CreateConnection();
        return connection.Query<Departure>(_getDepartureByRouteId, new { id = id }).ToList();
    }
}
