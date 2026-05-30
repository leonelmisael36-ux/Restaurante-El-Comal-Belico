using CapaLogica;
using CapaMo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaValidar
{
    public class CV_Platillo
    {
        private CL_Platillo datos = new CL_Platillo();

        public List<Platillo> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Platillo obj, out string mensaje)
        {
            mensaje = "";

            if (string.IsNullOrWhiteSpace(obj.Nombre_Platillo))
                mensaje += "El nombre del platillo es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.Descripcion))
                mensaje += "La descripción es obligatoria\n";

            if (obj.Precio_Venta <= 0)
                mensaje += "El precio debe ser mayor a 0\n";

            if (obj.Id_Categoria <= 0)
                mensaje += "La categoría es obligatoria\n";

            if (mensaje != "")
                return false;

            obj.Nombre_Platillo = obj.Nombre_Platillo.Trim();

            if (datos.ExistePlatillo(obj.Nombre_Platillo))
                mensaje += "Ya existe un platillo con ese nombre\n";

            if (mensaje != "")
                return false;

            return datos.Registrar(obj);
        }

        public bool Editar(Platillo obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Platillo <= 0)
                mensaje += "ID de platillo inválido\n";

            if (string.IsNullOrWhiteSpace(obj.Nombre_Platillo))
                mensaje += "El nombre del platillo es obligatorio\n";

            if (string.IsNullOrWhiteSpace(obj.Descripcion))
                mensaje += "La descripción es obligatoria\n";

            if (obj.Precio_Venta <= 0)
                mensaje += "El precio debe ser mayor a 0\n";

            if (obj.Id_Categoria <= 0)
                mensaje += "La categoría es obligatoria\n";

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }

        public bool Eliminar(int idPlatillo, out string mensaje)
        {
            mensaje = "";

            if (idPlatillo <= 0)
            {
                mensaje = "ID inválido";
                return false;
            }

            return datos.Eliminar(idPlatillo);
        }
    }
}
