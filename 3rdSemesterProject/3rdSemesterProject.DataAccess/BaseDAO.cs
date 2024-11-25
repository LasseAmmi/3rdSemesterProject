using Microsoft.Data.SqlClient;
using System.Data;

namespace _3rdSemesterProject.DataAccess;

public abstract class BaseDAO
{
    protected string _connectionstring;
    protected SqlConnection _sqlConnection;

    protected BaseDAO(string connectionstring) => _connectionstring = connectionstring;

    protected SqlConnection CreateConnection() => _sqlConnection = new SqlConnection(_connectionstring);
}