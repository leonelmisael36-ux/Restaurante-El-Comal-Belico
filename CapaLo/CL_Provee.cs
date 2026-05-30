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
    public class CL_Provee
    {
        public List<Provee> Listar()
        {
            List<Provee> lista = new List<Provee>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM provee";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Provee()
                            {
                                Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                                Id_Platillo = Convert.ToInt32(dr["Id_Platillo"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Provee>();
                }
            }

            return lista;
        }

        public bool Registrar(Provee obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO provee
                            (Id_Proveedor, Id_Platillo)
                            VALUES
                            (@Id_Proveedor, @Id_Platillo)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Proveedor", obj.Id_Proveedor);
                    cmd.Parameters.AddWithValue("@Id_Platillo", obj.Id_Platillo);

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

        public bool Eliminar(int idProveedor, int idPlatillo)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"DELETE FROM provee
                            WHERE Id_Proveedor = @Id_Proveedor
                            AND Id_Platillo = @Id_Platillo";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_Proveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@Id_Platillo", idPlatillo);

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

        public bool ExistePlatillo(int idPlatillo)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT COUNT(*) FROM platillo WHERE Id_Platillo = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idPlatillo);

                conexion.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }
    }
}
