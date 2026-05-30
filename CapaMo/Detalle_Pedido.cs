using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaMo
{
    public class Detalle_Pedido
    {
        public int Id_Detalle { get; set; }

        public int Id_Pedido { get; set; }

        public int Id_Tipo { get; set; }

        public int Cantidad { get; set; }

        public decimal PrecioUnitario { get; set; }

        public decimal Subtotal { get; set; }

        public DateTime Fecha_registro { get; set; }

    }
}
