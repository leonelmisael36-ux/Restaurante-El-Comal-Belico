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
    public class B_Usuario
    {
        public List<Usuario> BuscarPorId(int id)
        {
            List<Usuario> lista = new List<Usuario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM usuario
                         WHERE Id_Usuario = @Id";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", id);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario()
                        {
                            Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                            Nombre_usuario = dr["Nombre_Usuario"].ToString(),
                            APaterno = dr["APaterno"].ToString(),
                            AMaterno = dr["AMaterno"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Contraseña = dr["Contrasena"].ToString(),
                            Rol = dr["Rol"].ToString(),
                            EstadoUsuario = dr["EstadoUsuario"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Usuario> BuscarPorNombre(string nombre)
        {
            List<Usuario> lista = new List<Usuario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM usuario
                         WHERE Nombre_Usuario LIKE @Nombre";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Nombre", "%" + nombre + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario()
                        {
                            Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                            Nombre_usuario = dr["Nombre_Usuario"].ToString(),
                            APaterno = dr["APaterno"].ToString(),
                            AMaterno = dr["AMaterno"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Contraseña = dr["Contrasena"].ToString(),
                            Rol = dr["Rol"].ToString(),
                            EstadoUsuario = dr["EstadoUsuario"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Usuario> BuscarPorCorreo(string correo)
        {
            List<Usuario> lista = new List<Usuario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM usuario
                         WHERE Correo LIKE @Correo";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Correo", "%" + correo + "%");

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario()
                        {
                            Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                            Nombre_usuario = dr["Nombre_Usuario"].ToString(),
                            APaterno = dr["APaterno"].ToString(),
                            AMaterno = dr["AMaterno"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Contraseña = dr["Contrasena"].ToString(),
                            Rol = dr["Rol"].ToString(),
                            EstadoUsuario = dr["EstadoUsuario"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Usuario> BuscarPorRol(string rol)
        {
            List<Usuario> lista = new List<Usuario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM usuario
                         WHERE Rol = @Rol";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Rol", rol);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario()
                        {
                            Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                            Nombre_usuario = dr["Nombre_Usuario"].ToString(),
                            APaterno = dr["APaterno"].ToString(),
                            AMaterno = dr["AMaterno"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Contraseña = dr["Contrasena"].ToString(),
                            Rol = dr["Rol"].ToString(),
                            EstadoUsuario = dr["EstadoUsuario"].ToString()
                        });
                    }
                }
            }

            return lista;
        }

        public List<Usuario> BuscarPorEstado(string estado)
        {
            List<Usuario> lista = new List<Usuario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = @"SELECT * 
                         FROM usuario
                         WHERE EstadoUsuario = @Estado";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Estado", estado);

                conexion.Open();

                using (MySqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        lista.Add(new Usuario()
                        {
                            Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                            Nombre_usuario = dr["Nombre_Usuario"].ToString(),
                            APaterno = dr["APaterno"].ToString(),
                            AMaterno = dr["AMaterno"].ToString(),
                            Correo = dr["Correo"].ToString(),
                            Contraseña = dr["Contrasena"].ToString(),
                            Rol = dr["Rol"].ToString(),
                            EstadoUsuario = dr["EstadoUsuario"].ToString()
                        });
                    }
                }
            }

            return lista;
        }
    }
}
