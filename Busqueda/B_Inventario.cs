using CapaMo;
using MySql.Data.MySqlClient;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;

namespace Busqueda
{
    public class B_Inventario
    {
        public List<Inventario> BuscarPorId(int id)
        {
            List<Inventario> lista = new List<Inventario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM inventario 
                         WHERE Id_Inventario = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

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

            return lista;
        }

        public List<Inventario> BuscarPorIngrediente(int idIngrediente)
        {
            List<Inventario> lista = new List<Inventario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM inventario 
                         WHERE Id_Ingrediente = @IdIngrediente";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@IdIngrediente", idIngrediente);

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

            return lista;
        }

        public List<Inventario> BuscarPorStock(decimal stock)
        {
            List<Inventario> lista = new List<Inventario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM inventario 
                         WHERE Stock = @Stock";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Stock", stock);

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

            return lista;
        }

        public List<Inventario> BuscarPorStockMinimo(decimal minimo)
        {
            List<Inventario> lista = new List<Inventario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM inventario 
                         WHERE StockMinimo = @Minimo";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Minimo", minimo);

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

            return lista;
        }

        public List<Inventario> BuscarPorFecha(DateTime fecha)
        {
            List<Inventario> lista = new List<Inventario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM inventario 
                         WHERE DATE(FechaRegistro) = @Fecha";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Fecha", fecha.Date);

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

            return lista;
        }
    }
}
