﻿using _3rdSemesterProject.DataAccess.Models;
using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Data;
using static Dapper.SqlMapper;

namespace _3rdSemesterProject.DataAccess;

public class OrderDAO : BaseDAO, IOrderDAO
{
    #region SQL queries and constructor

    private readonly string _createOrder = $" INSERT INTO[Order] (totalPrice, FK_customerID, FK_departureID, seatsReserved) VALUES(@totalPrice, @FK_customerID, @FK_departureID, @seatsReserved); SELECT CAST(SCOPE_IDENTITY() AS INT);";
    private readonly string _getOrderById = $"SELECT PK_orderID, totalPrice, FK_customerID, FK_departureID, seatsReserved FROM [Order] WHERE PK_orderID = @id";
    private readonly string _updateDepartureSeatsSubtracted = $"UPDATE Departure SET availableSeats = availableSeats - @seatsReserved WHERE PK_departureID = @departureID";
    private readonly string _getDepartureVersionByDepartureId = $"SELECT RowVersion FROM [Departure] WHERE PK_departureID = @id";

    public OrderDAO(string connectionstring) : base(connectionstring)
    {
        CreateConnection();
    }

    #endregion
    //Pessimistic && optimistic concurreny control
    public int CreateOrder(Order newOrder)
    {
        // Sleep is used in order to run two or more operations concurrently.
        Thread.Sleep(5000);
        int id;
        try
        {
            _sqlConnection.Open();
            try
            {
                // Creates a DataReader to read the colum RowVersion
                var commandGetDepartureVersion = new SqlCommand(_getDepartureVersionByDepartureId, _sqlConnection);
                commandGetDepartureVersion.Parameters.AddWithValue("@id", newOrder.Departure.DepartureID);
                SqlDataReader reader = commandGetDepartureVersion.ExecuteReader();
                if (reader.Read())
                {
                    //If anything in the Reader then create a Departure with the RowVersion from the Database
                    Departure comparedDeparture = CreateDepartureRowversion(reader);
                    reader.Close();
                    //If the RowVersion's are the same then proceed to create a Transaction and tries to save the Order and update the Departure
                    if (comparedDeparture.RowVersion.SequenceEqual(newOrder.Departure.RowVersion))
                    {
                        // Set the Isolation level to RepeatableRead to ensure that no other changes the Departure while it is updating and solve the non repeatable reads
                        SqlTransaction transaction = _sqlConnection.BeginTransaction(IsolationLevel.RepeatableRead);
                        try
                        {
                            var commandOrder = new SqlCommand(_createOrder, _sqlConnection, transaction);
                            var commandDepartureUpdate = new SqlCommand(_updateDepartureSeatsSubtracted, _sqlConnection, transaction);
                            AssignVariables(commandOrder, newOrder);
                            commandDepartureUpdate.Parameters.AddWithValue("@seatsReserved", newOrder.SeatsReserved);
                            commandDepartureUpdate.Parameters.AddWithValue("@departureID", newOrder.Departure.DepartureID);
                            id = (int)commandOrder.ExecuteScalar();
                            commandDepartureUpdate.ExecuteNonQuery();
                            transaction.Commit();
                            return id;
                        }
                        catch (Exception ex)
                        {
                            try
                            {
                                transaction.Rollback();
                            }
                            catch (Exception exRollback)
                            {
                                throw new Exception($"Rollback failed." + exRollback.Message, exRollback);
                            }
                            throw new Exception($"Order could not be created." + ex.Message, ex);
                        }                       
                    }
                    throw new Exception($"Version number did not match");
                }
                throw new Exception($"Reader failed");
            }
            catch (Exception ex)
            {
                throw new Exception($"Could not retireve the departure" + ex.Message, ex);
            }

        }
        catch (Exception ex)
        {
            throw new Exception($"Could not connect to the database" + ex.Message, ex);
        }
        finally
        {
            _sqlConnection.Close();
        }
    }

    

    public Order? GetOrderById(int id)
    {
        Order? placeHolderOrder = null;
        try
        {
            var command = new SqlCommand(_getOrderById, _sqlConnection);
            _sqlConnection.Open();
            command.Parameters.AddWithValue("@id", id);
            using SqlDataReader sqlDataReader = command.ExecuteReader();
            if (sqlDataReader.Read())
            {
                return CreateOrderPlaceHolder(sqlDataReader);
            }
        }
        catch (Exception ex)
        {
            throw new Exception($"Failed to return a Order based on the ID" + ex.Message, ex);
        }
        finally
        {
            _sqlConnection.Close();
        }
        return placeHolderOrder;
    }

    #region HelperMethods
    // Helper method to reduce bloat of other methods
    // takes a reader to then create a Departure from the DataReader
    private static Order CreateOrderPlaceHolder(SqlDataReader reader)
    {
        Order placeholderOrder = new Order();
        Departure placeholderDeparture = new Departure();
        placeholderOrder.Departure = placeholderDeparture;
        placeholderOrder.OrderID = ((int)reader["PK_orderID"]);
        placeholderOrder.TotalPrice = ((decimal)reader["totalPrice"]);
        placeholderOrder.CustomerID = ((int)reader["FK_customerID"]);
        placeholderOrder.Departure.DepartureID = ((int)reader["FK_departureID"]);
        placeholderOrder.SeatsReserved = ((int)reader["seatsReserved"]);
        return placeholderOrder;
    }

    // Helper method to reduce bloat of other methods
    // Takes a SqlCommand and a Order and assigns the values for the Order to then be saved
    private static SqlCommand AssignVariables(SqlCommand cmd, Order newOrder)
    {
        cmd.Parameters.AddWithValue("@totalPrice", newOrder.TotalPrice);
        cmd.Parameters.AddWithValue("@FK_customerID", newOrder.CustomerID);
        cmd.Parameters.AddWithValue("@FK_departureID", newOrder.Departure.DepartureID);
        cmd.Parameters.AddWithValue("@seatsReserved", newOrder.SeatsReserved);
        return cmd;
    }

    // Helper method to reduce bloat of other methods
    // takes a reader to then create a Departure from the DataReader
    public static Departure CreateDepartureRowversion(SqlDataReader reader)
    {
        Departure placeholderDeparture = new Departure();
        placeholderDeparture.RowVersion = (byte[])reader["RowVersion"];
        return placeholderDeparture;
    } 
    #endregion

    public int UpdateOrderById(int id)
    {
        throw new NotImplementedException();
    }

    public int DeleteOrderById(int id)
    {
        throw new NotImplementedException();
    }
}