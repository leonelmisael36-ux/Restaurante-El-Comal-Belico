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
    public class B_Detalle_Pedido
    {
        public List<Detalle_Pedido> BuscarPorIdDetalle(int id)
        {
            List<Detalle_Pedido> lista = new List<Detalle_Pedido>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM detalle_pedido 
                         WHERE Id_Detalle = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Detalle_Pedido()
                        {
                            Id_Detalle = Convert.ToInt32(dr["Id_Detalle"]),
                            Id_Pedido = Convert.ToInt32(dr["Id_Pedido"]),
                            Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                            Subtotal = Convert.ToDecimal(dr["Subtotal"]),
                            Fecha_registro = Convert.ToDateTime(dr["Fecha_registro"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Detalle_Pedido> BuscarPorPedido(int idPedido)
        {
            List<Detalle_Pedido> lista = new List<Detalle_Pedido>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM detalle_pedido 
                         WHERE Id_Pedido = @IdPedido";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdPedido", idPedido);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Detalle_Pedido()
                        {
                            Id_Detalle = Convert.ToInt32(dr["Id_Detalle"]),
                            Id_Pedido = Convert.ToInt32(dr["Id_Pedido"]),
                            Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                            Subtotal = Convert.ToDecimal(dr["Subtotal"]),
                            Fecha_registro = Convert.ToDateTime(dr["FechaRegistro"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Detalle_Pedido> BuscarPorTipo(int idTipo)
        {
            List<Detalle_Pedido> lista = new List<Detalle_Pedido>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM detalle_pedido 
                         WHERE Id_Tipo = @IdTipo";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdTipo", idTipo);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Detalle_Pedido()
                        {
                            Id_Detalle = Convert.ToInt32(dr["Id_Detalle"]),
                            Id_Pedido = Convert.ToInt32(dr["Id_Pedido"]),
                            Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                            Subtotal = Convert.ToDecimal(dr["Subtotal"]),
                            Fecha_registro = Convert.ToDateTime(dr["FechaRegistro"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Detalle_Pedido> BuscarPorFecha(DateTime fecha)
        {
            List<Detalle_Pedido> lista = new List<Detalle_Pedido>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM detalle_pedido 
                         WHERE DATE(FechaRegistro) = @Fecha";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Detalle_Pedido()
                        {
                            Id_Detalle = Convert.ToInt32(dr["Id_Detalle"]),
                            Id_Pedido = Convert.ToInt32(dr["Id_Pedido"]),
                            Id_Tipo = Convert.ToInt32(dr["Id_Tipo"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            PrecioUnitario = Convert.ToDecimal(dr["PrecioUnitario"]),
                            Subtotal = Convert.ToDecimal(dr["Subtotal"]),
                            Fecha_registro = Convert.ToDateTime(dr["FechaRegistro"])
                        });
                    }
                }
            }

            return lista;
        }
    }
}
