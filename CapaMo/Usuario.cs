using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaMo
{
    public class Usuario
    {
        public int Id_Usuario { get; set; }

        public string Nombre_usuario { get; set; } = "";

        public string APaterno { get; set; } = "";

        public string AMaterno { get; set; } = "";

        public string Correo { get; set; } = "";

        public string Contraseña { get; set; } = "";

        public string Rol { get; set; } = ""; 

        public string EstadoUsuario { get; set; } = "";
    }
}
