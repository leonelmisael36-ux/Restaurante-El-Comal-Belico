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
    public class CL_Telefono_Cliente
    {
        public List<Telefono_Cliente> Listar()
        {
            List<Telefono_Cliente> lista = new List<Telefono_Cliente>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM telefono_cliente";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Telefono_Cliente()
                            {
                                Id_Telefono = Convert.ToInt32(dr["Id_Telefono"]),
                                Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]),
                                Telefono = dr["Telefono"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Telefono_Cliente>();
                }
            }

            return lista;
        }

        public bool Registrar(Telefono_Cliente obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO telefono_cliente
                            (Id_Cliente, Telefono)
                            VALUES
                            (@Id_Cliente, @Telefono)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Cliente", obj.Id_Cliente);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);

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

        public bool Editar(Telefono_Cliente obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE telefono_cliente
                            SET Id_Cliente = @Id_Cliente,
                                Telefono = @Telefono
                            WHERE Id_Telefono = @Id_Telefono";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Telefono", obj.Id_Telefono);
                    cmd.Parameters.AddWithValue("@Id_Cliente", obj.Id_Cliente);
                    cmd.Parameters.AddWithValue("@Telefono", obj.Telefono);

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

        public bool Eliminar(int idTelefono)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM telefono_cliente WHERE Id_Telefono = @Id_Telefono";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_Telefono", idTelefono);

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
                string query = "SELECT COUNT(*) FROM clientes WHERE Id_Cliente = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idCliente);

                conexion.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        public bool ExisteTelefono(string telefono)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT COUNT(*)
                         FROM telefono_cliente
                         WHERE Telefono = @Telefono";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Telefono", telefono);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool ExisteTelefonoEditar(string telefono, int idTelefono)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT COUNT(*)
                         FROM telefono_cliente
                         WHERE Telefono = @Telefono
                         AND Id_Telefono <> @IdTelefono";

                MySqlCommand cmd = new MySqlCommand(query, conexion);

                cmd.Parameters.AddWithValue("@Telefono", telefono);
                cmd.Parameters.AddWithValue("@IdTelefono", idTelefono);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
