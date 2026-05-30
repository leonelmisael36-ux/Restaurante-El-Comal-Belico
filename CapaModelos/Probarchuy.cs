using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;

namespace CapaModelos
{
    public bool ProbarConexion()
    {
        using (MysqlConnection coon = ObtenerConexion())
        {
            try
            {
                coon.Open();
                return true;

            }
            catch {  return false; }
        }
    }
}
