using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    public class CV_Correo_Cliente
    {
        private CL_Correo_Clientes datos = new CL_Correo_Clientes();

        public List<Correo_Cliente> Listar()
        {
            return datos.Listar();
        }


        public bool Registrar(Correo_Cliente obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Cliente <= 0)
                mensaje += "El cliente es obligatorio\n";
            else if (!datos.ExisteCliente(obj.Id_Cliente))
                mensaje += "El cliente no existe\n";

            if (string.IsNullOrWhiteSpace(obj.Correo))
                mensaje += "El correo es obligatorio\n";

            else if (!obj.Correo.Contains("@") || !obj.Correo.Contains("."))
                mensaje += "Formato de correo inválido\n";

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Correo_Cliente obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Correo <= 0)
                mensaje += "ID de correo inválido\n";

            if (!datos.ExisteCorreo(obj.Id_Correo))
                mensaje += "El correo no existe\n";

            if (obj.Id_Cliente <= 0)
                mensaje += "El cliente es obligatorio\n";
            else if (!datos.ExisteCliente(obj.Id_Cliente))
                mensaje += "El cliente no existe\n";

            if (string.IsNullOrWhiteSpace(obj.Correo))
                mensaje += "El correo es obligatorio\n";
            else
            {
                obj.Correo = obj.Correo.Trim();

                if (!obj.Correo.Contains("@") || !obj.Correo.Contains("."))
                    mensaje += "El correo no es válido\n";
            }

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int idCorreo, out string mensaje)
        {
            mensaje = "";

            if (idCorreo <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            if (!datos.ExisteCorreo(idCorreo))
            {
                mensaje = "El correo no existe";
                return false;
            }

            return datos.Eliminar(idCorreo);
        }
    }
}

