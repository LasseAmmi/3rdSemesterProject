using _3rdSemesterProject.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System;
using Dapper;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3rdSemesterProject.DataAccess;

public class RouteDAO : BaseDAO, IRouteDAO
{
    #region SQL queries and constructor
    private readonly string _getRouteById = $"SELECT PK_routeID, description, duration, title FROM [Route] WHERE PK_routeID = @id";
    private readonly string _getThreeRoutes = "SELECT TOP 3 PK_RouteID, description, duration, Title FROM [Route]";
    public RouteDAO(string connectionstring) : base(connectionstring)
    {
        CreateConnection();
    }
    #endregion
    public Route? GetRouteById(int id)
    {
        Route placeHolderRoute = null;
        try
        {
            var command = new SqlCommand(_getRouteById, _sqlConnection);
            _sqlConnection.Open();
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.Read())
            {
                return CreateRoutePlaceHolder(sqlDataReader);
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            _sqlConnection.Close();
        }
        return placeHolderRoute;
    }

    public IEnumerable<Route>? GetThreeRoutes()
    {
        try
        {
            List<Route> listOfRoutes = new List<Route>();
            var command = new SqlCommand(_getThreeRoutes, _sqlConnection);
            _sqlConnection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) 
            {
                listOfRoutes.Add(CreateRoutePlaceHolder(reader));
            }
            return listOfRoutes;
        }
        catch (Exception ex)
        {
            throw new Exception();
        }
    }
    // Helper method to reduce bloat of other methods
    // takes a reader to then create a Departure from the DataReader
    private Route CreateRoutePlaceHolder(SqlDataReader reader)
    {
        Route placeholderRoute = new Route();
        placeholderRoute.RouteID = ((int)reader["PK_routeID"]);
        placeholderRoute.Description = ((string)reader["description"]);
        placeholderRoute.Duration = ((int)reader["duration"]);
        placeholderRoute.Title = ((string)reader["Title"]);
        return placeholderRoute;
    }
}
