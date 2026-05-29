using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelos
{
    internal class Correo_Proveedor
    {
        public int Id_CorreoProveedor { get; set; }

        public int Id_Proveedor { get; set; }

        public string CorreoPr { get; set; } = "";
    }
}
