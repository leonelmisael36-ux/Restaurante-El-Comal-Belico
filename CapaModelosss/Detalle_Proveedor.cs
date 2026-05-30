using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelos
{
    public class Detalle_Proveedor
    {
        public int Id_DetallePro { get; set; }

        public int Id_Proveedor { get; set; }

        public int Cantidad { get; set; }

        public DateTime Fecha_Entrega { get; set; }

        public int Id_Ingrediente { get; set; }
    }
}
