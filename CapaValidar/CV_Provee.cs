using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    public class CV_Provee
    {
        private CL_Provee datos = new CL_Provee();

        public List<Provee> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Provee obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Proveedor <= 0)
                mensaje += "El proveedor es obligatorio\n";
            else if (!datos.ExisteProveedor(obj.Id_Proveedor))
                mensaje += "El proveedor no existe\n";

            if (obj.Id_Platillo <= 0)
                mensaje += "El platillo es obligatorio\n";
            else if (!datos.ExistePlatillo(obj.Id_Platillo))
                mensaje += "El platillo no existe\n";

            if (mensaje != "")
                return false;

            if (datos.ExisteRelacion(obj.Id_Proveedor, obj.Id_Platillo))
                mensaje += "Esta relación ya existe\n";

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Eliminar(int idProveedor, int idPlatillo, out string mensaje)
        {
            mensaje = "";

            if (idProveedor <= 0 || idPlatillo <= 0)
            {
                mensaje = "IDs inválidos";
                return false;
            }

            return datos.Eliminar(idProveedor, idPlatillo);
        }

        public bool Editar(Provee obj,
                    int proveedorOriginal,
                    int platilloOriginal,
                    out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Proveedor <= 0)
                mensaje += "El proveedor es obligatorio\n";
            else if (!datos.ExisteProveedor(obj.Id_Proveedor))
                mensaje += "El proveedor no existe\n";

            if (obj.Id_Platillo <= 0)
                mensaje += "El platillo es obligatorio\n";
            else if (!datos.ExistePlatillo(obj.Id_Platillo))
                mensaje += "El platillo no existe\n";

            if (mensaje != "")
                return false;

            if ((obj.Id_Proveedor != proveedorOriginal ||
                 obj.Id_Platillo != platilloOriginal) &&
                 datos.ExisteRelacion(obj.Id_Proveedor, obj.Id_Platillo))
            {
                mensaje = "Esta relación ya existe";
                return false;
            }

            return datos.Editar(obj, proveedorOriginal, platilloOriginal);
        }
    }
}
