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
    //TODO: Ændre så den ikke henter alt men kun det vi skal bruge
    private readonly string _getThreeRoutes = "SELECT TOP 3 PK_routeID, description, duration, title FROM [Route]";
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
        using var connection = CreateConnection();
        List<Route> _routes = connection.Query<Route>(_getThreeRoutes).ToList();
        return connection.Query<Route>(_getThreeRoutes).ToList();
        //List<Route> routes = new List<Route>();
        //try
        //{
        //    var command = new SqlCommand(_getThreeRoute, _sqlConnection);
        //    _sqlConnection.Open();
        //    using SqlDataReader sqlDataReader = command.ExecuteReader();
        //    if (sqlDataReader.Read())
        //    {

        //    }
        //}
        //throw new NotImplementedException();
    }

    private Route CreateRoutePlaceHolder(SqlDataReader reader)
    {
        Route placeholderRoute = new Route();
        //placeholderRoute.RouteID = ((int)reader["PK_routeID"]);
        placeholderRoute.Description = ((string)reader["description"]);
        placeholderRoute.Duration = ((int)reader["duration"]);
        placeholderRoute.Title = ((string)reader["title"]);
        return placeholderRoute;
    }
}
