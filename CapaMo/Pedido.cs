using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaMo
{
    public class Pedido
    {
        public int Id_Pedido { get; set; }

        public DateTime FechaPedido { get; set; }

        public int Total { get; set; }

        public int Id_Cliente { get; set; }

    }
}
