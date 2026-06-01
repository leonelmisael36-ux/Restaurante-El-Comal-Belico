using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaMo;
using CapaLogica;

namespace CapaValidar
{
    public class CV_Telefono_Cliente
    {
        private CL_Telefono_Cliente datos = new CL_Telefono_Cliente();

        public List<Telefono_Cliente> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Telefono_Cliente obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Cliente <= 0)
                mensaje += "El cliente es obligatorio\n";
            else if (!datos.ExisteCliente(obj.Id_Cliente))
                mensaje += "El cliente no existe\n";

            if (string.IsNullOrWhiteSpace(obj.Telefono))
                mensaje += "El teléfono es obligatorio\n";
            else
            {
                obj.Telefono = obj.Telefono.Trim();

                if (obj.Telefono.Length < 7)
                    mensaje += "El teléfono es demasiado corto\n";

                if (obj.Telefono.Length > 15)
                    mensaje += "El teléfono es demasiado largo\n";

                if (!obj.Telefono.All(char.IsDigit))
                    mensaje += "El teléfono solo debe contener números\n";
            }

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Telefono_Cliente obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Telefono <= 0)
                mensaje += "ID de teléfono inválido\n";

            if (obj.Id_Cliente <= 0)
                mensaje += "El cliente es obligatorio\n";
            else if (!datos.ExisteCliente(obj.Id_Cliente))
                mensaje += "El cliente no existe\n";

            if (string.IsNullOrWhiteSpace(obj.Telefono))
                mensaje += "El teléfono es obligatorio\n";
            else
            {
                obj.Telefono = obj.Telefono.Trim();

                if (obj.Telefono.Length < 7)
                    mensaje += "El teléfono es demasiado corto\n";

                if (obj.Telefono.Length > 15)
                    mensaje += "El teléfono es demasiado largo\n";

                if (!obj.Telefono.All(char.IsDigit))
                    mensaje += "El teléfono solo debe contener números\n";
            }

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int idTelefono, out string mensaje)
        {
            mensaje = "";

            if (idTelefono <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            return datos.Eliminar(idTelefono);
        }
    }
}
