using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;

namespace Busqueda
{
    public class B_ConsultasAvanzadas
    {
        public List<dynamic> PedidoCliente()
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT p.Id_Pedido, p.FechaPedido, p.Total,
                                        c.Nombre, c.Apellido
                                 FROM pedido p
                                 INNER JOIN cliente c ON p.Id_Cliente = c.Id_Cliente";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new
                        {
                            Id_Pedido = Convert.ToInt32(dr["Id_Pedido"]),
                            FechaPedido = Convert.ToDateTime(dr["FechaPedido"]),
                            Total = Convert.ToDecimal(dr["Total"]),
                            Nombre = dr["Nombre"].ToString(),
                            Apellido = dr["Apellido"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<dynamic> DetallePedidoPlatillo()
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT dp.Id_DetallePedido, dp.Cantidad,
                                pl.Nombre, pl.Precio
                         FROM detalle_pedido dp
                         INNER JOIN platillo pl ON dp.Id_Tipo = pl.Id_Platillo";

                MySqlCommand cmd = new MySqlCommand(query, conexion);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new
                        {
                            Id_DetallePedido = Convert.ToInt32(dr["Id_DetallePedido"]),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Nombre = dr["Nombre"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<dynamic> PedidoCompleto()
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT p.Id_Pedido, p.FechaPedido, c.Nombre AS Cliente,
                                dp.Cantidad, pl.Nombre AS Platillo
                         FROM pedido p
                         INNER JOIN cliente c ON p.Id_Cliente = c.Id_Cliente
                         INNER JOIN detalle_pedido dp ON p.Id_Pedido = dp.Id_Pedido
                         INNER JOIN platillo pl ON dp.Id_Tipo = pl.Id_Platillo";

                MySqlCommand cmd = new MySqlCommand(query, conexion);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new
                        {
                            Id_Pedido = Convert.ToInt32(dr["Id_Pedido"]),
                            FechaPedido = Convert.ToDateTime(dr["FechaPedido"]),
                            Cliente = dr["Cliente"].ToString(),
                            Cantidad = Convert.ToInt32(dr["Cantidad"]),
                            Platillo = dr["Platillo"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<dynamic> PlatilloCategoria()
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT pl.Nombre, pl.Precio, c.NombreCategoria
                                 FROM platillo pl
                                 INNER JOIN categoria c ON pl.Id_Categoria = c.Id_Categoria";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new
                        {
                            Nombre = dr["Nombre"].ToString(),
                            Precio = Convert.ToDecimal(dr["Precio"]),
                            Categoria = dr["NombreCategoria"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<dynamic> InventarioIngrediente()
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT i.Id_Inventario, ing.Nombre, i.Stock, i.StockMinimo
                                 FROM inventario i
                                 INNER JOIN ingrediente ing ON i.Id_Ingrediente = ing.Id_Ingrediente";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new
                        {
                            Id_Inventario = Convert.ToInt32(dr["Id_Inventario"]),
                            Nombre = dr["Nombre"].ToString(),
                            Stock = Convert.ToDecimal(dr["Stock"]),
                            StockMinimo = Convert.ToDecimal(dr["StockMinimo"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<dynamic> ProveedorEntregas()
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT d.Id_DetallePro, p.NombreEmpresa, d.Cantidad, d.Fecha
                                 FROM detalle_proveedor d
                                 INNER JOIN proveedor p ON d.Id_Proveedor = p.Id_Proveedor";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new
                        {
                            Id_DetallePro = Convert.ToInt32(dr["Id_DetallePro"]),
                            NombreEmpresa = dr["NombreEmpresa"].ToString(),
                            Cantidad = Convert.ToDecimal(dr["Cantidad"]),
                            Fecha = Convert.ToDateTime(dr["Fecha"])
                        });
                    }
                }
            }

            return lista;
        }

        public List<dynamic> ProveedorIngrediente()
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT p.NombreEmpresa, ing.Nombre, d.Cantidad
                                 FROM detalle_proveedor d
                                 INNER JOIN proveedor p ON d.Id_Proveedor = p.Id_Proveedor
                                 INNER JOIN ingrediente ing ON d.Id_Ingrediente = ing.Id_Ingrediente";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new
                        {
                            NombreEmpresa = dr["NombreEmpresa"].ToString(),
                            Ingrediente = dr["Nombre"].ToString(),
                            Cantidad = Convert.ToDecimal(dr["Cantidad"])
                        });
                    }
                }
            }

            return lista;
        }


        public List<dynamic> RankingPlatillos()
        {
            List<dynamic> lista = new List<dynamic>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT pl.Nombre, SUM(dp.Cantidad) AS TotalVendido
                                 FROM detalle_pedido dp
                                 INNER JOIN platillo pl ON dp.Id_Platillo = pl.Id_Platillo
                                 GROUP BY pl.Nombre
                                 ORDER BY TotalVendido DESC";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new
                        {
                            Nombre = dr["Nombre"].ToString(),
                            TotalVendido = Convert.ToInt32(dr["TotalVendido"])
                        });
                    }
                }
            }

            return lista;
        }
    }
}

