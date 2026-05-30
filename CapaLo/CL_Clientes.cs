using CapaMo;
using Google.Protobuf.Collections;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;

namespace CapaLogica
{
    public class CL_Clientes
    {
        public List<Clientes> Listar()
        {
            List<Clientes> lista = new List<Clientes>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM clientes";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Clientes()
                            {
                                Id_Cliente = Convert.ToInt32(dr["Id_Cliente"]),
                                NombreC = dr["NombreC"].ToString(),
                                ApellidoC = dr["ApellidoC"].ToString(),
                                Calle = dr["Calle"].ToString(),
                                Colonia = dr["Colonia"].ToString(),
                                NumCasa = dr["NumCasa"].ToString(),
                                Ciudad = dr["Ciudad"].ToString(),
                                Estado = dr["Estado"].ToString(),
                                CP = dr["CP"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Clientes>();
                }
            }

            return lista;
        }

        public bool Registrar(Clientes obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO clientes
                            (NombreC, ApellidoC, Calle, Colonia,
                             NumCasa, Ciudad, Estado, CP)
                            VALUES
                            (@NombreC, @ApellidoC, @Calle, @Colonia,
                             @NumCasa, @Ciudad, @Estado, @CP)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@NombreC", obj.NombreC);
                    cmd.Parameters.AddWithValue("@ApellidoC", obj.ApellidoC);
                    cmd.Parameters.AddWithValue("@Calle", obj.Calle);
                    cmd.Parameters.AddWithValue("@Colonia", obj.Colonia);
                    cmd.Parameters.AddWithValue("@NumCasa", obj.NumCasa);
                    cmd.Parameters.AddWithValue("@Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("@CP", obj.CP);

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

        public bool Editar(Clientes obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE clientes
                            SET NombreC = @NombreC,
                                ApellidoC = @ApellidoC,
                                Calle = @Calle,
                                Colonia = @Colonia,
                                NumCasa = @NumCasa,
                                Ciudad = @Ciudad,
                                Estado = @Estado,
                                CP = @CP
                            WHERE Id_Cliente = @Id_Cliente";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Cliente", obj.Id_Cliente);
                    cmd.Parameters.AddWithValue("@NombreC", obj.NombreC);
                    cmd.Parameters.AddWithValue("@ApellidoC", obj.ApellidoC);
                    cmd.Parameters.AddWithValue("@Calle", obj.Calle);
                    cmd.Parameters.AddWithValue("@Colonia", obj.Colonia);
                    cmd.Parameters.AddWithValue("@NumCasa", obj.NumCasa);
                    cmd.Parameters.AddWithValue("@Ciudad", obj.Ciudad);
                    cmd.Parameters.AddWithValue("@Estado", obj.Estado);
                    cmd.Parameters.AddWithValue("@CP", obj.CP);

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

        public bool Eliminar(int idCliente)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM clientes WHERE Id_Cliente = @Id_Cliente";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_Cliente", idCliente);

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
