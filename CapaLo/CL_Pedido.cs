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
    public class CL_Pedido
    {
        public List<Pedido> Listar()
        {
            List<Pedido> lista = new List<Pedido>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM pedido";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

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
                                Id_Cliente = dr["Id_Cliente"] == DBNull.Value
                                    ? (int?)null
                                    : Convert.ToInt32(dr["Id_Cliente"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Pedido>();
                }
            }

            return lista;
        }

        public bool Registrar(Pedido obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO pedido
                    (FechaPedido, Id_Cliente)
                    VALUES
                    (@FechaPedido, @Id_Cliente)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    obj.FechaPedido = DateTime.Today;

                    cmd.Parameters.AddWithValue("@FechaPedido", obj.FechaPedido);
                    cmd.Parameters.AddWithValue("@Id_Cliente",
                        obj.Id_Cliente.HasValue ? obj.Id_Cliente.Value : (object)DBNull.Value);

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

        public bool Editar(Pedido obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE pedido
                            SET FechaPedido = @FechaPedido,
                                Total = @Total,
                                Id_Cliente = @Id_Cliente
                            WHERE Id_Pedido = @Id_Pedido";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Pedido", obj.Id_Pedido);
                    cmd.Parameters.AddWithValue("@FechaPedido", obj.FechaPedido);
                    cmd.Parameters.AddWithValue("@Total", obj.Total);
                    cmd.Parameters.AddWithValue("@Id_Cliente",
                        obj.Id_Cliente.HasValue ? obj.Id_Cliente.Value : (object)DBNull.Value);

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

        public bool Eliminar(int idPedido)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM pedido WHERE Id_Pedido = @Id_Pedido";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_Pedido", idPedido);

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

        public bool ExisteCliente(int idCliente)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT COUNT(*) FROM clientes WHERE Id_Cliente = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idCliente);

                conexion.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        public decimal CalcularTotal(int idPedido)
        {
            decimal total = 0;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"
            SELECT SUM(dp.Cantidad * p.Precio_Venta)
            FROM detalle_pedido dp
            INNER JOIN tipo_platillo t 
                ON dp.Id_Tipo = t.Id_Tipo
            INNER JOIN platillo p 
                ON t.Id_Platillo = p.Id_Platillo
            WHERE dp.Id_Pedido = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idPedido);

                conexion.Open();

                object result = cmd.ExecuteScalar();

                if (result != DBNull.Value && result != null)
                    total = Convert.ToDecimal(result);
            }

            return total;
        }

        public bool ActualizarTotal(int idPedido)
        {
            if (idPedido <= 0) return false;

            decimal total = CalcularTotal(idPedido);

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"UPDATE pedido
                         SET Total = @Total
                         WHERE Id_Pedido = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Total", total);
                cmd.Parameters.AddWithValue("@Id", idPedido);

                conexion.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }
    }
}
