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
    public class CL_Tipo_Platillo
    {
        public List<Tipo_Platillo> Listar()
        {
            List<Tipo_Platillo> lista = new List<Tipo_Platillo>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM tipo_platillo";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Tipo_Platillo()
                            {
                                Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]),
                                Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                                Tamaño = dr["Tamano"].ToString(),
                                TipoPreparacion = dr["TipoPreparacion"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Tipo_Platillo>();
                }
            }

            return lista;
        }

        public bool Registrar(Tipo_Platillo obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO tipo_platillo
                        (Id_Platillo, Tamano, TipoPreparacion)
                        VALUES
                        (@Id_Platillo, @Tamano, @TipoPreparacion)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Platillo", obj.Id_Platillo);
                    cmd.Parameters.AddWithValue("@Tamano", obj.Tamaño);
                    cmd.Parameters.AddWithValue("@TipoPreparacion", obj.TipoPreparacion);

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

        public bool Editar(Tipo_Platillo obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE tipo_platillo
                        SET Id_Platillo = @Id_Platillo,
                            Tamano = @Tamano,
                            TipoPreparacion = @TipoPreparacion
                        WHERE Id_Tipo = @Id_Tipo";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Tipo", obj.Id_Tipo);
                    cmd.Parameters.AddWithValue("@Id_Platillo", obj.Id_Platillo);
                    cmd.Parameters.AddWithValue("@Tamano", obj.Tamaño);
                    cmd.Parameters.AddWithValue("@TipoPreparacion", obj.TipoPreparacion);

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

        public bool Eliminar(int idTipo)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM tipo_platillo WHERE Id_Tipo = @Id_Tipo";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_Tipo", idTipo);

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

        public bool ExistePlatillo(int idPlatillo)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT 1 FROM platillo WHERE Id_Platillo = @Id LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idPlatillo);

                conexion.Open();

                return cmd.ExecuteScalar() != null;
            }
        }

        public bool ExisteTipo(int idTipo)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT 1 FROM tipo_platillo WHERE Id_Tipo = @Id LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idTipo);

                conexion.Open();

                return cmd.ExecuteScalar() != null;
            }
        }
    }
}
