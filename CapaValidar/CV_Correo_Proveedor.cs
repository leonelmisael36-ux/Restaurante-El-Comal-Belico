using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    public class CV_Correo_Proveedor
    {
        private Cl_Correo_Proveedor datos = new Cl_Correo_Proveedor();

        public List<Correo_Proveedor> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Correo_Proveedor obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Proveedor <= 0)
                mensaje += "El proveedor es obligatorio\n";
            else if (!datos.ExisteProveedor(obj.Id_Proveedor))
                mensaje += "El proveedor no existe\n";

            if (string.IsNullOrWhiteSpace(obj.Correo))
                mensaje += "El correo es obligatorio\n";
            else
            {
                obj.Correo = obj.Correo.Trim();

                if (!obj.Correo.Contains("@") || !obj.Correo.Contains("."))
                    mensaje += "Formato de correo inválido\n";
                else if (datos.ExisteCorreoProveedorDuplicado(obj.Id_Proveedor, obj.Correo))
                    mensaje += "Este proveedor ya tiene este correo registrado\n";
            }

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Correo_Proveedor obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_CorreoProveedor <= 0)
                mensaje += "ID inválido\n";

            if (!datos.ExisteCorreoProveedor(obj.Id_CorreoProveedor))
                mensaje += "El correo no existe\n";

            if (obj.Id_Proveedor <= 0)
                mensaje += "El proveedor es obligatorio\n";
            else if (!datos.ExisteProveedor(obj.Id_Proveedor))
                mensaje += "El proveedor no existe\n";

            if (string.IsNullOrWhiteSpace(obj.Correo))
                mensaje += "El correo es obligatorio\n";
            else
            {
                obj.Correo = obj.Correo.Trim();

                if (!obj.Correo.Contains("@") || !obj.Correo.Contains("."))
                    mensaje += "Formato de correo inválido\n";
                else if (datos.ExisteCorreoProveedorEditar(obj.Id_CorreoProveedor, obj.Id_Proveedor, obj.Correo))
                    mensaje += "Este proveedor ya tiene este correo registrado\n";
            }

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int idCorreoProveedor, out string mensaje)
        {
            mensaje = "";

            if (idCorreoProveedor <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            if (!datos.ExisteCorreoProveedor(idCorreoProveedor))
            {
                mensaje = "El correo no existe";
                return false;
            }

            return datos.Eliminar(idCorreoProveedor);
        }
    }
}
