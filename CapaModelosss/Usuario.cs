using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelos
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }

        public string Nombre_Usuario { get; set; } = "";

        public string APaterno { get; set; } = "";

        public string AMaterno { get; set; } = ""; 

        public string Contraseña { get; set; } = "";

        public string Correo { get; set; } = "";
    }
}
