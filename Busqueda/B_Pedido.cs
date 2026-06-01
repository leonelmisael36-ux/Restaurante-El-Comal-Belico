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
    public class B_Pedido
    {
        public List<Pedido> BuscarPorId(int id)
        {
            List<Pedido> lista = new List<Pedido>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM pedido 
                         WHERE Id_Pedido = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Pedido()
                        {
                            Id_Pedido = Convert.ToInt32(dr["Id_Pedido"]),
                            FechaPedido = Convert.ToDateTime(dr["FechaPedido"]),
                            Total = Convert.ToDecimal(dr["Total"]),
                            Id_Cliente = dr["Id_Cliente"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id_Cliente"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Pedido> BuscarPorFecha(DateTime fecha)
        {
            List<Pedido> lista = new List<Pedido>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM pedido 
                         WHERE DATE(FechaPedido) = @Fecha";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Pedido()
                        {
                            Id_Pedido = Convert.ToInt32(dr["Id_Pedido"]),
                            FechaPedido = Convert.ToDateTime(dr["FechaPedido"]),
                            Total = Convert.ToDecimal(dr["Total"]),
                            Id_Cliente = dr["Id_Cliente"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id_Cliente"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Pedido> BuscarPorTotal(decimal total)
        {
            List<Pedido> lista = new List<Pedido>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM pedido 
                         WHERE Total = @Total";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Total", total);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Pedido()
                        {
                            Id_Pedido = Convert.ToInt32(dr["Id_Pedido"]),
                            FechaPedido = Convert.ToDateTime(dr["FechaPedido"]),
                            Total = Convert.ToDecimal(dr["Total"]),
                            Id_Cliente = dr["Id_Cliente"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id_Cliente"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<Pedido> BuscarPorCliente(int idCliente)
        {
            List<Pedido> lista = new List<Pedido>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM pedido 
                         WHERE Id_Cliente = @IdCliente";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdCliente", idCliente);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Pedido()
                        {
                            Id_Pedido = Convert.ToInt32(dr["Id_Pedido"]),
                            FechaPedido = Convert.ToDateTime(dr["FechaPedido"]),
                            Total = Convert.ToDecimal(dr["Total"]),
                            Id_Cliente = dr["Id_Cliente"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Id_Cliente"])
                        });
                    }
                }
            }

            return lista;
        }
    }
}
