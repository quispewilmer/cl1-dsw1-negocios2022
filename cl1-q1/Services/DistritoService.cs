using cl1_q1.Interfaces;
using cl1_q1.Models;
using Microsoft.Data.SqlClient;
using MssqlConnector;
using Microsoft.Extensions.Configuration;

namespace cl1_q1.Services
{
    public class DistritoService : IDistrito
    {
        private readonly IConfiguration _configuration;

        public DistritoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Distrito> GetDistritos()
        {
            List<Distrito> distritos = new List<Distrito>();

            using (SqlConnection sqlConnection = Connector.getConnection(_configuration.GetConnectionString("connectionString")))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "uspListarDistritos";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        sqlConnection.Open();

                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            distritos.Add(new Distrito()
                            {
                                IdDistrito = reader.GetInt32(0),
                                NomDistrito = reader.GetString(1)
                            });
                        }

                        reader.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    finally
                    {
                        sqlConnection.Close();
                    }
                }
            }

            return distritos;
        }
    }
}
