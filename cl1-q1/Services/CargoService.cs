using cl1_q1.Interfaces;
using cl1_q1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MssqlConnector;

namespace cl1_q1.Services
{
    public class CargoService : ICargo
    {
        private readonly IConfiguration _configuration;

        public CargoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public List<Cargo> GetCargos()
        {
            List<Cargo> cargos = new List<Cargo>();

            using (SqlConnection sqlConnection = Connector.getConnection(_configuration.GetConnectionString("connectionString")))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "uspListarCargos";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        sqlConnection.Open();

                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            cargos.Add(new Cargo()
                            {
                                IdCargo = reader.GetInt32(0),
                                DesCargo = reader.GetString(1)
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

            return cargos;
        }
    }
}
