using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;
using CapaMo;
using MySql.Data.MySqlClient;

namespace CapaLogica
{
    public class CL_Correo_Clientes
    {
        public List<Correo_Cliente> Listar()
        {
            List<Correo_Cliente> lista = new List<Correo_Cliente>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"SELECT * FROM correo_cliente";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Correo_Cliente()
                            {
                                Id_Correo = Convert.ToInt32(dr["Id_Correo"]),
                                Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]),
                                Correo = dr["Correo"] == DBNull.Value ? "" : dr["Correo"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Correo_Cliente>();
                }
            }

            return lista;
        }

        public bool Registrar(Correo_Cliente obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO correo_cliente
                            (Id_Cliente, Correo)
                            VALUES
                            (@Id_Cliente, @Correo)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Cliente", obj.Id_Cliente);
                    cmd.Parameters.AddWithValue("@Correo", obj.Correo);

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

        public bool Editar(Correo_Cliente obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE correo_cliente
                            SET Id_Cliente = @Id_Cliente,
                                Correo = @Correo
                            WHERE Id_Correo = @Id_Correo";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Correo", obj.Id_Correo);
                    cmd.Parameters.AddWithValue("@Id_Cliente", obj.Id_Cliente);
                    cmd.Parameters.AddWithValue("@Correo", obj.Correo);

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

        public bool Eliminar(int idCorreo)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM correo_cliente WHERE Id_Correo = @Id_Correo";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_Correo", idCorreo);

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

        public bool ExisteCliente(int idCliente)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT 1 FROM clientes WHERE Id_Cliente = @Id LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idCliente);

                conexion.Open();

                return cmd.ExecuteScalar() != null;
            }
        }

        public bool ExisteCorreoDuplicado(int idCliente, string correo)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT 1 
                         FROM correo_cliente 
                         WHERE Id_Cliente = @IdCliente 
                         AND Correo = @Correo 
                         LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                cmd.Parameters.AddWithValue("@Correo", correo);

                conexion.Open();

                return cmd.ExecuteScalar() != null;
            }
        }

        public bool ExisteCorreo(int idCorreo)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT 1 
                         FROM correo_cliente 
                         WHERE Id_Correo = @Id 
                         LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idCorreo);

                conexion.Open();

                return cmd.ExecuteScalar() != null;
            }
        }

        public bool ExisteCorreoDuplicadoEditar(int idCorreo, int idCliente, string correo)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT 1 
                         FROM correo_cliente 
                         WHERE Id_Cliente = @IdCliente 
                         AND Correo = @Correo
                         AND Id_Correo <> @IdCorreo
                         LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);
                cmd.Parameters.AddWithValue("@Correo", correo);
                cmd.Parameters.AddWithValue("@IdCorreo", idCorreo);

                conexion.Open();
                return cmd.ExecuteScalar() != null;
            }
        }

    }
}
