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
    public class B_Platillo
    {
        public List<Platillo> BuscarPorId(int id)
        {
            List<Platillo> lista = new List<Platillo>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM platillo 
                         WHERE Id_Platillo = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Platillo()
                        {
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Nombre_Platillo = dr["Nombre_Platillo"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Precio_Venta = Convert.ToDecimal(dr["Precio_Venta"]),
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Platillo> BuscarPorNombre(string nombre)
        {
            List<Platillo> lista = new List<Platillo>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM platillo 
                         WHERE Nombre_Platillo LIKE @Nombre";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Platillo()
                        {
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Nombre_Platillo = dr["Nombre_Platillo"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Precio_Venta = Convert.ToDecimal(dr["Precio_Venta"]),
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Platillo> BuscarPorPrecio(decimal precio)
        {
            List<Platillo> lista = new List<Platillo>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM platillo 
                         WHERE Precio_Venta = @Precio";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Precio", precio);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Platillo()
                        {
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Nombre_Platillo = dr["Nombre_Platillo"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Precio_Venta = Convert.ToDecimal(dr["Precio_Venta"]),
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Platillo> BuscarPorCategoria(int idCategoria)
        {
            List<Platillo> lista = new List<Platillo>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM platillo 
                         WHERE Id_Categoria = @IdCategoria";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdCategoria", idCategoria);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Platillo()
                        {
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Nombre_Platillo = dr["Nombre_Platillo"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Precio_Venta = Convert.ToDecimal(dr["Precio_Venta"]),
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"])
                        });
                    }
                }
            }

            return lista;
        }
    }
}
