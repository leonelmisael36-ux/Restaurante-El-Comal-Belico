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
    public class B_Ingredientes
    {
        public List<Ingredientes> BuscarPorId(int id)
        {
            List<Ingredientes> lista = new List<Ingredientes>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM ingredientes 
                         WHERE Id_Ingrediente = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Ingredientes()
                        {
                            Id_Ingrediente = Convert.ToInt32(dr["Id_Ingrediente"]),
                            Nombre = dr["Nombre"].ToString(),
                            Unidad = dr["Unidad"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Ingredientes> BuscarPorNombre(string nombre)
        {
            List<Ingredientes> lista = new List<Ingredientes>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM ingredientes 
                         WHERE Nombre LIKE @Nombre";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Ingredientes()
                        {
                            Id_Ingrediente = Convert.ToInt32(dr["Id_Ingrediente"]),
                            Nombre = dr["Nombre"].ToString(),
                            Unidad = dr["Unidad"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Ingredientes> BuscarPorUnidad(string unidad)
        {
            List<Ingredientes> lista = new List<Ingredientes>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM ingredientes 
                         WHERE Unidad LIKE @Unidad";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Unidad", "%" + unidad + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Ingredientes()
                        {
                            Id_Ingrediente = Convert.ToInt32(dr["Id_Ingrediente"]),
                            Nombre = dr["Nombre"].ToString(),
                            Unidad = dr["Unidad"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
