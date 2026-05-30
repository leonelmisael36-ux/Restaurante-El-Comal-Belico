using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace CapaMo
{
    internal class ProbarConex
    {
        public void ObtenerConexion()
        {

            ConexChuy.Conexion conexion = new ConexChuy.Conexion();

            using (MySqlConnection conn = conexion.ObtenerConexion())
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Exito en la conexión");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error al conectar a la base de datos: " + ex.Message);
                }
            }
        }
    }
}
