using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaMo
{
    public class Detalle_Proveedor
    {
        public int Id_DetalleProveedor { get; set; }

        public int Id_Proveedor { get; set; }

        public int Id_Ingrediente { get; set; }

        public int Cantidad { get; set; }

        public DateTime Fecha { get; set; }

    }
}
