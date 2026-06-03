using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    public class CV_Detalle_Pedido
    {
        private CL_Detalle_Pedido datos = new CL_Detalle_Pedido();

        public List<Detalle_Pedido> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Detalle_Pedido obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Pedido <= 0)
                mensaje += "El pedido es obligatorio\n";

            if (obj.Id_Tipo <= 0)
                mensaje += "El tipo es obligatorio\n";
            else if (!datos.ExisteTipo(obj.Id_Tipo))
                mensaje += "El tipo no existe\n";
            else if (!datos.PlatilloDisponible(obj.Id_Tipo))
                mensaje += "El platillo no está disponible\n";

            if (obj.Cantidad <= 0)
                mensaje += "La cantidad debe ser mayor a 0\n";

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Detalle_Pedido obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Detalle <= 0)
                mensaje += "ID inválido\n";

            if (obj.Id_Pedido <= 0)
                mensaje += "El pedido es obligatorio\n";
            else if (!datos.ExistePedido(obj.Id_Pedido))
                mensaje += "El pedido no existe\n";

            if (obj.Id_Tipo <= 0)
                mensaje += "El tipo de platillo es obligatorio\n";
            else if (!datos.ExisteTipo(obj.Id_Tipo))
                mensaje += "El tipo de platillo no existe\n";

            if (obj.Cantidad <= 0)
                mensaje += "La cantidad debe ser mayor a 0\n";

            if (obj.PrecioUnitario <= 0)
                mensaje += "El precio debe ser mayor a 0\n";

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int idDetalle, out string mensaje)
        {
            mensaje = "";

            if (idDetalle <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            return datos.Eliminar(idDetalle);
        }
    }
}
