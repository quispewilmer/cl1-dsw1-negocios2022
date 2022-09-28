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
    public class CategoriaService : ICategoriaService
    {
        String connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

        public List<Categoria> GetCategorias()
        {
            List<Categoria> categorias = new List<Categoria>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                using (SqlCommand sqlCommand = sqlConnection.CreateCommand())
                {
                    sqlCommand.CommandText = "uspCategoriaListar";
                    sqlCommand.CommandType = System.Data.CommandType.StoredProcedure;

                    try
                    {
                        sqlConnection.Open();

                        SqlDataReader reader = sqlCommand.ExecuteReader();

                        while (reader.Read())
                        {
                            categorias.Add(new Categoria()
                            {
                                IdCategoria = reader.GetInt32(0),
                                NombreCategoria = reader.GetString(1),
                                Descripcion = reader.GetString(2)
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

            return categorias;
        }
    }
}