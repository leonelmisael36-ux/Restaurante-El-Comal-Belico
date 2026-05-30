using System;
using System.Collections.Generic;
using System.Text;
using MySqlConnector;
using System.Data;
namespace CapaModelos
{
    public class Conexion
    {
        private string CadenaConexion = "Server=localhost;Database=comal;User ID=root;password=;";
        public MySqlConnection ObtenerConexion() 
        {
            return new MySqlConnection(CadenaConexion);
        }
        

    }

}
