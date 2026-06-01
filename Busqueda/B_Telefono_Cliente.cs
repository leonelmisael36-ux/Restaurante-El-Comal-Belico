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
    public class B_Telefono_Cliente
    {
        public List<Telefono_Cliente> BuscarPorId(int id)
        {
            List<Telefono_Cliente> lista = new List<Telefono_Cliente>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM telefono_cliente
                         WHERE Id_Telefono = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

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

            return lista;
        }

        public List<Telefono_Cliente> BuscarPorCliente(int idCliente)
        {
            List<Telefono_Cliente> lista = new List<Telefono_Cliente>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM telefono_cliente
                         WHERE Id_Cliente = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idCliente);

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

            return lista;
        }

        public List<Telefono_Cliente> BuscarPorTelefono(string telefono)
        {
            List<Telefono_Cliente> lista = new List<Telefono_Cliente>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM telefono_cliente
                         WHERE Telefono LIKE @Telefono";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Telefono", "%" + telefono + "%");

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

            return lista;
        }
    }
}
