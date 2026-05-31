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
                    cmd.CommandType = System.Data.CommandType.Text;
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
                    lista = new List<Categoria>();
                }
            }

            return lista;
        }

        public bool Registrar(Categoria obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
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

        public bool Editar(Categoria obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE categoria
                            SET Descripcion = @Descripcion,
                                Disponible = @Disponible
                            WHERE Id_Categoria = @Id_Categoria";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Categoria", obj.Id_Categoria);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@Disponible", obj.Disponible ? 1 : 0);

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


        public bool Existe(int idCategoria)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT COUNT(*) FROM categoria WHERE Id_Categoria = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idCategoria);

                conexion.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        public bool YaExisteDescripcion(string descripcion)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT COUNT(*) FROM categoria WHERE Descripcion = @Desc";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Desc", descripcion);

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
                         WHERE Descripcion = @Desc 
                         AND Id_Categoria <> @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Desc", descripcion);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
