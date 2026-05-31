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
    public class B_Detalle_Proveedor
    {
        public List<Detalle_Proveedor> BuscarPorIdDetalle(int id)
        {
            List<Detalle_Proveedor> lista = new List<Detalle_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM detalle_proveedor 
                         WHERE Id_DetallePro = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Detalle_Proveedor()
                        {
                            Id_DetalleProveedor = Convert.ToInt32(dr["Id_DetallePro"]),
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            Id_Ingrediente = Convert.ToInt32(dr["Id_Ingrediente"]),
                            Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Detalle_Proveedor> BuscarPorIdProveedor(int idProveedor)
        {
            List<Detalle_Proveedor> lista = new List<Detalle_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM detalle_proveedor 
                         WHERE Id_Proveedor = @IdProveedor";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Detalle_Proveedor()
                        {
                            Id_DetalleProveedor = Convert.ToInt32(dr["Id_DetallePro"]),
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            Id_Ingrediente = Convert.ToInt32(dr["Id_Ingrediente"]),
                            Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Detalle_Proveedor> BuscarPorIdIngrediente(int idIngrediente)
        {
            List<Detalle_Proveedor> lista = new List<Detalle_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM detalle_proveedor 
                         WHERE Id_Ingrediente = @IdIngrediente";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdIngrediente", idIngrediente);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Detalle_Proveedor()
                        {
                            Id_DetalleProveedor = Convert.ToInt32(dr["Id_DetallePro"]),
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            Id_Ingrediente = Convert.ToInt32(dr["Id_Ingrediente"]),
                            Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Detalle_Proveedor> BuscarPorFecha(DateTime fecha)
        {
            List<Detalle_Proveedor> lista = new List<Detalle_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM detalle_proveedor 
                         WHERE DATE(Fecha) = @Fecha";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Detalle_Proveedor()
                        {
                            Id_DetalleProveedor = Convert.ToInt32(dr["Id_DetallePro"]),
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            Id_Ingrediente = Convert.ToInt32(dr["Id_Ingrediente"]),
                            Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Detalle_Proveedor> BuscarPorCantidad(decimal cantidad)
        {
            List<Detalle_Proveedor> lista = new List<Detalle_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM detalle_proveedor 
                         WHERE Cantidad = @Cantidad";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Cantidad", cantidad);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Detalle_Proveedor()
                        {
                            Id_DetalleProveedor = Convert.ToInt32(dr["Id_DetallePro"]),
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            Id_Ingrediente = Convert.ToInt32(dr["Id_Ingrediente"]),
                            Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"])
                        });
                    }
                }
            }

            return lista;
        }
    }
}
