using CapaMo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;

namespace CapaLogica
{
    public class CL_Categoria
    {
        public List<Categoria> Listar()
        {
            List<Categoria> lista = new List<Categoria>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM categoria";
                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Categoria()
                            {
                                Id_Categoria = Convert.ToInt32(dr["Id_Categoria"]),
                                Descripcion = dr["Descripcion"].ToString(),
                                Disponible = Convert.ToByte(dr["Disponible"]) == 1,
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return lista;
        }

        public bool Registrar(Categoria obj)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    obj.Descripcion = obj.Descripcion.Trim();

                    string query = @"INSERT INTO categoria
                               (Descripcion, Disponible, FechaRegistro)
                               VALUES
                               (@Descripcion, @Disponible, @FechaRegistro)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    obj.FechaRegistro = DateTime.Today;

                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@Disponible", obj.Disponible ? 1 : 0);
                    cmd.Parameters.AddWithValue("@FechaRegistro", obj.FechaRegistro);

                    conexion.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool Editar(Categoria obj)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    obj.Descripcion = obj.Descripcion.Trim();

                    string query = @"UPDATE categoria
                            SET Descripcion = @Descripcion,
                                Disponible = @Disponible
                            WHERE Id_Categoria = @Id_Categoria";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Categoria", obj.Id_Categoria);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@Disponible", obj.Disponible ? 1 : 0);

                    conexion.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }


        public bool YaExisteDescripcion(string descripcion)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT COUNT(*) 
                             FROM categoria 
                             WHERE LOWER(Descripcion) = LOWER(@Desc)";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Desc", descripcion.Trim());

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool YaExisteDescripcionEditar(int id, string descripcion)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT COUNT(*) 
                             FROM categoria 
                             WHERE LOWER(Descripcion) = LOWER(@Desc)
                             AND Id_Categoria <> @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Desc", descripcion.Trim());
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
