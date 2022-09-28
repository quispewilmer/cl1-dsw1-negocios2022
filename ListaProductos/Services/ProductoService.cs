using ListaProductos.Interfaces;
using ListaProductos.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ListaProductos.Services
{
    public class ProductoService : IProductoService
    {
        String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public List<Producto> GetProductos()
        {
            List<Producto> productos = new List<Producto>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "uspProductoListar";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        sqlConnection.Open();

                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            productos.Add(new Producto()
                            {
                                IdProducto = reader.GetInt32(0),
                                NomProducto = reader.GetString(1),
                                IdProveedor = reader.GetInt32(2),
                                IdCategoria = reader.GetInt32(3),
                                CantxUnidad = reader.GetString(4),
                                PrecioUnidad = reader.GetDecimal(5),
                                UnidadesEnExistencia = reader.GetInt16(6),
                                UnidadesEnPedido = reader.GetInt16(7)
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

            return productos;
        }
    }
}