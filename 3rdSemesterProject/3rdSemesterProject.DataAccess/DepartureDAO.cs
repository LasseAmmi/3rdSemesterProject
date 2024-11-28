﻿using _3rdSemesterProject.DataAccess.Models;
using _3rdSemesterProject.DataAccess.Models__Lasse_;
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
    #region skibidi
    private readonly string _getDepartureById = $"SELECT PK_departureID, FK_routeID, FK_boatID, price, departureName, description, availableSeats, time FROM [Departure] WHERE PK_departureID = @id";
    private readonly string _getDepartureByRouteId = $"SELECT PK_departureID, FK_routeID, FK_boatID, price, departureName, description, availableSeats, time FROM [Departure] WHERE FK_routeID = @id";


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
            //TODO: Fix failure 404 error
            var command = new SqlCommand(_getDepartureById, _sqlConnection);
            _sqlConnection.Open();
            command.Parameters.AddWithValue("@id", id);
            SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.Read())
            {
                return CreateDeparturePlaceHolder(sqlDataReader);
            }
        }
        catch (Exception ex)
        {

        }
        finally
        {
            _sqlConnection.Close();
        }
        return placeHolderDeparture;
    }
    private Departure CreateDeparturePlaceHolder(SqlDataReader reader)
    {
        Departure placeholderDeparture = new Departure();
        placeholderDeparture.PK_departureID = ((int)reader["PK_departureID"]);
        placeholderDeparture.FK_routeID = ((int)reader["FK_routeID"]);
        placeholderDeparture.FK_boatID = ((int)reader["FK_boatID"]);
        placeholderDeparture.Price = ((decimal)reader["price"]);
        placeholderDeparture.DepartureName = ((string)reader["departureName"]);
        placeholderDeparture.Description = ((string)reader["description"]);
        placeholderDeparture.AvailableSeats = ((int)reader["availableSeats"]);
        placeholderDeparture.Time = ((DateTime)reader["time"]);
        return placeholderDeparture;
    }
    
    public IEnumerable<Departure> GetDeparturesByRouteId(int id)
    {
        using var connection = CreateConnection();

        return connection.Query<Departure>(_getDepartureByRouteId, new { id = id }).ToList();
    }
}