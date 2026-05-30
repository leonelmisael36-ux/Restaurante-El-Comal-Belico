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
    public class CL_Usuario
    {
        public List<Usuario> Listar()
        {
            List<Usuario> lista = new List<Usuario>();

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "SELECT * FROM usuario";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.CommandType = System.Data.CommandType.Text;

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
                                Correo = dr["Correo"] == DBNull.Value ? null : dr["Correo"].ToString(),
                                Contraseña = dr["Contrasena"].ToString(),
                                Rol = dr["Rol"].ToString(),
                                EstadoUsuario = dr["EstadoUsuario"].ToString()
                            });
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    lista = new List<Usuario>();
                }
            }

            return lista;
        }

        public bool Registrar(Usuario obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"INSERT INTO usuario
            (Nombre_Usuario, APaterno, AMaterno, Correo, Contrasena, Rol, EstadoUsuario)
            VALUES
            (@Nombre_Usuario, @APaterno, @AMaterno, @Correo, @Contrasena, @Rol, @EstadoUsuario)";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Nombre_Usuario", obj.Nombre_usuario);
                    cmd.Parameters.AddWithValue("@APaterno", obj.APaterno);
                    cmd.Parameters.AddWithValue("@AMaterno", obj.AMaterno);
                    cmd.Parameters.AddWithValue("@Correo", (object)obj.Correo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Contrasena", obj.Contraseña);
                    cmd.Parameters.AddWithValue("@Rol", obj.Rol);
                    cmd.Parameters.AddWithValue("@EstadoUsuario", obj.EstadoUsuario);

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

        public bool Editar(Usuario obj)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"UPDATE usuario
            SET Nombre_Usuario = @Nombre_Usuario,
                APaterno = @APaterno,
                AMaterno = @AMaterno,
                Correo = @Correo,
                Contrasena = @Contrasena,
                Rol = @Rol,
                EstadoUsuario = @EstadoUsuario
            WHERE Id_Usuario = @Id_Usuario";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);

                    cmd.Parameters.AddWithValue("@Id_Usuario", obj.Id_Usuario);
                    cmd.Parameters.AddWithValue("@Nombre_Usuario", obj.Nombre_usuario);
                    cmd.Parameters.AddWithValue("@APaterno", obj.APaterno);
                    cmd.Parameters.AddWithValue("@AMaterno", obj.AMaterno);
                    cmd.Parameters.AddWithValue("@Correo", (object)obj.Correo ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@Contrasena", obj.Contraseña);
                    cmd.Parameters.AddWithValue("@Rol", obj.Rol);
                    cmd.Parameters.AddWithValue("@EstadoUsuario", obj.EstadoUsuario);

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

        public bool Eliminar(int idUsuario)
        {
            bool respuesta = false;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = "DELETE FROM usuario WHERE Id_Usuario = @Id_Usuario";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@Id_Usuario", idUsuario);

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

        public Usuario Login(string usuario, string contrasena)
        {
            Usuario obj = null;

            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                try
                {
                    string query = @"SELECT * FROM usuario 
                             WHERE Nombre_Usuario = @usuario 
                             AND Contrasena = @contrasena";

                    MySqlCommand cmd = new MySqlCommand(query, conexion);
                    cmd.Parameters.AddWithValue("@usuario", usuario);
                    cmd.Parameters.AddWithValue("@contrasena", contrasena);

                    conexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        if (dr.Read())
                        {
                            obj = new Usuario()
                            {
                                Id_Usuario = Convert.ToInt32(dr["Id_Usuario"]),
                                Nombre_usuario = dr["Nombre_Usuario"].ToString(),
                                Rol = dr["Rol"].ToString(),
                                EstadoUsuario = dr["EstadoUsuario"].ToString()
                            };
                        }
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return obj;
        }

        public bool ExisteCorreo(string correo)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT COUNT(*) FROM usuario WHERE Correo = @Correo";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Correo", correo);

                conexion.Open();

                return Convert.ToInt32(cmd.ExecuteScalar()) > 0;
            }
        }

        public bool ExisteUsuario(int idUsuario)
        {
            using (MySqlConnection conexion = new MySqlConnection(Conexion.cadena))
            {
                string query = "SELECT 1 FROM usuario WHERE Id_Usuario = @Id LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conexion);
                cmd.Parameters.AddWithValue("@Id", idUsuario);

                conexion.Open();

                return cmd.ExecuteScalar() != null;
            }
        }
    }
}
