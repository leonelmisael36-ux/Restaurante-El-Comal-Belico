using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelos
{
    public class Platillo
    {
        public int Id_Platillo { get; set; }

        public string Nombre_Platillo { get; set; } = "";

        public string Descripcion { get; set; } = "";

        public int Precio_Venta { get; set; }

        public int Id_Categoria { get; set; }

    }
}
