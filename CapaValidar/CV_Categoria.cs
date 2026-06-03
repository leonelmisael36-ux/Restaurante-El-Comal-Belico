using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaLogica;
using CapaMo;

namespace CapaValidar
{
    public class CV_Categoria
    {
        private CL_Categoria datos = new CL_Categoria();

        public List<Categoria> Listar()
        {
            return datos.Listar();
        }

        public bool Registrar(Categoria obj, out string mensaje)
        {
            mensaje = "";

            if (string.IsNullOrWhiteSpace(obj.Descripcion))
                mensaje += "La descripción es obligatoria\n";

            if (obj.Descripcion != null && obj.Descripcion.Trim().Length < 3)
                mensaje += "La descripción debe tener al menos 3 caracteres\n";

            if (datos.YaExisteDescripcion(obj.Descripcion))
                mensaje += "Ya existe una categoría con esa descripción\n";

            if (mensaje != "")
                return false;

            obj.Disponible = true;
            obj.FechaRegistro = DateTime.Now;

            return datos.Registrar(obj);
        }

        public bool Editar(Categoria obj, out string mensaje)
        {
            mensaje = "";

            if (obj.Id_Categoria == 0)
                mensaje += "ID inválido\n";

            if (string.IsNullOrWhiteSpace(obj.Descripcion))
                mensaje += "La descripción es obligatoria\n";

            if (obj.Descripcion != null && obj.Descripcion.Trim().Length < 3)
                mensaje += "La descripción debe tener al menos 3 caracteres\n";

            string desc = obj.Descripcion.Trim();

            if (datos.YaExisteDescripcionEditar(obj.Id_Categoria, desc))
                mensaje += "Ya existe otra categoría con esa descripción\n";

            if (mensaje != "")
                return false;

            return datos.Editar(obj);
        }


    }
}
