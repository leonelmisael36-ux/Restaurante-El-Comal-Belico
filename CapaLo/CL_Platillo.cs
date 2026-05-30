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
    public class CL_Platillo
    {
        public List<Platillo> Listar()
        {
            List<Platillo> lista = new List<Platillo>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM platillo";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Platillo()
                            {
                                Id_Platillo = Convert.ToInt32(dr["Id_Platillo"]),
                                Nombre_Platillo = dr["Nombre_Platillo"].ToString(),
                                Descripcion = dr["Descripcion"].ToString(),
                                Precio_Venta = Convert.ToDecimal(dr["Precio_Venta"]),
                                Id_Categoria = Convert.ToInt32(dr["Id_Categoria"])
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Platillo>();
                }
            }

            return lista;
        }

        public bool Registrar(Platillo obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO platillo
                            (Nombre_Platillo, Descripcion, Precio_Venta, Id_Categoria)
                            VALUES
                            (@Nombre_Platillo, @Descripcion, @Precio_Venta, @Id_Categoria)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Nombre_Platillo", obj.Nombre_Platillo);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio_Venta", obj.Precio_Venta);
                    cmd.Parameters.AddWithValue("@Id_Categoria", obj.Id_Categoria);

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

        public bool Editar(Platillo obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE platillo
                            SET Nombre_Platillo = @Nombre_Platillo,
                                Descripcion = @Descripcion,
                                Precio_Venta = @Precio_Venta,
                                Id_Categoria = @Id_Categoria
                            WHERE Id_Platillo = @Id_Platillo";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Platillo", obj.Id_Platillo);
                    cmd.Parameters.AddWithValue("@Nombre_Platillo", obj.Nombre_Platillo);
                    cmd.Parameters.AddWithValue("@Descripcion", obj.Descripcion);
                    cmd.Parameters.AddWithValue("@Precio_Venta", obj.Precio_Venta);
                    cmd.Parameters.AddWithValue("@Id_Categoria", obj.Id_Categoria);

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

        public bool Eliminar(int idPlatillo)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM platillo WHERE Id_Platillo = @Id_Platillo";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_Platillo", idPlatillo);

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
    }
}
