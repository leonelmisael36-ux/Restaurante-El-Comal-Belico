using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;

namespace Busqueda
{
    public class B_Tipo_Platillo_Union
    {
        private string baseQuery = @"
    SELECT 
        t.Id_Tipo,
        p.Id_Platillo,
        p.Nombre_Platillo,
        p.Descripcion,
        p.Precio_Venta,
        p.Id_Categoria,
        t.Tamano,
        t.TipoPreparacion
    FROM tipo_platillo t
    INNER JOIN platillo p 
        ON t.Id_Platillo = p.Id_Platillo";
        public List<dynamic> ListarUnido()
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"
                SELECT 
                    t.Id_Tipo,
                    p.Id_Platillo,
                    p.Nombre_Platillo,
                    p.Descripcion,
                    p.Precio_Venta,
                    p.Id_Categoria,
                    t.Tamano,
                    t.TipoPreparacion
                FROM tipo_platillo t
                INNER JOIN platillo p 
                    ON t.Id_Platillo = p.Id_Platillo";

                MySqlCommand cmd = new MySqlCommand(query, conexion);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new
                        {
                            Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]),
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Nombre_Platillo = dr["Nombre_Platillo"].ToString(),
                            Descripcion = dr["Descripcion"].ToString(),
                            Precio_Venta = Convert.ToDecimal(dr["Precio_Venta"]),
                            Id_Categoria = Convert.ToInt32(dr["Id_Categoria"]),
                            Tamano = dr["Tamano"].ToString(),
                            TipoPreparacion = dr["TipoPreparacion"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<dynamic> BuscarPorNombre(string texto)
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = baseQuery + " WHERE p.Nombre_Platillo LIKE @Texto";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(Map(dr));
                    }
                }
            }

            return lista;
        }

        public List<dynamic> BuscarPorNombreUnion(string texto)
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = baseQuery + " WHERE p.Nombre_Platillo LIKE @Texto";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(Map(dr));
                    }
                }
            }

            return lista;
        }

        public List<dynamic> BuscarPorTamañoUnion(string texto)
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = baseQuery + " WHERE t.Tamano LIKE @Texto";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(Map(dr));
                    }
                }
            }

            return lista;
        }

        public List<dynamic> BuscarPorPreparacionUnion(string texto)
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = baseQuery + " WHERE t.TipoPreparacion LIKE @Texto";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(Map(dr));
                    }
                }
            }

            return lista;
        }

        private object Map(MySqlDataReader dr)
        {
            return new
            {
                Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]),
                Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                Nombre_Platillo = dr["Nombre_Platillo"].ToString(),
                Descripcion = dr["Descripcion"].ToString(),
                Precio_Venta = Convert.ToDecimal(dr["Precio_Venta"]),
                Id_Categoria = Convert.ToInt32(dr["Id_Categoria"]),
                Tamano = dr["Tamano"].ToString(),
                TipoPreparacion = dr["TipoPreparacion"].ToString()
            };
        }
    }
}
