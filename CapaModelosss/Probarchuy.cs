using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using System.Data;
namespace CapaModelos
{
    public class ProbarChuy
    {
        public void ProbarConexion()
        {

            Conexion conexion = new Conexion();

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
