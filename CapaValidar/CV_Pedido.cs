using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    public class CV_Pedido
    {
        private CL_Pedido datos = new CL_Pedido();

        public List<Pedido> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Pedido obj, out string mensaje)
        {
            mensaje = "";

            if (obj.FechaPedido == default)
                mensaje += "La fecha del pedido no es válida\n";

            if (obj.Total < 0)
                mensaje += "El total no puede ser negativo\n";

            if (obj.Id_Cliente.HasValue)
            {
                if (obj.Id_Cliente <= 0)
                    mensaje += "El cliente es inválido\n";
                else if (!datos.ExisteCliente(obj.Id_Cliente.Value))
                    mensaje += "El cliente no existe\n";
            }

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Pedido obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Pedido <= 0)
                mensaje += "ID de pedido inválido\n";

            if (obj.FechaPedido == default)
                mensaje += "La fecha del pedido no es válida\n";

            if (obj.Total < 0)
                mensaje += "El total no puede ser negativo\n";

            if (obj.Id_Cliente.HasValue)
            {
                if (obj.Id_Cliente <= 0)
                    mensaje += "El cliente es inválido\n";
                else if (!datos.ExisteCliente(obj.Id_Cliente.Value))
                    mensaje += "El cliente no existe\n";
            }

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int idPedido, out string mensaje)
        {
            mensaje = "";

            if (idPedido <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            return datos.Eliminar(idPedido);
        }

        public decimal CalcularTotal(int idPedido)
        {
            if (idPedido <= 0)
                return 0;

            return datos.CalcularTotal(idPedido);
        }
    }
}
