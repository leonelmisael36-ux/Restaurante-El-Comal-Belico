using CapaMo;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;

namespace Busqueda
{
    internal class B_Proveedor
    {
        public List<Proveedor> BuscarPorId(int id)
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM proveedor 
                         WHERE Id_Proveedor = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Proveedor()
                        {
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            NombreEmpresa = dr["NombreEmpresa"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            CallePr = dr["CallePr"].ToString(),
                            NumeroPr = dr["NumeroPr"].ToString(),
                            ColoniaPr = dr["ColoniaPr"].ToString(),
                            CiudadPr = dr["CiudadPr"].ToString(),
                            EstadoPr = dr["EstadoPr"].ToString(),
                            CPPr = dr["CPPr"].ToString(),
                            EstadoProveedor = dr["EstadoProveedor"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Proveedor> BuscarPorNombre(string nombre)
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM proveedor 
                         WHERE NombreEmpresa LIKE @Nombre";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Proveedor()
                        {
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            NombreEmpresa = dr["NombreEmpresa"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            CallePr = dr["CallePr"].ToString(),
                            NumeroPr = dr["NumeroPr"].ToString(),
                            ColoniaPr = dr["ColoniaPr"].ToString(),
                            CiudadPr = dr["CiudadPr"].ToString(),
                            EstadoPr = dr["EstadoPr"].ToString(),
                            CPPr = dr["CPPr"].ToString(),
                            EstadoProveedor = dr["EstadoProveedor"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Proveedor> BuscarPorCiudad(string ciudad)
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM proveedor 
                         WHERE CiudadPr LIKE @Ciudad";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Ciudad", "%" + ciudad + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Proveedor()
                        {
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            NombreEmpresa = dr["NombreEmpresa"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            CallePr = dr["CallePr"].ToString(),
                            NumeroPr = dr["NumeroPr"].ToString(),
                            ColoniaPr = dr["ColoniaPr"].ToString(),
                            CiudadPr = dr["CiudadPr"].ToString(),
                            EstadoPr = dr["EstadoPr"].ToString(),
                            CPPr = dr["CPPr"].ToString(),
                            EstadoProveedor = dr["EstadoProveedor"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Proveedor> BuscarPorEstado(string estado)
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM proveedor 
                         WHERE EstadoPr LIKE @Estado";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Estado", "%" + estado + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Proveedor()
                        {
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            NombreEmpresa = dr["NombreEmpresa"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            CallePr = dr["CallePr"].ToString(),
                            NumeroPr = dr["NumeroPr"].ToString(),
                            ColoniaPr = dr["ColoniaPr"].ToString(),
                            CiudadPr = dr["CiudadPr"].ToString(),
                            EstadoPr = dr["EstadoPr"].ToString(),
                            CPPr = dr["CPPr"].ToString(),
                            EstadoProveedor = dr["EstadoProveedor"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Proveedor> BuscarPorEstadoProveedor(string estado)
        {
            List<Proveedor> lista = new List<Proveedor>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM proveedor 
                         WHERE EstadoProveedor = @Estado";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Estado", estado);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Proveedor()
                        {
                            Id_Proveedor = Convert.ToInt32(dr["Id_Proveedor"]),
                            NombreEmpresa = dr["NombreEmpresa"].ToString(),
                            RazonSocial = dr["RazonSocial"].ToString(),
                            CallePr = dr["CallePr"].ToString(),
                            NumeroPr = dr["NumeroPr"].ToString(),
                            ColoniaPr = dr["ColoniaPr"].ToString(),
                            CiudadPr = dr["CiudadPr"].ToString(),
                            EstadoPr = dr["EstadoPr"].ToString(),
                            CPPr = dr["CPPr"].ToString(),
                            EstadoProveedor = dr["EstadoProveedor"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
