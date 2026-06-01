using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaMo;
using CapaLogica;

namespace CapaValidar
{
    public class CV_Proveedor
    {
        private CL_Proveedor datos = new CL_Proveedor();

        public List<Proveedor> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Proveedor obj, out string mensaje)
        {
            mensaje = "";

            if (string.IsNullOrWhiteSpace(obj.NombreEmpresa))
                mensaje += "El nombre de la empresa es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.EstadoProveedor))
                mensaje += "El estado del proveedor es obligatorio\n";

            if (!string.IsNullOrWhiteSpace(obj.CPPr) && obj.CPPr.Length > 10)
                mensaje += "El código postal es demasiado largo\n";

            if (datos.YaExisteNombre(obj.NombreEmpresa))
                mensaje += "Ya existe un proveedor con ese nombre\n";

            if (mensaje != "")
                return false;

            obj.EstadoProveedor = obj.EstadoProveedor.Trim();

            return datos.Registrar(obj);
        }

        public bool Editar(Proveedor obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Proveedor <= 0)
                mensaje += "ID inválido\n";

            if (string.IsNullOrWhiteSpace(obj.NombreEmpresa))
                mensaje += "El nombre de la empresa es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.EstadoProveedor))
                mensaje += "El estado del proveedor es obligatorio\n";

            if (!string.IsNullOrWhiteSpace(obj.CPPr) && obj.CPPr.Length > 10)
                mensaje += "El código postal es demasiado largo\n";

            if (datos.YaExisteNombreEditar(obj.Id_Proveedor, obj.NombreEmpresa))
                mensaje += "Ya existe otro proveedor con ese nombre\n";

            if (mensaje != "")
                return false;

            obj.EstadoProveedor = obj.EstadoProveedor.Trim();

            return datos.Editar(obj);
        }
    }
}
