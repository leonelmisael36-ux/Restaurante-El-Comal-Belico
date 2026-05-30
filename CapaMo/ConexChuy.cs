using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace CapaMo
{
    public class ConexChuy
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
}
