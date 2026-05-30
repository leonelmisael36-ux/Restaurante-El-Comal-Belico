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
    public class CL_Correo_Clientes
    {
        public List<Correo_Cliente> Listar()
        {
            List<Correo_Cliente> lista = new List<Correo_Cliente>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"SELECT * FROM correo_cliente";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Correo_Cliente()
                            {
                                Id_Correo = Convert.ToInt32(dr["Id_Correo"]),
                                Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]),
                                Correo = dr["Correo"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Correo_Cliente>();
                }
            }

            return lista;
        }

        public bool Registrar(Correo_Cliente obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO correo_cliente
                            (Id_Cliente, Correo)
                            VALUES
                            (@Id_Cliente, @Correo)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Cliente", obj.Id_Cliente);
                    cmd.Parameters.AddWithValue("@Correo", obj.Correo);

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

        public bool Editar(Correo_Cliente obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE correo_cliente
                            SET Id_Cliente = @Id_Cliente,
                                Correo = @Correo
                            WHERE Id_Correo = @Id_Correo";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Correo", obj.Id_Correo);
                    cmd.Parameters.AddWithValue("@Id_Cliente", obj.Id_Cliente);
                    cmd.Parameters.AddWithValue("@Correo", obj.Correo);

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
                string query = "SELECT COUNT(*) FROM cliente WHERE Id_Cliente = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idCliente);

                conexion.Open();
                int count = Convert.ToInt32(cmd.ExecuteScalar());

                return count > 0;
            }
        }

    }
}
