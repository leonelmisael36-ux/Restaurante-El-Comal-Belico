using CapaMo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;

namespace CapaLogica
{
    public class CL_Inventario
    {
        public List<Inventario> Listar()
        {
            List<Inventario> lista = new List<Inventario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM inventario";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Inventario()
                            {
                                Id_Inventario = Convert.ToInt32(dr["Id_Inventario"]),
                                Id_Ingrediente = Convert.ToInt32(dr["Id_Ingrediente"]),
                                Stock = Convert.ToDecimal(dr["Stock"]),
                                StockMinimo = Convert.ToDecimal(dr["StockMinimo"]),
                                FechaRegistro = Convert.ToDateTime(dr["FechaRegistro"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Inventario>();
                }
            }

            return lista;
        }

        public bool Registrar(Inventario obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO inventario
                            (Id_Ingrediente, Stock, StockMinimo, FechaRegistro)
                            VALUES
                            (@Id_Ingrediente, @Stock, @StockMinimo, @FechaRegistro)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    obj.FechaRegistro = DateTime.Today;

                    cmd.Parameters.AddWithValue("@Id_Ingrediente", obj.Id_Ingrediente);
                    cmd.Parameters.AddWithValue("@Stock", obj.Stock);
                    cmd.Parameters.AddWithValue("@StockMinimo", obj.StockMinimo);
                    cmd.Parameters.AddWithValue("@FechaRegistro", obj.FechaRegistro);

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

        public bool Editar(Inventario obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE inventario
                            SET Id_Ingrediente = @Id_Ingrediente,
                                StockMinimo = @StockMinimo
                            WHERE Id_Inventario = @Id_Inventario";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Inventario", obj.Id_Inventario);
                    cmd.Parameters.AddWithValue("@Id_Ingrediente", obj.Id_Ingrediente);
                    cmd.Parameters.AddWithValue("@StockMinimo", obj.StockMinimo);
                    cmd.Parameters.AddWithValue("@FechaRegistro", obj.FechaRegistro);

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

        public bool Eliminar(int idInventario)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM inventario WHERE Id_Inventario = @Id_Inventario";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_Inventario", idInventario);

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

        public bool AumentarStock(int idIngrediente, decimal cantidad)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE inventario
                             SET Stock = Stock + @Cantidad
                             WHERE Id_Ingrediente = @Id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@Id", idIngrediente);

                    conexion.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }

        public bool ExisteIngredienteInventario(int idIngrediente)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT COUNT(*) 
                         FROM inventario 
                         WHERE Id_Ingrediente = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idIngrediente);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool DisminuirStock(int idIngrediente, decimal cantidad)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE inventario
                             SET Stock = Stock - @Cantidad
                             WHERE Id_Ingrediente = @Id";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Cantidad", cantidad);
                    cmd.Parameters.AddWithValue("@Id", idIngrediente);

                    conexion.Open();
                    return cmd.ExecuteNonQuery() > 0;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return false;
                }
            }
        }
    }
}
