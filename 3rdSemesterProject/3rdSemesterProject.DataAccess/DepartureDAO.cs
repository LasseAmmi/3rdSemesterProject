using _3rdSemesterProject.DataAccess.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.DataAccess;

public class DepartureDAO : BaseDAO, IDepartureDAO
{
    #region Constructor and SQL queries
    private readonly string _getDepartureById = $"SELECT * FROM [Departure] WHERE PK_departureID = @id";
    private readonly string _getDepartureByRouteId = $"SELECT * FROM [Departure] WHERE FK_routeID = @id";
    private readonly string _getAllDepartures = "SELECT * FROM [Departure]";
    private readonly string _updateDeparture = $"UPDATE [Departure] SET time = @time, FK_routeID = @routeID, FK_boatID = @boatID, price = @price, departureName = @departureName, " +
        $"description = @description, availableSeats = @availSeats WHERE PK_departureID = @id";
    private readonly string _deleteDepartureById = $"DELETE FROM [Departure] WHERE PK_departureID = @id";
    private readonly string _createDeparture = $"INSERT INTO [Departure] (time, FK_routeID, FK_boatID, price, departureName, description, availableSeats) " +
        $"VALUES (@time, @routeID, @boatID, @price, @departureName, @description, (SELECT totalSeats FROM [Boat] WHERE [Boat].PK_boatID = @boatID)); SELECT CAST(SCOPE_IDENTITY() AS INT);";


    public DepartureDAO(string connectionstring) : base(connectionstring)
    {
        CreateConnection();
    }
    #endregion
    public Departure? GetDepartureById(int id)
    {
        Departure? placeHolderDeparture = null;
        try
        {
            _sqlConnection.Open();
            var command = new SqlCommand(_getDepartureById, _sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.Read())
            {
                placeHolderDeparture = CreateDeparturePlaceHolder(sqlDataReader);
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
        List<Departure> departures = new List<Departure>();
        try
        {
            _sqlConnection.Open();
            var command = new SqlCommand(_getDepartureByRouteId, _sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                departures.Add(CreateDeparturePlaceHolder(sqlDataReader));
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to return a Departure on the given Route ID" + ex.Message, ex);
        }
        finally
        {
            _sqlConnection.Close();
        }
        return departures;
    }

    public IEnumerable<Departure> GetAllDepartures()
    {
        List<Departure> departures = new List<Departure>();
        try
        {
            _sqlConnection.Open();
            var command = new SqlCommand(_getAllDepartures, _sqlConnection);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            while (sqlDataReader.Read())
            {
                departures.Add(CreateDeparturePlaceHolder(sqlDataReader));
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to return all Departures" + ex.Message, ex);
        }
        finally
        {
            _sqlConnection.Close();
        }
        return departures;
    }

    public bool UpdateDeparture(Departure departure)
    {
        bool updateSucceeded = false;
        try
        {
            _sqlConnection.Open();
            var command = new SqlCommand(_updateDeparture, _sqlConnection);
            AddParameters(command, departure);
            command.Parameters.AddWithValue("@id", departure.DepartureID);
            command.Parameters.AddWithValue("@availSeats", departure.AvailableSeats);
            updateSucceeded = command.ExecuteNonQuery() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to update Departure" + ex.Message, ex);
        }
        finally
        {
            _sqlConnection.Close();
        }
        return updateSucceeded;
    }

    public bool DeleteDepartureByID(int id)
    {
        bool deleteSucceeded = false;
        try
        {
            _sqlConnection.Open();
            var command = new SqlCommand(_deleteDepartureById, _sqlConnection);
            command.Parameters.AddWithValue("@id", id);
            deleteSucceeded = command.ExecuteNonQuery() > 0;
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to delete Departure" + ex.Message, ex);
        }
        finally
        {
            _sqlConnection.Close();
        }
        return deleteSucceeded;
    }

    public int CreateDeparture(Departure departure)
    {
        int id;
        try
        {
            _sqlConnection.Open();
            var command = new SqlCommand(_createDeparture, _sqlConnection);

            AddParameters(command, departure);

            id = (int)command.ExecuteScalar();
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to create Departure" + ex.Message, ex);
        }
        finally
        {
            _sqlConnection.Close();
        }
        return id;
    }

    private static void AddParameters(SqlCommand command, Departure departure)
    {
        command.Parameters.AddWithValue("@time", departure.Time);
        command.Parameters.AddWithValue("@routeID", departure.RouteID);
        command.Parameters.AddWithValue("@boatID", departure.BoatID);
        command.Parameters.AddWithValue("@price", departure.Price);
        command.Parameters.AddWithValue("@departureName", departure.DepartureName);
        command.Parameters.AddWithValue("@description", departure.Description);
    }

}
