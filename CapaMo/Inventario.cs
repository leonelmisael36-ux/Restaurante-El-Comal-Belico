using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaMo
{
    public class Inventario
    {
        public int Id_Inventario { get; set; }

        public int Id_Ingrediente { get; set; }

        public decimal Stock { get; set; }

        public decimal StockMinimo { get; set; }

        public DateTime FechaRegistro { get; set; }

    }
}
