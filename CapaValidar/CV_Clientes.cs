using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    public class CV_Clientes
    {
        private CL_Clientes datos = new CL_Clientes();

        public List<Clientes> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Clientes obj, out string mensaje)
        {
            mensaje = "";

            if (string.IsNullOrWhiteSpace(obj.NombreC))
                mensaje += "El nombre es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.ApellidoC))
                mensaje += "El apellido es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.Calle))
                mensaje += "La calle es obligatoria\n";

            if (string.IsNullOrWhiteSpace(obj.Colonia))
                mensaje += "La colonia es obligatoria\n";

            if (string.IsNullOrWhiteSpace(obj.NumCasa))
                mensaje += "El número de casa es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.Ciudad))
                mensaje += "La ciudad es obligatoria\n";

            if (string.IsNullOrWhiteSpace(obj.Estado))
                mensaje += "El estado es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.CP))
                mensaje += "El código postal es obligatorio\n";

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Clientes obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Cliente == 0)
                mensaje += "ID inválido\n";

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int id, out string mensaje)
        {
            mensaje = "";

            if (id == 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            return datos.Eliminar(id);
        }
    }
}
