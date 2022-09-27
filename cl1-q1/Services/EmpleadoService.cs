using cl1_q1.Interfaces;
using cl1_q1.Models;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using MssqlConnector;

namespace cl1_q1.Services
{
    public class EmpleadoService : IEmpleado
    {
        private readonly IConfiguration _configuration;

        public EmpleadoService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int AddEmpleado(Empleado empleado)
        {
            int result = 0;

            using (SqlConnection sqlConnection = Connector.getConnection(_configuration.GetConnectionString("connectionString")))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "uspRegistrarEmpleado";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@IdEmpleado", empleado.IdEmpleado);
                    sqlCommand.Parameters.AddWithValue("@ApeEmpleado", empleado.ApeEmpleado);
                    sqlCommand.Parameters.AddWithValue("@NomEmpleado", empleado.NomEmpleado);
                    sqlCommand.Parameters.AddWithValue("@FecNac", empleado.FecNac);
                    sqlCommand.Parameters.AddWithValue("@DirEmpleado", empleado.DirEmpleado);
                    sqlCommand.Parameters.AddWithValue("@idDistrito", empleado.IdDistrito);
                    sqlCommand.Parameters.AddWithValue("@fonoEmpleado", empleado.FonoEmpleado);
                    sqlCommand.Parameters.AddWithValue("@idCargo", empleado.IdCargo);
                    sqlCommand.Parameters.AddWithValue("@FecContrata", empleado.FecContrata);

                    try
                    {
                        sqlConnection.Open();

                        result = sqlCommand.ExecuteNonQuery();
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

            return result;
        }

        public int DeleteEmpleado(int id)
        {
            int result = 0;

            using (SqlConnection sqlConnection = Connector.getConnection(_configuration.GetConnectionString("connectionString")))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "uspEliminarEmpleado";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idEmpleado", id);

                    try
                    {
                        sqlConnection.Open();

                        result = sqlCommand.ExecuteNonQuery();
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

            return result;
        }

        public Empleado GetEmpleado(int id)
        {
            Empleado empleado = new Empleado();

            using (SqlConnection sqlConnection = Connector.getConnection(_configuration.GetConnectionString("connectionString")))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "uspObtenerEmpleado";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idEmpleado", id);

                    try
                    {
                        sqlConnection.Open();

                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            empleado = new Empleado()
                            {
                                IdEmpleado = reader.GetInt32(0),
                                ApeEmpleado = reader.GetString(1),
                                NomEmpleado = reader.GetString(2),
                                FecNac = reader.GetDateTime(3),
                                DirEmpleado = reader.GetString(4),
                                IdDistrito = reader.GetInt32(5),
                                FonoEmpleado = reader.GetString(6),
                                IdCargo = reader.GetInt32(7),
                                FecContrata = reader.GetDateTime(8)
                            };
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

            return empleado;
        }

        public List<Empleado> GetEmpleados()
        {
            List<Empleado> empleados = new List<Empleado>();

            using (SqlConnection sqlConnection = Connector.getConnection(_configuration.GetConnectionString("connectionString")))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "uspListarEmpleados";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        sqlConnection.Open();

                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            empleados.Add(new Empleado()
                            {
                                IdEmpleado = reader.GetInt32(0),
                                ApeEmpleado = reader.GetString(1),
                                NomEmpleado = reader.GetString(2),
                                FecNac = reader.GetDateTime(3),
                                DirEmpleado = reader.GetString(4),
                                IdDistrito = reader.GetInt32(5),
                                FonoEmpleado = reader.GetString(6),
                                IdCargo = reader.GetInt32(7),
                                FecContrata = reader.GetDateTime(8)
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

            return empleados;
        }

        public int UpdateEmpleado(Empleado empleado)
        {
            int result = 0;

            using (SqlConnection sqlConnection = Connector.getConnection(_configuration.GetConnectionString("connectionString")))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "uspActualizarEmpleado";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    sqlCommand.Parameters.AddWithValue("@idEmpleado", empleado.IdEmpleado);
                    sqlCommand.Parameters.AddWithValue("@ApeEmpleado", empleado.ApeEmpleado);
                    sqlCommand.Parameters.AddWithValue("@NomEmpleado", empleado.NomEmpleado);
                    sqlCommand.Parameters.AddWithValue("@FecNac", empleado.FecNac);
                    sqlCommand.Parameters.AddWithValue("@DirEmpleado", empleado.DirEmpleado);
                    sqlCommand.Parameters.AddWithValue("@idDistrito", empleado.IdDistrito);
                    sqlCommand.Parameters.AddWithValue("@fonoEmpleado", empleado.FonoEmpleado);
                    sqlCommand.Parameters.AddWithValue("@idCargo", empleado.IdCargo);
                    sqlCommand.Parameters.AddWithValue("@FecContrata", empleado.FecContrata);

                    try
                    {
                        sqlConnection.Open();

                        result = sqlCommand.ExecuteNonQuery();
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

            return result;
        }
    }
}
