using _3rdSemesterProject.DataAccess.Models__Lasse_;
using Microsoft.Data.SqlClient;
using System.Transactions;

namespace _3rdSemesterProject.DataAccess
{
    internal class OrderDAO : BaseDAO, IOrderDAO
    {
        #region SQL queries and constructor

        private readonly string _createOrder = $"INSERT INTO [Order] (totalPrice, FK_customerID, FK_departureID, seatsReserved) VALUES (@totalPrice, @FK_customerID, @FK_departureID, @seatsReserved)";
        private readonly string _getOrderById = $"SELECT PK_orderID, totalPrice, FK_customerID, FK_departureID, seatsReserved FROM [Order] WHERE PK_orderID = @id";
        private readonly string _updateDepartureSeatsSubtracted = $"UPDATE Departure SET availableSeats = availableSeats - @seatsReserved WHERE PK_departureID = @departureID;";

        public OrderDAO(string connectionstring) : base(connectionstring)
        {
            CreateConnection();
        }

        #endregion

        public int CreateOrder(Order newOrder)
        {
            int id;
            _sqlConnection.Open();
            SqlTransaction transaction = _sqlConnection.BeginTransaction();
            try
            {
                var commandOrder = new SqlCommand(_createOrder, _sqlConnection);
                var commandDepartureUpdate = new SqlCommand(_updateDepartureSeatsSubtracted, _sqlConnection);
                AssignVariables(commandOrder, newOrder);
                //Get the given departure to then change the
                commandDepartureUpdate.Parameters.AddWithValue("@seatsReserved", newOrder.SeatsReserved);
                commandDepartureUpdate.Parameters.AddWithValue("@departureID", newOrder.DepartureID);
                //Not sure if the line below is necesary
                commandOrder.Transaction = transaction;
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
                catch(Exception exRollback)
                {
                    throw new Exception($"Rollback failed." + exRollback.Message, exRollback);

                }
                throw new Exception($"Order could not be created." + ex.Message, ex);
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
    }
}