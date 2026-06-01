using CapaMo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;

namespace Busqueda
{
    public class B_Telefono_Proveedor
    {
        public List<Telefono_Proveedor> BuscarPorId(int id)
        {
            List<Telefono_Proveedor> lista = new List<Telefono_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM telefono_proveedor
                         WHERE Id_TelefonoProveedor = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

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

            return lista;
        }

        public List<Telefono_Proveedor> BuscarPorProveedor(int idProveedor)
        {
            List<Telefono_Proveedor> lista = new List<Telefono_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM telefono_proveedor
                         WHERE Id_Proveedor = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idProveedor);

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

            return lista;
        }

        public List<Telefono_Proveedor> BuscarPorTelefono(string telefono)
        {
            List<Telefono_Proveedor> lista = new List<Telefono_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM telefono_proveedor
                         WHERE Telefono LIKE @Telefono";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Telefono", "%" + telefono + "%");

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

            return lista;
        }
    }
}
