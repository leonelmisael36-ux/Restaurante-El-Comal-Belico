using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaMo
{
    public class Tipo_Platillo
    {
        public int Id_Tipo { get; set; }
        
        public int Id_Platillo { get; set; }

        public string Tamaño { get; set; } = "";

        public string TipoPreparacion { get; set; } = "";

    }
}
