using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelos
{
    public class Correo_Cliente
    {
        public int Id_Correo { get; set; }

        public int Id_Cliente { get; set; }

        public string Correo { get; set; } = "";
    }
}
