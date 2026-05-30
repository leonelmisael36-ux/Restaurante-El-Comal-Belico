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
    public class Cl_Correo_Proveedor
    {
        public List<Correo_Proveedor> Listar()
        {
            List<Correo_Proveedor> lista = new List<Correo_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM correo_proveedor";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Correo_Proveedor()
                            {
                                Id_CorreoProveedor = Convert.ToInt32(dr["Id_CorreoProveedor"]),
                                Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                                Correo = dr["Correo"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Correo_Proveedor>();
                }
            }

            return lista;
        }

        public bool Registrar(Correo_Proveedor obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO correo_proveedor
                            (Id_Proveedor, Correo)
                            VALUES
                            (@Id_Proveedor, @Correo)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Proveedor", obj.Id_Proveedor);
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

        public bool Editar(Correo_Proveedor obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE correo_proveedor
                            SET Correo = @Correo
                            WHERE Id_CorreoProveedor = @Id_CorreoProveedor";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_CorreoProveedor", obj.Id_CorreoProveedor);
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

        public bool Eliminar(int idCorreoProveedor)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM correo_proveedor WHERE Id_CorreoProveedor = @Id_CorreoProveedor";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_CorreoProveedor", idCorreoProveedor);

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

        public bool ExisteCorreoProveedor(int idCorreoProveedor)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT 1 FROM correo_proveedor WHERE Id_CorreoProveedor = @Id LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idCorreoProveedor);

                conexion.Open();

                return cmd.ExecuteScalar() != null;
            }
        }
    }
}
