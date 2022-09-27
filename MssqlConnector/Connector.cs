using Microsoft.Data.SqlClient;

namespace MssqlConnector
{
    public static class Connector
    {
        public static SqlConnection getConnection(string connectionString)
        {
            return new SqlConnection(connectionString);
        }
    }
}