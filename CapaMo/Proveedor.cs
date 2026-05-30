using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaMo
{
    public class Proveedor
    {
        public int Id_Proveedor { get; set; }

        public string NombreEmpresa { get; set; } = "";

        public string RazonSocial { get; set; } = "";

        public string CallePr { get; set; } = "";

        public string NumeroPr { get; set; } = "";

        public string ColoniaPr { get; set; } = "";

        public string CiudadPr { get; set; } = "";

        public string EstadoPr { get; set; } = "";

        public string CPPr { get; set; } = "";

        public string EstadoProveedor { get; set; } = "";
    }
}
