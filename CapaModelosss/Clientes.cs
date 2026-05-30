using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelos
{
    public class Clientes
    {
        public int Id_Cliente { get; set; }

        public string NombreC { get; set; } = "";

        public string ApellidoC { get; set; } = "";
        
        public string Calle { get; set; } = "";

        public string Colonia { get; set; } = "";

        public int NumCasa { get; set; }

        public string Estado { get; set; } = "";

        public string CP { get; set; } = "";
    }
}
