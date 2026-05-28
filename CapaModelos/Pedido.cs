using System;
using System.Collections.Generic;
using System.Text;

namespace CapaModelos
{
    internal class Pedido
    {
        public int Id_Pedido { get; set; }

        public int FechaD { get; set; }

        public int FechaM { get; set; }

        public int FechaA { get; set; }

        public int Total { get; set; }

        public int Id_Cliente { get; set; }

    }
}
