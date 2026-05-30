using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaMo
{
    public class Categoria
    {
        public int Id_Categporia { get; set; }

        public string Descripcion { get; set; } = "";

        public byte Disponible { get; set; } 

        public DateTime FechaRegistro { get; set; }

    }
}
