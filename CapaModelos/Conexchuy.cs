using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelos
{
    using .Data.MySqlClient;

    public class Conexion
    {
        private string connectionString = "server=localhost;database=comal;user=root;password=;";
        public MySqlConnection ObtenerConexion()
        {
            return new MySqlConnection(connectionString);
        }
    }

}
