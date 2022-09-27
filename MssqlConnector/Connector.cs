using Microsoft.Data.SqlClient;

namespace MssqlConnector
{
    public class Connector
    {
        SqlConnection getConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}