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
    public class CL_Telefono_Proveedor
    {
        public List<Telefono_Proveedor> Listar()
        {
            List<Telefono_Proveedor> lista = new List<Telefono_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM telefono_proveedor";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Telefono_Proveedor()
                            {
                                Id_TelefonoProveedor = Convert.ToInt32(dr["Id_TelefonoProveedor"]),
                                Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                                Telefono = dr["Telefono"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Telefono_Proveedor>();
                }
            }

            return lista;
        }

        public bool Registrar(Telefono_Proveedor obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO telefono_proveedor
                            (Id_Proveedor, Telefono)
                            VALUES
                            (@Id_Proveedor, @Telefono)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Proveedor", obj.Id_Proveedor);
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

        public bool Editar(Telefono_Proveedor obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE telefono_proveedor
                            SET Id_Proveedor = @Id_Proveedor,
                                Telefono = @Telefono
                            WHERE Id_TelefonoProveedor = @Id_TelefonoProveedor";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_TelefonoProveedor", obj.Id_TelefonoProveedor);
                    cmd.Parameters.AddWithValue("@Id_Proveedor", obj.Id_Proveedor);
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

        public bool Eliminar(int idTelefonoProveedor)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM telefono_proveedor WHERE Id_TelefonoProveedor = @Id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id", idTelefonoProveedor);

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

        public bool ExisteProveedor(int idProveedor)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT COUNT(*) FROM proveedor WHERE Id_Proveedor = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idProveedor);

                conexion.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }
    }
}
