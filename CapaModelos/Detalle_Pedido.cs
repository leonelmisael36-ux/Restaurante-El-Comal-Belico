using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelos
{
    internal class Detalle_Pedido
    {
        public int Id_Detalle { get; set; }

        public int Id_Pedido { get; set; }

        public int Id_platillo { get; set; }

        public int Cantidad { get; set; }

        public int Total { get; set; }
    }
}
