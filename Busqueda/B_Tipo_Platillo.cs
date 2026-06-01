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
    public class B_Tipo_Platillo
    {
        public List<Tipo_Platillo> BuscarPorId(int id)
        {
            List<Tipo_Platillo> lista = new List<Tipo_Platillo>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM tipo_platillo
                         WHERE Id_Tipo = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Tipo_Platillo()
                        {
                            Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]),
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Tamaño = dr["Tamano"].ToString(),
                            TipoPreparacion = dr["TipoPreparacion"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Tipo_Platillo> BuscarPorPlatillo(int idPlatillo)
        {
            List<Tipo_Platillo> lista = new List<Tipo_Platillo>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM tipo_platillo
                         WHERE Id_Platillo = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idPlatillo);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Tipo_Platillo()
                        {
                            Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]),
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Tamaño = dr["Tamano"].ToString(),
                            TipoPreparacion = dr["TipoPreparacion"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Tipo_Platillo> BuscarPorTamano(string tamano)
        {
            List<Tipo_Platillo> lista = new List<Tipo_Platillo>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM tipo_platillo
                         WHERE Tamano LIKE @Tamano";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Tamano", "%" + tamano + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Tipo_Platillo()
                        {
                            Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]),
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Tamaño = dr["Tamano"].ToString(),
                            TipoPreparacion = dr["TipoPreparacion"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Tipo_Platillo> BuscarPorPreparacion(string tipo)
        {
            List<Tipo_Platillo> lista = new List<Tipo_Platillo>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM tipo_platillo
                         WHERE TipoPreparacion LIKE @Tipo";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Tipo", "%" + tipo + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Tipo_Platillo()
                        {
                            Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]),
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Tamaño = dr["Tamano"].ToString(),
                            TipoPreparacion = dr["TipoPreparacion"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}

