using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using CapaMo;
using static CapaMo.ConexChuy;

namespace Busqueda
{
    public class B_Correo_Proveedor
    {
        public List<Correo_Proveedor> BuscarPorIdCorreo(int id)
        {
            List<Correo_Proveedor> lista = new List<Correo_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM correo_proveedor 
                         WHERE Id_CorreoProveedor = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

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

            return lista;
        }

        public List<Correo_Proveedor> BuscarPorIdProveedor(int idProveedor)
        {
            List<Correo_Proveedor> lista = new List<Correo_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM correo_proveedor 
                         WHERE Id_Proveedor = @IdProveedor";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);

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

            return lista;
        }

        public List<Correo_Proveedor> BuscarPorCorreo(string texto)
        {
            List<Correo_Proveedor> lista = new List<Correo_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM correo_proveedor 
                         WHERE Correo LIKE @Texto";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

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

            return lista;
        }
    }
}
