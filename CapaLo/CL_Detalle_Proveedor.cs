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
    public class CL_Detalle_Proveedor
    {
        public List<Detalle_Proveedor> Listar()
        {
            List<Detalle_Proveedor> lista = new List<Detalle_Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM detalle_proveedor";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

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
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Detalle_Proveedor>();
                }
            }

            return lista;
        }

        public bool Registrar(Detalle_Proveedor obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();

                    string queryProveedor = @"SELECT EstadoProveedor 
                                      FROM proveedor 
                                      WHERE Id_Proveedor = @Id";

                    MySqlCommand cmdProv = new MySqlCommand(queryProveedor, conexion);
                    cmdProv.Parameters.AddWithValue("@Id", obj.Id_Proveedor);

                    object result = cmdProv.ExecuteScalar();

                    if (result == null)
                    {
                        Console.WriteLine("El proveedor no existe");
                        return false;
                    }

                    string estado = result.ToString().Trim();

                    if (!estado.Equals("Activo", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("El proveedor está inactivo");
                        return false;
                    }

                    string query = @"INSERT INTO detalle_proveedor
                    (Id_Proveedor, Id_Ingrediente, Cantidad, Fecha)
                    VALUES
                    (@Id_Proveedor, @Id_Ingrediente, @Cantidad, @Fecha)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Proveedor", obj.Id_Proveedor);
                    cmd.Parameters.AddWithValue("@Id_Ingrediente", obj.Id_Ingrediente);
                    cmd.Parameters.AddWithValue("@Cantidad", obj.Cantidad);
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);

                    respuesta = cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }

            return respuesta;
        }

        public bool Editar(Detalle_Proveedor obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE detalle_proveedor
                            SET Id_Proveedor = @Id_Proveedor,
                                Id_Ingrediente = @Id_Ingrediente,
                                Cantidad = @Cantidad,
                                Fecha = @Fecha
                            WHERE Id_DetallePro = @Id_DetallePro";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_DetallePro", obj.Id_DetalleProveedor);
                    cmd.Parameters.AddWithValue("@Id_Proveedor", obj.Id_Proveedor);
                    cmd.Parameters.AddWithValue("@Id_Ingrediente", obj.Id_Ingrediente);
                    cmd.Parameters.AddWithValue("@Cantidad", obj.Cantidad);
                    cmd.Parameters.AddWithValue("@Fecha", obj.Fecha);

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

        public bool Eliminar(int idDetallePro)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    conexion.Open();

                    int idIngrediente = 0;
                    decimal cantidad = 0;

                    string queryGet = @"SELECT Id_Ingrediente, Cantidad 
                                FROM detalle_proveedor
                                WHERE Id_DetallePro = @Id";

                    MySqlCommand cmdGet = new MySqlCommand(queryGet, conexion);
                    cmdGet.Parameters.AddWithValue("@Id", idDetallePro);

                    using (MySqlDataReader dr = cmdGet.ExecuteReader())
                    {
                        if (!dr.Read())
                            return false;

                        idIngrediente = Convert.ToInt32(dr["Id_Ingrediente"]);
                        cantidad = Convert.ToDecimal(dr["Cantidad"]);
                    }

                    string queryStockActual = @"SELECT Stock 
                                        FROM inventario 
                                        WHERE Id_Ingrediente = @Id";

                    MySqlCommand cmdStockActual = new MySqlCommand(queryStockActual, conexion);
                    cmdStockActual.Parameters.AddWithValue("@Id", idIngrediente);

                    object result = cmdStockActual.ExecuteScalar();

                    if (result == null)
                    {
                        Console.WriteLine("Ingrediente no existe en inventario");
                        return false;
                    }

                    decimal stockActual = Convert.ToDecimal(result);

                    if (stockActual < cantidad)
                    {
                        Console.WriteLine("No se puede eliminar: stock insuficiente");
                        return false;
                    }

                    string queryStock = @"UPDATE inventario
                                  SET Stock = Stock - @Cantidad
                                  WHERE Id_Ingrediente = @Id";

                    MySqlCommand cmdStock = new MySqlCommand(queryStock, conexion);
                    cmdStock.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmdStock.Parameters.AddWithValue("@Id", idIngrediente);
                    cmdStock.ExecuteNonQuery();

                    string queryDelete = @"DELETE FROM detalle_proveedor
                                   WHERE Id_DetallePro = @Id";

                    MySqlCommand cmdDelete = new MySqlCommand(queryDelete, conexion);
                    cmdDelete.Parameters.AddWithValue("@Id", idDetallePro);

                    return cmdDelete.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool ExisteProveedor(int idProveedor)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT COUNT(*) FROM proveedor WHERE Id_Proveedor = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idProveedor);

                conexion.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

        public bool ExisteIngrediente(int idIngrediente)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT COUNT(*) FROM ingredientes WHERE Id_Ingrediente = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idIngrediente);

                conexion.Open();

                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }
    }
}
