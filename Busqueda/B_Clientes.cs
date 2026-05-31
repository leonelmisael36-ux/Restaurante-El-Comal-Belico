using CapaMo;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static CapaMo.ConexChuy;

namespace Busqueda
{
    public class B_Clientes
    {
        public List<Clientes> BuscarPorNombre(string texto)
        {
            List<Clientes> lista = new List<Clientes>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM cliente 
                         WHERE NombreC LIKE @Texto";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

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

            return lista;
        }

        public List<Clientes> BuscarPorApellido(string texto)
        {
            List<Clientes> lista = new List<Clientes>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM cliente 
                         WHERE ApellidoC LIKE @Texto";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

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

            return lista;
        }

        public List<Clientes> BuscarPorCiudad(string texto)
        {
            List<Clientes> lista = new List<Clientes>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM cliente 
                         WHERE Ciudad LIKE @Texto";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

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

            return lista;
        }

        public List<Clientes> BuscarPorEstado(string texto)
        {
            List<Clientes> lista = new List<Clientes>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM cliente 
                         WHERE Estado LIKE @Texto";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Texto", "%" + texto + "%");

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

            return lista;
        }

        public List<Clientes> BuscarPorId(int id)
        {
            List<Clientes> lista = new List<Clientes>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM cliente 
                         WHERE Id_Cliente = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

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

            return lista;
        }
    }
}
