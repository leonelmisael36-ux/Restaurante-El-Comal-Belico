using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;
using CapaMo;
using MySql.Data.MySqlClient;

namespace CapaLogica
{
    public class CL_Detalle_Pedido
    {
        public List<Detalle_Pedido> Listar()
        {
            List<Detalle_Pedido> lista = new List<Detalle_Pedido>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM detalle_pedido";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Detalle_Pedido>();
                }
            }

            return lista;
        }

        public bool Registrar(Detalle_Pedido obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();

                    string queryPrecio = @"SELECT Precio_Venta 
                                   FROM platillo 
                                   WHERE Id_Platillo = @Id";

                    MySqlCommand cmdPrecio = new MySqlCommand(queryPrecio, conexion);
                    cmdPrecio.Parameters.AddWithValue("@Id", obj.Id_Tipo);

                    decimal precioUnitario = Convert.ToDecimal(cmdPrecio.ExecuteScalar());

                    decimal subtotal = obj.Cantidad * precioUnitario;

                    string query = @"INSERT INTO detalle_pedido
            (Id_Pedido, Id_Tipo, Cantidad, PrecioUnitario, Subtotal, FechaPedido)
            VALUES
            (@Id_Pedido, @Id_Tipo, @Cantidad, @PrecioUnitario, @Subtotal, @FechaPedido)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Pedido", obj.Id_Pedido);
                    cmd.Parameters.AddWithValue("@Id_Tipo", obj.Id_Tipo);
                    cmd.Parameters.AddWithValue("@Cantidad", obj.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", precioUnitario);
                    cmd.Parameters.AddWithValue("@Subtotal", subtotal);
                    cmd.Parameters.AddWithValue("@FechaPedido", DateTime.Today);

                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Editar(Detalle_Pedido obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE detalle_pedido
                            SET Id_Pedido = @Id_Pedido,
                                Id_Tipo = @Id_Tipo,
                                Cantidad = @Cantidad,
                                PrecioUnitario = @PrecioUnitario,
                                Subtotal = @Subtotal,
                                FechaRegistro = @FechaRegistro
                            WHERE Id_Detalle = @Id_Detalle";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Detalle", obj.Id_Detalle);
                    cmd.Parameters.AddWithValue("@Id_Pedido", obj.Id_Pedido);
                    cmd.Parameters.AddWithValue("@Id_Tipo", obj.Id_Tipo);
                    cmd.Parameters.AddWithValue("@Cantidad", obj.Cantidad);
                    cmd.Parameters.AddWithValue("@PrecioUnitario", obj.PrecioUnitario);
                    cmd.Parameters.AddWithValue("@Subtotal", obj.Subtotal);
                    cmd.Parameters.AddWithValue("@FechaRegistro", obj.Fecha_registro);

                    conexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool Eliminar(int idDetalle)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM detalle_pedido WHERE Id_Detalle = @Id_Detalle";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_Detalle", idDetalle);

                    conexion.Open();
                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    respuesta = false;
                }
            }

            return respuesta;
        }

        public bool ExisteTipo(int idTipo)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT COUNT(*) FROM tipo_platillo WHERE Id_Tipo = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idTipo);

                conexion.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        public bool ExistePedido(int idPedido)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT COUNT(*) FROM pedido WHERE Id_Pedido = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idPedido);

                conexion.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }
    }
}
