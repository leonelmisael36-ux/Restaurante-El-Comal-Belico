using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;
using CapaMo;
using MySql.Data.MySqlClient;

namespace CapaLo
{
    internal class CL_Ingredientes
    {
        public List<Ingredientes> Listar()
        {
            List<Ingredientes> lista = new List<Ingredientes>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM ingrediente";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Ingredientes()
                            {
                                Id_Ingrediente = Convert.ToInt32(dr["Id_Ingrediente"]),
                                Nombre = dr["Nombre"].ToString(),
                                Unidad = dr["Unidad"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Ingredientes>();
                }
            }

            return lista;
        }

        public bool Registrar(Ingredientes obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO ingrediente
                            (Nombre, Unidad)
                            VALUES
                            (@Nombre, @Unidad)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Unidad", obj.Unidad);

                    conexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Editar(Ingredientes obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE ingrediente
                            SET Nombre = @Nombre,
                                Unidad = @Unidad
                            WHERE Id_Ingrediente = @Id_Ingrediente";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Ingrediente", obj.Id_Ingrediente);
                    cmd.Parameters.AddWithValue("@Nombre", obj.Nombre);
                    cmd.Parameters.AddWithValue("@Unidad", obj.Unidad);

                    conexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Eliminar(int idIngrediente)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM ingrediente WHERE Id_Ingrediente = @Id_Ingrediente";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_Ingrediente", idIngrediente);

                    conexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    respuesta = false;
                }
            }

            return respuesta;
        }
    }

}
