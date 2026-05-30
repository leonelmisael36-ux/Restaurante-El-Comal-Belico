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
                    string query = @"INSERT INTO detalle_proveedor
                            (Id_Proveedor, Id_Ingrediente, Cantidad, Fecha)
                            VALUES
                            (@Id_Proveedor, @Id_Ingrediente, @Cantidad, @Fecha)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    obj.Fecha = DateTime.Today;

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
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM detalle_proveedor WHERE Id_DetallePro = @Id_DetallePro";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_DetallePro", idDetallePro);

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

        public bool ExisteDuplicado(int idProveedor, int idIngrediente)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"SELECT COUNT(*) 
                             FROM detalle_proveedor 
                             WHERE Id_Proveedor = @IdProveedor 
                             AND Id_Ingrediente = @IdIngrediente";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@IdProveedor", idProveedor);
                    cmd.Parameters.AddWithValue("@IdIngrediente", idIngrediente);

                    conexion.Open();

                    int count = Convert.ToInt32(cmd.ExecuteScalar());

                    return count > 0;
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
