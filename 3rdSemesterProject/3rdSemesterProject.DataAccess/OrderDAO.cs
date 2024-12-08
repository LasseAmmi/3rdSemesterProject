using _3rdSemesterProject.DataAccess.Models;
using _3rdSemesterProject.DataAccess.Models__Lasse_;
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
    //Pessimistic concurreny control
    public int CreateOrder(Order newOrder)
    {
        int id = 0;
        try
        {
            _sqlConnection.Open();

            try
            {
                //TODO: Retrieve a Departure and check if the rowversion checks out (If instead of using try?)
                var commandGetDepartureVersion = new SqlCommand(_getDepartureVersionByDepartureId, _sqlConnection);
                commandGetDepartureVersion.Parameters.AddWithValue("@id", newOrder.DepartureID);
                SqlDataReader reader = commandGetDepartureVersion.ExecuteReader();
                if (reader.Read())
                {
                    Departure comparedDeparture = CreateDepartureRowversion(reader);
                    reader.Close();
                    if (comparedDeparture.RowVersion.SequenceEqual(newOrder.Departure.RowVersion))
                    {
                        SqlTransaction transaction = _sqlConnection.BeginTransaction(IsolationLevel.RepeatableRead);
                        try
                        {
                            var commandOrder = new SqlCommand(_createOrder, _sqlConnection, transaction);
                            var commandDepartureUpdate = new SqlCommand(_updateDepartureSeatsSubtracted, _sqlConnection, transaction);
                            AssignVariables(commandOrder, newOrder);
                            commandDepartureUpdate.Parameters.AddWithValue("@seatsReserved", newOrder.SeatsReserved);
                            commandDepartureUpdate.Parameters.AddWithValue("@departureID", newOrder.DepartureID);
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
                //Handle not being able to find the departure
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



    private SqlCommand AssignVariables(SqlCommand cmd, Order newOrder)
    {
        // (@totalPrice, @FK_customerID, @FK_departureID, @seatsReserved)
        cmd.Parameters.AddWithValue("@totalPrice", newOrder.TotalPrice);
        cmd.Parameters.AddWithValue("@FK_customerID", newOrder.CustomerID);
        cmd.Parameters.AddWithValue("@FK_departureID", newOrder.DepartureID);
        cmd.Parameters.AddWithValue("@seatsReserved", newOrder.SeatsReserved);

        return cmd;
    }

    public int DeleteOrderById(int id)
    {
        throw new NotImplementedException();
    }

    public Order? GetOrderById(int id)
    {
        Order placeHolderOrder = null;
        try
        {
            //TODO: Fix failure 404 error
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
            //TODO: Handle Exception
        }
        finally
        {
            _sqlConnection.Close();
        }
        return placeHolderOrder;
    }

    private Order CreateOrderPlaceHolder(SqlDataReader reader)
    {
        Order placeholderOrder = new Order();
        placeholderOrder.OrderID = ((int)reader["PK_orderID"]);
        placeholderOrder.TotalPrice = ((decimal)reader["totalPrice"]);
        placeholderOrder.CustomerID = ((int)reader["FK_customerID"]);
        placeholderOrder.DepartureID = ((int)reader["FK_departureID"]);
        placeholderOrder.SeatsReserved = ((int)reader["seatsReserved"]);
        return placeholderOrder;
    }

    public int UpdateOrderById(int id)
    {
        throw new NotImplementedException();
    }
    public Departure CreateDepartureRowversion(SqlDataReader reader)
    {
        Departure placeholderDeparture = new Departure();
        placeholderDeparture.RowVersion = (byte[])reader["RowVersion"];
        return placeholderDeparture;
    }
}