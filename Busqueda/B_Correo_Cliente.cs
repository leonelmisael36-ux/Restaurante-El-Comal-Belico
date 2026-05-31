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
    public class B_Correo_Cliente
    {
        public List<Correo_Cliente> BuscarPorIdCorreo(int id)
        {
            List<Correo_Cliente> lista = new List<Correo_Cliente>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM correo_cliente 
                         WHERE Id_Correo = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Correo_Cliente()
                        {
                            Id_Correo = Convert.ToInt32(dr["Id_Correo"]),
                            Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Correo_Cliente> BuscarPorIdCliente(int idCliente)
        {
            List<Correo_Cliente> lista = new List<Correo_Cliente>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM correo_cliente 
                         WHERE Id_Cliente = @IdCliente";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Correo_Cliente()
                        {
                            Id_Correo = Convert.ToInt32(dr["Id_Correo"]),
                            Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Correo_Cliente> BuscarPorCorreo(string texto)
        {
            List<Correo_Cliente> lista = new List<Correo_Cliente>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM correo_cliente 
                         WHERE Correo LIKE @Texto";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Correo_Cliente()
                        {
                            Id_Correo = Convert.ToInt32(dr["Id_Correo"]),
                            Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]),
                            Correo = dr["Correo"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
