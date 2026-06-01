using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaMo;
using CapaLogica;

namespace CapaValidar
{
    public class CV_Telefono_Proveedor
    {
        private CL_Telefono_Proveedor datos = new CL_Telefono_Proveedor();

        public List<Telefono_Proveedor> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Telefono_Proveedor obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Proveedor <= 0)
                mensaje += "El proveedor es obligatorio\n";
            else if (!datos.ExisteProveedor(obj.Id_Proveedor))
                mensaje += "El proveedor no existe\n";

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

        public bool Editar(Telefono_Proveedor obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_TelefonoProveedor <= 0)
                mensaje += "ID inválido\n";

            if (obj.Id_Proveedor <= 0)
                mensaje += "El proveedor es obligatorio\n";
            else if (!datos.ExisteProveedor(obj.Id_Proveedor))
                mensaje += "El proveedor no existe\n";

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

        public bool Eliminar(int idTelefonoProveedor, out string mensaje)
        {
            mensaje = "";

            if (idTelefonoProveedor <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            return datos.Eliminar(idTelefonoProveedor);
        }
    }
}
