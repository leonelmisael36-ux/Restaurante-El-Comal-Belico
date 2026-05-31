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
    public class B_Categoria
    {
        public List<Categoria> BuscarPorDescripcion(string texto)
        {
            List<Categoria> lista = new List<Categoria>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM categoria 
                         WHERE Descripcion LIKE @Texto";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Categoria()
                        {
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"]),
                            Descripcion = dr["Descripcion"].ToString(),
                            Disponible = Convert.ToByte(dr["Disponible"]) == 1,
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Categoria> BuscarPorId(int id)
        {
            List<Categoria> lista = new List<Categoria>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM categoria 
                         WHERE Id_Categoria = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Categoria()
                        {
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"]),
                            Descripcion = dr["Descripcion"].ToString(),
                            Disponible = Convert.ToByte(dr["Disponible"]) == 1,
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Categoria> BuscarPorEstado(bool estado)
        {
            List<Categoria> lista = new List<Categoria>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM categoria 
                         WHERE Disponible = @Estado";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Estado", estado ? 1 : 0);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Categoria()
                        {
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"]),
                            Descripcion = dr["Descripcion"].ToString(),
                            Disponible = Convert.ToByte(dr["Disponible"]) == 1,
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Categoria> BuscarPorFecha(DateTime fecha)
        {
            List<Categoria> lista = new List<Categoria>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM categoria 
                         WHERE FechaRegistro = @Fecha";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Categoria()
                        {
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"]),
                            Descripcion = dr["Descripcion"].ToString(),
                            Disponible = Convert.ToByte(dr["Disponible"]) == 1,
                            FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                        });
                    }
                }
            }

            return lista;
        }
    }
}
