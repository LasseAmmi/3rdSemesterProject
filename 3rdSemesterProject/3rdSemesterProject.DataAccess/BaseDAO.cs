using Microsoft.Data.SqlClient;
using System.Data;
using System.Linq;

namespace _3rdSemesterProject.DataAccess;
// Super class for other DAO's to handle the connection and reduce dublicate code
public abstract class BaseDAO
{
    protected string _connectionstring;
    protected SqlConnection _sqlConnection;

    protected BaseDAO(string connectionstring) => _connectionstring = connectionstring;

    protected SqlConnection CreateConnection() => _sqlConnection = new SqlConnection(_connectionstring);
}