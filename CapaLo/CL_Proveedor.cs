using CapaMo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;

namespace CapaLogica
{
    public class CL_Proveedor
    {
        public List<Proveedor> Listar()
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM proveedor";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            lista.Add(new Proveedor()
                            {
                                Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                                NombreEmpresa = dr["NombreEmpresa"].ToString(),
                                RazonSocial = dr["RazonSocial"] == DBNull.Value ? null : dr["RazonSocial"].ToString(),
                                CallePr = dr["CallePr"] == DBNull.Value ? null : dr["CallePr"].ToString(),
                                NumeroPr = dr["NumeroPr"] == DBNull.Value ? null : dr["NumeroPr"].ToString(),
                                ColoniaPr = dr["ColoniaPr"] == DBNull.Value ? null : dr["ColoniaPr"].ToString(),
                                CiudadPr = dr["CiudadPr"] == DBNull.Value ? null : dr["CiudadPr"].ToString(),
                                EstadoPr = dr["EstadoPr"] == DBNull.Value ? null : dr["EstadoPr"].ToString(),
                                CPPr = dr["CPPr"] == DBNull.Value ? null : dr["CPPr"].ToString(),
                                EstadoProveedor = dr["EstadoProveedor"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Proveedor>();
                }
            }

            return lista;
        }

        public bool Registrar(Proveedor obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO proveedor
            (NombreEmpresa, RazonSocial, CallePr, NumeroPr, ColoniaPr, CiudadPr, EstadoPr, CPPr, EstadoProveedor)
            VALUES
            (@NombreEmpresa, @RazonSocial, @CallePr, @NumeroPr, @ColoniaPr, @CiudadPr, @EstadoPr, @CPPr, @EstadoProveedor)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@NombreEmpresa", obj.NombreEmpresa);
                    cmd.Parameters.AddWithValue("@RazonSocial", (object)obj.RazonSocial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CallePr", (object)obj.CallePr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NumeroPr", (object)obj.NumeroPr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ColoniaPr", (object)obj.ColoniaPr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CiudadPr", (object)obj.CiudadPr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EstadoPr", (object)obj.EstadoPr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CPPr", (object)obj.CPPr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EstadoProveedor", obj.EstadoProveedor);

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

        public bool Editar(Proveedor obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE proveedor
            SET NombreEmpresa = @NombreEmpresa,
                RazonSocial = @RazonSocial,
                CallePr = @CallePr,
                NumeroPr = @NumeroPr,
                ColoniaPr = @ColoniaPr,
                CiudadPr = @CiudadPr,
                EstadoPr = @EstadoPr,
                CPPr = @CPPr,
                EstadoProveedor = @EstadoProveedor
            WHERE Id_Proveedor = @Id_Proveedor";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Proveedor", obj.Id_Proveedor);
                    cmd.Parameters.AddWithValue("@NombreEmpresa", obj.NombreEmpresa);
                    cmd.Parameters.AddWithValue("@RazonSocial", (object)obj.RazonSocial ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CallePr", (object)obj.CallePr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@NumeroPr", (object)obj.NumeroPr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@ColoniaPr", (object)obj.ColoniaPr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CiudadPr", (object)obj.CiudadPr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EstadoPr", (object)obj.EstadoPr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@CPPr", (object)obj.CPPr ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@EstadoProveedor", obj.EstadoProveedor);

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

        public bool YaExisteNombre(string nombreEmpresa)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT COUNT(*) 
                         FROM proveedor 
                         WHERE NombreEmpresa = @Nombre";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", nombreEmpresa);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool YaExisteNombreEditar(int id, string nombreEmpresa)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT COUNT(*) 
                         FROM proveedor 
                         WHERE NombreEmpresa = @Nombre 
                         AND Id_Proveedor <> @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", nombreEmpresa);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }
    }
}
