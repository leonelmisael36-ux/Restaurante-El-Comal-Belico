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
    public class B_Provee
    {
        public List<Provee> BuscarPorProveedor(int idProveedor)
        {
            List<Provee> lista = new List<Provee>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"
            SELECT 
                p.Id_Proveedor,
                pr.Nombre_Proveedor,
                p.Id_Platillo,
                pl.Nombre_Platillo
            FROM proveedor_platillo p
            INNER JOIN proveedor pr ON pr.Id_Proveedor = p.Id_Proveedor
            INNER JOIN platillo pl ON pl.Id_Platillo = p.Id_Platillo
            WHERE p.Id_Proveedor = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idProveedor);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Provee()
                        {
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            Nombre_Proveedor = dr["Nombre_Proveedor"].ToString(),
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Nombre_Platillo = dr["Nombre_Platillo"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Provee> BuscarPorPlatillo(int idPlatillo)
        {
            List<Provee> lista = new List<Provee>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"
            SELECT 
                p.Id_Proveedor,
                pr.Nombre_Proveedor,
                p.Id_Platillo,
                pl.Nombre_Platillo
            FROM proveedor_platillo p
            INNER JOIN proveedor pr ON pr.Id_Proveedor = p.Id_Proveedor
            INNER JOIN platillo pl ON pl.Id_Platillo = p.Id_Platillo
            WHERE p.Id_Platillo = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idPlatillo);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Provee()
                        {
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            Nombre_Proveedor = dr["Nombre_Proveedor"].ToString(),
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Nombre_Platillo = dr["Nombre_Platillo"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Provee> BuscarPorNombreProveedor(string nombre)
        {
            List<Provee> lista = new List<Provee>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"
            SELECT 
                p.Id_Proveedor,
                pr.Nombre_Proveedor,
                p.Id_Platillo,
                pl.Nombre_Platillo
            FROM proveedor_platillo p
            INNER JOIN proveedor pr ON pr.Id_Proveedor = p.Id_Proveedor
            INNER JOIN platillo pl ON pl.Id_Platillo = p.Id_Platillo
            WHERE pr.Nombre_Proveedor LIKE @Nombre";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Provee()
                        {
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            Nombre_Proveedor = dr["Nombre_Proveedor"].ToString(),
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Nombre_Platillo = dr["Nombre_Platillo"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Provee> BuscarPorNombrePlatillo(string nombre)
        {
            List<Provee> lista = new List<Provee>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"
            SELECT 
                p.Id_Proveedor,
                pr.Nombre_Proveedor,
                p.Id_Platillo,
                pl.Nombre_Platillo
            FROM proveedor_platillo p
            INNER JOIN proveedor pr ON pr.Id_Proveedor = p.Id_Proveedor
            INNER JOIN platillo pl ON pl.Id_Platillo = p.Id_Platillo
            WHERE pl.Nombre_Platillo LIKE @Nombre";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Provee()
                        {
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            Nombre_Proveedor = dr["Nombre_Proveedor"].ToString(),
                            Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                            Nombre_Platillo = dr["Nombre_Platillo"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
